using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ZealandZooLIB.Services
{
    public class EventRepoService : IRepositoryService
    {
        
        public List<BaseModel> GetAll()
        {
            SqlConnection conn = new SqlConnection(Secret.GetSecret());
            conn.Open();

            string sql = "SELECT " +
                         "[Id]," +
                         "[Name]," +
                         "[Description]," +
                         "[Date_To]," +
                         "[Date_From]," +
                         "[Max_Guest]," +
                         "[Price]" +
                         "[Image_Id]" +
                         "FROM" +
                         "[bullerbob_dk_db_zealandzoo].[dbo].[Event]";



            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<BaseModel> events = new List<BaseModel>();
            while (reader.Read())
            {
                events.Add(ReadEvent(reader));
            }

            conn.Close();

            return events;

        }

        public BaseModel GetById(int id)
        {
            SqlConnection conn = new SqlConnection(Secret.GetSecret());
            conn.Open();

            string sql = "SELECT " +
                         "[Id]," +
                         "[Name]," +
                         "[Description]," +
                         "[Date_To]," +
                         "[Date_From]," +
                         "[Max_Guest]," +
                         "[Price]" +
                         "[Image_Id]" +
                         "FROM" +
                         "[bullerbob_dk_db_zealandzoo].[dbo].[Event]" +
                         "WHERE" +
                         $"[Id] = {id}";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Event> events = new List<Event>();
            while (reader.Read())
            {
                events.Add(ReadEvent(reader));

            }

            conn.Close();

            return events[0];
        }

        public BaseModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BaseModel Create (BaseModel model)
        {
            string queryString = "Insert into Event values(@Name,@Description,@Date_To,@Date_From,@Max_Guest,@Price)";
            using SqlConnection createcommand = new SqlConnection(Secret.GetSecret());
            {
                createcommand.Open();
                SqlCommand command = new SqlCommand(queryString, createcommand);
                Event zooevent = (Event) model;
                
                command.Parameters.AddWithValue("@Name", zooevent.Name);
                command.Parameters.AddWithValue("@Description", zooevent.Description);               
                command.Parameters.AddWithValue("@Date_To", zooevent.DateTo);
                command.Parameters.AddWithValue("@Date_From", zooevent.DateFrom);
                command.Parameters.AddWithValue("@Max_Guest", zooevent.MaxGuest);
                command.Parameters.AddWithValue("@Price", zooevent.Price);



                int rows = command.ExecuteNonQuery();

                if (rows != 1)
                {
                    throw new ArgumentException("Event er ikke oprettet");
                }

                return model;
            }

        }

        public BaseModel Update(int id, BaseModel model)
        {
            throw new NotImplementedException();
        }

        private Event ReadEvent(SqlDataReader reader)
        {
            Event zooEvent = new Event();

            zooEvent.Id = reader.GetInt32(0);
            zooEvent.Name = reader.GetString(1);
            zooEvent.Description = reader.GetString(2);
            zooEvent.DateTo = reader.GetDateTime(3);
            zooEvent.DateFrom = reader.GetDateTime(4);
            zooEvent.MaxGuest = reader.GetInt32(5);
            zooEvent.Price = reader.GetDouble(6);
            zooEvent.ImageId = reader.GetInt32(7);

            return zooEvent;
        }
    }
}
