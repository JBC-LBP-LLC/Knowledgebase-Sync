using Newtonsoft.Json;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     An object containing more specific information about the error. 
    ///     As per Microsoft One API guidelines - 
    ///         https://github.com/Microsoft/api-guidelines/blob/vNext/Guidelines.md#7102-error-condition-responses.
    /// </summary>
    public class InnerErrorModel
    {
        /// <summary>
        ///     A more specific error code than was provided by the containing error.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        ///     An object containing more specific information than the current object about the error.
        /// </summary>
        [JsonProperty("innerError")]
        public InnerErrorModel InnerError { get; set; }
    }
}
