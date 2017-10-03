using System.Collections.Generic;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.API.View
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractView<T> where T:IEnumerable<BaseEntity>
    {
        /// <summary>
        /// Abstract render method for all the view class to define.
        /// </summary>
        /// <param name="entity">entity to be used by view.</param>
        /// <returns></returns>
        public abstract string RenderView(T entity);
    }
}
