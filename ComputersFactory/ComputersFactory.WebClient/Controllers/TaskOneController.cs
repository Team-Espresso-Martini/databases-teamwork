using System.Web.Mvc;

using ComputersFactory.Data.MongoDbWriter.Facade;
using ComputersFactory.Data.SalesReports.Excel;

namespace ComputersFactory.WebClient.Controllers
{
    public class TaskOneController : Controller
    {
        private readonly IMongoDbDataFacade mongoDbData;
        private readonly IExcelSalesReportsImporter excelImporter;

        public TaskOneController(IMongoDbDataFacade mongoDbData, IExcelSalesReportsImporter excelImporter)
        {
            this.mongoDbData = mongoDbData;
            this.excelImporter = excelImporter;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RunTask()
        {
            this.mongoDbData.GenerateMongoDbData();
            this.mongoDbData.TransferDataFromMongoDbToSqlServer();
            var importedReports = this.excelImporter.ImportSalesReportsFromExcel(null, null);

            return View();
        }
    }
}