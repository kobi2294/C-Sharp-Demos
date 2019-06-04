using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemo
{
    public class ChildConsumer
    {
        private Service4 _service4;

        public ChildConsumer(Service4 service)
        {
            _service4 = service;
        }

        public void DoSomething()
        {
            Console.WriteLine("Service 4 UID = " + _service4.Uid);
        }
    }
}
