namespace ZealandZooLIB.Models;

public class Bullet : BaseModel
{
	public int Id { get; set; }
	public string Title { get; set; } 

	public string ContentBullet { get; set; } 

	public Bullet()
	{
		Title = "default";
		ContentBullet= "default";
	}

	public Bullet(int id, string title, string contentBullet) 
	{
		Id = id;
		Title = title;
		ContentBullet = contentBullet;
	}
}