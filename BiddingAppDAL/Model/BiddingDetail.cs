using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingAppDAL.Model
{
    public class BiddingDetail
    {
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

        public bool isNew { get; set; }
    }
}
