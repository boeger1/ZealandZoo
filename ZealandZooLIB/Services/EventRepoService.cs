using System.Data.SqlClient;
using ZealandZooLIB.Exception;
using ZealandZooLIB.Helper;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services;

public class EventRepoService : IRepositoryService
{
    /// <summary>
    /// (mate by matias)
    /// This method selects the given parameters from the event table, 
    /// for each event and returns all events whit their information
    /// </summary>
    /// <returns></returns>
    public List<BaseModel> GetAll()
    {
        var conn = new SqlConnection(Secret.GetSecret());
        conn.Open();

        var sql = "SELECT " +
                  "[Id]," +
                  "[Name]," +
                  "[Description]," +
                  "[Date_To]," +
                  "[Date_From]," +
                  "[Max_Guest]," +
                  "[Guests]," +
                  "[Price]," +
                  "[Image_Id]" +
                  "FROM" +
                  "[bullerbob_dk_db_zealandzoo].[dbo].[Event]";

        var cmd = new SqlCommand(sql, conn);

        var reader = cmd.ExecuteReader();

        var events = new List<BaseModel>();

        while (reader.Read()) events.Add(ReadEvent(reader));

        conn.Close();

        return events;
    }
    
    /// <summary>
    /// (made by matias)
    /// when you chose the event you will only get the information on the one you chose. 
    /// The method looks on the id for the event then fiend that specific event in the table whit that id,
    /// and returns only the information which it contains.
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
                  "[Description]," +
                  "[Date_To]," +
                  "[Date_From]," +
                  "[Max_Guest]," +
                  "[Guests]," +
                  "[Price]," +
                  "[Image_Id]" +
                  "FROM" +
                  "[bullerbob_dk_db_zealandzoo].[dbo].[Event]" +
                  "WHERE" +
                  $"[Id] = {id}";

        var cmd = new SqlCommand(sql, conn);

        var reader = cmd.ExecuteReader();

        var events = new List<Event>();
        while (reader.Read()) events.Add(ReadEvent(reader));

        conn.Close();

        return events[0];
    }


    public BaseModel Create(BaseModel model)
    {
        var zooevent = (Event)model;
        var queryString =
            "Insert into Event values(@Name,@Description,@Date_To,@Date_From,@Max_Guest,@Guests,@Price,@Image_Id)";

        using var createcommand = new SqlConnection(Secret.GetSecret());
        {
            createcommand.Open();
            var command = new SqlCommand(queryString, createcommand);


            command.Parameters.AddWithValue("@Name", zooevent.Name);
            command.Parameters.AddWithValue("@Description", zooevent.Description);
            command.Parameters.AddWithValue("@Date_To", zooevent.DateTo);
            command.Parameters.AddWithValue("@Date_From", zooevent.DateFrom);
            command.Parameters.AddWithValue("@Max_Guest", zooevent.MaxGuest);
            command.Parameters.AddWithValue("@Guests", zooevent.Guests);
            command.Parameters.AddWithValue("@Price", zooevent.Price);


            if (zooevent.ImageId == 0)
                command.Parameters.AddWithValue("@Image_Id", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Image_Id", zooevent.ImageId);


            var rows = command.ExecuteNonQuery();

            if (rows != 1) throw new ArgumentException("Event er ikke oprettet");

            createcommand.Close();

            return model;
        }
    }

    public BaseModel Update(int id, BaseModel model)
    {
        var zooEvent = (Event)model;

        var queryUpdate = "UPDATE [dbo].[Event] SET " +
                          "[Name] = @Name," +
                          "[Description] = @Description," +
                          "[Date_To] = @Date_To," +
                          "[Date_From] = @Date_From," +
                          "[Max_Guest] = @Max_Guest," +
                          "[Guests] = @Guests," +
                          "[Price] = @Price " +
                          $"WHERE Id = {id}";


        using var createcommand = new SqlConnection(Secret.GetSecret());
        {
            createcommand.Open();
            var command = new SqlCommand(queryUpdate, createcommand);

            command.Parameters.AddWithValue("@Name", zooEvent.Name);
            command.Parameters.AddWithValue("@Description", zooEvent.Description);
            command.Parameters.AddWithValue("@Date_To", zooEvent.DateTo);
            command.Parameters.AddWithValue("@Date_From", zooEvent.DateFrom);
            command.Parameters.AddWithValue("@Max_Guest", zooEvent.MaxGuest);
            command.Parameters.AddWithValue("@Guests", zooEvent.Guests);
            command.Parameters.AddWithValue("@Price", zooEvent.Price);

            try
            {
                var rows = command.ExecuteNonQuery();


                if (rows != 1) throw new ArgumentException("Event er ikke Updateret");

                createcommand.Close();
            }
            catch (SqlException sqle)
            {
                foreach (var error in sqle.Errors)
                    if (error.ToString().Contains("CheckGuestsNotGreaterThanMax"))
                        throw new ZooException(ZooErrorCode.SQL_CheckGuestsNotGreaterThanMax, sqle.StackTrace);
            }

            return model;
        }
    }

    /// <summary>
    /// (made by matias)
    /// This will delete the chosen event the way it knows which event to delete is by looking on the id for the event,
    /// and then remove all values for the event whit that id from the table.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public BaseModel Delete(int id)
    {
        var zooEvent = (Event)GetById(id);

        var queryString = "Delete from Event where id = @Id";

        using var Deletecommand = new SqlConnection(Secret.GetSecret());
        {
            var command = new SqlCommand(queryString, Deletecommand);
            command.Connection.Open();
            command.Parameters.AddWithValue("@Id", id);

            var rows = command.ExecuteNonQuery();

            return zooEvent;
        }
    }

    private Event ReadEvent(SqlDataReader reader)
    {
        var zooEvent = new Event();

        zooEvent.Id = reader.GetInt32(0);
        zooEvent.Name = reader.GetString(1);
        zooEvent.Description = reader.GetString(2);
        zooEvent.DateTo = reader.GetDateTime(3);
        zooEvent.DateFrom = reader.GetDateTime(4);
        zooEvent.MaxGuest = reader.GetInt32(5);
        zooEvent.Guests = reader.GetInt32(6);
        zooEvent.Price = reader.GetDouble(7);
        zooEvent.ImageId = DataReaderHelper.SafeInt32Get(reader, 8);

        return zooEvent;
    }
}