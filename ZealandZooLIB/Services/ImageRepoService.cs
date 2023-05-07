using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Helper;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services
{
    public class ImageRepoService : IRepositoryService
    {
        public List<BaseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseModel GetById(int id)
        {
            SqlConnection conn = new SqlConnection(Secret.GetSecret());
            conn.Open();

            string sql = "SELECT " +
                         "[Id]," +
                         "[Name]," +
                         "[date_added]" +
                         "FROM" +
                         "[bullerbob_dk_db_zealandzoo].[dbo].[Image]" +
                         "WHERE" +
                         $"[Id] = {id}";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<EventImage> images = new List<EventImage>();
            while (reader.Read())
            {
                images.Add(ReadEventImage(reader));
            }

            conn.Close();

            return images[0];
        }

        public BaseModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BaseModel Create(BaseModel model)
        {
            EventImage image = (EventImage)model;

            string queryString =
                "INSERT into Image ([name],[image_path]) OUTPUT inserted.ID VALUES(@name,@image_path)";

            using SqlConnection createcommand = new SqlConnection(Secret.GetSecret());
            {
                createcommand.Open();
                SqlCommand command = new SqlCommand(queryString, createcommand);

                command.Parameters.AddWithValue("@name", image.Name);
                command.Parameters.AddWithValue("@image_path", image.Path);


                int id = (int)command.ExecuteScalar();

                if (id <= 0)
                {
                    throw new ArgumentException("Image ikke oprettet");
                }

                image.Id = id;

                createcommand.Close();
            }

            return image;
        }

        public BaseModel Update(int id, BaseModel model)
        {
            throw new NotImplementedException();
        }

        private EventImage ReadEventImage(SqlDataReader reader)
        {
            EventImage eventImage = new EventImage();

            eventImage.Id = reader.GetInt32(0);
            eventImage.Name = reader.GetString(1);
            eventImage.DateAdded = reader.GetDateTime(2);

            return eventImage;
        }
    }
}
