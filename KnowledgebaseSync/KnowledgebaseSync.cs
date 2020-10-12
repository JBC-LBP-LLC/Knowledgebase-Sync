using KnowledgebaseSync.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgebaseSync
{
    public static class KnowledgebaseSync
    {
        public static string CreateKnowledgebaseUpdate(string portalDb, string knowledgebase)
        {
            IEnumerable<PortalDbRecordDTO> portalDbRecords = JsonConvert.DeserializeObject<IEnumerable<PortalDbRecordDTO>>(portalDb);
            QnADocumentsDTO qnaDocumentsDTO = JsonConvert.DeserializeObject<QnADocumentsDTO>(knowledgebase);

            List<QnADTO> qnaDTOs = new List<QnADTO>();
            LoadQnaDocuments(qnaDocumentsDTO, qnaDTOs);

            List<PortalDbRecordDTO> portalDbRecordsDTO = new List<PortalDbRecordDTO>();
            LoadPortalDbRecords(portalDbRecords, portalDbRecordsDTO);

            List<MetadataDTO> metadataDTO = new List<MetadataDTO>();
            LoadMetadata(qnaDTOs, metadataDTO);

            KnowledgebaseUpdateDTO knowledgebaseUpdateDTO = new KnowledgebaseUpdateDTO();
            LoadKbUpdate(portalDbRecordsDTO, metadataDTO, knowledgebaseUpdateDTO);

            var knowledgebaseUpdateObject = JsonConvert.SerializeObject(knowledgebaseUpdateDTO);

            return knowledgebaseUpdateObject;
        }

        private static void LoadKbUpdate(List<PortalDbRecordDTO> portalDbRecordsDTO, List<MetadataDTO> metadataDTO, KnowledgebaseUpdateDTO knowledgebaseUpdateDTO)
        {
            foreach (var metadataItem in metadataDTO)
            {
                if (metadataItem.Name == "faqid")
                {
                    foreach (var dbRecord in portalDbRecordsDTO)
                    {
                        if (metadataItem.Value == dbRecord.FaqId.ToString())
                        {
                            string answer = dbRecord.FaqAnswer;
                            ContextDTO contextDTO = new ContextDTO();
                            //contextDTO.IsContextOnly = doc
                            //Upd
                            //knowledgebaseUpdateDTO.update.name = $"QA-bcnocg-{dbRecord.PortalId}";
                            //knowledgebaseUpdateDTO.update.qnaList = ;
                        }
                    }
                }
            }
        }

        private static void LoadMetadata(List<QnADTO> qnaDTOs, List<MetadataDTO> metadataDTO)
        {
            var metadataArray = qnaDTOs.ToArray();

            foreach (var metadata in metadataArray)
            {
                var metadataFields = metadata.Metadata.ToArray();

                for (int i = 0; i < metadataFields.Length; i++)
                {
                    MetadataDTO metadataRecord = new MetadataDTO
                    {
                        Name = metadataFields[i].Name,
                        Value = metadataFields[i].Value
                    };

                    metadataDTO.Add(metadataRecord);
                }
            }
        }

        private static void LoadQnaDocuments(QnADocumentsDTO qnaDocumentsDTO, List<QnADTO> qnaDTOs)
        {
            foreach (var document in qnaDocumentsDTO.QnaDTO)
            {
                QnADTO qnaDTO = new QnADTO
                {
                    Answer = document.Answer,
                    Context = document.Context,
                    Id = document.Id,
                    Metadata = document.Metadata,
                    Questions = document.Questions,
                    Source = document.Source
                };

                qnaDTOs.Add(qnaDTO);
            }
        }

        private static void LoadPortalDbRecords(IEnumerable<PortalDbRecordDTO> portalDbRecords, List<PortalDbRecordDTO> portalDbRecordsDTO)
        {
            foreach (var record in portalDbRecords)
            {
                PortalDbRecordDTO portalDbRecord = new PortalDbRecordDTO
                {
                    CategoryDescription = record.CategoryDescription,
                    CategorySortOrder = record.CategorySortOrder,
                    CategoryTitle = record.CategoryTitle,
                    ContentGroupIds = record.ContentGroupIds,
                    DenyRoleIds = record.DenyRoleIds,
                    FaqAnswer = record.FaqAnswer,
                    FaqCategoryFaqId = record.FaqCategoryFaqId,
                    FaqCategoryId = record.FaqCategoryId,
                    FaqDescription = record.FaqDescription,
                    FaqId = record.FaqId,
                    FaqQuestion = record.FaqQuestion,
                    FaqSortOrder = record.FaqSortOrder,
                    IsCommonlyAsked = record.IsCommonlyAsked,
                    PortalId = record.PortalId,
                    RoleIds = record.RoleIds
                };

                portalDbRecordsDTO.Add(portalDbRecord);
            }
        }
    }
}
