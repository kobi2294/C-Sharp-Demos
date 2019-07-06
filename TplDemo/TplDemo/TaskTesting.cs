using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TplDemo
{
    public static class TaskTesting
    {
        public static async Task<string> SaySomething()
        {
            await Task.Delay(1000);
            return "Hello";
        }

        public static async Task<string> SaySomethingElse()
        {
            await Task.Delay(2000);
            return "World";
        }

        public static Task<string> SayItQuickly()
        {
            return Task.FromResult("Fast");
        }

    }
}
