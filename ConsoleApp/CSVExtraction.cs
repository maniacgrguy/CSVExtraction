using OfficeOpenXml;
using System;
using System.Data;
using System.IO;


namespace ConsoleApp
{
    public class CSVExtraction
    {
        public CSVExtraction()
        {

        }

        public void GenerateCSV(DataTable dtData)
        {
            var directory = Directory.GetCurrentDirectory();
            FileInfo fileInfo = new FileInfo($"{directory}\\{DateTime.Today.ToString("yyyyMMdd") }.xlsx");
            using (ExcelPackage pck = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Accounts");
                ws.Cells["A1"].LoadFromDataTable(dtData, true);
                pck.Save();
            }
        }
    }
}
