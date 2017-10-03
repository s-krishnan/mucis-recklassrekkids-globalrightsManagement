using System.Reflection;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.Controller;

namespace RecklassRekkids.GlblRightsMgmt.Application
{
    public class BootStrap
    {
        public static string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
        public string Execute(string partnerName, string StartByDate)
        {
            ProductSearchController prodSearchController = new ProductSearchController();
            return prodSearchController.Get(partnerName, StartByDate);
        }

        public void Init(string[] args)
        {
            //Create produt table in database and load Music contract Data from the file.
            string productContractInput = args?.Length>0 ? args[0]: $@"{GetAssemblyDirectory()}\TestData\MusicContract.txt";
            ProductCreateController prodCreatecontroller = new ProductCreateController();
            prodCreatecontroller.Upload(productContractInput);

            //Create partner table in database and load partner contract Data from the file.
            string partnerContractInput = args?.Length > 1 ? args[1]: $@"{GetAssemblyDirectory()}\TestData\PartnerContract.txt";
            PartnerCreateController partnerCreatorController = new PartnerCreateController();
            partnerCreatorController.Upload(partnerContractInput);
        }
    }
}
