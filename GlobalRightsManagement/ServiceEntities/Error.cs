using System;


namespace RecklassRekkids.GlblRightsMgmt.ServiceEntities
{
    /// <summary>
    /// Model represents error entity
    /// </summary>
    public class Error : BaseEntity
    {
        /// <summary>
        /// exception object
        /// </summary>
        public Exception exception { get; set; }
    }
}
