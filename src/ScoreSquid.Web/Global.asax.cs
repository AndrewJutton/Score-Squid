using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using ScoreSquid.Web.Context;
using ScoreSquid.Web.DependencyResolvers;
using ScoreSquid.Web.Repositories;
using Ninject;
using MvcMiniProfiler;
using AutoMapper;

namespace ScoreSquid.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Player", action = "Register", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterDependencyResolver();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MvcMiniProfiler.MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

        private void SetDatabaseInitializer()
        {
            Database.SetInitializer(new ScoreSquidContextInitializer());
        }

        private void RegisterDependencyResolver()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IScoreSquidContext>()
                .To<ScoreSquidContext>();
            kernel.Bind<IPlayerRepository>()
                .To<PlayerRepository>()
                .WithConstructorArgument("ScoreSquidContext", x => x.Kernel.Get<IScoreSquidContext>());
            kernel.Bind<IFixtureRepository>()
                .To<FixtureRepository>()
                .WithConstructorArgument("ScoreSquidContext", x => x.Kernel.Get<IScoreSquidContext>());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        private class AutoMapperConfiguration
        {
            public static void Configure()
            {
                Mapper.Initialize(x => GetConfiguration(Mapper.Configuration));
            }

            private static void GetConfiguration(IConfiguration configuration)
            {
                var profiles = typeof(IAmWeb).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
                foreach (var profile in profiles)
                {
                    configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            }
        }
    }
}