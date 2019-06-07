using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace UnityWebApiDemo.Utils
{
    public class UnityResolver : IResolver
    {
        private IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type t)
        {
            return _container.Resolve(t);
        }
    }
}