using Autofac;
using Autofac.Integration.Mvc;
using Seenit.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Seenit.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryPostData>()
                   .As<IPostData>()
                   .SingleInstance();

            builder.RegisterType<InMemoryCommentData>()
                   .As<ICommentData>()
                   .SingleInstance();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //MVC web
        }
    }
}