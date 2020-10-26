using Newtonsoft.Json;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     PATCH Body schema for Update Qna List
    /// </summary>
    public class UpdateQnaDTO
    {
        /// <summary>
        ///     Answer text
        /// </summary>
        [JsonProperty("answer")]
        public string Answer { get; set; }

        /// <summary>
        ///     Context associated with Qna to be updated.
        /// </summary>
        [JsonProperty("context")]
        public Context Context { get; set; }

        /// <summary>
        ///     Unique id for the Q-A
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     List of metadata associated with the answer to be updated
        /// </summary>
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        /// <summary>
        ///     List of questions associated with the answer.
        /// </summary>
        [JsonProperty("questions")]
        public Questions Questions { get; set; }

        /// <summary>
        ///     Source from which Q-A was indexed. eg. https://docs.microsoft.com/en-us/azure/cognitive-services/QnAMaker/FAQs
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
