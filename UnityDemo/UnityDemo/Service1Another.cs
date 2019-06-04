using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemo
{
    public class Service1Another : IService1
    {
        private object _service4;

        public string Uid { get; }

        public Service1Another(Service4 service)
        {
            _service4 = service;
            Uid = "bla bla bla" + service.Uid;
        }
    }
}
