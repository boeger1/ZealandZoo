using System.Data.SqlClient;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services;

public class BulletRepoService : IRepositoryService
{
    #region Create

    public BaseModel Create(BaseModel model)
    {
        var queryString = "INSERT INTO Bullet VALUES (@Title, @Content_Bullet)";
        using var conn = new SqlConnection(Secret.GetSecret());
        {
            conn.Open();
            var command = new SqlCommand(queryString, conn);
            var bullet = (Bullet)model;

            command.Parameters.AddWithValue("@Title", bullet.Title);
            command.Parameters.AddWithValue("@Content_Bullet", bullet.Content_Bullet);

            var rows = command.ExecuteNonQuery(); //syntax fejl??
            if (rows != 1) throw new ArgumentException("Artiklen kan ikke blive oprettet");


            conn.Close();

            return model;
        }
    }

    #endregion

    #region Delete

    public BaseModel Delete(int id)
    {
        var deleteBullet = (Bullet)GetById(id);

        var queryString = "DELETE FROM [dbo].[Bullet] WHERE id = @Id";

        using var conn = new SqlConnection(Secret.GetSecret());
        {
            var command = new SqlCommand(queryString, conn);
            command.Connection.Open();
            command.Parameters.AddWithValue("@Id", id);

            var rows = command.ExecuteNonQuery();
            return deleteBullet;
        }
    }

    #endregion

    #region GetAll

    public List<BaseModel> GetAll()
    {
        var conn = new SqlConnection(Secret.GetSecret());
        conn.Open();

        var sql = "SELECT" +
                  "[Id]," +
                  "[Title]," +
                  "[Content_Bullet]" +
                  "FROM" +
                  "[bullerbob_dk_db_zealandzoo].[dbo].[Bullet]";

        var cmd = new SqlCommand(sql, conn);
        var reader = cmd.ExecuteReader();

        var bullets = new List<BaseModel>();
        while (reader.Read()) bullets.Add(ReadBullet(reader));

        conn.Close();
        return bullets;
    }

    #endregion


    #region GetByID

    public BaseModel GetById(int id)
    {
        var conn = new SqlConnection(Secret.GetSecret());
        conn.Open();

        var sql = "SELECT" +
                  "[Id]," +
                  "[Title]," +
                  "[Content_Bullet]" +
                  "FROM" +
                  "[bullerbob_dk_db_zealandzoo].[dbo].[Bullet]" +
                  "WHERE" +
                  $"[Id] = {id}";

        var cmd = new SqlCommand(sql, conn);
        var reader = cmd.ExecuteReader();

        var bullets = new List<Bullet>();
        while (reader.Read()) bullets.Add(ReadBullet(reader));
        conn.Close();

        if (bullets.Count > 0)
            return bullets[0];
        throw new ArgumentException("Artiklen ikke fundet");
    }

    #endregion

    #region Update

    public BaseModel Update(int id, BaseModel model)
    {
        var queryString = "UPDATE Bullet SET [Title] = @Title, Content_Bullet = @Content_Bullet WHERE Id = @Id";
        using var conn = new SqlConnection(Secret.GetSecret());
        {
            conn.Open();
            var cmd = new SqlCommand(queryString, conn);
            var bullet = (Bullet)model;
            cmd.Parameters.AddWithValue("@Title", bullet.Title);
            cmd.Parameters.AddWithValue("@Content_Bullet", bullet.Content_Bullet);
            cmd.Parameters.AddWithValue("@Id", bullet.Id);

            var rows = cmd.ExecuteNonQuery();
            if (rows == 0) throw new ArgumentException("Artikel ikke opdateret");

            return model;
        }
    }

    #endregion

    private Bullet ReadBullet(SqlDataReader reader)
    {
        var bullet = new Bullet();

        bullet.Id = reader.GetInt32(0);
        bullet.Title = reader.GetString(1);
        bullet.Content_Bullet = reader.GetString(2);

        return bullet;
    }
}