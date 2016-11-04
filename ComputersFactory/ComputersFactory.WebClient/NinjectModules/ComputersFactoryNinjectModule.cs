using Ninject.Modules;
using Ninject.Extensions.Conventions;

using System.IO;
using System.Reflection;

namespace ComputersFactory.WebClient.NinjectModules
{
    public class ComputersFactoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(ctx =>
                 ctx.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                 .SelectAllClasses()
                 .BindDefaultInterface());
        }
    }
}