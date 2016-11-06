using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

using ComputersFactory.Data.MySql.ExcelReports.ExcelFileGenerators.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.MySql.ExcelReports.ExcelFileGenerators
{
    public class ExcelFileGenerator : IExcelFileGenerator
    {
        public void GenerateExcelTable(IEnumerable<MySqlReport> data, string fileName)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var fileNameInfo = new FileInfo(fileName);
            if (!Directory.Exists(fileNameInfo.DirectoryName))
            {
                throw new DirectoryNotFoundException(fileNameInfo.DirectoryName);
            }

            if (fileNameInfo.Exists)
            {
                fileNameInfo.Delete();
            }

            var table = this.CreateDataTable();
            foreach (var item in data)
            {
                table.Rows.Add(item.Model, item.TotalQuantity, item.TotalSales);
            }

            var dataSet = new DataSet("MySqlReports");
            dataSet.Tables.Add(table);

            ExcelLibrary.DataSetHelper.CreateWorkbook(fileName, dataSet);
        }

        private DataTable CreateDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Model");
            table.Columns.Add("TotalQty");
            table.Columns.Add("TotalSales");

            return table;
        }
    }
}
