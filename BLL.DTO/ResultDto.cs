using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ResultDto
    {
        public string MarketType { get; set; }

        public int Gradient { get; set; }

        public string Period { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
