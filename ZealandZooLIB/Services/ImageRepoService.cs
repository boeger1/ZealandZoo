using System.Data.SqlClient;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services;

/// <summary>
///     Peter
/// </summary>
public class ImageRepoService : EventRepoService
{
    /// <summary>
    ///     Peter
    /// </summary>
    /// <returns></returns>
    public List<BaseModel> GetAll()
    {
        var conn = new SqlConnection(Secret.GetSecret());
        conn.Open();


        var sql = "SELECT " +
                  "[Id]," +
                  "[Name]," +
                  "[image_path]" +
                  "[date_added]," +
                  "[type]" +
                  "FROM" +
                  "[bullerbob_dk_db_zealandzoo].[dbo].[Image]";

        var cmd = new SqlCommand(sql, conn);

        var reader = cmd.ExecuteReader();

        var items = new List<BaseModel>();
        while (reader.Read()) items.Add(ReadEventImage(reader));

        conn.Close();

        return items;
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public BaseModel GetById(int id)
    {
        var conn = new SqlConnection(Secret.GetSecret());
        conn.Open();

        var sql = "SELECT " +
                  "[Id]," +
                  "[Name]," +
                  "[image_path]," +
                  "[date_added]," +
                  "[type]" +
                  "FROM" +
                  "[bullerbob_dk_db_zealandzoo].[dbo].[Image]" +
                  "WHERE" +
                  $"[Id] = {id}";

        var cmd = new SqlCommand(sql, conn);

        var reader = cmd.ExecuteReader();

        var images = new List<ZooImage>();
        while (reader.Read()) images.Add(ReadEventImage(reader));

        conn.Close();

        return images[0];
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public BaseModel Delete(int id)
    {
        var queryString =
            $"DELETE FROM Image WHERE [id] = {id}";

        using var deleteCommand = new SqlConnection(Secret.GetSecret());
        {
            deleteCommand.Open();
            var command = new SqlCommand(queryString, deleteCommand);
            command.ExecuteNonQuery();
            deleteCommand.Close();
        }
        return null;
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public BaseModel Create(BaseModel model)
    {
        var image = (ZooImage)model;

        var queryString =
            "INSERT into Image ([name],[image_path],[type]) OUTPUT inserted.ID VALUES(@name,@image_path,@type)";

        using var createcommand = new SqlConnection(Secret.GetSecret());
        {
            createcommand.Open();
            var command = new SqlCommand(queryString, createcommand);

            command.Parameters.AddWithValue("@name", image.Name);
            command.Parameters.AddWithValue("@image_path", image.Path);
            command.Parameters.AddWithValue("@type", image.Type.ToString());


            var id = (int)command.ExecuteScalar();

            if (id <= 0) throw new ArgumentException("Image ikke oprettet");

            image.Id = id;

            createcommand.Close();
        }

        return image;
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public BaseModel Update(int id, BaseModel model)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    private ZooImage ReadEventImage(SqlDataReader reader)
    {
        var eventImage = new ZooImage();

        eventImage.Id = reader.GetInt32(0);
        eventImage.Name = reader.GetString(1);
        eventImage.Path = reader.GetString(2);
        eventImage.DateAdded = reader.GetDateTime(3);
        eventImage.Type = Enum.Parse<ImageType>(reader.GetString(4));

        return eventImage;
    }
}