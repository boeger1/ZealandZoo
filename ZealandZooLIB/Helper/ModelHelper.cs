using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.Helper
{
    public static class ModelHelper
    {

        //private const string SerializeKey = "SerializedObject";

        public static string SerializeBaseModel(BaseModel model)
        {
            return JsonConvert.SerializeObject(model);
        }

        public static Event? DeSerializeEvent(string model) 
        {
            return  JsonConvert.DeserializeObject<Event>(model);
        }
}
}
    
    

