using System;
using System.Linq;
using NUnit;
using NUnit.Framework;
using Moq;
using System.Collections;
using System.Collections.Generic;

using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;
using RecklassRekkids.GlblRightsMgmt.Tests.TestsCore;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Data;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Query;

namespace ServiceComponents.Tests.Repositories
{
    [TestFixture]

    public class ProductRepositoryTest
    {
        private TestingObject<ProductRepository> GetTestingObject()
        {
            var testingObject = new TestingObject<ProductRepository>();
            testingObject.AddDependency(new Mock<IDataContext<Product>>(MockBehavior.Loose));
            testingObject.AddDependency(new Mock<IProductCommand>(MockBehavior.Loose));
            return testingObject;
        }

        [Test]
        public void Find_InvalidArgument_ThrowArgumentException()
        {
            TestingObject<ProductRepository> testingObject = this.GetTestingObject();
            ProductRepository prodRepository = testingObject.GetResolvedTestingObject();
            Assert.Throws<ArgumentException>(() => prodRepository.Find(null));
        }

        [Test]
        public void Find_InvalidQuery_ThrowArgumentException()
        {
            TestingObject<ProductRepository> testingObject = this.GetTestingObject();
            var mockProductCommand = testingObject.GetDependency<Mock<IProductCommand>>();

            Func<Product, bool> query = null;

            mockProductCommand
                .Setup(c => c.Command())
                .Returns(query);

            ProductRepository prodRepository = testingObject.GetResolvedTestingObject();
            var a = testingObject.GetDependency<Mock<IProductCommand>>();

            Assert.Throws<ArgumentException>(() => prodRepository.Find(It.IsAny<IProductCommand>()));
        }

        [Test]
        public void Find_validQuery_ReturnsCorrectProducts()
        {
            TestingObject<ProductRepository> testingObject = this.GetTestingObject();

            var mockDataContext = testingObject.GetDependency<Mock<IDataContext<Product>>>();

            IList<Product> products = new List<Product> {
                new Product{Artist="Tinie Tempah", Title="Frisky (Live from SoHo)", Usages="digital download", StartDate=DateTime.Parse("2012/02/01") },
                new Product{Artist="Tinie Tempah", Title="Frisky (Live from SoHo)", Usages="streaming", StartDate=DateTime.Parse("2012/02/01") },
                new Product{Artist="Tinie Tempah", Title="Miami 2 Ibiza", Usages="digital download", StartDate=DateTime.Parse("2012/02/01") },
                new Product{Artist="Tinie Tempah", Title="Till I'm Gone", Usages="digital download", StartDate=DateTime.Parse("2012/08/01") }
            };
            mockDataContext
                .Setup(d => d.Data)
                .Returns(products);

            Func<Product, bool> query = (product => product.Usages == "digital download");

            var mockProductCommand = testingObject.GetDependency<Mock<IProductCommand>>();

            mockProductCommand
                .Setup(c => c.Command())
                .Returns(query);

            ProductRepository prodRepository = testingObject.GetResolvedTestingObject();
            var a = testingObject.GetDependency<Mock<IProductCommand>>();

            Assert.AreEqual(3, prodRepository.Find(mockProductCommand.Object).Count<Product>());

        }
    }
}

