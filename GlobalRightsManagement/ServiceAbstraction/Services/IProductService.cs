using System;
using System.Collections.Generic;
using System.Text;



using RecklassRekkids.GlblRightsMgmt.ServiceEntities;


namespace RecklassRekkids.GlblRightsMgmt.ServiceAbstraction.Services
{
    public interface IProductService
    {
        List<Product> Get();
    }
}
