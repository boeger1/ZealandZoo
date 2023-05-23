using System.Data.SqlClient;
using ZealandZooLIB.Helper;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services;

public class StudentRepoService : IRepositoryService
{
    public List<BaseModel> GetAll()
    {
        var conn = new SqlConnection(Secret.GetSecret());
        conn.Open();

        var sql = "SELECT" +
                  "[Id]," +
                  "[First_Name]," +
                  "[Last_Name]," +
                  "[Email]," +
                  "[Phone]," +
                  "[Subscribed] " +
                  "FROM" +
                  "[bullerbob_dk_db_zealandzoo].[dbo].[Student]";

        var cmd = new SqlCommand(sql, conn);

        var reader = cmd.ExecuteReader();

        var items = new List<BaseModel>();
        while (reader.Read()) items.Add(ReadStudent(reader));

        conn.Close();

        return items;
    }

    public BaseModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public BaseModel Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BaseModel Create(BaseModel model)
    {
        var student = (Student)model;

        var queryString =
            "INSERT INTO [dbo].[Student] ([First_Name],[Last_Name],[Email],[Phone],[Subscribed]) " +
            "OUTPUT inserted.ID VALUES" +
            "(@First_Name,@Last_Name,@Email,@Phone,@Subscribed)";

        using var createcommand = new SqlConnection(Secret.GetSecret());
        {
            createcommand.Open();
            var command = new SqlCommand(queryString, createcommand);

            if (student.FirstName == null)
                command.Parameters.AddWithValue("@First_Name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@First_Name", student.FirstName);

            if (student.FirstName == null)
                command.Parameters.AddWithValue("@Last_Name", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Last_Name", student.FirstName);

            command.Parameters.AddWithValue("@Email", student.Email);

            if (student.FirstName == null)
                command.Parameters.AddWithValue("@Phone", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Phone", student.Phone);

            command.Parameters.AddWithValue("@Subscribed", student.Subscribed);


            var id = (int)command.ExecuteScalar();

            if (id <= 0) throw new ArgumentException("Image ikke oprettet");

            student.Id = id;

            createcommand.Close();
        }

        return student;
    }

    public BaseModel Update(int id, BaseModel model)
    {
        var queryString =
            "UPDATE StorageItem " +
            "SET " +
            "[First_Name] = @First_Name," +
            "[Last_Name] = @Last_Name," +
            "[Email] = @Email," +
            "[Phone] = @Phone," +
            "[Subscribed] = @Subscribed," +
            "WHERE Id = @Id";

        using var conn = new SqlConnection(Secret.GetSecret());
        {
            var cmd = new SqlCommand(queryString, conn);
            var student = (Student)model;
            cmd.Parameters.AddWithValue("@Name", student.FirstName);
            cmd.Parameters.AddWithValue("@Last_Name", student.LastName);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Phone", student.Phone);
            cmd.Parameters.AddWithValue("@Subscribed", student.Subscribed);
            cmd.Parameters.AddWithValue("@Id", student.Id);
            conn.Open();

            var rows = cmd.ExecuteNonQuery();
            if (rows == 0) throw new ArgumentException("Student ikke opdateret");


            return model;
        }
    }

    private BaseModel ReadStudent(SqlDataReader reader)
    {
        var item = new Student();

        item.Id = reader.GetInt32(0);
        item.FirstName = DataReaderHelper.SafeGetString(reader, 1);
        item.LastName = DataReaderHelper.SafeGetString(reader, 2);
        item.Email = DataReaderHelper.SafeGetString(reader, 3);
        item.Phone = DataReaderHelper.SafeGetString(reader, 4);
        item.Subscribed = reader.GetBoolean(5);

        return item;
    }
}