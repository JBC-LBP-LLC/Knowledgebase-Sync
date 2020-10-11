namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Context of a QnA, not to be confused with an EntityFramework Context.
    /// </summary>
    public class Context
    {
        /// <summary>
        ///     To mark if a prompt is relevant only with a previous question or not. 
        ///         true - Do not include this QnA as search result for queries without context 
        ///         false - ignores context and includes this QnA in search result
        /// </summary>
        public bool IsContextOnly { get; set; }

        /// <summary>
        ///     List of prompts associated with the answer.
        /// </summary>
        public PromptDTO[] Prompts { get; set; }
    }
}
