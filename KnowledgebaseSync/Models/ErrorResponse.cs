namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Error response. 
    ///     As per Microsoft One API guidelines - 
    ///         https://github.com/Microsoft/api-guidelines/blob/vNext/Guidelines.md#7102-error-condition-responses.
    /// </summary>
    public class ErrorResponse
    {
        public string error { get; set; }
    }
}
