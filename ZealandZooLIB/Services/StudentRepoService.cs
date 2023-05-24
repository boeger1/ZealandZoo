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

    public List<BaseModel> GetStudentsWithNewsletter()
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
                  "[bullerbob_dk_db_zealandzoo].[dbo].[Student] " +
                  "WHERE" +
                  "[Subscribed] = 1";

        var cmd = new SqlCommand(sql, conn);

        var reader = cmd.ExecuteReader();

        var items = new List<BaseModel>();
        while (reader.Read()) items.Add(ReadStudent(reader));

        conn.Close();

        return items;
    }

    public Student? NewsLetterSignUp(Student student)
    {
        var s = GetById(student.Id);
        if (s is null)
        {
            Create(student);
            return student;
        }
        Update(student.Id, student);
        return student;
        
    }

    public BaseModel? GetById(int id)
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
                  "FROM " +
                  "[bullerbob_dk_db_zealandzoo].[dbo].[Student] " +
                  "WHERE " +
                  $"[Id] = {id}";

        var cmd = new SqlCommand(sql, conn);

        var reader = cmd.ExecuteReader();

        var students = new List<Student>();
        while (reader.Read()) students.Add(ReadStudent(reader));

        conn.Close();

        if (students.Count > 0)
        {
            return students[0];
        }

        return null;
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
            "UPDATE [bullerbob_dk_db_zealandzoo].[dbo].[Student] " +
            "SET " +
            "[First_Name] = @First_Name," +
            "[Last_Name] = @Last_Name," +
            "[Email] = @Email," +
            "[Phone] = @Phone," +
            "[Subscribed] = @Subscribed " +
            $"WHERE Id = {id}";

        using var conn = new SqlConnection(Secret.GetSecret());
        {
            var command = new SqlCommand(queryString, conn);
            var student = (Student)model;

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
            conn.Open();

            var rows = command.ExecuteNonQuery();
            if (rows == 0) throw new ArgumentException("Student ikke opdateret");


            return model;
        }
    }

    public void NewsLetterUnSubscribe(string email)
        {
            var queryString =
                "UPDATE [bullerbob_dk_db_zealandzoo].[dbo].[Student] " +
                "SET " +
                "[Subscribed] = @Subscribed " +
                $"WHERE Email = '{email}'";

            using var conn = new SqlConnection(Secret.GetSecret());
            {
                var command = new SqlCommand(queryString, conn);

                command.Parameters.AddWithValue("@Subscribed", 0);
                conn.Open();

                var rows = command.ExecuteNonQuery();
            }
        }

    private Student ReadStudent(SqlDataReader reader)
    {
        var student = new Student();

        student.Id = reader.GetInt32(0);
        student.FirstName = DataReaderHelper.SafeGetString(reader, 1);
        student.LastName = DataReaderHelper.SafeGetString(reader, 2);
        student.Email = DataReaderHelper.SafeGetString(reader, 3);
        student.Phone = DataReaderHelper.SafeGetString(reader, 4);
        student.Subscribed = reader.GetBoolean(5);

        return student;
    }


}