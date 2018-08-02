using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ServerConfiguration
    {
        private DataAccess _dataAccess;
        private CSVExtraction _csvExtraction;
        public string flag = "Disable";
        public ServerConfiguration()
        {
            _dataAccess = new DataAccess();
            _csvExtraction = new CSVExtraction();
        }
        void SetUpServer()
        {
            Console.WriteLine("Type Server name or IP");
            var serverName = Console.ReadLine();

            Console.WriteLine("Type User Id");
            var userID = Console.ReadLine();

            Console.WriteLine("Type Password");
            var password = Console.ReadLine();

            Console.WriteLine("Type Database Name");
            var databaseName = Console.ReadLine();

            bool success = _dataAccess.TestConnection(serverName, databaseName, userID, password);

        }

        void StartSetupTable()
        {
            
            Console.WriteLine("Type quit to exit the Table Setup,");
            
            //SetUpTableAndColumn(tableColInfo);
        }


        public void SetUpTableAndColumn(Dictionary<string, List<string>> tableColInfo)
        {
            
            Console.WriteLine("Type Table name :");
            var tableName = Console.ReadLine().ToLower();
            do
            {
                if (tableName == "quit")
                {
                    Console.WriteLine("Thanks for using this program.");
                    break;
                }
                Console.WriteLine("Start providing column name,Type quit to exit the flow");
                List<string> colNameList = new List<string>();
                
                string value = string.Empty;
                do
                {
                    Console.Write("Type Column name :");
                    value = Console.ReadLine().ToLower();
                    if (value == "quit")
                    {
                        Console.WriteLine("Enter another table ? (Y/N)");
                        value = Console.ReadLine().ToLower();
                        if (value == "y")
                            SetUpTableAndColumn(tableColInfo);
                        else
                        {
                            tableColInfo.Add(tableName, colNameList);
                            tableName = "quit";
                            break;
                        }
                    }
                    colNameList.Add(value);

                } while (value != "quit");

                
            } while (tableName != "quit");
            Console.WriteLine("New Query is :");
            _csvExtraction.GenerateQuery(tableColInfo);

        }
    }
}
