using Newtonsoft.Json;
using System.Collections.Generic;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Q-A object.
    /// </summary>
    public class QnADTO
    {
        /// <summary>
        ///     Answer text.
        /// </summary>
        [JsonProperty("answer")] 
        public string Answer { get; set; }

        /// <summary>
        ///     Context of a QnA.
        /// </summary>
        [JsonProperty("context")] 
        public Context Context { get; set; }

        /// <summary>
        ///     Unique id for the Q-A.
        /// </summary>
        [JsonProperty("id")] 
        public int Id { get; set; }

        /// <summary>
        ///     List of metadata associated with the answer.
        /// </summary>
        [JsonProperty("metadata")] 
        public List<MetadataDTO> Metadata { get; set; }

        /// <summary>
        ///     List of questions associated with the answer.
        /// </summary>
        [JsonProperty("questions")] 
        public List<string> Questions { get; set; }

        /// <summary>
        ///     Source from which Q-A was indexed. eg. https://docs.microsoft.com/en-us/azure/cognitive-services/QnAMaker/FAQs
        /// </summary>
        [JsonProperty("source")] 
        public string Source { get; set; }
    }
}
