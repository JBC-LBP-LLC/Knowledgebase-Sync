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
        public string Answer { get; set; }

        /// <summary>
        ///     Context of a QnA.
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        ///     Unique id for the Q-A.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     List of metadata associated with the answer.
        /// </summary>
        public MetadataDTO[] Metadata { get; set; }

        /// <summary>
        ///     List of questions associated with the answer.
        /// </summary>
        public string[] Questions { get; set; }

        /// <summary>
        ///     Source from which Q-A was indexed. eg. https://docs.microsoft.com/en-us/azure/cognitive-services/QnAMaker/FAQs
        /// </summary>
        public string Source { get; set; }
    }
}
