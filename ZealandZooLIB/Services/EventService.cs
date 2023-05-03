using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.Services
{
    public class EventService : ServiceBase
    {

        public void CreateEvent (Event e)
        {
            Db.Events.Add (e);
            Db.SaveChanges();
        }

        public List<Event> GetEvents()
        {
            return Db.Events.ToList();
        }




    }
}
