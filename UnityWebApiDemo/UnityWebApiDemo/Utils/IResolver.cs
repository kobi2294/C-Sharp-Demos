using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace UnityWebApiDemo.Utils
{
    public interface IResolver
    {
        T Resolve<T>();

        object Resolve(Type t);
    }
}