using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using System.Web.Mvc;
using System.Reflection;
using SimpleInjector.Integration.Web.Mvc;
using Soft.Api.Areas.HelpPage.Controllers;
using Soft.Bussiness.Core.Notifications;
using Soft.Bussiness.Core.Services;
using Soft.Bussiness.Models.Books;
using Soft.Infra.Data.Repository;
using System.Net.Http;
using System;

namespace Soft.Api
{
    public static class SimpleInjectorConfig
    {
        public static void RegisterDependencies()
        {
            // Create the container
            var container = new Container();

            // Set the scoped lifestyle to AsyncScopedLifestyle
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register HttpClient as a singleton
            container.Register<HttpClient>(() =>
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:50547/")
                };
                return client;
            }, Lifestyle.Singleton);

            // Register HttpConfiguration as a singleton
            var config = GlobalConfiguration.Configuration;
            container.RegisterInstance(config);

            // Register your other types, for instance:
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IBookRepository, BookRepository>(Lifestyle.Scoped);
            container.Register<INotification, Notification>(Lifestyle.Singleton);
            container.Register<IBookServices, BookServices>(Lifestyle.Transient);

            // Register Web API and MVC controllers
            container.RegisterWebApiControllers(config);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // Verify the container configuration
            container.Verify();

            // Set the Web API dependency resolver
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            // Set the MVC dependency resolver
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
