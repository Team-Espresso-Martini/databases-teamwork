using System.Linq;

using ComputersFactory.Data.Contracts;

namespace ComputersFactory.Data.Xml.Facade
{
    public class WriteXmlReportsFacade: IWriteXmlReportsFacade
    {
        private const string BaseFileName = @"D:\TeamWorkFiles\GeneratedReports\Report";

        private readonly AbstractComputersFactoryDbContext context;

        public WriteXmlReportsFacade(AbstractComputersFactoryDbContext context)
        {
            this.context = context;
        }

        public void GenerateXmlReports()
        {
            var computers = context.Computers.ToList();

            for (int i = 0; i < computers.Count; i++)
            {
                var pc = computers[i];
                var fileName = BaseFileName + i + ".xml";
                XmlReports.GenerateComputerShopXmlReport(pc, fileName);
            }
        }
    }
}
