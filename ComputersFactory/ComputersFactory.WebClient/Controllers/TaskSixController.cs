using ComputersFactory.Data.MySql.ExcelReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputersFactory.WebClient.Controllers
{
    public class TaskSixController : Controller
    {
        private readonly IExcelReportsFromMySqlProvider reportsGenerator;

        public TaskSixController(IExcelReportsFromMySqlProvider reportsGenerator)
        {
            this.reportsGenerator = reportsGenerator;
        }

        // GET: TaskSix
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RunTask()
        {
            var reports = this.reportsGenerator.CreateExcelReport(null);
            return View(reports);
        }
    }
}