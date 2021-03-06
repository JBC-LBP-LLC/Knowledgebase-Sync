using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using RPA.KnowledgebaseSync.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using RPA.KnowledgebaseSync.Activities.Utilities;

namespace RPA.KnowledgebaseSync.Activities
{
    [LocalizedDisplayName(nameof(Resources.KnowledgebaseSync_DisplayName))]
    [LocalizedDescription(nameof(Resources.KnowledgebaseSync_Description))]
    public class KnowledgebaseSync : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.KnowledgebaseSync_PortalDT_DisplayName))]
        [LocalizedDescription(nameof(Resources.KnowledgebaseSync_PortalDT_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<DataTable> PortalDT { get; set; }

        [LocalizedDisplayName(nameof(Resources.KnowledgebaseSync_Knowledgebase_DisplayName))]
        [LocalizedDescription(nameof(Resources.KnowledgebaseSync_Knowledgebase_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Knowledgebase { get; set; }

        [LocalizedDisplayName(nameof(Resources.KnowledgebaseSync_KnowledgebaseName_DisplayName))]
        [LocalizedDescription(nameof(Resources.KnowledgebaseSync_KnowledgebaseName_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> KnowledgebaseName { get; set; }

        [LocalizedDisplayName(nameof(Resources.KnowledgebaseSync_UpdateKbJson_DisplayName))]
        [LocalizedDescription(nameof(Resources.KnowledgebaseSync_UpdateKbJson_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<string> UpdateKbJson { get; set; }

        #endregion


        #region Constructors

        public KnowledgebaseSync()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (PortalDT == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(PortalDT)));
            if (Knowledgebase == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Knowledgebase)));
            if (KnowledgebaseName == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(KnowledgebaseName)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var portaldt = PortalDT.Get(context);
            var knowledgebase = Knowledgebase.Get(context);
            var knowledgebasename = KnowledgebaseName.Get(context);

            var JsonObjectUpdateKbOperationDTO = KnowledgebaseUtility.CreateKnowledgebaseUpdate(portaldt, knowledgebase, knowledgebasename);

            // Outputs
            return (ctx) => {
                UpdateKbJson.Set(ctx, JsonObjectUpdateKbOperationDTO);
            };
        }

        #endregion
    }
}

