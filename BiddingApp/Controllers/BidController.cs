using BiddingApp.Hubs;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BiddingApp.Controllers
{
    [RoutePrefix("bid")]
    public class BidController : ApiController
    {
        private IHubContext _context;
        
        public BidController() {
            _context = GlobalHost.ConnectionManager.GetHubContext<BiddingHub>();
            
        }

        [Route("get")]
        [HttpGet]
        [ResponseType(typeof(IList<BiddingAppDAL.Model.BiddingDetail>))]
        public IHttpActionResult Get() {
            return Ok(BiddingAppDAL.BiddingDetailDataAccess.BiddingDetails);
        }

        [Route("post")]
        [HttpPost]
        public void Post([FromBody]JObject  inputData) {
            BiddingAppDAL.BiddingDetailDataAccess.AddToBidding(inputData["userName"].ToString(), Convert.ToDecimal(inputData["bidValue"]));
            _context.Clients.All.onEvent("BID_POSTED", BiddingAppDAL.BiddingDetailDataAccess.BiddingDetails);
        }

        [Route("delete")]
        [HttpPost]
        public void Delete([FromBody]JObject inputData) {
            BiddingAppDAL.BiddingDetailDataAccess.RemoveFromBidding(inputData["uniqueId"].ToString());
            _context.Clients.All.onEvent("BID_REMOVED", BiddingAppDAL.BiddingDetailDataAccess.BiddingDetails);
        }
    }
}
