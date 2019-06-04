using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace UnityDemo
{
    class Program
    {
        private static Consumer _consumer;

        private static void Bootstrap()
        {
            var uc = new UnityContainer();

            uc.RegisterType<IService1, Service1Another>(new ContainerControlledLifetimeManager());
            uc.RegisterType<Service2>(new ContainerControlledLifetimeManager());
            uc.RegisterType<Service3>(new ContainerControlledLifetimeManager());
            uc.RegisterType<Service4>(new ContainerControlledLifetimeManager());



            _consumer = uc.Resolve<Consumer>();
        }


        static void Main(string[] args)
        {
            Bootstrap();

            _consumer.Run();
            Console.ReadLine();
            _consumer.Run();
            Console.ReadLine();
            _consumer.Run();
            Console.ReadLine();
        }
    }
}
