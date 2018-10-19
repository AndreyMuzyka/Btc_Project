using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btc.Modeles
{
    public class MarketTypeDto
    {
        public string MarketTypeTitle { get; set; }

        public double BaseVolume { get; set; }

        public bool IsActive { get; set; }
    }
}
