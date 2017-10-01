using System;
using System.Collections.Generic;
using System.Text;

using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Services
{
    /// <summary>
    /// Base service class which every service class shoudl inherit
    /// </summary>
    public abstract class Repository<T> where T: BaseEntity
    {

        public abstract List<T> Get();
    }
}
