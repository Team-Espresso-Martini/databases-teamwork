using ComputersFactory.Data.Xml.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputersFactory.WebClient.Controllers
{
    public class TaskThreeController : Controller
    {
        private readonly IWriteXmlReportsFacade xmlReports;

        public TaskThreeController(IWriteXmlReportsFacade xmlReports)
        {
            this.xmlReports = xmlReports;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RunTask()
        {
            this.xmlReports.GenerateXmlReports();

            return View();
        }
    }
}