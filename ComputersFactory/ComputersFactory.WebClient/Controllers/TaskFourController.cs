using System.Web.Mvc;

using ComputersFactory.Data.Json.Facade;

namespace ComputersFactory.WebClient.Controllers
{
    public class TaskFourController : Controller
    {
        private readonly IWriteJsonReportsFacade jsonReports;

        public TaskFourController(IWriteJsonReportsFacade jsonReports)
        {
            this.jsonReports = jsonReports;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RunTask()
        {
            var generatedReports = this.jsonReports.GenerateJsonReports();

            return View(generatedReports);
        }
    }
}