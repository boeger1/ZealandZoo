using Newtonsoft.Json;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.Helper;

public static class ModelHelper
{
    public static string SerializeBaseModel(BaseModel model)
    {
        return JsonConvert.SerializeObject(model);
    }

    public static Event? DeSerializeEvent(string json)
    {
        return JsonConvert.DeserializeObject<Event>(json);
    }

    public static Student? DeSerializeStudent(string json)
    {
        return JsonConvert.DeserializeObject<Student>(json);
    }
}