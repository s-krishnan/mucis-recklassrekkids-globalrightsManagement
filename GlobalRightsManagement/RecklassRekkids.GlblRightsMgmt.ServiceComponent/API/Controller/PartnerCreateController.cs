// <copyright file="PartnerCreateController.cs" company="Recklass Rekkids">
//     Copyright (c) 2017 RecklassRekkids Ltd. All rights Reserved.
// </copyright>
// <author>Saravana</author>

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.Controller
{
    using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services;
    using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Repositories;
    using RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services;

    /// <summary>
    /// Controller for product search functinality
    /// </summary>
    public class PartnerCreateController
    {
        /// <summary>
        /// The partner service
        /// </summary>
        private IPartnerService partnerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerCreateController"/> class.
        /// </summary>
        public PartnerCreateController()
            : this(new PartnerService(PartnerRepository.CreatePartnerRepository()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerCreateController"/> class.
        /// </summary>
        /// <param name="partnerService">The partner service.</param>
        public PartnerCreateController(PartnerService partnerService)
        {
            this.partnerService = partnerService;
        }

        /// <summary>
        /// Factory method to create controller from given connection string.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public void Upload(string connection)
        {
            this.partnerService.Upload(connection);
        }
    }
}
