using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SignalRWorkbench.Hubs
{
    [HubName("pricesHub")]
    public class PricesHub : Hub
    {
        public void GetPrices()
        {
            var task = GetPricesAsync();

            
            task.ContinueWith(t => Clients.Caller.onPricesRecieved(t.Result.Timestamp));
        }

        private async Task<GetPricesResult> GetPricesAsync()
        {
            await Task.Run(() => Thread.Sleep(5000));

            return new GetPricesResult { Timestamp = DateTime.UtcNow };
        }
    }

    public class GetPricesResult
    {
        public DateTime Timestamp { get; set; }
    }
}