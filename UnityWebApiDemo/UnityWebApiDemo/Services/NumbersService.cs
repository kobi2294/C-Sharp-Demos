using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnityWebApiDemo.Services
{
    public class NumbersService : INumbersService
    {
        private Random _rand;

        public NumbersService(Random rand)
        {
            _rand = rand;
        }

        public IEnumerable<int> GenerateRandomNumbers()
        {
            var count = _rand.Next(10, 20);

            var res = Enumerable.Range(1, count)
                    .Select(i => _rand.Next(5, 100))
                    .ToList();

            return res;
        }
    }
}