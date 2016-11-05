using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

using Ninject;

namespace ComputersFactory.WebClient.CustomControllerFactories
{
    public class ComputersFactoryControllersFactory : IControllerFactory
    {
        private readonly IKernel ninject;

        public ComputersFactoryControllersFactory(IKernel ninject)
        {
            this.ninject = ninject;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            return ninject.Get<Controller>(controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}