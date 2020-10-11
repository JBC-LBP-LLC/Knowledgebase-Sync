namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Prompt for an answer.
    /// </summary>
    public class PromptDTO
    {
        /// <summary>
        ///     Index of the prompt - used in ordering of the prompts
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        ///     Text displayed to represent a follow up question prompt.
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        ///     QnADTO - Either QnaId or QnADTO needs to be present in a PromptDTO object.
        /// </summary>
        public QnADTO Qna { get; set; }

        /// <summary>
        ///     Qna id corresponding to the prompt - if QnaId is present, QnADTO object is ignored.
        /// </summary>
        public int QnaId { get; set; }
    }
}
