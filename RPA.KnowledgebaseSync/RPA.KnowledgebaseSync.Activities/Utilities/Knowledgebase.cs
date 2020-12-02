using KnowledgebaseSync.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RPA.KnowledgebaseSync.Activities.Utilities
{
    public static class KnowledgebaseUtility
    {
        public static string CreateKnowledgebaseUpdate(
          DataTable portal,
          string knowledgebase,
          string knowledgebaseName)
        {
            IEnumerable<PortalDbRecordDTO> portalDbRecords = (IEnumerable<PortalDbRecordDTO>)JsonConvert.DeserializeObject<IEnumerable<PortalDbRecordDTO>>(JsonConvert.SerializeObject((object)portal));
            QnADocumentsDTO qnaDocumentsDTO = (QnADocumentsDTO)JsonConvert.DeserializeObject<QnADocumentsDTO>(knowledgebase);
            new List<FileDTO>()
            {
                new FileDTO()
                {
                    FileName = (string) null,
                    FileUri = (string) null
                }
            };

            List<MetadataDTO> metadataDtoList = new List<MetadataDTO>();
            KnowledgebaseUtility.LoadMetadata(qnaDocumentsDTO.QnaDTO, metadataDtoList);
            List<QnADTO> qnADTOs = new List<QnADTO>();
            KnowledgebaseUtility.LoadAddQnADTOs(portalDbRecords, qnaDocumentsDTO, qnADTOs);
            List<UpdateQnaDTO> updateQnADTOs = new List<UpdateQnaDTO>();
            KnowledgebaseUtility.LoadUpdateQnADTOs(portalDbRecords, qnaDocumentsDTO, updateQnADTOs);
            IEnumerable<MetadataDTO> metadataDtos = metadataDtoList.Where<MetadataDTO>((Func<MetadataDTO, bool>)(m => m.Name == "faqid")).Where<MetadataDTO>((Func<MetadataDTO, bool>)(m => !portalDbRecords.Any<PortalDbRecordDTO>((Func<PortalDbRecordDTO, bool>)(p => p.FaqId.ToString() == m.Value))));
            List<int> intList = new List<int>();
            
            foreach (MetadataDTO metadataDto in metadataDtos)
            {
                foreach (QnADTO qnAdto in qnaDocumentsDTO.QnaDTO)
                {
                    IEnumerable<string> source = qnAdto.Metadata.Where<MetadataDTO>((Func<MetadataDTO, bool>)(m => m.Name.ToLower() == "faqid")).Select<MetadataDTO, string>((Func<MetadataDTO, string>)(m => m.Value));
                    if (source.FirstOrDefault<string>() != null && source.FirstOrDefault<string>() == metadataDto.Value)
                        intList.Add(qnAdto.Id);
                }
            }

            Add add = new Add()
            {
                Files = (List<FileDTO>)null,
                QnaList = qnADTOs,
                Urls = new List<string>()
            };

            Update update = new Update()
            {
                Name = knowledgebaseName,
                QnaList = updateQnADTOs,
                Urls = new List<string>()
            };

            Delete delete = new Delete()
            {
                Ids = intList,
                Sources = new List<string>()
            };

            return JsonConvert.SerializeObject((object)new UpdateKbOperationDTO()
            {
                Add = add,
                DefaultAnswerUsedForExtraction = "",
                Delete = delete,
                EnableHierarchicalExtraction = false,
                Update = update
            });
        }

        private static void LoadUpdateQnADTOs(
          IEnumerable<PortalDbRecordDTO> portalDbRecords,
          QnADocumentsDTO qnaDocumentsDTO,
          List<UpdateQnaDTO> updateQnADTOs)
        {
            foreach (PortalDbRecordDTO portalDbRecord in portalDbRecords)
            {
                Questions questions = new Questions();
                questions.Add = new List<string>();
                Metadata metadata = new Metadata();
                metadata.Add = new List<MetadataDTO>();
                
                foreach (QnADTO qnAdto in qnaDocumentsDTO.QnaDTO)
                {
                    IEnumerable<string> source = qnAdto.Metadata.Where<MetadataDTO>((Func<MetadataDTO, bool>)(m => m.Name.ToLower() == "faqid")).Select<MetadataDTO, string>((Func<MetadataDTO, string>)(m => m.Value));
                    
                    if (source.FirstOrDefault<string>() != null)
                    {
                        string str = source.FirstOrDefault<string>().ToString();
                        
                        if (portalDbRecord.FaqId.ToString() == str)
                        {
                            questions.Add.Add(portalDbRecord.FaqQuestion);
                            
                            foreach (MetadataDTO metadataDto1 in qnAdto.Metadata)
                            {
                                MetadataDTO metadataDto2 = new MetadataDTO()
                                {
                                    Name = metadataDto1.Name,
                                    Value = metadataDto1.Value
                                };
                                metadata.Add.Add(metadataDto2);
                            }
                            
                            UpdateQnaDTO updateQnaDto = new UpdateQnaDTO()
                            {
                                Answer = portalDbRecord.FaqAnswer,
                                Context = qnAdto.Context,
                                Id = qnAdto.Id,
                                Metadata = metadata,
                                Questions = questions,
                                Source = qnAdto.Source
                            };
                            
                            updateQnADTOs.Add(updateQnaDto);
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
            foreach (PortalDbRecordDTO portalDbRecord in portalDbRecords)
            {
                bool flag = false;
                string str = "";
                List<string> source = new List<string>();
                
                foreach (QnADTO qnAdto in qnaDocumentsDTO.QnaDTO)
                {
                    foreach (MetadataDTO metadataDto in qnAdto.Metadata)
                    {
                        if (metadataDto.Name == "faqid")
                            str = metadataDto.Value;
                    }
                    
                    if (str == portalDbRecord.FaqId.ToString())
                        flag = true;
                }
                
                if (!flag)
                {
                    List<MetadataDTO> metadataDtoList = new List<MetadataDTO>();
                    metadataDtoList.Add(new MetadataDTO()
                    {
                        Name = "faqcategoryid",
                        Value = portalDbRecord.FaqCategoryFaqId.ToString()
                    });
                    
                    MetadataDTO metadataDto1 = new MetadataDTO();
                    metadataDto1.Name = "sortOrder";
                    
                    int num = portalDbRecord.FaqSortOrder;
                    metadataDto1.Value = num.ToString();

                    MetadataDTO metadataDto2 = metadataDto1;
                    metadataDtoList.Add(metadataDto2);

                    MetadataDTO metadataDto3 = new MetadataDTO();
                    metadataDto3.Name = "faqid";

                    num = portalDbRecord.FaqId;
                    metadataDto3.Value = num.ToString();

                    MetadataDTO metadataDto4 = metadataDto3;
                    metadataDtoList.Add(metadataDto4);

                    MetadataDTO metadataDto5 = new MetadataDTO();
                    metadataDto5.Name = "portalid";

                    num = portalDbRecord.PortalId;
                    metadataDto5.Value = num.ToString();

                    MetadataDTO metadataDto6 = metadataDto5;
                    metadataDtoList.Add(metadataDto6);
                    
                    MetadataDTO metadataDto7 = new MetadataDTO()
                    {
                        Name = "iscommonlyasked",
                        Value = portalDbRecord.IsCommonlyAsked.ToString()
                    };
                    
                    metadataDtoList.Add(metadataDto7);
                    source.Add(portalDbRecord.FaqQuestion);
                    
                    QnADTO qnAdto = new QnADTO()
                    {
                        Answer = portalDbRecord.FaqAnswer,
                        Metadata = metadataDtoList,
                        Questions = source.ToList<string>(),
                        Source = "FAQ"
                    };
                    
                    qnADTOs.Add(qnAdto);
                }
            }
        }

        private static void LoadMetadata(List<QnADTO> qnADTOs, List<MetadataDTO> metadataDTOs)
        {
            foreach (QnADTO qnAdto in qnADTOs.ToArray())
            {
                MetadataDTO[] array = qnAdto.Metadata.ToArray();
                
                for (int index = 0; index < array.Length; ++index)
                {
                    MetadataDTO metadataDto = new MetadataDTO()
                    {
                        Name = array[index].Name,
                        Value = array[index].Value
                    };
                    
                    metadataDTOs.Add(metadataDto);
                }
            }
        }
    }
}