using Btc.Modeles;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Btc.Algoritm
{
    public class GradientCalculate
    {
        private DbEntities _context;

        //private MarketTypeDto _marketType;

        //private PeriodDto _period;

        private ResultDto _result;

        private TotalUnionDto _totalUnionDto;

        private DateTime _dateTimeNow;

        //private DateTime _dateTimeForPeriodOne;

        public GradientCalculate(TotalUnionDto totalUnionDto)
        {
           
            _context = new DbEntities();
            _totalUnionDto = totalUnionDto;
            _dateTimeNow = new DateTime(2018,10,8,18,56,20);
            //_dateTimeNow = DateTime.Now;


        }

        public TotalUnionDto GetResult()
        {
            TotalUnionDto totalUnionDto = new TotalUnionDto();
            var calculate = Calculate(_totalUnionDto, _totalUnionDto.PeriodOne, "1");
            totalUnionDto.Results.AddRange(calculate);
            return totalUnionDto;
        }

        private DateTime GetDateTimeForPeiod(PeriodDto period)
        {
            var dateTimeForPeriod = new DateTime();
            //days
            if (period.CurrentTimeType == "1")
            {
                dateTimeForPeriod = _dateTimeNow.AddDays(period.CurrentTimeValue);
            }
            //hours
            if (period.CurrentTimeType == "2")
            {
                dateTimeForPeriod = _dateTimeNow.AddHours(period.CurrentTimeValue);
            }
            //Minutes
            if (period.CurrentTimeType == "3")
            {
                dateTimeForPeriod = _dateTimeNow.AddMinutes(period.CurrentTimeValue);
            }
            //Seconds
            if (period.CurrentTimeType == "4")
            {
                dateTimeForPeriod = _dateTimeNow.AddSeconds(period.CurrentTimeValue);
            }

            return dateTimeForPeriod;
        }

        private List<ResultDto> Calculate(TotalUnionDto totalUnionDto ,PeriodDto periodDto,string periodNumber)
        {
            List<ResultDto> resulList = new List<ResultDto>();
            var dateTimeForPeriod = GetDateTimeForPeiod(periodDto);
            int timeFault = 10;
            
            foreach (var element in totalUnionDto.MarketTypes)
            {
                var bitrexForDateTimeNow = _context.Bittrexes
                    .Where(w => ((w.Created.Year == _dateTimeNow.Year &&
                                  w.Created.Month == _dateTimeNow.Month &&
                                  w.Created.Day == _dateTimeNow.Day &&
                                  w.Created.Hour == _dateTimeNow.Hour &&
                                  w.Created.Minute == _dateTimeNow.Minute &&
                                  w.Created.Second >= _dateTimeNow.Second)
                                 ||
                                 (w.Created.Year == _dateTimeNow.Year &&
                                  w.Created.Month == _dateTimeNow.Month &&
                                  w.Created.Day == _dateTimeNow.Day &&
                                  w.Created.Hour == _dateTimeNow.Hour &&
                                  w.Created.Minute == _dateTimeNow.Minute &&
                                  w.Created.Second >= _dateTimeNow.Second+timeFault))
                                &&
                                w.MarketName == element.MarketTypeTitle)
                    .ToList()
                    .FirstOrDefault();
                var bitrexForPeriod = _context.Bittrexes
                    .Where(w => ((w.Created.Year == dateTimeForPeriod.Year &&
                                  w.Created.Month == dateTimeForPeriod.Month &&
                                  w.Created.Day == dateTimeForPeriod.Day &&
                                  w.Created.Hour == dateTimeForPeriod.Hour &&
                                  w.Created.Minute == dateTimeForPeriod.Minute &&
                                  w.Created.Second >= dateTimeForPeriod.Second)
                                 ||
                                 (w.Created.Year == dateTimeForPeriod.Year &&
                                  w.Created.Month == dateTimeForPeriod.Month &&
                                  w.Created.Day == dateTimeForPeriod.Day &&
                                  w.Created.Hour == dateTimeForPeriod.Hour &&
                                  w.Created.Minute == dateTimeForPeriod.Minute &&
                                  w.Created.Second <= dateTimeForPeriod.Second+timeFault))
                                &&
                                w.MarketName == element.MarketTypeTitle)
                    .ToList()
                    .FirstOrDefault();

                if (bitrexForDateTimeNow.Ask >= _totalUnionDto.Volume && bitrexForPeriod.Ask >= _totalUnionDto.Volume)
                {
                    var gradient = Convert.ToInt32((bitrexForDateTimeNow.Ask / bitrexForPeriod.Ask - 1) * 100);

                    _result = new ResultDto();

                    _result.MarketType = element.MarketTypeTitle;
                    _result.CalculateDate=DateTime.Now;
                    _result.Gradient = gradient;
                    _result.Period = periodNumber;

                    resulList.Add(_result);
                }
            }
            
            return resulList;
        }


    }
}
