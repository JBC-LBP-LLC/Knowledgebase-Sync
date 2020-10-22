using System;

namespace KbSyncDevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var portalDb = System.IO.File.ReadAllText(@"C:\Dev\WTW\RPA-Knowledgebase\Knowledgebase-Sync\Documents\Portal-905-Db.json");
            var kbDownload = System.IO.File.ReadAllText(@"C:\Dev\WTW\RPA-Knowledgebase\Knowledgebase-Sync\Documents\Knowledgebase-905.json");
            
            string kbUpdate = KnowledgebaseSync.KnowledgebaseSync.CreateKnowledgebaseUpdate(portalDb, kbDownload);

            Console.WriteLine(kbUpdate);
            Console.ReadLine();
            Console.WriteLine();
        }
    }
}
