using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemo
{
    public class Consumer
    {
        Printer _printer;
        Logger _logger;

        public Consumer(Printer printer, Logger logger)
        {
            _printer = printer;
            _logger = logger;
        }

        public void Run()
        {
            _printer.Print("Some text");
            _logger.Log("Some other text");
        }

    }
}
