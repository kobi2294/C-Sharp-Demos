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
        
        public string Uid { get; }

        public ChildConsumer(Service4 service)
        {
            _service4 = service;
            Uid = Guid.NewGuid().ToString();
        }

        public void DoSomething()
        {
            Console.WriteLine("Child Consumer UID = " + Uid + " Service 4 UID = " + _service4.Uid);
        }
    }
}
