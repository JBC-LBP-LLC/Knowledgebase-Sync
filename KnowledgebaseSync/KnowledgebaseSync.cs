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
            LoadKbUpdate(qnaDocumentsDTO, portalDbRecordsDTO, metadataDTO, knowledgebaseUpdateDTO);

            var knowledgebaseUpdateObject = JsonConvert.SerializeObject(knowledgebaseUpdateDTO);

            return knowledgebaseUpdateObject;
        }

        private static void LoadKbUpdate(QnADocumentsDTO qnaDocumentsDTO, List<PortalDbRecordDTO> portalDbRecordsDTO, List<MetadataDTO> metadataDTO, KnowledgebaseUpdateDTO knowledgebaseUpdateDTO)
        {
            var currentKbDocumentsFaqIds = from m in metadataDTO
                                   where m.Name == "faqid"
                                   select new
                                   {
                                       KbId = m.Id,
                                       FaqId = m.Value
                                   };

            var updateQuestions = from p in portalDbRecordsDTO
                                  join m in metadataDTO
                                  on p.FaqId.ToString() equals m.Value
                                  join q in qnaDocumentsDTO.QnaDTO
                                  on m.Id equals q.Id
                                  select p.FaqQuestion;

            var updateAnswers = from p in portalDbRecordsDTO
                                join m in metadataDTO
                                on p.FaqId.ToString() equals m.Value
                                join q in qnaDocumentsDTO.QnaDTO
                                on m.Id equals q.Id
                                select p.FaqAnswer;

            var updateUrls = from p in portalDbRecordsDTO
                             join m in metadataDTO
                             on m.Id equals q.Id
                             select m.

            var wow = true;
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
                        Id = metadata.Id,
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
