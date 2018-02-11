using BiddingAppDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingAppDAL
{
    public class BiddingDetailDataAccess
    {
        private static List<BiddingDetail> _biddingDetails;

        public static List<BiddingDetail> BiddingDetails
        {
            get {
                if (_biddingDetails == null) {
                    _biddingDetails = new List<BiddingDetail>();
                    InitialiseBiddingDetail();
                }
                return _biddingDetails.OrderBy(_=>_.Value).ToList();
            }
        }

        public static void AddToBidding(string userName, decimal biddingValue) {
            FlipExistingNewBid();
            var newBid = new BiddingDetail()
            {
                UniqueId = new Guid(),
                Name = userName,
                Value = biddingValue,
                isNew = true
            };
            _biddingDetails.Add(newBid);
        }

        public static void RemoveFromBidding(string uniqueId) {
            if (_biddingDetails?.Any(_=> _.UniqueId.ToString() == uniqueId) == true)
            {
                var indexToRemove = _biddingDetails.FindIndex(_ => _.UniqueId.ToString() == uniqueId);
                _biddingDetails.RemoveAt(indexToRemove);
            }
        }

        private static IList<BiddingDetail> InitialiseBiddingDetail() {

            _biddingDetails.Add(new BiddingDetail() {
                UniqueId = new Guid(),
                Name = "AAA",
                Value = 125,
                isNew = false
            });
            _biddingDetails.Add(new BiddingDetail()
            {
                UniqueId = new Guid(),
                Name = "BBB",
                Value = 125,
                isNew = false
            });
            _biddingDetails.Add(new BiddingDetail()
            {
                UniqueId = new Guid(),
                Name = "CCC",
                Value = 234,
                isNew = false
            });
            _biddingDetails.Add(new BiddingDetail()
            {
                UniqueId = new Guid(),
                Name = "DDD",
                Value = 346,
                isNew = false
            });

            return _biddingDetails;
        }

        /** 
            Make the existing isNew as false as a new bid has come in
         */
        private static void FlipExistingNewBid() {
            if (BiddingDetails.Any(_ => _.isNew)) {
                BiddingDetails.Find(_ => _.isNew).isNew = false;
            }
        }

        
    }
}
