using Newtonsoft.Json;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Name - value pair of metadata.
    /// </summary>
    public class MetadataDTO
    {
        /// <summary>
        ///     Id of the parent record of the metadata record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Name of the metadata item. Example: "categorytitle"
        /// </summary>
        [JsonProperty("name")] 
        public string Name { get; set; }

        /// <summary>
        ///     Value of the metadata item. Example: "401(k)"
        /// </summary>
        [JsonProperty("value")] 
        public string Value { get; set; }
    }
}
