using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using RPA.KnowledgebaseSync.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace RPA.KnowledgebaseSync.Activities
{
    [LocalizedDisplayName(nameof(Resources.SyncKnowledgebase_DisplayName))]
    [LocalizedDescription(nameof(Resources.SyncKnowledgebase_Description))]
    public class SyncKnowledgebase : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.SyncKnowledgebase_PortalID_DisplayName))]
        [LocalizedDescription(nameof(Resources.SyncKnowledgebase_PortalID_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<int> PortalID { get; set; }

        #endregion


        #region Constructors

        public SyncKnowledgebase()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (PortalID == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(PortalID)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var portalid = PortalID.Get(context);

            ///////////////////////////
            // Add execution logic HERE
            ///////////////////////////
            var portalDb = System.IO.File.ReadAllText(@"C:\Dev\WTW\RPA-Knowledgebase\Knowledgebase-Sync\Documents\Portal-905-Db.json");
            var kbDownload = System.IO.File.ReadAllText(@"C:\Dev\WTW\RPA-Knowledgebase\Knowledgebase-Sync\Documents\Knowledgebase-905.json");
            //string kbUpdate = CreateKnowledgebaseUpdate(portalDb, kbDownload);

            //Console.WriteLine(kbUpdate);
            Console.ReadLine();
            Console.WriteLine();

            // Outputs
            return (ctx) => {
            };
        }

        #endregion
    }
}

