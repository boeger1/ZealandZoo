using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandZooLIB.Models
{
    public class Day
    {
        public Event? ZooEvent { get; set; }
        public DateTime Date { get; init; }

        public Day(Event zooEvent, DateTime date)
        {
            ZooEvent = zooEvent;
            Date = date;
        }
    }
}
