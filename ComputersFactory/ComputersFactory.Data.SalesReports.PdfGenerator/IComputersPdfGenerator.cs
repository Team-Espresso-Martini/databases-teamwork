using System.Collections.Generic;

namespace ComputersFactory.Data.SalesReports.PdfGenerator
{
    public interface IComputersPdfGenerator<TModel>
    {
        IList<TModel> GeneratePdfReports(string fileName);
    }
}