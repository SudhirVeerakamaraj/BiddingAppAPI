using Microsoft.AspNet.SignalR.Client;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiddingApp
{
    public class main
    {
        public static void Main(string[] args) {
            string baseAddress = "http://localhost:9123";
            using (WebApp.Start<Startup>(url: baseAddress)) {
                var hubConnection = new HubConnection(baseAddress);
                IHubProxy hubProxy = hubConnection.CreateHubProxy("BiddingHub");
                hubProxy.On<String>("OnEvent", (eventName) =>
                {
                    Console.Write($"Event name is {eventName}");
                });

                hubConnection.Start().Wait();
                Console.WriteLine("Press <enter> to stop server");
                Console.ReadLine();
            }
        }
    }
}