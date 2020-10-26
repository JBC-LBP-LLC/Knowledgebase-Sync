using Newtonsoft.Json;
using System.Collections.Generic;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     List of QnADTO
    /// </summary>
    public class QnADocumentsDTO
    {
        /// <summary>
        ///     List of QnaDTO.
        /// </summary>
        [JsonProperty("qnaDocuments")]
        public List<QnADTO> QnaDTO { get; set; }
    }
}
