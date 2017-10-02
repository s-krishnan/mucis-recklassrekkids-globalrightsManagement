using System.Collections.Generic;


using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Services
{
    public interface IProductService
    {
        IEnumerable<Product> Get(string u, string b);
    }
}
