using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Repositories;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Data;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Query;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories
{
    /// <summary>
    /// Base service class which every service class shoudl inherit
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private IList<Product> products;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public ProductRepository(IDataContext<Product> db)
        {
            this.products = db.Data;
        }

        /// <summary>
        /// Find products from given database using given query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Product> Find(IProductCommand query)
        {
            if (query == null)
            {
                throw new ArgumentException("Command can not be null");
            }
            else
            {
                return this.products.Where(query.Command());
            }
        }
    }
}
