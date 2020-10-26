using Newtonsoft.Json;
using System.Collections.Generic;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     List of questions associated with the answer.
    /// </summary>
    public class Questions
    {
        /// <summary>
        ///     List of questions to be added.
        /// </summary>
        [JsonProperty("add")]
        public List<string> Add { get; set; }

        /// <summary>
        ///     List of questions to be deleted.
        /// </summary>
        [JsonProperty("delete")]
        public List<string> Delete { get; set; }
    }
}
