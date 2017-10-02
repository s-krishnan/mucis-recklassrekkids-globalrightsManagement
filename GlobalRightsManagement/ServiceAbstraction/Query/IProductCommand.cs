using System.Linq.Expressions;
using System;
using System.Linq;
using System.Collections.Generic;
using RecklassRekkids.GlblRightsMgmt.ServiceEntities;


namespace RecklassRekkids.GlblRightsMgmt.ServiceAbstractions.Query
{
    /// <summary>
    /// Interface for all teh query command
    /// </summary>
    public interface IProductCommand
    {
        Func<Product, bool> Command();
    }
}