using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.Models;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ComputersFactory.Data.SalesReports.PdfGenerator
{
    public class ComputersPdfGenerator : IComputersPdfGenerator<Computer>
    {
        private readonly AbstractComputersFactoryDbContext context;

        public ComputersPdfGenerator(AbstractComputersFactoryDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
        }

        public IList<Computer> GeneratePdfReports(string fileName)
        {
            var computers = this.context.Computers.ToList();

            var pdf = new Document();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                PdfWriter.GetInstance(pdf, fs);

                var computersTable = new PdfPTable(3);
                var headingCell = new PdfPCell(new Phrase("Available Computers"));
                headingCell.Colspan = 2;
                headingCell.HorizontalAlignment = 1;
                computersTable.AddCell(headingCell);
                computersTable.AddCell("Model");
                computersTable.AddCell("Price");

                foreach (var item in computers)
                {
                    computersTable.AddCell(item.Model);
                    computersTable.AddCell($"${item.Price}");
                }

                pdf.Open();
                pdf.Add(computersTable);
                pdf.Close();
            }

            return computers;
        }
    }
}
