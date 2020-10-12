using System.Collections.Generic;

namespace KnowledgebaseSync.Models
{
    public class KnowledgebaseUpdateDTO
    {
        public Add add { get; set; }
        public Delete delete { get; set; }
        public Update update { get; set; }
    }

    public class QnaList
    {
        public int id { get; set; }
        public string answer { get; set; }
        public string source { get; set; }
        public List<string> questions { get; set; }
        public List<object> metadata { get; set; }
    }

    public class File
    {
        public string fileName { get; set; }
        public string fileUri { get; set; }
    }

    public class Add
    {
        public List<QnaList> qnaList { get; set; }
        public List<string> urls { get; set; }
        public List<File> files { get; set; }
    }

    public class Delete
    {
        public List<int> ids { get; set; }
    }

    public class Questions
    {
        public List<object> add { get; set; }
        public List<object> delete { get; set; }
    }

    public class Add2
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Delete2
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Metadata
    {
        public List<Add2> add { get; set; }
        public List<Delete2> delete { get; set; }
    }

    public class Context2
    {
        public bool isContextOnly { get; set; }
        public List<object> prompts { get; set; }
    }

    public class Qna
    {
        public int id { get; set; }
        public string answer { get; set; }
        public string source { get; set; }
        public List<string> questions { get; set; }
        public List<object> metadata { get; set; }
        public Context2 context { get; set; }
    }

    public class PromptsToAdd
    {
        public string displayText { get; set; }
        public int displayOrder { get; set; }
        public Qna qna { get; set; }
        public int qnaId { get; set; }
    }

    public class Context
    {
        public bool isContextOnly { get; set; }
        public List<PromptsToAdd> promptsToAdd { get; set; }
        public List<int> promptsToDelete { get; set; }
    }

    public class QnaList2
    {
        public int id { get; set; }
        public string answer { get; set; }
        public string source { get; set; }
        public Questions questions { get; set; }
        public Metadata metadata { get; set; }
        public ContextDTO context { get; set; }
    }

    public class Update
    {
        public string name { get; set; }
        public List<QnaList2> qnaList { get; set; }
    }
}
