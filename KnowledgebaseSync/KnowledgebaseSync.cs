using KnowledgebaseSync.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgebaseSync
{
    public class KnowledgebaseSync
    {
        public string CreateKnowledgebaseUpdate(string portalDb, string knowledgebase)
        {
            IEnumerable<PortalDbRecordDTO> portalDbRecords = JsonConvert.DeserializeObject<IEnumerable<PortalDbRecordDTO>>(portalDb);
            QnADocumentsDTO qnaDocumentsDTO = JsonConvert.DeserializeObject<QnADocumentsDTO>(knowledgebase);

            FileDTO fileDTO = new FileDTO
            {
                FileName = "",
                FileUri = ""
            };

            List<FileDTO> fileDTOs = new List<FileDTO>
            {
                fileDTO
            };

            List<MetadataDTO> metadataDTOs = new List<MetadataDTO>();
            LoadMetadata(qnaDocumentsDTO.QnaDTO, metadataDTOs);

            List<QnADTO> addQnADTOs = new List<QnADTO>();
            LoadAddQnADTOs(portalDbRecords, qnaDocumentsDTO, addQnADTOs);

            List<UpdateQnaDTO> updateQnaDTOs = new List<UpdateQnaDTO>();
            LoadUpdateQnADTOs(portalDbRecords, qnaDocumentsDTO, updateQnaDTOs);

            var metadatafaqIds = metadataDTOs.Where(m => m.Name == "faqid");
            var deletes = metadatafaqIds.Where(m => !portalDbRecords.Any(p => p.FaqId.ToString() == m.Value));

            Add add = new Add
            {
                Files = fileDTOs,
                QnaList = addQnADTOs,
                Urls = new List<string>()
            };

            Update update = new Update
            {
                Name = "Troy",
                QnaList = updateQnaDTOs,
                Urls = new List<string>()
            };

            Delete delete = new Delete
            {
                Ids = deletes.Select(d => int.Parse(d.Value)).ToList(),
                Sources = new List<string>()
            };

            UpdateKbOperationDTO updateKbOperationDTO = new UpdateKbOperationDTO
            {
                Add = add,
                DefaultAnswerUsedForExtraction = "",
                Delete = delete,
                EnableHierarchicalExtraction = false,
                Update = update
            };

            string JsonObjectUpdateKbOperationDTO = JsonConvert.SerializeObject(updateKbOperationDTO);
            return JsonObjectUpdateKbOperationDTO;
        }

        private static void LoadUpdateQnADTOs(
            IEnumerable<PortalDbRecordDTO> portalDbRecords,
            QnADocumentsDTO qnaDocumentsDTO,
            List<UpdateQnaDTO> updateQnADTOs)
        {
            foreach (var portalDbRecord in portalDbRecords)
            {
                Questions questions = new Questions();
                questions.Add = new List<string>();
                Metadata metadata = new Metadata();
                metadata.Add = new List<MetadataDTO>();

                foreach (var qnaDTO in qnaDocumentsDTO.QnaDTO)
                {
                    var metadataFaqId = from m in qnaDTO.Metadata
                                        where m.Name == "faqid"
                                        select m.Value;

                    if (metadataFaqId.FirstOrDefault() != null)
                    {
                        string faqid = metadataFaqId.FirstOrDefault().ToString();

                        if (portalDbRecord.FaqId.ToString() == faqid)
                        {
                            questions.Add.Add(portalDbRecord.FaqQuestion);

                            foreach (var item in qnaDTO.Metadata)
                            {
                                MetadataDTO metadataDTO = new MetadataDTO
                                {
                                    Name = item.Name,
                                    Value = item.Value
                                };

                                metadata.Add.Add(metadataDTO);
                            }

                            UpdateQnaDTO updateQnaDTO = new UpdateQnaDTO
                            {
                                Answer = portalDbRecord.FaqAnswer,
                                Context = qnaDTO.Context,
                                Id = qnaDTO.Id,
                                Metadata = metadata,
                                Questions = questions,
                                Source = qnaDTO.Source
                            };

                            updateQnADTOs.Add(updateQnaDTO);
                        }
                    }
                }
            }
        }

        private static void LoadAddQnADTOs(
            IEnumerable<PortalDbRecordDTO> portalDbRecords,
            QnADocumentsDTO qnaDocumentsDTO,
            List<QnADTO> qnADTOs)
        {
            foreach (var portalDbRecord in portalDbRecords)
            {
                List<string> questions = new List<string>();
                foreach (var qnaDTO in qnaDocumentsDTO.QnaDTO)
                {
                    var metadata = from m in qnaDTO.Metadata
                                   where m.Name == "faqid"
                                   select m.Value;

                    if (metadata.FirstOrDefault() == null)
                    {
                        questions.Add(portalDbRecord.FaqQuestion);
                        QnADTO qnADTO = new QnADTO
                        {
                            Answer = portalDbRecord.FaqAnswer,
                            Context = null,
                            Id = portalDbRecord.FaqId,
                            Metadata = null,
                            Questions = questions.ToList(),
                            Source = null
                        };

                        qnADTOs.Add(qnADTO);
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
                };
            };
        }
    }
}
