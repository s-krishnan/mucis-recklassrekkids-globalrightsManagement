using System;
using System.Collections.Generic;
using System.Text;

namespace RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Data
{
    public interface IDataContext<T>
    {
        IList<T> Data { get; }
    }
}
