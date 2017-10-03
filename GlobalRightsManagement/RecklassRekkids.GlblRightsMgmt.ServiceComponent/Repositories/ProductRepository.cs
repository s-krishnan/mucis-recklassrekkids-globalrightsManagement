using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Repositories;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Data;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Query;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Data;
using RecklassRekkids.GlblRightsMgmt.CoreAbstractions.Utilities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories
{
    /// <summary>
    /// Base service class which every service class shoudl inherit
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private IList<Product> products;

        /// <summary>
        /// Constructor for creating repository.
        /// </summary>
        /// <param name="db"></param>
        public ProductRepository(IDataContext<Product> db)
        {
            this.products = db.Data;
        }

        public static ProductRepository CreateProductRepository()
        {
            return new ProductRepository(new DataContext<Product>());
        }

        /// <summary>
        /// Find products from given database using given query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Product> Find(IProductCommand<Product,bool> query)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newProducts"></param>
        public void Insert(IEnumerable<string> values)
        {
            if (values != null)
            {

                var newProducts = values
                                    .Skip(1)
                                    .Select(x => x.Split('|'))
                                    .SelectMany(parts => parts[2]?.Split(',')
                                        , (parts, c) =>
                                    new Product
                                    {
                                        Artist = parts[0]?.Trim(),
                                        Title = parts[1]?.Trim(),
                                        Usages = c?.Trim(),
                                        StartDate = DateTimeUtil.ConvertFromString(parts[3]),
                                        EndDate = parts[4]
                                    });
                foreach (var np in newProducts)
                {
                    //foreach (var us in np.Usages.Split(','))
                    //{
                    //    np.Usages = us;
                    //    this.products.Add(np);
                    //}
                    this.products.Add(np);
                }
            }
            
        }
    }
}
