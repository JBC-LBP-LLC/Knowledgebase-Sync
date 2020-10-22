namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     Operation state.
    /// </summary>
    public class OperationStateType
    {
        public string Failed { get; set; }
        public string NotStarted { get; set; }
        public string Running { get; set; }
        public string Succeeded { get; set; }
    }
}
