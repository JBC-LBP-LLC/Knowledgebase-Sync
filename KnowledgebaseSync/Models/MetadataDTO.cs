namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Name - value pair of metadata.
    /// </summary>
    public class MetadataDTO
    {
        /// <summary>
        ///     Name of the metadata item. Example: "categorytitle"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Value of the metadata item. Example: "401(k)"
        /// </summary>
        public string Value { get; set; }
    }
}
