using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace UnityWebApiDemo.Models
{
    public class Transaction : IDisposable
    {
        public string Id { get; }

        public List<string> Actions { get; }

        public Transaction()
        {
            Id = Guid.NewGuid().ToString();
            Actions = new List<string>();
            Actions.Add("Transaction created");
            Debug.WriteLine($"Transction {Id} is starting");
        }

        public void Dispose()
        {
            Debug.WriteLine($"Transction {Id} is ending");
            foreach (var item in Actions)
            {
                Debug.WriteLine(item);
            }
        }
    }
}