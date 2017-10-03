using System.Collections.Generic;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;

namespace RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.View
{

    public interface IView<T> where T : IEnumerable<BaseEntity>
    {
        /// <summary>
        /// Abstract render method for all the view class to define.
        /// </summary>
        /// <param name="entity">entity to be used by view.</param>
        /// <returns></returns>
        string RenderView(T entity);
    }
}
