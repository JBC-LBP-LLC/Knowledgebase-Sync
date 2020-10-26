using Newtonsoft.Json;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     DTO to hold details of uploaded files.
    /// </summary>
    public class FileDTO
    {
        /// <summary>
        ///     File name. Supported file types are ".tsv", ".pdf", ".txt", ".docx", ".xlsx".
        /// </summary>
        [JsonProperty("fileName")]
        public string FileName { get; set; }

        /// <summary>
        ///     Public URI of the file.
        /// </summary>
        [JsonProperty("fileUri")]
        public string FileUri { get; set; }
    }
}
