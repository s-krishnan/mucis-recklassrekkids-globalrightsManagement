﻿using System;
using System.Collections.Generic;
using System.Linq;

using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.View;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.View;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.Controller
{
    /// <summary>
    /// Controller for product search functinality
    /// </summary>
    public class ProductSearchController_Old
    {
        private IProductService prodService;
        private IPartnerService partnerService;

        private IView<IEnumerable<Product>> resultView;
        private IView<IEnumerable<Error>> errorView;


        /// <summary>
        /// Initialise product service
        /// </summary>
        public ProductSearchController() : this(
            new ProductService(ProductRepository.CreateProductRepository())
            , new PartnerService(PartnerRepository.CreatePartnerRepository()))
        { }
            

        public ProductSearchController(ProductService prodService, PartnerService partnerService)
        {
            this.prodService = prodService;
            this.partnerService = partnerService;
            errorView = new ProductSearchErrorView();
            resultView = new ProductSearchResultView();
        }

        /// <summary>
        /// Factory method to create controller from given connection string. 
        /// </summary>
        /// <param name="connectionstring">connection detail to file from where initiail data should be loaded</param>
        /// <returns></returns>
        public void Upload(string connection)
        {
             this.prodService.Upload(connection);
        }

        /// <summary>
        /// Method to be called by the UI to display the product serach results.
        /// </summary>
        /// <param name="startByDate"></param>
        /// <returns></returns>
        public string Get(string partner, string startByDate)
        {
            try {

                if (String.IsNullOrEmpty(startByDate) || String.IsNullOrEmpty(partner))
                {
                    throw new ArgumentException("Missing Input, Both Usage and Start-by-date should be passed");
                }

                IList<Product> results = new List<Product>();

                var partnerUsages = partnerService.Get(partner);
                
                foreach(var p in partnerUsages)
                {
                    var filteredProdcuts = prodService.Get(p.DistributionType, startByDate);

                    foreach (var cur in filteredProdcuts)
                    {
                        results.Add(cur);
                    }
                }

                    return resultView.RenderView(results);
            }
            catch (Exception e) {
                return errorView.RenderView(new List<Error>() { new Error { exception = e } });
            }
        }

    }
}
