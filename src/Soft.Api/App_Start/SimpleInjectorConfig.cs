using System;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using Soft.Bussiness.Core.Notifications;
using Soft.Bussiness.Core.Services;
using Soft.Bussiness.Models.Books;
using Soft.Bussiness.Models.Users;
using Soft.Infra.Data.Repository;

namespace Soft.Api
{
    public static class SimpleInjectorConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            // Register ApplicationDbContext with Scoped lifestyle
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);

            // Register repositories with Scoped lifestyle if they depend on ApplicationDbContext
            container.Register<IBookRepository, BookRepository>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);

            // Register HttpClient as a singleton
            container.Register<HttpClient>(() =>
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:50547/")
                };
                return client;
            }, Lifestyle.Singleton);

            // Register other services
            container.Register<INotification, Notification>(Lifestyle.Singleton);
            container.Register<IBookServices, BookServices>(Lifestyle.Scoped);
            container.Register<IUserServices, UserServices>(Lifestyle.Scoped);

            // Register HttpConfiguration instance
            var config = GlobalConfiguration.Configuration;
            container.RegisterInstance(config);
        }
    }
}
