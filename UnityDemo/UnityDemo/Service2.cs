using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemo
{
    public class Service2
    {
        public string Uid { get; }

        public Service2()
        {
            Uid = Guid.NewGuid().ToString();
        }

    }
}
