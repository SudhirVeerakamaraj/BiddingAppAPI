using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace BiddingApp.Hubs
{
    public class BiddingHub : Hub
    {
       
        public void Hello()
        {
            Clients.All.hello();
        }
        public void GetBiddingValue()
        {
            Clients.Caller.setBiddingValue(232.32);
        }
        public override Task OnConnected()
        {
            Publish("CONNECTED");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            BiddingAppDAL.BiddingDetailDataAccess.RemoveFromBidding("AAA");
            Publish("REFRESH");
            return base.OnDisconnected(stopCalled);
        }
        public Task Publish(string eventName) {
            Clients.Caller.onEvent(eventName, BiddingAppDAL.BiddingDetailDataAccess.BiddingDetails);
            return Task.FromResult(0);
        }
    }
}