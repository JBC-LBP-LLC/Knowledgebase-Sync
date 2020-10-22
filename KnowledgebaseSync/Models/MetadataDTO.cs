using Newtonsoft.Json;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Name - value pair of metadata.
    /// </summary>
    public class MetadataDTO
    {
        /// <summary>
        ///     Name of the metadata item. Example: "categorytitle".
        /// </summary>
        [JsonProperty("name")] 
        public string Name { get; set; }

        /// <summary>
        ///     Value of the metadata item. Example: "401(k)".
        /// </summary>
        [JsonProperty("value")] 
        public string Value { get; set; }
    }
}
