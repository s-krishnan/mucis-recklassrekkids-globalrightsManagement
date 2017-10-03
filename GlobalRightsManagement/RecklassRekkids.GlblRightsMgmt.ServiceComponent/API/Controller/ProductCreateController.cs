// <copyright file="ProductCreateController.cs" company="Recklass Rekkids">
//     Copyright (c) 2017 RecklassRekkids Ltd. All rights Reserved.
// </copyright>
// <author>Saravana</author>

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.Controller
{
    using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
    using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;
    using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services;

    /// <summary>
    /// Controller for product search functinality
    /// </summary>
    public class ProductCreateController
    {
        /// <summary>
        /// The product service
        /// </summary>
        private IProductService prodService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCreateController"/> class.
        /// </summary>
        public ProductCreateController()
            : this(new ProductService(ProductRepository.CreateProductRepository()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCreateController"/> class.
        /// </summary>
        /// <param name="prodService">The product service.</param>
        public ProductCreateController(ProductService prodService)
        {
            this.prodService = prodService;
        }

        /// <summary>
        /// Uploads the specified connection.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public void Upload(string connection)
        {
            this.prodService.Upload(connection);
        }
    }
}