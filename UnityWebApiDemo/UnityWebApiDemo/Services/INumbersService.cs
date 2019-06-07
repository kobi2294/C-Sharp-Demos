using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityWebApiDemo.Services
{
    public interface INumbersService
    {
        IEnumerable<int> GenerateRandomNumbers();
    }
}
