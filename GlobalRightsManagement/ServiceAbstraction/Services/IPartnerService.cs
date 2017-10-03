using System.Collections.Generic;

using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services
{
    public interface IPartnerService
    {
        IEnumerable<Distributor> Get(string name);
        void Upload(string connection);
    }
}
