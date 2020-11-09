using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using RPA.KnowledgebaseSync.Activities.Design.Designers;
using RPA.KnowledgebaseSync.Activities.Design.Properties;

namespace RPA.KnowledgebaseSync.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");
            builder.AddCustomAttributes(typeof(KnowledgebaseSync), categoryAttribute);
            builder.AddCustomAttributes(typeof(KnowledgebaseSync), new DesignerAttribute(typeof(SyncKnowledgebaseDesigner)));
            builder.AddCustomAttributes(typeof(KnowledgebaseSync), new HelpKeywordAttribute(""));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
