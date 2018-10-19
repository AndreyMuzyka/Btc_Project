using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TimeTypeRepository
    {
        public List<TimeType> TimeTypes { get; set; }

        public TimeTypeRepository()
        {
            TimeTypes = new List<TimeType>();

            TimeTypes.Add(new TimeType() {Id = "1",Title = "Дни"});
            TimeTypes.Add(new TimeType() { Id = "1", Title = "Часы" });
            TimeTypes.Add(new TimeType() { Id = "1", Title = "Минуты" });
            TimeTypes.Add(new TimeType() { Id = "1", Title = "Секунды" });
        }
    }
}
