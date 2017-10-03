using System;
using System.Collections.Generic;
using System.Linq;

using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.View;
using RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.View;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.Controller
{
    /// <summary>
    /// Controller for product search functinality
    /// </summary>
    public class PartnerSearchController
    {
        private IPartnerService partnerService;

        /// <summary>
        /// Initialise product service
        /// </summary>
        public PartnerSearchController() : this(new PartnerService(PartnerRepository.CreatePartnerRepository()))
        { }


        public PartnerSearchController(PartnerService partnerService)
        {
            this.partnerService = partnerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partner"></param>
        public IEnumerable<Distributor> Get(string name)
        {
            return this.partnerService.Get(name);
        }

    }
}
