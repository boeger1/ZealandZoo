namespace ZealandZooLIB.Models;

public class EventImage : BaseModel
{
    public string Name { get; set; }
    public DateTime DateAdded { get; set; }
    public string Path { get; set; }
    public ImageType Type { get; set; }

    public static bool IsImageNullOrEmpty(EventImage image)
    {
        if (image == null) return true;
        if (string.IsNullOrEmpty(image.Name) && string.IsNullOrEmpty(image.Path)) return true;

        return false;
    }
}