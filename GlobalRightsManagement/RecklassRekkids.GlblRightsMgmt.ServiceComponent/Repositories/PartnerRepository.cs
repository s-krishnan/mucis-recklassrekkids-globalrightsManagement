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

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories
{
    /// <summary>
    /// Base service class which every service class shoudl inherit
    /// </summary>
    public class PartnerRepository : IPartnerRepository
    {
        private IList<Distributor> partners;

        /// <summary>
        /// Constructor for creating repository.
        /// </summary>
        /// <param name="db"></param>
        public PartnerRepository(IDataContext<Distributor> db)
        {
            this.partners = db.Data;
        }

        public static PartnerRepository CreatePartnerRepository()
        {
            return new PartnerRepository(new DataContext<Distributor>());
        }

        /// <summary>
        /// Find usage type for the given partner name.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Distributor> Find(IPartnerCommand<Distributor,bool> query)
        {
            if (query == null)
            {
                throw new ArgumentException("Command can not be null");
            }
            else
            {
                return this.partners.Where(query.Command());
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

                var newPartners = values
                                    .Skip(1)
                                    .Select(x => x.Split('|'))
                                  .Select(
                                  parts => new Distributor
                                  {
                                      Name = parts[0]?.Trim(),
                                      DistributionType = parts[1]?.Trim()
                                  });
                
                foreach (var p in newPartners)
                {
                    
                    this.partners.Add(p);
                }
            }

        }
    }
}
