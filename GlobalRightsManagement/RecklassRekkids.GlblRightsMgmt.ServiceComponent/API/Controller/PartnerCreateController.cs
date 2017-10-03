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
    public class PartnerCreateController
    {
        private IPartnerService partnerService;

        /// <summary>
        /// Initialise product service
        /// </summary>
        public PartnerCreateController() : this(new PartnerService(PartnerRepository.CreatePartnerRepository()))
        { }


        public PartnerCreateController(PartnerService partnerService)
        {
            this.partnerService = partnerService;
        }

        /// <summary>
        /// Factory method to create controller from given connection string. 
        /// </summary>
        /// <param name="connectionstring">connection detail to file from where initiail data should be loaded</param>
        /// <returns></returns>
        public void Upload(string connection)
        {
            this.partnerService.Upload(connection);
        }

    }
}
