using System.Web.Http;

using Unity.AspNet.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UnityWebApiDemo.UnityWebApiActivator), nameof(UnityWebApiDemo.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(UnityWebApiDemo.UnityWebApiActivator), nameof(UnityWebApiDemo.UnityWebApiActivator.Shutdown))]

namespace UnityWebApiDemo
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            // Use UnityHierarchicalDependencyResolver if you want to use
            // a new child container for each IHttpController resolution.
            // var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);
            var resolver = new UnityDependencyResolver(UnityConfig.Container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}