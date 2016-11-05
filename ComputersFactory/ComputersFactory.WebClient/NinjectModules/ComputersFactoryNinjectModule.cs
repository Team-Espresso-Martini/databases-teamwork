using Ninject.Modules;
using Ninject.Extensions.Conventions;

using System.IO;
using System.Reflection;
using System.Web.Mvc;

using ComputersFactory.Data;
using ComputersFactory.Data.Contracts;
using ComputersFactory.Data.SalesReports.MongoDbImport;
using ComputersFactory.Data.SalesReports.DataImporter.Contracts;
using ComputersFactory.Data.SalesReports.DataImporter;
using ComputersFactory.Data.SalesReports.Adapters.Contracts;
using ComputersFactory.Data.SalesReports.Adapters;
using ComputersFactory.Data.SalesReports.XmlDeserializers.Contracts;
using ComputersFactory.Data.SalesReports.XmlDeserializers;
using ComputersFactory.Data.SalesReports.Converters.Contracts;
using ComputersFactory.Data.SalesReports.Converters;
using ComputersFactory.WebClient.Controllers;
using ComputersFactory.Data.MongoDbWriter.Facade;
using ComputersFactory.Data.Xml.Facade;
using ComputersFactory.Data.Json.Contracts;
using ComputersFactory.Data.Json;
using ComputersFactory.Data.Json.JsonProviders;
using ComputersFactory.Data.FileSystem.Contracts;
using ComputersFactory.Data.FileSystem;
using ComputersFactory.Data.Json.Facade;
using ComputersFactory.Data.MySql;

namespace ComputersFactory.WebClient.NinjectModules
{
    public class ComputersFactoryNinjectModule : NinjectModule
    {
        private const string HomeControllerName = "Home";
        private const string TaskOneControllerName = "TaskOne";
        private const string TaskThreeControllerName = "TaskThree";
        private const string TaskFiveControllerName = "TaskFive";

        public override void Load()
        {
            this.Kernel.Bind(ctx =>
                 ctx.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                 .SelectAllClasses()
                 .BindDefaultInterface());

            this.Bind<IFileSystemService>().To<FileSystemService>();
            this.Bind<IJsonProvider>().To<NewtonsoftJsonProvider>();
            this.Bind<IJsonService>().To<JsonService>();

            this.Bind<ISalesReportsMongoDbImporter>().To<SalesReportsMongoDbImporter>();
            this.Bind<IXmlDeserializer>().To<XmlDeserializer>();
            this.Bind<IModelConverter>().To<ModelConverter>();
            this.Bind<IAdaptedXmlDeserializer>().To<AdaptedXmlDeserializer>();
            this.Bind<IAdaptedModelConverter>().To<AdaptedModelConverter>();

            this.Bind<IMongoDbDataFacade>().To<MongoDbDataFacade>();
            this.Bind<IWriteXmlReportsFacade>().To<WriteXmlReportsFacade>();
            this.Bind<IWriteJsonReportsFacade>().To<WriteJsonReportsFacade>();

            this.Bind<Controller>().To<HomeController>().Named(HomeControllerName);
            this.Bind<Controller>().To<TaskOneController>().Named(TaskOneControllerName);
            this.Bind<Controller>().To<TaskThreeController>().Named(TaskThreeControllerName);
            this.Bind<Controller>().To<TaskFiveController>().Named(TaskFiveControllerName);

            this.Bind<AbstractComputersFactoryDbContext>().To<ComputersFactoryDbContext>()
                .WhenInjectedInto<XmlSalesReportDataImporter>().InSingletonScope();

            this.Bind<AbstractComputersFactoryDbContext>().To<ComputersFactoryDbContext>()
                .WhenInjectedInto<WriteXmlReportsFacade>().InSingletonScope();

            this.Bind<AbstractComputersFactoryDbContext>().To<ComputersFactoryDbContext>()
                .WhenInjectedInto<WriteJsonReportsFacade>().InSingletonScope();

            this.Bind<IMySqlDatabaseContext>().To<ComputersFactoryMySqlDbContext>()
                .WhenInjectedInto<WriteJsonReportsFacade>().InSingletonScope();

            this.Bind<IXmlDataImporter>().To<XmlSalesReportDataImporter>();
        }
    }
}