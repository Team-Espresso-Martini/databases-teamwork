using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Reflection;

using ComputersFactory.Data.MySql.ExcelReports.ExcelFileGenerators.Contracts;

namespace ComputersFactory.Data.MySql.ExcelReports.ExcelFileGenerators
{
    public class ExcelFileGenerator : IExcelFileGenerator
    {
        public void GenerateExcelTable<TModel>(IEnumerable<TModel> data, string fileName)
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

            var propertiesInfo = typeof(TModel).GetProperties();
            var table = this.CreateDataTable(propertiesInfo);

            foreach (var item in data)
            {
                var values = new List<object>();
                foreach (var property in propertiesInfo)
                {
                    var nextValue = property.GetValue(item);
                    values.Add(nextValue);
                }

                table.Rows.Add(values);
            }

            var dataSet = new DataSet("MySqlReports");
            dataSet.Tables.Add(table);

            ExcelLibrary.DataSetHelper.CreateWorkbook(fileName, dataSet);
        }

        private DataTable CreateDataTable(IEnumerable<PropertyInfo> properties)
        {
            var table = new DataTable();
            foreach (var property in properties)
            {
                table.Columns.Add(property.Name);
            }

            return table;
        }
    }
}
