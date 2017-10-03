using System;
using System.Linq.Expressions;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Query;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Query
{
    /// <summary>
    /// Query for finding usage type for given partner
    /// </summary>
    public class UsageByPartner : IPartnerCommand<Distributor,bool>
    {
        public String Partner { get; set; }


        /// <summary>
        /// Constructor to create this command
        /// </summary>
        /// <param name="Partner">partner name for whome usage should be found.</param>
        public UsageByPartner(string partner)
        {
            if (string.IsNullOrEmpty(partner))
            {
                throw new ArgumentException("Invalid Argument(s).");
            }

            this.Partner = partner;
        }

        /// <summary>
        /// LINQ expression to query list of usages supported by selected distributor
        /// </summary>
        /// <returns></returns>
        public Func<Distributor, bool> Command()
        {
            return (d =>d.Name == this.Partner);
        }
    }
}
