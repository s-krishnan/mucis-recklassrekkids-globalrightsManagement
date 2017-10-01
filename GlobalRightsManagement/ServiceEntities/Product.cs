using System;


namespace RecklassRekkids.GlblRightsMgmt.ServiceEntities
{
    /// <summary>
    /// Model represents album entity
    /// </summary>
    public class Product:BaseEntity
    {
        /// <summary>
        /// Name of the creator (artist) for current album
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Title of the album (song)
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// It represents the media through which current album can be sold to a customer.
        /// <value>digital download</value>
        /// <value>streaming</value>
        /// </summary>
        public String Usages { get; set; }

        /// <summary>
        /// Effective start date of the album for a customer available in the selected media.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Effective end date of the album should be out of shelves in the selected media (usgae).
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
