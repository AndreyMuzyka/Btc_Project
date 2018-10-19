using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Btc.Models
{
    public class BittrexDto
    {
        public int Id { get; set; }
        public string MarketName { get; set; }
        public float BaseVolume { get; set; }
        public float Bid { get; set; }
        public float Ask { get; set; }
        public DateTime Created { get; set; }

        public float PriceNow { get; set; }
        public float PriceForPeriod { get; set; }


    }
}