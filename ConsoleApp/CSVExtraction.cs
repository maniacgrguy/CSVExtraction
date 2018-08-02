using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml;


namespace ConsoleApp1
{
    public class CSVExtraction
    {
        private Dictionary<string, List<string>> _tableColInfo;
        public CSVExtraction(Dictionary<string, List<string>> tableColInfo)
        {
            _tableColInfo = tableColInfo;
        }

        public CSVExtraction()
        {

        }

        public void GenerateQuery(Dictionary<string, List<string>> tableColInfo)
        {
            int colCount = 1;
            int tableCount = 1;
            // string query = string.Format("SELECT {0} FROM {1} INNER JOIN {2} on {3}");
            StringBuilder sb = new StringBuilder("SELECT ");
            int i = 0;
            string tableName = string.Empty;

            foreach (KeyValuePair<string, List<string>> tableList in tableColInfo)
            {
                i++;
               
                tableName = tableList.Key + "_" + i;
                var columnNames = tableList.Value;
                foreach (var colName in columnNames)
                {
                    if (tableColInfo.Count == tableCount)
                    {
                        sb.Insert(6, " " + tableName + "." + colName + ",");
                    }
                    else
                    {
                        if (colCount == 1)
                        {
                            sb.Insert(6, " " + tableName + "." + colName);
                        }
                        else
                        {
                            sb.Insert(6, " " + tableName + "." + colName + ",");
                        }
                    }
                   
                    colCount+=1;
                }
              
                if (tableCount != 1)
                {
                    sb.Append($"  {tableName}");
                }
                else
                {
                    sb.Append($" FROM {tableName}");
                }
                tableCount += 1;

            }
            Console.WriteLine("Dynamic query is " + sb);
        }

    }
}
