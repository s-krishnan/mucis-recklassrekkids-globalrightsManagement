
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;


namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.Controller
{
    /// <summary>
    /// Controller for product search functinality
    /// </summary>
    public class ProductCreateController
    {
        private IProductService prodService;

        /// <summary>
        /// Initialise product service
        /// </summary>
        public ProductCreateController() : this(
            new ProductService(ProductRepository.CreateProductRepository()))
        { }


        public ProductCreateController(ProductService prodService)
        {
            this.prodService = prodService;
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

    }
}

