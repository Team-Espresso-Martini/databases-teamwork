using System.Web.Mvc;

using ComputersFactory.Data.MongoDbWriter.Facade;

namespace ComputersFactory.WebClient.Controllers
{
    public class TaskOneController : Controller
    {
        private readonly IMongoDbDataFacade mongoDbData;

        public TaskOneController(IMongoDbDataFacade mongoDbData)
        {
            this.mongoDbData = mongoDbData;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RunTask()
        {
            this.mongoDbData.GenerateMongoDbData();
            this.mongoDbData.TransferDataFromMongoDbToSqlServer();

            return View();
        }
    }
}