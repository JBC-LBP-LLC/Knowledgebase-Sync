namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     A record from the Portal database to be merged with the 
    ///     KnowledgebaseDownloadDTO into the KnowledgebaseUpdateDTO.
    /// </summary>
    public class PortalDbRecordDTO
    {
        public int FaqCategoryFaqId { get; set; }
        public int FaqId { get; set; }
        public string FaqQuestion { get; set; }
        public string FaqAnswer { get; set; }
        public string FaqDescription { get; set; }
        public int FaqSortOrder { get; set; }
        public int FaqCategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDescription { get; set; }
        public int CategorySortOrder { get; set; }
        public string RoleIds { get; set; }
        public string DenyRoleIds { get; set; }
        public bool IsCommonlyAsked { get; set; }
        public string ContentGroupIds { get; set; }
        public int PortalId { get; set; }
    }
}
