// <copyright file="ProductSearchController.cs" company="Recklass Rekkids">
//     Copyright (c) 2017 RecklassRekkids Ltd. All rights Reserved.
// </copyright>
// <author>Saravana</author>

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.Controller
{
    using System;
    using System.Collections.Generic;
    using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
    using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.View;
    using RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.View;
    using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;
    using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services;
    using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

    /// <summary>
    /// Controller for product search functinality
    /// </summary>
    public class ProductSearchController
    {
        /// <summary>
        /// The product service
        /// </summary>
        private IProductService prodService;

        /// <summary>
        /// The result view
        /// </summary>
        private IView<IEnumerable<Product>> resultView;

        /// <summary>
        /// The error view
        /// </summary>
        private IView<IEnumerable<Error>> errorView;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSearchController"/> class.
        /// </summary>
        public ProductSearchController() :
            this(new ProductService(ProductRepository.CreateProductRepository()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSearchController"/> class.
        /// </summary>
        /// <param name="prodService">The product service.</param>
        public ProductSearchController(ProductService prodService)
        {
            this.prodService = prodService;
            this.errorView = new ProductSearchErrorView();
            this.resultView = new ProductSearchResultView();
        }

        /// <summary>
        /// Gets the specified partner.
        /// </summary>
        /// <param name="partner">The partner.</param>
        /// <param name="startByDate">The start by date.</param>
        /// <returns>the search result</returns>
        /// <exception cref="ArgumentException">Missing Input, Both Usage and Start-by-date should be passed</exception>
        public string Get(string partner, string startByDate)
        {
            try
            {
                if (string.IsNullOrEmpty(startByDate) || string.IsNullOrEmpty(partner))
                {
                    throw new ArgumentException("Missing Input, Both Usage and Start-by-date should be passed");
                }

                IList<Product> results = new List<Product>();

                var partnerUsages = new PartnerSearchController().Get(partner);

                foreach (var p in partnerUsages)
                {
                    var filteredProdcuts = this.prodService.Get(p.DistributionType, startByDate);

                    foreach (var cur in filteredProdcuts)
                    {
                        results.Add(cur);
                    }
                }

                return this.resultView.RenderView(results);
            }
            catch (Exception e)
            {
                return this.errorView.RenderView(new List<Error> { new Error { exception = e } });
            }
        }
    }
}
