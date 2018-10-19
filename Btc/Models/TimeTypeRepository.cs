using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btc.Modeles
{
    public class TimeTypeRepository
    {
        public List<TimeType> TimeTypes { get; set; }

        public TimeTypeRepository()
        {
            TimeTypes = new List<TimeType>();

            TimeTypes.Add(new TimeType() {Id = "1",Title = "Дни"});
            TimeTypes.Add(new TimeType() { Id = "2", Title = "Часы" });
            TimeTypes.Add(new TimeType() { Id = "3", Title = "Минуты" });
            TimeTypes.Add(new TimeType() { Id = "4", Title = "Секунды" });
        }
    }
}
