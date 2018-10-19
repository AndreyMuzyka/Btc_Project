using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Entity
{
    public class Bittrex : BaseEntity
    {
        public string MarketName { get; set; }
        public float BaseVolume { get; set; }
        public float Bid { get; set; }
        public float Ask { get; set; }
        public DateTime Created { get; set; }

        public MarketType MarketType { get; set; }
    }
}
