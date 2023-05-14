namespace ZealandZooLIB.Models;

public class Bullet : BaseModel
{
	public string Title { get; set; } = null!;

	public string ContentBullet { get; set; } = null!;

	public Bullet()
	{
		Title = "default";
		ContentBullet= "default";
	}

	public Bullet(int id, string title, string contentBullet) 
	{
		Title = title;
		ContentBullet = contentBullet;
	}
}