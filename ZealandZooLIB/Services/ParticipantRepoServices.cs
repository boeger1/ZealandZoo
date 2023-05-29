using System.Data.SqlClient;
using ZealandZooLIB.Exception;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services;

/// <summary>
///     Peter
/// </summary>
public class ParticipantRepoServices
{
    /// <summary>
    ///     Peter
    /// </summary>
    /// <returns></returns>
    public List<BaseModel> GetAll()
    {
        var conn = new SqlConnection(Secret.GetSecret());
        conn.Open();


        var sql =
            "SELECT [event_id],[student_id],[student_email],[participants] FROM [bullerbob_dk_db_zealandzoo].[dbo].[EventParticipants]";

        var cmd = new SqlCommand(sql, conn);

        var reader = cmd.ExecuteReader();

        var items = new List<BaseModel>();
        while (reader.Read()) items.Add(ReadParticipant(reader));

        conn.Close();

        return items;
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<ParticipantSignUp> GetByEventId(int id)
    {
        var conn = new SqlConnection(Secret.GetSecret());
        conn.Open();


        var sql =
            $"SELECT [event_id],[student_id],[student_email],[participants] FROM [bullerbob_dk_db_zealandzoo].[dbo].[EventParticipants] WHERE [event_id] = {id}";

        var cmd = new SqlCommand(sql, conn);

        var reader = cmd.ExecuteReader();

        var items = new List<ParticipantSignUp>();
        while (reader.Read()) items.Add((ParticipantSignUp)ReadParticipant(reader));

        conn.Close();

        return items;
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public BaseModel DeleteByEventId(int id)
    {
        var queryString =
            $"DELETE FROM [bullerbob_dk_db_zealandzoo].[dbo].[EventParticipants] WHERE [event_id] = {id}";

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
    /// <param name="participantSignUpnUp"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ZooException"></exception>
    public ParticipantSignUp Create(ParticipantSignUp participantSignUpnUp)
    {
        var signUp = participantSignUpnUp;
        var queryString =
            "INSERT INTO [dbo].[EventParticipants] ([event_id],[student_id],[student_email],[participants]) VALUES(@event_id,@student_id,@student_email,@participants)";

        using var createCommand = new SqlConnection(Secret.GetSecret());
        {
            createCommand.Open();
            var command = new SqlCommand(queryString, createCommand);

            command.Parameters.AddWithValue("@event_id", signUp.ZooEvent.Id);
            command.Parameters.AddWithValue("@student_id", signUp.Student.Id);
            command.Parameters.AddWithValue("@student_email", signUp.Student.Email);
            command.Parameters.AddWithValue("@participants", signUp.Participants);

            try
            {
                var rows = command.ExecuteNonQuery();

                if (rows != 1) throw new ArgumentException("Tilmelding er ikke oprettet");
            }
            catch (SqlException ex)
            {
                throw new ZooException(ZooErrorCode.SQL_Duplicate_Key);
            }

            createCommand.Close();

            return null;
        }
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    private ParticipantSignUp ReadParticipant(SqlDataReader reader)
    {
        var signUp = new ParticipantSignUp();

        signUp.ZooEvent = new Event { Id = reader.GetInt32(0) };
        signUp.Student = new Student { Id = reader.GetInt32(1) };
        signUp.Student.Email = reader.GetString(2);
        signUp.Participants = reader.GetInt32(3);

        return signUp;
    }
}