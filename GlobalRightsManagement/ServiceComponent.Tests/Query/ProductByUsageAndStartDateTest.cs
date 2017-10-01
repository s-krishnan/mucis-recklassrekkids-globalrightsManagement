using System;
using System.Linq;
using System.Linq.Expressions;
using Xunit;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.Tests.TestsCore;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Query;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponent.Tests.Query
{
    public class ProductByUsageAndStartDateTest
    {
        /// <summary>
        /// Retrieve testable object using this method instaed of new instantiation.
        /// </summary>
        /// <returns></returns>
        private TestingObject<ProductByUsageAndStartDate> GetTestingObject()
        {
            var testingObject = new TestingObject<ProductByUsageAndStartDate>();
            //testingObject.AddDependency(new Mock<IDatabaseContext>(MockBehavior.Strict));
            return testingObject;
        }

        [Fact]
        public void new_InvalidArguments_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
                ()=> new ProductByUsageAndStartDate("",new DateTime()) );
        }
    }
}
