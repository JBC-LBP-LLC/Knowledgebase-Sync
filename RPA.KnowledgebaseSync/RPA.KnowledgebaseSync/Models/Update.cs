using Newtonsoft.Json;
using System.Collections.Generic;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     An instance of UpdateKbContentsDTO for Update Operation
    /// </summary>
    public class Update
    {
        /// <summary>
        ///     Friendly name for the knowledgebase. Example: "QA-bcnocg-905"
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     List of Q-A (UpdateQnaDTO) to be added to the knowledgebase.
        /// </summary>
        [JsonProperty("qnaList")]
        public List<UpdateQnaDTO> QnaList { get; set; }

        /// <summary>
        ///     List of existing URLs to be refreshed. The content will be extracted again and re-indexed.
        /// </summary>
        [JsonProperty("urls")]
        public List<string> Urls { get; set; }
    }
}
