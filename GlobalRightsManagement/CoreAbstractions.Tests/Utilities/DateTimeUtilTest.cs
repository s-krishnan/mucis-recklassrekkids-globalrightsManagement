using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit;
using NUnit.Framework;

using RecklassRekkids.GlblRightsMgmt.CoreAbstractions.Utilities;

namespace CoreAbstractions.Tests.Utilities
{
    [TestFixture]
    public class DateTimeUtilTest
    {
        [TestCase("1st Feb 2012", "01/02/2012")]
        [TestCase("1st Aug 2012", "01/08/2012")]
        [TestCase("1st June 2012", "01/06/2012")]
        [TestCase("1st Mar 2011", "01/03/2011")]
        [TestCase("31st Dec 2012", "31/12/2012")]
        [TestCase("25th Dec 2012", "25/12/2012")]
        public void ConvertFromString_ValidStringArgument_DateTimeIsReturn(string input, string expected)
        {
            DateTime actual = DateTimeUtil.ConvertFromString(input);
            Assert.AreEqual(expected, actual.ToShortDateString());
        }

        [TestCase("InvalidArguments")]
        [TestCase("Feb")]
        [TestCase("31Feb2012")]
        [TestCase("31082012")]
        public void ConvertFromString_InvalidStringArgument_ThrowArgumentException_InvalidMessage(string input)
        {
            Assert.Throws<ArgumentException>(() => DateTimeUtil.ConvertFromString(input));
        }
    }
}
