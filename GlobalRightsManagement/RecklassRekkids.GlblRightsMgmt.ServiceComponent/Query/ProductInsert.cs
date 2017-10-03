using System;
using System.Linq;
using System.Linq.Expressions;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Query;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.CoreAbstractions.Utilities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Query
{
    /// <summary>
    /// Query for finding products which are supported by given partner and 
    /// start date should be before given date.
    /// </summary>
    public class ProductInsert : IProductCommand<string[],Product>
    {
        public String[] data { get; set; }


        public ProductInsert(String[] data)
        {
            if (data?.Length <= 0)
            {
               throw new ArgumentException("Invalid Argument(s).");
            }

            this.data = data;
        }

        /// <summary>
        /// LINQ expression to query list of products distributed by selected partner
        /// and start date is before given cutoff date 
        /// </summary>
        /// <returns></returns>
        public Func<string[], Product> Command()
        {
            return (c => new Product
            {
                Artist = c[0]?.Trim(),
                Title = c[1]?.Trim(),
                Usages = c[2]?.Trim(),
                StartDate = DateTimeUtil.ConvertFromString(c[3]),
                EndDate = c[4]?.Trim()
            });

        }
    }
}
