using SimpleInjector.Integration.WebApi;
using SimpleInjector;
using Soft.Bussiness.Core.Notifications;
using Soft.Bussiness.Core.Services;
using Soft.Bussiness.Models.Books;
using Soft.Infra.Data.Repository;
using System.Web.Http;
using SimpleInjector.Lifestyles;

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

            // Register your types, for instance:
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IBookRepository, BookRepository>(Lifestyle.Scoped);
            container.Register<IBookServices, BookServices>(Lifestyle.Scoped);
            container.Register<INotification, Notification>(Lifestyle.Singleton);

            // Register the Web API controllers
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Verify the container configuration
            container.Verify();

            // Set the Web API dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
 }