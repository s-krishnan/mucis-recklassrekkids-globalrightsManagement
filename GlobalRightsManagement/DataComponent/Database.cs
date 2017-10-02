using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecklassRekkids.GlblRightsMgmt.ServiceEntities;


namespace RecklassRekkids.GlblRightsMgmt.DataComponent
{
    public static class Database
    {
        /// <summary>
        /// local dataset for storing and retrieving products.
        /// </summary>
        public static IList<BaseEntity> Products { get; set; }

        /// <summary>
        /// local dataset for storing and retrieving distributor.
        /// </summary>
        public static IList<BaseEntity> Distributors { get; set; }

        static Database()
        {
            Products = new List<BaseEntity>();
            Distributors = new List<BaseEntity>();

        }
    }
}
