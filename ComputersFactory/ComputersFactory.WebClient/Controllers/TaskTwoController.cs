using System.Web.Mvc;

using ComputersFactory.Data.Models;
using ComputersFactory.Data.SalesReports.PdfGenerator;

namespace ComputersFactory.WebClient.Controllers
{
    public class TaskTwoController : Controller
    {
        private readonly IComputersPdfGenerator<Computer> pdfGenerator;

        public TaskTwoController(IComputersPdfGenerator<Computer> pdfGenerator)
        {
            this.pdfGenerator = pdfGenerator;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RunTask()
        {
            var computers = this.pdfGenerator.GeneratePdfReports(null);

            return View(computers);
        }
    }
}