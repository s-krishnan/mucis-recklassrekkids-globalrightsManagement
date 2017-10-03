using System;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
using System.IO;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.Controller;
using RecklassRekkids.GlblRightsMgmt.Application;

namespace EndToEnd.Tests
{
    

    [TestFixture]
    public class EndToEndTest
    {

        [TestCase("ITunes", "1st March 2012", "output is:\r\nArtist | Title | Usage | StartDate | EndDate")]
        public void Upload_ValidProdutFile_ProductsCreated(string partner,string startBy,string expected)
        {
            //string productContractInput = $@"{GetAssemblyDirectory()}\TestData\MusicContract.txt";
            //ProductCreateController prodCreatecontroller = new ProductCreateController();
            //prodCreatecontroller.Upload(productContractInput);

            //string partnerContractInput = $@"{GetAssemblyDirectory()}\TestData\PartnerContract.txt";
            //PartnerCreateController partnerCreatorController = new PartnerCreateController();
            //partnerCreatorController.Upload(partnerContractInput);

            BootStrap bs = new BootStrap();
            //Initialise database with default data from the local file
            bs.Init(null);

            //Execute the search
            var actual = bs.Execute(partner, startBy);

            Assert.IsTrue(actual.StartsWith(expected));
        }
    }
}