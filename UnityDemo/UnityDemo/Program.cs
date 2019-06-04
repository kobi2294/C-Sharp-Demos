using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace UnityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var uc = new UnityContainer();

            var c = uc.Resolve<Consumer>();

            c.Run();
            Console.ReadLine();
            c.Run();
            Console.ReadLine();
            c.Run();
            Console.ReadLine();
        }
    }
}
