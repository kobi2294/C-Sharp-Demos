using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TplDemo
{
    public static class PrimesCalculator
    {
        private static bool _isPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        private static IEnumerable<int> _allPrimes(int startNumber, int endNumber)
        {
            for (int i = startNumber; i < endNumber; i++)
            {
                if (_isPrime(i))
                    yield return i;
            }
        }

        public static List<int> GetAllPrimes(int startNumber, int endNumber)
        {
            return _allPrimes(startNumber, endNumber).ToList();
        }
    }
}
