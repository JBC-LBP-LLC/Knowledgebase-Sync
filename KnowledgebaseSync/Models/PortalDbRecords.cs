namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     All records from the Portal database for a specific portal.
    ///     
    ///     Example: Portal-905-Db.json
    /// </summary>
    public class PortalDbRecords
    {
        /// <summary>
        ///     The records for a specific Portal's FAQs.
        /// </summary>
        public PortalDbRecordDTO[] PortalDbFAQs { get; set; }
    }
}
