using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            // tell container what other pieces of soft I want injected in my applic
            builder.RegisterControllers(typeof(MvcApplication).Assembly); // telling Autofac and register diff Controller types in my app (Home, Greetings etc)
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly); // register api controllers
            builder.RegisterType<InMemoryRestaurantData>() // builder.RegisterType<InMemoryRestaurantData>()
                   .As<IRestaurantData>()
                   .SingleInstance();

            /*builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();
            builder.RegisterType<SqlRestaurantData>() // builder.RegisterType<InMemoryRestaurantData>()
            .As<IRestaurantData>()
            .InstancePerRequest();
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();*/

            var container = builder.Build(); //when need to resolve dependencies, use this container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); // for web container (dependency resolver)
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container); // for the api one

        }
    }
}