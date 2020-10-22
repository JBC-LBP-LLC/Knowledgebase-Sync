namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     One of a server-defined set of error codes.
    /// </summary>
    public class ErrorCodeType
    {
        public string BadArgument { get; set; }
        public string EndpointKeysError { get; set; }
        public string ExtractionFailure { get; set; }
        public string Forbidden { get; set; }
        public string KbNotFound { get; set; }
        public string NotFound { get; set; }
        public string OperationNotFound { get; set; }
        public string QnaRuntimeError { get; set; }
        public string QuotaExceeded { get; set; }
        public string SKULimitExceeded { get; set; }
        public string ServiceError { get; set; }
        public string Unauthorized { get; set; }
        public string Unspecified { get; set; }
        public string ValidationFailure { get; set; }
    }
}
