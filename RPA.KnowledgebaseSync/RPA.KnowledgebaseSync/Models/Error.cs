using Newtonsoft.Json;
using System.Collections.Generic;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     The error object. 
    ///     As per Microsoft One API guidelines - 
    ///         https://github.com/Microsoft/api-guidelines/blob/vNext/Guidelines.md#7102-error-condition-responses.
    /// </summary>
    public class Error
    {
        /// <summary>
        ///     One of a server-defined set of error codes..
        /// </summary>
        [JsonProperty("code")]
        public ErrorCodeType code { get; set; }

        /// <summary>
        ///     An array of details about specific errors that led to this reported error.
        /// </summary>
        [JsonProperty("details")]
        public List<Error> Details { get; set; }

        /// <summary>
        ///     An object containing more specific information than the current object about the error.
        /// </summary>
        [JsonProperty("innerError")]
        public InnerErrorModel InnerError { get; set; }

        /// <summary>
        ///     A human-readable representation of the error.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        ///     The target of the error.
        /// </summary>
        [JsonProperty("target")]
        public string Target { get; set; }
    }
}
