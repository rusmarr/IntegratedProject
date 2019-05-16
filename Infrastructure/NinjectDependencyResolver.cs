using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Buttons.Domain.Abstract;
using Buttons.Domain.Entities;
using Moq;
using Buttons.Domain.Concrete;

namespace Buttons.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();

            
        }
        public object GetService(Type myserviceType)
        {
            return kernel.TryGet(myserviceType);
        }
        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return kernel.GetAll(myserviceType);
        }
        private void AddBindings()
        {
            /*
            Mock<IProductRepository> myMock = new Mock<IProductRepository>();
            myMock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {Name = "Sample", Category = "Buttons"}
            });
            kernel.Bind<IProductRepository>().ToConstant(myMock.Object);*/
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}