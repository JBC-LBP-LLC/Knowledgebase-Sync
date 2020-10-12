using Newtonsoft.Json;
using System.Collections.Generic;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Context of a QnA, not to be confused with an EntityFramework Context.
    /// </summary>
    public class ContextDTO
    {
        /// <summary>
        ///     To mark if a prompt is relevant only with a previous question or not. 
        ///         true - Do not include this QnA as search result for queries without context 
        ///         false - ignores context and includes this QnA in search result
        /// </summary>
        [JsonProperty("isContextOnly")] 
        public bool IsContextOnly { get; set; }

        /// <summary>
        ///     List of prompts associated with the answer.
        /// </summary>
        [JsonProperty("prompts")] 
        public List<PromptDTO> Prompts { get; set; }
    }
}
