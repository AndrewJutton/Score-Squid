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
using ScoreSquid.Web.Repositories.Commands;
using Quartz;
using Quartz.Impl;
using ScoreSquid.Web.Scheduler;
using ScoreSquid.Web.Authentication;
using ScoreSquid.Web.Tasks;
using System.Web.Security;
using System.Security.Principal;

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
                new { controller = "Player", action = "Login", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            RegisterDependencyResolver();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            AutoMapperConfiguration.Configure();

            //StartScheduler();
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

        public override void Init()
        {
            this.PostAuthenticateRequest += new EventHandler(MvcApplication_PostAuthenticateRequest);
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                string encTicket = authCookie.Value;
                if (!String.IsNullOrEmpty(encTicket))
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encTicket);
                    PlayerIdentity playerIdentity = new PlayerIdentity(ticket);
                    GenericPrincipal principal = new GenericPrincipal(playerIdentity, null);
                    HttpContext.Current.User = principal;
                }
            }
        }

        private void RegisterDependencyResolver()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IFormsAuthentication>().To<FormsAuthenticationService>();
            kernel.Bind<IPlayerTasks>().To<PlayerTasks>();
            kernel.Bind<ITeamTasks>().To<TeamTasks>();
            kernel.Bind<IPlayerCommands>().To<Commands>();
            kernel.Bind<IFixtureCommands>().To<Commands>();
            kernel.Bind<ITeamCommands>().To<Commands>();
            kernel.Bind<IPlayerRepository>()
                .To<PlayerRepository>()
                .WithConstructorArgument("commands", x => x.Kernel.Get<IPlayerCommands>());
            kernel.Bind<IFixtureRepository>()
                .To<FixtureRepository>()
                .WithConstructorArgument("commands", x => x.Kernel.Get<IFixtureCommands>());
            kernel.Bind<ITeamRepository>()
                .To<TeamRepository>()
                .WithConstructorArgument("commands", x => x.Kernel.Get<ITeamCommands>());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        private void StartScheduler()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

            IScheduler sched = schedulerFactory.GetScheduler();
            sched.Start();

            JobDetail championshipDownloader = new JobDetail("ResultExtractor", null, typeof(ChampionshipJob));

            Trigger trigger = TriggerUtils.MakeMinutelyTrigger();
            trigger.StartTimeUtc = TriggerUtils.GetEvenMinuteDate(DateTime.UtcNow);
            trigger.Name = "Hourly Trigger";

            sched.ScheduleJob(championshipDownloader, trigger);
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