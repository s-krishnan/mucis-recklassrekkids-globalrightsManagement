using System;
using System.Collections.Generic;
using System.Text;

using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Query;

namespace RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Repositories
{
    /// <summary>
    /// Interface for product repository.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Skelton method for finding products using given query.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        IEnumerable<Product> Find(IProductCommand<Product,bool> command);

        /// <summary>
        /// Method for inserting new products.
        /// </summary>
        /// <param name="newProducts"></param>
        void Insert(IEnumerable<string> newProducts);
    }
}
