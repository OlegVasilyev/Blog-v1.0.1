using Ninject;
using System;
using System.Collections.Generic;
using DependencyResolver;
using System.Web.Mvc;

namespace EpamBlog.Ninject
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            kernelParam.ConfigurateResolver();
        }
        public object GetService(Type servicetype)
        {
            return _kernel.TryGet(servicetype);
        }
        public IEnumerable<object> GetServices(Type servicetype)
        {
            return _kernel.GetAll(servicetype);
        }
    }
}