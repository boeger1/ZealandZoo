using System.Data.SqlClient;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

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
                         "[Describtion]," +
                         "[Date_To]," +
                         "[Date_From]," +
                         "[Max_Guest]," +
                         "[Price]" +
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
                         "[Describtion]," +
                         "[Date_To]," +
                         "[Date_From]," +
                         "[Max_Guest]," +
                         "[Price]" +
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

        public BaseModel Create(BaseModel model)
        {
            throw new NotImplementedException();
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
            zooEvent.Describtion = reader.GetString(2);
            zooEvent.DateTo = reader.GetDateTime(3);
            zooEvent.DateFrom = reader.GetDateTime(4);
            zooEvent.MaxGuest = reader.GetInt32(5);
            zooEvent.Price = reader.GetDouble(6);

            return zooEvent;
        }
    }
}
