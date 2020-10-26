using Newtonsoft.Json;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Record to track long running operation.
    /// </summary>
    public class Operation
    {
        /// <summary>
        ///     Timestamp when the operation was created.
        /// </summary>
        [JsonProperty("createdTimestamp")] 
        public string CreatedTimestamp { get; set; }

        /// <summary>
        ///     Error details in case of failures.
        /// </summary>
        [JsonProperty("errorResponse")]
        public ErrorResponse ErrorResponse { get; set; }

        /// <summary>
        ///     Timestamp when the current state was entered.
        /// </summary>
        [JsonProperty("lastActionTimestamp")]
        public string LastActionTimestamp { get; set; }

        /// <summary>
        ///     Operation Id.
        /// </summary>
        [JsonProperty("operationId")]
        public string OperationId { get; set; }

        /// <summary>
        ///     Operation state.
        /// </summary>
        [JsonProperty("operationState")]
        public OperationStateType OperationState { get; set; }

        /// <summary>
        ///     Relative URI to the target resource location for completed resources.
        /// </summary>
        [JsonProperty("resourceLocation")]
        public string ResourceLocation { get; set; }

        /// <summary>
        ///     User Id.
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
