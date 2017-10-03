using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Repositories;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Query;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Query;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.CoreAbstractions.Utilities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services
{
    /// <summary>
    /// Service class for service product service. This service call is called from ProductController.
    /// </summary>
    public class ProductService : IProductService
    {
        private IProductRepository repositiry;

        /// <summary>
        /// Constructor accepts ProductRepository interafce for querying underlying data
        /// </summary>
        /// <param name="repository"></param>
        public ProductService(IProductRepository repository)
        {
            this.repositiry = repository;
        }

        /// <summary>
        /// Retrieve products meets given condition. Condition is passed in the form of query
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> Get(string usage, string startBy)
        {
            if(string.IsNullOrEmpty(usage) || string.IsNullOrEmpty(startBy) )
            {
                throw new ArgumentException("Invalid Argument, Argument can not be Null or Empty.");
            }

            IProductCommand<Product,bool> command =
                new ProductByUsageAndStartDate(
                    usage, DateTimeUtil.ConvertFromString(startBy));

            return this.repositiry.Find(command);
        }

        public void Upload(string connection)
        {
            if (String.IsNullOrEmpty(connection) || !System.IO.File.Exists(connection))
            {
                throw new ArgumentException("Invalid input product file.");
            }
            else
            {
                string[] s = System.IO.File.ReadAllLines(connection);
                this.repositiry.Insert(s);
            }
        }
    }
}
