using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class QueryExtractor
    {
        public string GenerateQuery(Dictionary<string, List<string>> tableColInfo)
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
                tableName = tableList.Key;
                var columnNames = tableList.Value;
                foreach (var colName in columnNames)
                {
                    if (colCount == 1)
                    {
                        sb.Insert(6, " " + tableName + "." + colName);
                    }
                    else
                    {
                        sb.Insert(6, " " + tableName + "." + colName + ",");
                    }
                    //if (tableColInfo.Count == tableCount)
                    //{
                    //    sb.Insert(6, " " + tableName + "." + colName + ",");
                    //}
                    //else
                    //{
                       
                    //}
                    colCount += 1;
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
            return sb.ToString();
        }
    }
}
