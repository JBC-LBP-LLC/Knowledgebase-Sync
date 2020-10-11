using KnowledgebaseSync.Models;
using Newtonsoft.Json;

namespace KnowledgebaseSync
{
    public class KnowledgebaseSync
    {
        private PortalDbRecords _portalDb;
        private KnowledgebaseDownloadDTO _knowledgebase;
        private string _knowledgebaseUpdate;

        public KnowledgebaseSync(string portalDb, string knowledgebase)
        {
            _portalDb = JsonConvert.DeserializeObject<PortalDbRecords>(portalDb);
            _knowledgebase = JsonConvert.DeserializeObject<KnowledgebaseDownloadDTO>(knowledgebase);
        }

        public string CreateKnowledgebaseUpdate()
        {


            return _knowledgebaseUpdate;
        }
    }
}
