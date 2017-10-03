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
    public interface IPartnerRepository
    {
        /// <summary>
        /// Skelton method for finding usage type supported by given distributor.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        IEnumerable<Distributor> Find(IPartnerCommand<Distributor,bool> command);

        /// <summary>
        /// Method for inserting new products.
        /// </summary>
        /// <param name="newProducts"></param>
        void Insert(IEnumerable<string> newPartners);
    }
}
