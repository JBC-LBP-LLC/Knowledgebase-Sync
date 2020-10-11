namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     This is a specific QnA Knowledgebase to be merged with a 
    ///     specific Portal database into the KnowledgebaseUpdateDTO.
    ///     
    ///     Example: Portal-905-Db.json and Knowledgebase-905.json into KnowledgebaseUpdateDTO.
    /// </summary>
    public class KnowledgebaseDownloadDTO
    {
        /// <summary>
        ///     Collection of all Q-A in the knowledgebase.
        /// </summary>
        public QnADocumentsDTO QnADocuments { get; set; }
    }
}
