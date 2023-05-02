using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.Services
{
    public abstract class ServiceBase
    {

        public BullerbobDkDbZealandzooContext DB { get; set;}

        public ServiceBase()
        {

            DB = new BullerbobDkDbZealandzooContext();            

        }



    }
}
