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
            LoadMetadata(qnaDocumentsDTO.QnaDTO, metadataDtoList);
            
            List<QnADTO> qnADTOs = new List<QnADTO>();
            LoadAddQnADTOs(portalDbRecords, qnaDocumentsDTO, qnADTOs);
            
            List<UpdateQnaDTO> updateQnADTOs = new List<UpdateQnaDTO>();
            LoadUpdateQnADTOs(portalDbRecords, qnaDocumentsDTO, updateQnADTOs);
            
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
                metadata.Delete = new List<MetadataDTO>();

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
                                metadata.Delete.Add(metadataDto2);
                            }

                            List<MetadataDTO> metadataDtoList = LoadMetadata(portalDbRecord);

                            foreach (var metadataDto in metadataDtoList)
                            {
                                metadata.Add.Add(metadataDto);
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
                    List<MetadataDTO> metadataDtoList = LoadMetadata(portalDbRecord);

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

        private static List<MetadataDTO> LoadMetadata(PortalDbRecordDTO portalDbRecord)
        {
            List<MetadataDTO> metadataDtoList = new List<MetadataDTO>();

            if (portalDbRecord.FaqCategoryFaqId.ToString() != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "faqcategoryfaqid",
                    Value = portalDbRecord.FaqCategoryFaqId.ToString()
                });
            }

            if (portalDbRecord.FaqId.ToString() != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "faqid",
                    Value = portalDbRecord.FaqId.ToString()
                });
            }

            if (portalDbRecord.FaqSortOrder.ToString() != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO
                {
                    Name = "faqsortorder",
                    Value = portalDbRecord.FaqSortOrder.ToString()
                });
            }

            if (portalDbRecord.FaqCategoryId.ToString() != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "faqcategoryid",
                    Value = portalDbRecord.FaqCategoryId.ToString()
                });
            }

            if (portalDbRecord.CategoryTitle != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "categorytitle",
                    Value = portalDbRecord.CategoryTitle.Replace(":", "").Replace("|", "")
                });
            }

            if (portalDbRecord.CategoryDescription != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "categorydescription",
                    Value = portalDbRecord.CategoryDescription.Replace(":", "").Replace("|", "")
                });
            }

            if (portalDbRecord.CategorySortOrder.ToString() != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "categorysortorder",
                    Value = portalDbRecord.CategorySortOrder.ToString()
                });
            }

            if (portalDbRecord.RoleIds != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "roleids",
                    Value = portalDbRecord.RoleIds.Replace(":", "").Replace("|", "")
                });
            }

            if (portalDbRecord.DenyRoleIds != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "denyroleids",
                    Value = portalDbRecord.DenyRoleIds.Replace(":", "").Replace("|", "")
                });
            }

            if (portalDbRecord.IsCommonlyAsked.ToString() != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "iscommonlyasked",
                    Value = portalDbRecord.IsCommonlyAsked.ToString()
                });
            }

            if (portalDbRecord.ContentGroupIds != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "contentgroupids",
                    Value = portalDbRecord.ContentGroupIds.Replace(":", "").Replace("|", "")
                });
            }

            if (portalDbRecord.PortalId.ToString() != string.Empty)
            {
                metadataDtoList.Add(new MetadataDTO()
                {
                    Name = "portalid",
                    Value = portalDbRecord.PortalId.ToString()
                });
            }

            return metadataDtoList;
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