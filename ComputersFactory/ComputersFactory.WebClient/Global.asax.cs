using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using ComputersFactory.WebClient.CustomControllerFactories;
using Ninject;

namespace ComputersFactory.WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var customControllerFactory = ninject.Get<ComputersFactoryControllersFactory>();
            ControllerBuilder.Current.SetControllerFactory(customControllerFactory);
        }
    }
}
