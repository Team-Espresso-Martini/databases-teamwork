using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.Json.Contracts;
using ComputersFactory.Data.MySql;

namespace ComputersFactory.Data.Json.Facade
{
    public class WriteJsonReportsFacade
    {
        private readonly IJsonService jsonService;
        private readonly IMySqlDatabaseContext mySqlContext;
        private readonly AbstractComputersFactoryDbContext sqlServercontext;

        public WriteJsonReportsFacade(
            IJsonService jsonService, 
            IMySqlDatabaseContext mySqlContext, 
            AbstractComputersFactoryDbContext sqlServercontext)
        {
            this.jsonService = jsonService;
            this.mySqlContext = mySqlContext;
            this.sqlServercontext = sqlServercontext;
        }

        public void GenerateXmlReports()
        {

        }
    }
}
