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
            builder.RegisterType<SQLPostData>()
                   .As<IPostData>()
                   .InstancePerRequest();

            builder.RegisterType<SQLCommentData>()
                   .As<ICommentData>()
                   .InstancePerRequest();

            builder.RegisterType<SeenitDBContext>().InstancePerRequest();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //MVC web
        }
    }
}