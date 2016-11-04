using System.Web.Mvc;

using ComputersFactory.Data.SalesReports.DataImporter.Contracts;

namespace ComputersFactory.WebClient.Controllers
{
    public class TaskFiveController : Controller
    {
        private const string ReportsFileLocation = @"D:\TeamWorkFiles\XmlSalesReports\SalesReports.xml";
        private const string RootElement = "Reports";

        private readonly IXmlDataImporter xmlImporter;

        public TaskFiveController(IXmlDataImporter xmlImporter)
        {
            this.xmlImporter = xmlImporter;
        }

        // GET: TaskFive
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RunTask()
        {
            this.xmlImporter.ImportData(ReportsFileLocation, RootElement);

            return View();
        }
    }
}