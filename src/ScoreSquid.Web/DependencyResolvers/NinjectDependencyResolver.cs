using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;

namespace ScoreSquid.Web.DependencyResolvers
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
 
        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
 
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }
    }
}