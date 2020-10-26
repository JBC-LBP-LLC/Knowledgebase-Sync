using Newtonsoft.Json;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Contains list of QnAs to be updated
    /// </summary>
    public class UpdateKbOperationDTO
    {
        /// <summary>
        ///     An instance of CreateKbInputDTO for add operation.
        /// </summary>
        [JsonProperty("add")]
        public Add Add { get; set; }

        /// <summary>
        ///     Text string to be used as the answer in any Q-A which 
        ///     has no extracted answer from the document but has a hierarchy. 
        ///     Required when EnableHierarchicalExtraction field is set to True.
        /// </summary>
        [JsonProperty("defaultAnswerUsedForExtraction")]
        public string DefaultAnswerUsedForExtraction { get; set; }

        /// <summary>
        ///     An instance of DeleteKbContentsDTO for delete Operation
        /// </summary>
        [JsonProperty("delete")]
        public Delete Delete { get; set; }

        /// <summary>
        ///     An instance of CreateKbInputDTO for add operation.
        /// </summary>
        [JsonProperty("enableHierarchicalExtraction")]
        public bool EnableHierarchicalExtraction { get; set; }

        /// <summary>
        ///     An instance of UpdateKbContentsDTO for Update Operation
        /// </summary>
        [JsonProperty("update")]
        public Update Update { get; set; }
    }
}
