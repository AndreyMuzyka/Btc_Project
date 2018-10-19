using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btc.Modeles
{
    public class TotalUnionDto
    {
        public double Volume { get; set; }

        public PeriodDto PeriodOne { get; set; }

        public PeriodDto PeriodTwo { get; set; } 

        //public string PeriodThree { get; set; } = "3";

        //public string PeriodFour { get; set; } = "4";

        //public string PeriodFive { get; set; } = "5";

        //public string PeriodSix { get; set; } = "6";

        //public string PeriodSeven { get; set; } = "7";

        //public string PeriodEight { get; set; } = "8";

        //public string PeriodNine { get; set; } = "9";

        //public string PeriodTen { get; set; } = "10";

        //public string PeriodEleven { get; set; } = "11";

        //public string PeriodTwelve { get; set; } = "12";

        //public string PeriodThirteen { get; set; } = "13";

        //public string PeriodFourteen { get; set; } = "14";

        //public string PeriodFifteen { get; set; } = "15";

        public List<MarketTypeDto> MarketTypes { get; set; }

        //public List<PeriodDto> Periods { get; set; }

        public List<TimeType> TimeTypes { get; set; }

        public List<ResultDto> Results { get; set; }

        public TotalUnionDto()
        {
            MarketTypes = new List<MarketTypeDto>();

            var marketTypeRepository = new MarketTypeRepository();

            MarketTypes = marketTypeRepository.MarketTypes;

            //Periods = new List<PeriodDto>();
                      
            Results = new List<ResultDto>();

            //var timeTypeRepository =new TimeTypeRepository();

            //TimeTypes = new List<TimeType>();

            PeriodOne = new PeriodDto();
            PeriodTwo = new PeriodDto();


        }
    }
}
