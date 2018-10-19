using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Dto
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public string MarketName { get; set; }
        [DataMember]
        public float High { get; set; }
        [DataMember]
        public float Low { get; set; }
        [DataMember]
        public float Volume { get; set; }
        [DataMember]
        public float Last { get; set; }
        [DataMember]
        public float BaseVolume { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }
        [DataMember]
        public float Bid { get; set; }
        [DataMember]
        public float Ask { get; set; }
        [DataMember]
        public int OpenBuyOrders { get; set; }
        [DataMember]
        public int OpenSellOrders { get; set; }
        [DataMember]
        public float PrevDay { get; set; }
        [DataMember]
        public DateTime Created { get; set; }
    }
}
