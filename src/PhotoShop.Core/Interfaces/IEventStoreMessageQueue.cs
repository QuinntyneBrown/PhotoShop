using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShop.Core.Interfaces
{
    public interface IEventStoreMessageQueue
    {
        Task<string> TryDequeue();
        void Enqueue(string message);
        int Count { get; }
    }
}
