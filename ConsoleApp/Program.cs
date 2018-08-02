using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerConfiguration serverConfiguration = new ServerConfiguration();
            CSVExtraction csvExtraction = new CSVExtraction();
            QueryExtractor queryExtractor = new QueryExtractor();
            Dictionary<string, List<string>> tableColInfo = new Dictionary<string, List<string>>();
            Console.WriteLine("CSV Extraction Program");
            Console.WriteLine("======================");
            serverConfiguration.SetUpServer();
            serverConfiguration.SetUpTableAndColumn(ref tableColInfo);
            string query = queryExtractor.GenerateQuery(tableColInfo);
            csvExtraction.GenerateCSV(serverConfiguration.ExecuteQuery(query));
            Console.ReadLine();
        }
    }
}
