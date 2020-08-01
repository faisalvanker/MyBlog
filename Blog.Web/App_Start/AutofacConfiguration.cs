using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Blog.Business;
using Blog.Business.Contracts;

namespace Blog.Web
{
    public class AutofacConfiguration
    {
        /// <summary>
        /// Method Register's Autofac  Depenencies
        /// </summary>
        public static void ConfigAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BlogManager>().As<IBlogManager>();

            // Register your MVC controllers. (MvcApplication is the name of // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}