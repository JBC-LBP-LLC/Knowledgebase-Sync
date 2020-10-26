using Newtonsoft.Json;
using System.Collections.Generic;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     An instance of DeleteKbContentsDTO for delete Operation
    /// </summary>
    public class Delete
    {
        /// <summary>
        ///     List of Qna Ids to be deleted.
        /// </summary>
        [JsonProperty("ids")]
        public List<int> Ids { get; set; }

        /// <summary>
        ///     List of sources to be deleted from knowledgebase.
        /// </summary>
        [JsonProperty("sources")]
        public List<string> Sources { get; set; }
    }
}
