using System.Web.Mvc;

using ComputersFactory.Data.SalesReports.DataImporter.Contracts;
using ComputersFactory.Data.SalesReports.MongoDbImport;

namespace ComputersFactory.WebClient.Controllers
{
    public class TaskFiveController : Controller
    {
        private const string ReportsFileLocation = @"D:\TeamWorkFiles\XmlSalesReports\SalesReports.xml";
        private const string RootElement = "Reports";

        private readonly IXmlDataImporter xmlImporter;
        private readonly ISalesReportsMongoDbImporter mongoImporter;

        public TaskFiveController(IXmlDataImporter xmlImporter, ISalesReportsMongoDbImporter mongoImporter)
        {
            this.xmlImporter = xmlImporter;
            this.mongoImporter = mongoImporter;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RunTask()
        {
            var result = this.xmlImporter.ImportData(ReportsFileLocation, RootElement);
            this.mongoImporter.ImportSalesReports(result);

            return View(result);
        }
    }
}