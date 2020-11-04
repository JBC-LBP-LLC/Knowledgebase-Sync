using CsvHelper;
using RPA.KnowledgebaseSync.Activities.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KbSyncDebugUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            var DataTable905 = new DataTable();
            string kbObject905 = System.IO.File.ReadAllText(@"C:\Dev\WTW\RPA-Knowledgebase\Knowledgebase-Sync\Documents\kbObject905.txt");
            using (var reader = new StreamReader(@"C:\Dev\WTW\RPA-Knowledgebase\Knowledgebase-Sync\Documents\DataTable905.csv"))
            using (var DataTable = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                using (var dr = new CsvDataReader(DataTable))
                {
                    DataTable905.Load(dr);
                }
            }

            var JsonObjectUpdateKbOperationDTO = KnowledgebaseUtility.CreateKnowledgebaseUpdate(DataTable905, kbObject905);

            Console.WriteLine(JsonObjectUpdateKbOperationDTO);
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
