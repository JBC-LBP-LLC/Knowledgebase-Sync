using System.ComponentModel.DataAnnotations;

namespace KnowledgebaseSync.Models
{
    /// <summary>
    ///     A record from the Portal database to be merged with the 
    ///     KnowledgebaseDownloadDTO into the KnowledgebaseUpdate.
    /// </summary>
    public class PortalDbRecordDTO
    {
        [Key]
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

        public override string ToString()
        {
            return $"FaqCategoryFaqId [{FaqCategoryFaqId}]\n\r" +
                   $"FaqId [{FaqId}]\n\r" +
                   $"FaqQuestion [{FaqQuestion}]\n\r" +
                   $"FaqAnswer [{FaqAnswer}]\n\r" +
                   $"FaqDescription [{FaqDescription}]\n\r" +
                   $"FaqSortOrder [{FaqSortOrder}]\n\r" +
                   $"FaqCategoryId [{FaqCategoryId}]\n\r" +
                   $"CategoryTitle [{CategoryTitle}]\n\r" +
                   $"CategoryDescription [{CategoryDescription}]\n\r" +
                   $"CategorySortOrder [{CategorySortOrder}]\n\r" +
                   $"RoleIds [{RoleIds}]\n\r" +
                   $"DenyRoleIds [{DenyRoleIds}]\n\r" +
                   $"IsCommonlyAsked [{IsCommonlyAsked}]\n\r" +
                   $"ContentGroupIds [{ContentGroupIds}]\n\r" +
                   $"PortalId [{PortalId}]\n\r";
        }
    }
}
