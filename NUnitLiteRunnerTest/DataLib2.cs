using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Test2
{
    class DataLib2
    {
        private static DataTable ExcelToDataTable2(string fileName2)
        {
            FileStream stream2 = File.Open(fileName2, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream2); 

            var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            DataTableCollection table2 = result.Tables;
           
            DataTable resultTable2 = table2["Sheet1"];

            //Dont really need to close this stream.
            stream2.Close();
            return resultTable2;
        }
        static List<Datacollection> dataCol2 = new List<Datacollection>();

        public static void PopulateInCollection2(string fileName2)
        {
            DataTable table = ExcelToDataTable2(fileName2);


            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable2 = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };

                    dataCol2.Add(dtTable2);
                }
            }
        }

        public static string ReadData2(int rowNumber, string columnName)
        {
            try
            {

                string data2 = (from colData in dataCol2
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data2.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
    public class Datacollection2
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}

