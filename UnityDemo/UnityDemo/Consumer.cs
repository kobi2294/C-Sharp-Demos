using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace UnityDemo
{
    public class Consumer
    {
        private Printer _printer;
        private Logger _logger;
        private Service1 _service1;
        private Func<ChildConsumer> _childFactory;
        private Service3 _service3;

        private List<ChildConsumer> _children = new List<ChildConsumer>();

        // 1. Injection by Constructor
        public Consumer(
            Printer printer, 
            Logger logger, 
            Service1 service1, 
            Func<ChildConsumer> childFactory
            )
        {
            _printer = printer;
            _logger = logger;
            _service1 = service1;
            _childFactory = childFactory;
        }

        // 2. Injection by property
        private Service2 _service2;
        [Dependency]
        public Service2 Service2
        {
            get
            {
                return _service2;
            }
            set
            {
                _service2 = value;
            }
        }

        // 3. Injection Method
        [InjectionMethod]
        public void Inject(Service3 service)
        {
            _service3 = service;
        }


        public void Run()
        {
            _printer.Print("Some text");
            _logger.Log("Some other text");

            Console.WriteLine("Service 1 has the ID: " + _service1.Uid);
            Console.WriteLine("Service 2 has the ID: " + Service2.Uid);
            Console.WriteLine("Service 3 has the ID: " + _service3.Uid);


            var newChild = _childFactory();
            _children.Add(newChild);
            Console.WriteLine("I currently have: " + _children.Count + " Children");

            foreach (var child in _children)
            {
                child.DoSomething();
            }

        }

    }
}
