using System;
using System.Collections.Generic;
using System.Text;

namespace RecklassRekkids.GlblRightsMgmt.ServiceEntities
{
    /// <summary>
    /// Model represents partner business entity.
    /// </summary>
    public class Distributor:BaseEntity
    {
        /// <summary>
        /// Partner name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Type of distribution partner offers.
        /// </summary>
        public String DistributionType { get; set; }

    }
}
