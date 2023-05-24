using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Helper;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services
{
    public class ZooStudentRepoService : IRepositoryService
    {

        public List<BaseModel> GetAll()
        {
            var conn = new SqlConnection(Secret.GetSecret());
            conn.Open();

            var sql= "SELECT" +
                   "[Id]," +
                  "[First_Name]," +
                  "[Last_Name]," +
                  "[Image_Id]" + 
                  "FROM" +
                  "[bullerbob_dk_db_zealandzoo].[dbo].[ZooStudent]";

            var cmd = new SqlCommand(sql, conn);

            var reader = cmd.ExecuteReader();

            var items = new List<BaseModel>();
            while (reader.Read())
            {
                items.Add(ReadZooStudent(reader));
            }

            conn.Close();

            return items;


        }





        public BaseModel Create(BaseModel model)
        {
            var queryString = "INSERT INTO ZooStudent (First_Name, Last_Name, Image_Id) VALUES (@First_Name, @Last_Name, @Image_Id)";
            using var conn = new SqlConnection(Secret.GetSecret());
            {
                conn.Open();
                var command = new SqlCommand(queryString, conn);
                var item = (ZooStudent)model;

                command.Parameters.AddWithValue("@First_Name", item.First_Name);
                command.Parameters.AddWithValue("@Last_Name", item.Last_Name);

                if (item.ImageId == 0)
                { 
                    command.Parameters.AddWithValue("@Image_Id", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Image_Id", item.ImageId);
                }
                
                

               
                var rows = command.ExecuteNonQuery();
                if (rows != 1)
                {
                    throw new ArgumentException("Frivillig ikke oprettet");
                }

                conn.Close();

                return model;
            }

            
        }





        public BaseModel Delete(int id)
        {
            var deleteItem = (ZooStudent)GetById(id);

            var sql = "DELETE FROM ZooStudent WHERE id = @Id";

            using var conn = new SqlConnection(Secret.GetSecret());
            {
                var command = new SqlCommand(sql, conn);
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);

                var rows = command.ExecuteNonQuery();

                return deleteItem;
            }
        }

        

        public BaseModel GetById(int id)
        {
            var conn = new SqlConnection(Secret.GetSecret());
            conn.Open();

            var sql = "SELECT [Id], [First_Name], [Last_Name], [Image_Id] FROM [bullerbob_dk_db_zealandzoo].[dbo].[ZooStudent] WHERE" + $"[Id] = {id}";

            var cmd = new SqlCommand(sql, conn);

            var reader = cmd.ExecuteReader();

            var items = new List<ZooStudent>();
            while (reader.Read())
            {
                items.Add((ZooStudent)ReadZooStudent(reader));

            }
            conn.Close();

            if (items.Count > 0)
            {
                return items[0];
            }
            throw new ArgumentException("Frivillig ikke fundet");
        }





        public BaseModel Update(int id, BaseModel model)
        {
            var sql = "UPDATE ZooStudent SET First_Name = @First_Name, Last_Name = @Last_Name, Image_Id = @Image_Id WHERE Id = @Id";

            using var conn = new SqlConnection(Secret.GetSecret());
            {
                var cmd = new SqlCommand(sql, conn);
                var item = (ZooStudent)model;
                cmd.Parameters.AddWithValue("@First_Name", item.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", item.Last_Name);
                cmd.Parameters.AddWithValue("@Image_Id", item.ImageId);
                conn.Open();

                var rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ArgumentException("Frivillig ikke opdateret");
                }

                return model;
            }
        }







        private BaseModel ReadZooStudent(SqlDataReader reader)
        {
            var item = new ZooStudent();

            item.Id = reader.GetInt32(0);
            item.First_Name = reader.GetString(1);
            item.Last_Name = reader.GetString(2);
            item.ImageId = DataReaderHelper.SafeInt32Get(reader, 3);
            

            return item;
        }








    }
}
