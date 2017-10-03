using System;
using System.Linq;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

using RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.Controller;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Data;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
using RecklassRekkids.GlblRightsMgmt.Tests.TestsCore;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services;
namespace ServiceComponents.Tests.API.Controller
{
    [TestFixture]
    public class ProductControllerIntegrationTest
    {
        private IList<Product> products;
        private IList<Distributor> partners;

        public ProductControllerIntegrationTest()
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

            partners = new List<Distributor>
            {
                new Distributor{ DistributionType="digital download", Name="ITunes" },
                new Distributor{ DistributionType="streaming", Name="YouTube" }
            };

        }

        private TestingObject<R> GetTestingObject<R,D>() where R:class
        {
            var testingObject = new TestingObject<R>();
            testingObject.AddDependency(new Mock<IDataContext<D>>(MockBehavior.Strict));
            return testingObject;
        }


        //[TestCase("Invalid Partner", "1st March 2012", "output is:\r\nNo data found for the given input")]
        //[TestCase("", "", "Error Occured in search, please check the user input.")]
        //[TestCase(null, "", "Error Occured in search, please check the user input.")]
        //[TestCase(null, null, "Error Occured in search, please check the user input.")]
        //[TestCase("", null, "Error Occured in search, please check the user input.")]
        //[TestCase("ITunes", "1st March 2012", "output is:\r\nArtist | Title | Usage | StartDate | EndDate")]
        //public void Get_AlwaysReturnsValidString(string partner, string startBy, string expected)
        //{
        //    TestingObject<ProductRepository> testingProductRepository = this.GetTestingObject<ProductRepository, Product>();

        //    var mockProductDataContext = testingProductRepository.GetDependency<Mock<IDataContext<Product>>>();
        //    mockProductDataContext.Setup(d => d.Data).Returns(products);

        //    TestingObject<PartnerRepository> testingPartnerRepository = this.GetTestingObject<PartnerRepository, Distributor>();

        //    var mockPartnerDataContext = testingPartnerRepository.GetDependency<Mock<IDataContext<Distributor>>>();
        //    mockPartnerDataContext.Setup(d => d.Data).Returns(partners);

        //    ProductService prodService = new ProductService(testingProductRepository.GetResolvedTestingObject());
        //    //ProductSearchController prodCtrlr = new ProductSearchController(prodService);

        //    PartnerService partnerService = new PartnerService(testingPartnerRepository.GetResolvedTestingObject());
        //    PartnerSearchController partnerControler = new PartnerSearchController(partnerService);

        //    var testingProductSearchController = new TestingObject<ProductSearchController>();
        //    testingProductSearchController.AddDependency(new Mock<ProductRepository>(MockBehavior.Strict));
        //    testingProductSearchController.AddDependency(new Mock<PartnerRepository>(MockBehavior.Strict));

        //    var mockProductServiceContext = testingProductSearchController.GetDependency<Mock<IProductService>>();

        //    //mockProductServiceContext.DefaultValue = .
        //    //    Setup(
        //    //    ps => ps.Get(It.Is<string>(name => name == partner)
        //    //    , It.Is<string>(sb => sb == startBy)))
        //    //    .Returns(prodService.Get(partner,));


        //    var actual = prodCtrlr.Get(partner, startBy);

        //    Assert.IsTrue(actual.StartsWith(expected));
        //}

    }
}
