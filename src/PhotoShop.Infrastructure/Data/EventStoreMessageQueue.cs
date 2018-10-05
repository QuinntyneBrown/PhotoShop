using PhotoShop.Core.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoShop.Infrastructure.Data
{
    public class EventStoreMessageQueue : IEventStoreMessageQueue
    {
        private ConcurrentQueue<string> _messages { get; set; } = new ConcurrentQueue<string>();
        private SemaphoreSlim _signal = new SemaphoreSlim(0);

        public void Enqueue(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            _messages.Enqueue(message);

            _signal.Release();

        }
        public async Task<string> TryDequeue()
        {
            await _signal.WaitAsync(default(CancellationToken));

            _messages.TryDequeue(out string result);

            return await Task.FromResult(result);
        }
    }
}
