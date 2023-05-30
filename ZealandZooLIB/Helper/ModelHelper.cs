using Newtonsoft.Json;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.Helper;

/// <summary>
///     Peter
/// </summary>
public static class ModelHelper
{
    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static string SerializeBaseModel(BaseModel model)
    {
        return JsonConvert.SerializeObject(model);
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public static Event? DeSerializeEvent(string json)
    {
        return JsonConvert.DeserializeObject<Event>(json);
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public static Student? DeSerializeStudent(string json)
    {
        return JsonConvert.DeserializeObject<Student>(json);
    }
}