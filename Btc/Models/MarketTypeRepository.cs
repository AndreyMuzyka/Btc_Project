using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btc.Modeles
{
    public class MarketTypeRepository
    {
        public List<MarketTypeDto> MarketTypes { get; set; }

        public MarketTypeRepository()
        {
            MarketTypes = new List<MarketTypeDto>();

            MarketTypes.Add(new MarketTypeDto() { MarketTypeTitle = "BTC-2GIVE", BaseVolume = 0.06174841, IsActive = true});

            MarketTypes.Add(new MarketTypeDto() { MarketTypeTitle = "BTC-ABY", BaseVolume = 1.118676, IsActive = true });

            MarketTypes.Add(new MarketTypeDto() { MarketTypeTitle = "BTC-ADA", BaseVolume = 88.77349, IsActive = true });

            MarketTypes.Add(new MarketTypeDto() { MarketTypeTitle = "BTC-ADT", BaseVolume = 7.858309, IsActive = true });

            MarketTypes.Add(new MarketTypeDto() { MarketTypeTitle = "BTC-ADX", BaseVolume = 15.80436, IsActive = true });

            MarketTypes.Add(new MarketTypeDto() { MarketTypeTitle = "BTC-AEON", BaseVolume = 0.9779395, IsActive = true });

            MarketTypes.Add(new MarketTypeDto() { MarketTypeTitle = "BTC-AID", BaseVolume = 0.7822131, IsActive = true });

            MarketTypes.Add(new MarketTypeDto() { MarketTypeTitle = "BTC-AMP", BaseVolume = 20.1529, IsActive = true });

            MarketTypes.Add(new MarketTypeDto() { MarketTypeTitle = "BTC-BAT", BaseVolume = 54.35674, IsActive = true });

            MarketTypes.Add(new MarketTypeDto() { MarketTypeTitle = "BTC-BCH", BaseVolume = 74.42785, IsActive = true });
        }
    }
}
