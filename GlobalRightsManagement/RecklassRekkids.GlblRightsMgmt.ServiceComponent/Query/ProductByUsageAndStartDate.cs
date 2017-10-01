﻿using System;
using System.Linq.Expressions;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Query;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Query
{
    /// <summary>
    /// Query for finding products which are supported by given partner and 
    /// start date should be before given date.
    /// </summary>
    public class ProductByUsageAndStartDate : IProductCommand
    {
        public String Usage { get; set; }

        public DateTime StartDate { get; set; }

        /// <summary>
        /// Constructor to create this command
        /// </summary>
        /// <param name="usage">actual usage should be used in the filter against 
        /// available data</param>
        /// <param name="cutoff">actual cutoff time shoudl be used in the filter against available data</param>
        public ProductByUsageAndStartDate(string usage, DateTime cutoff)
        {
            this.Usage = usage;
            this.StartDate = cutoff;
        }

        /// <summary>
        /// LINQ expression to query list of products distributed by selected partner
        /// and start date is before given cutoff date 
        /// </summary>
        /// <returns></returns>
        public Expression<Func<Product, bool>> Command()
        {
            throw new NotImplementedException();
        }
    }
}