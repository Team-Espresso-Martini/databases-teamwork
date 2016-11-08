using System;
using System.Collections.Generic;
using System.Linq;

using ComputersFactory.Data.MySql.ExcelReports.ExcelFileGenerators.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.MySql.ExcelReports
{
    public class ExcelReportsFromMySqlProvider : IExcelReportsFromMySqlProvider
    {
        private const string DefaultFileName = @"D:\TeamWorkFiles\GeneratedExcelReports\MySqlReports.xls";

        private readonly IExcelFileGenerator excelGenerator;
        private readonly IMySqlDatabaseContext context;

        public ExcelReportsFromMySqlProvider(IExcelFileGenerator excelGenerator, IMySqlDatabaseContext context)
        {
            if (excelGenerator == null)
            {
                throw new ArgumentNullException(nameof(excelGenerator));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.excelGenerator = excelGenerator;
            this.context = context;
        }

        public IList<MySqlReport> CreateExcelReport(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = ExcelReportsFromMySqlProvider.DefaultFileName;
            }

            var reports = this.context.Reports.ToList();
            this.excelGenerator.GenerateExcelTable(reports, fileName);

            return reports;
        }
    }
}
