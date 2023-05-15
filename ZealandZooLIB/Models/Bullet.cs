namespace ZealandZooLIB.Models;

public class Bullet : BaseModel
{
	public int Id { get; set; }
	public string Title { get; set; } 

	public string Content_Bullet { get; set; } 

	public Bullet()
	{
		Title = "default";
		Content_Bullet= "default";
	}

	public Bullet(int id, string title, string content_Bullet) 
	{
		Id = id;
		Title = title;
		Content_Bullet = content_Bullet;
	}
}