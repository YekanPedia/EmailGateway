﻿namespace YekanPedia.EmailGateway.DependencyResolver
{
    using StructureMap;
    using StructureMap.Web.Pipeline;
    using System;
    using Service.Implement;
    using Service.Interfaces;
    using Data.Context;

    public class IocInitializer
    {
        public static IContainer Container;
        public static void Initialize()
        {
            Container = new Container(x =>
            {
                x.For<IUnitOfWork>().Use(() => new EmailGatewayDbContext()).LifecycleIs<HttpContextLifecycle>();
                x.For<IAboutUsService>().Use<AboutUsService>();
            });
        }
        public static object GetInstance(Type pluginType)
        {
            return Container.GetInstance(pluginType);
        }
        public static TPluginType GetInstance<TPluginType>()
        {
            return Container.GetInstance<TPluginType>();
        }
        public static void HttpContextDisposeAndClearAll()
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }
    }
}
