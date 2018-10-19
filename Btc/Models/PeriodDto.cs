using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Btc.Modeles
{
    public class PeriodDto
    {
        public string Number { get; set; }

        public string CurrentTimeType { get; set; }

        public List<SelectListItem> TimeTipes { get; set; } 
        
        public int CurrentTimeValue { get; set; }

        public int Gradient { get; set; }

        public string GradientCollor { get; set; }

        public bool IsSound { get; set; }

        public PeriodDto()
        {
            TimeTipes = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = "1", Text = "День"
                },
                new SelectListItem()
                {
                    Value = "2", Text = "Час"
                },
                new SelectListItem()
                {
                    Value = "3", Text = "Мин."
                },
                new SelectListItem()
                {
                    Value = "4", Text = "Сек."
                }

            };
        }
    }
}
