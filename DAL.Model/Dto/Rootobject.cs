using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Dto
{
    [DataContract]
    public class Rootobject
    {
        [DataMember]
        public bool success { get; set; }
        [DataMember]
        public string message { get; set; }
        public List<Result> result { get; set; }
    }
}
