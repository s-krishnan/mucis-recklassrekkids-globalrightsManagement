using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;
using RecklassRekkids.GlblRightsMgmt.Tests.TestsCore;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Data;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services
{
    /// <summary>
    /// nunit test class for productservice integration. this class test end to end flow except external resources such as Disk, file, network, etc. 
    /// </summary>
    [TestFixture]
    class ProductServiceIntegrationTest
    {
        private IList<Product> products;

        public ProductServiceIntegrationTest()
        {
            products = new List<Product> {
                new Product{Artist="Tinie Tempah", Title="Frisky (Live from SoHo)", Usages="digital download", StartDate=DateTime.Parse("2012/02/01") },
                new Product{Artist="Tinie Tempah", Title="Frisky (Live from SoHo)", Usages="streaming", StartDate=DateTime.Parse("2012/02/01") },
                new Product{Artist="Tinie Tempah", Title="Miami 2 Ibiza", Usages="digital download", StartDate=DateTime.Parse("2012/02/01") },
                new Product{Artist="Tinie Tempah", Title="Till I'm Gone", Usages="digital download", StartDate=DateTime.Parse("2012/08/01") },
                new Product{Artist="Monkey Claw", Title="Black Mountain", Usages="digital download", StartDate=DateTime.Parse("2012/02/01") },
                new Product{Artist="Monkey Claw", Title="Iron Horse", Usages="digital download", StartDate=DateTime.Parse("2012/06/01") },
                new Product{Artist="Monkey Claw", Title="Iron Horse", Usages="streaming", StartDate=DateTime.Parse("2012/06/01") },
                new Product{Artist="Monkey Claw", Title="Motor Mouth", Usages="digital download", StartDate=DateTime.Parse("2011/03/01") },
                new Product{Artist="Monkey Claw", Title="Motor Mouth", Usages="streaming", StartDate=DateTime.Parse("2011/03/01") },
                new Product{Artist="Monkey Claw", Title="Christmas Special", Usages="streaming", StartDate=DateTime.Parse("2012/12/25"), EndDate="2012/12/31" }
            };
        }

        private TestingObject<ProductRepository> GetTestingObject()
        {
            var testingObject = new TestingObject<ProductRepository>();
            testingObject.AddDependency(new Mock<IDataContext<Product>>(MockBehavior.Loose));
            return testingObject;
        }

        [TestCase("digital download", "1st March 2012",4)]
        [TestCase("streaming", "1st April 2012", 2)]
        [TestCase("streaming", "27th Dec 2012", 4)]
        public void Get_ValidArgument_ReturnResults(string usage,string startBy, int expected)
        {
            TestingObject<ProductRepository> testingObject = this.GetTestingObject();
            var mockDataContext = testingObject.GetDependency<Mock<IDataContext<Product>>>();
            mockDataContext.Setup(d => d.Data).Returns(products);
            ProductService prodService = new ProductService(testingObject.GetResolvedTestingObject());
            IEnumerable<Product> actual = prodService.Get(usage, startBy);
            Assert.AreEqual(expected, actual.Count<Product>());
        }
    }
}
