using System;
using System.Collections.Generic;

using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Repositories;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Query;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Query;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.CoreAbstractions.Utilities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services
{
    /// <summary>
    /// Service class for service Partner service. This service call is called from ProductController.
    /// </summary>
    public class PartnerService : IPartnerService
    {
        private IPartnerRepository repositiry;

        /// <summary>
        /// Constructor accepts PartnerRepository interafce for querying underlying data
        /// </summary>
        /// <param name="repository"></param>
        public PartnerService(IPartnerRepository repository)
        {
            this.repositiry = repository;
        }

        /// <summary>
        /// Retrieve Partners meeting given condition. Condition is passed in the form of query
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Distributor> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid Argument, Argument can not be Null or Empty.");
            }

            IPartnerCommand<Distributor,bool> command = new UsageByPartner(name);

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
