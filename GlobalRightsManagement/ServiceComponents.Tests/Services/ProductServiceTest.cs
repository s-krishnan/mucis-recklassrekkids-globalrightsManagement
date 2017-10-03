using System;
using NUnit.Framework;
using Moq;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Repositories;
using RecklassRekkids.GlblRightsMgmt.Tests.TestsCore;


namespace RecklassRekkids.GlblRightsMgmt.ServiceComponent.Tests.Services
{
    [TestFixture]
    public class ProductServiceTest
    {
        private TestingObject<ProductService> GetTestingObject()
        {
            var testingObject = new TestingObject<ProductService>();
            testingObject.AddDependency(new Mock<IProductRepository>(MockBehavior.Loose));
            return testingObject;
        }

        [Test]
        public void Get_InvalidArgument_ThrowArgumentException1()
        {
            TestingObject<ProductService> testingObject = this.GetTestingObject();
            ProductService prodService = testingObject.GetResolvedTestingObject();
            Assert.Throws<ArgumentException>(() => prodService.Get("", ""));
        }

        [Test]
        public void Get_InvalidArgument_ThrowArgumentException2()
        {
            TestingObject<ProductService> testingObject = this.GetTestingObject();
            ProductService prodService = testingObject.GetResolvedTestingObject();
            Assert.Throws<ArgumentException>(() => prodService.Get(null, null));
        }

        [Test]
        public void Get_InvalidArgument_ThrowArgumentException3()
        {
            TestingObject<ProductService> testingObject = this.GetTestingObject();
            ProductService prodService = testingObject.GetResolvedTestingObject();
            Assert.Throws<ArgumentException>(() => prodService.Get("NotValid", null));
        }

        [Test]
        public void Get_InvalidArgument_ThrowArgumentException4()
        {
            TestingObject<ProductService> testingObject = this.GetTestingObject();
            ProductService prodService = testingObject.GetResolvedTestingObject();
            Assert.Throws<ArgumentException>(() => prodService.Get(null, "NotValid"));
        }

        [Test]
        public void Get_InvalidArgument_ThrowArgumentException5()
        {
            TestingObject<ProductService> testingObject = this.GetTestingObject();
            ProductService prodService = testingObject.GetResolvedTestingObject();
            Assert.Throws<ArgumentException>(() => prodService.Get(null, ""));
        }

        [Test]
        public void Get_InvalidArgument_ThrowArgumentException6()
        {
            TestingObject<ProductService> testingObject = this.GetTestingObject();
            ProductService prodService = testingObject.GetResolvedTestingObject();
            Assert.Throws<ArgumentException>(() => prodService.Get("", null));
        }

    }
}

