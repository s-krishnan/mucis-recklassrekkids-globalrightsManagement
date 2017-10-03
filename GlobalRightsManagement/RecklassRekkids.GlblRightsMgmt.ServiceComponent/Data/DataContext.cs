using System;
using System.Collections.Generic;
using System.Text;

using RecklassRekkids.GlblRightsMgmt.ServiceEntities;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Data;
using RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Repositories;
using RecklassRekkids.GlblRightsMgmt.DataComponent;

namespace RecklassRekkids.GlblRightsMgmt.ServiceComponents.Data
{
    public class DataContext<T> : IDataContext<T> where T : BaseEntity, new()
    {
        IList<T> _data;

        IList<T> IDataContext<T>.Data
        {
            get { return _data; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataContext()
        {
            if(typeof(T)==typeof(Product))
            {
                _data = (IList<T>) Database.Products;
            }
            if (typeof(T) == typeof(Distributor))
            {
                _data = (IList<T>)Database.Distributors;
            }
            
        }
    }
}
