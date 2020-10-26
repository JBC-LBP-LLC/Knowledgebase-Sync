using Newtonsoft.Json;
using System.Collections.Generic;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     List of metadata associated with the answer to be updated.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        ///     List of metadata associated with answer to be added.
        /// </summary>
        [JsonProperty("add")]
        public List<MetadataDTO> Add { get; set; }

        /// <summary>
        ///     List of Metadata associated with answer to be deleted.
        /// </summary>
        [JsonProperty("delete")]
        public List<MetadataDTO> Delete { get; set; }
    }
}
