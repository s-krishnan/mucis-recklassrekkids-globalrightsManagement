// <copyright file="PartnerSearchController.cs" company="Recklass Rekkids">
//     Copyright (c) 2017 RecklassRekkids Ltd. All rights Reserved.
// </copyright>
// <author>Saravana</author>

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.Controller
{
    using System.Collections.Generic;
    using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
    using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;
    using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services;
    using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

    /// <summary>
    /// Controller for product search functinality
    /// </summary>
    public class PartnerSearchController
    {
        /// <summary>
        /// The partner service
        /// </summary>
        private IPartnerService partnerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerSearchController"/> class.
        /// </summary>
        public PartnerSearchController()
            : this(new PartnerService(PartnerRepository.CreatePartnerRepository()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerSearchController"/> class.
        /// </summary>
        /// <param name="partnerService">The partner service.</param>
        public PartnerSearchController(PartnerService partnerService)
        {
            this.partnerService = partnerService;
        }

        /// <summary>
        /// Gets the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>the distributors</returns>
        public IEnumerable<Distributor> Get(string name)
        {
            return this.partnerService.Get(name);
        }
    }
}
