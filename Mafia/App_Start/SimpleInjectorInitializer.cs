using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using MafiaRepository.Concrete;
using MafiaRepository.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System.Data.Entity;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Mafia.SimpleInjectorInitializer), "Initialize")]

namespace Mafia
{

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {

            // Did you know the container can diagnose your configuration? Go to: https://bit.ly/YE8OJj.
            var container = new Container();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            // Mongo
            var connString = ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString;
            container.RegisterPerWebRequest<IRepository>(() => new MongoRepository(connString));
        }
    }
}