using System;
using System.Linq;
using System.Linq.Expressions;
using NUnit;
using NUnit.Framework;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Query;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponent.Tests.Query
{
    [TestFixture]
    public class ProductByUsageAndStartDateTest
    {
        [Test]
        public void NewInstance_InvalidUsageInput_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ProductByUsageAndStartDate("", new DateTime()));
        }

        [Test]
        public void NewInstance_InvalidCutOffInput_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ProductByUsageAndStartDate("digital download", new DateTime()));
        }

        [Test]
        public void NewInstance_validInputs_ObjectCreated()
        {
            var testObject = new ProductByUsageAndStartDate("digital download", new DateTime(2012,3,1));
            Assert.IsNotNull(testObject);
        }
    }
}