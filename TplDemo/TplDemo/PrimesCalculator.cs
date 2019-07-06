using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private static IEnumerable<int> _allPrimes(int startNumber, int endNumber, CancellationToken ct, IProgress<double> pr)
        {
            var range = endNumber - startNumber; 
            var portion = range / 100; 

            for (int i = startNumber; i < endNumber; i++)
            {
                var completedRange = i - startNumber;
                if (completedRange % portion == 0)
                    pr.Report(((double)completedRange) / range);

                if (ct.IsCancellationRequested)
                    throw new OperationCanceledException();
                if (_isPrime(i))
                    yield return i;
            }

            pr.Report(1.0);
        }

        public static List<int> GetAllPrimes(int startNumber, int endNumber, CancellationToken ct, IProgress<double> pr)
        {
            return _allPrimes(startNumber, endNumber, ct, pr).ToList();
        }
    }
}
