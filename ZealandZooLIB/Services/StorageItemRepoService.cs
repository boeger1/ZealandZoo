using Azure.Identity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace ZealandZooLIB.Services
{
    public class StorageItemRepoService : EventRepoService
    { 
        public List<BaseModel> GetAll()
        {
            SqlConnection conn = new SqlConnection(Secret.GetSecret());
            conn.Open();

            string sql = "SELECT" +
                                "[Id]," +
                                "[Name]," +
                                "[Item_Type]," +
                                "[Price]" +
                         "FROM" +
                                "[bullerbob_dk_db_zealandzoo].[dbo].[StorageItem]";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<BaseModel> items = new List<BaseModel>();
            while (reader.Read())
            {
                items.Add(ReadStorageItem(reader));
            }

            conn.Close();

            return items;
        }

       
        public BaseModel Create(BaseModel model)
        {
            string queryString = "INSERT INTO StorageItem VALUES (@Name, @Item_Type, @Price)";
            using SqlConnection createCmd = new SqlConnection(Secret.GetSecret());
            {
                createCmd.Open();
                SqlCommand command = new SqlCommand(queryString, createCmd);
                StorageItem item = (StorageItem)model;

                command.Parameters.AddWithValue("@Name", item.Name);
                command.Parameters.AddWithValue("@Item_Type", item.Item_Type.ToString());
                command.Parameters.AddWithValue("@Price", item.Price);



                int rows = command.ExecuteNonQuery();
                if (rows != 1)
                {
                    throw new ArgumentException("Vare ikke oprettet");
                }

                return model;

            }
        }

        public BaseModel Delete(int id)
        {
            throw new NotImplementedException();
        }

       

        public BaseModel GetById(int id)
        {
            SqlConnection conn = new SqlConnection(Secret.GetSecret());
            conn.Open();

            string sql = "SELECT" +
                                "[Id]," +
                                "[Name]," +
                                "[Item_Type]," + 
                                "[Price]," +
                         "FROM" +
                                "[bullerbob_dk_db_zealandzoo].[dbo].[StorageItem]" +
                         "WHERE" + 
                                $"[Id] = {id}";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<StorageItem> items = new List<StorageItem>();
            while (reader.Read())
            {
                items.Add(ReadStorageItem(reader));
            }

            conn.Close();

            return items[0];
        }

        public BaseModel Update(int id, BaseModel model)
        {
            throw new NotImplementedException();
        }

        private StorageItem ReadStorageItem(SqlDataReader reader)
        {
            StorageItem item = new StorageItem();

            item.Id = reader.GetInt32(0);
            item.Name = reader.GetString(1);
            item.Item_Type = reader.IsDBNull(2) ? ItemType.Snack : Enum.Parse<ItemType>(reader.GetString(2));
            item.Price = reader.GetDouble(3);

            return item;
        }

        public BaseModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public BaseModel DeleteEvent(string name)
        {
            throw new NotImplementedException();
        }
    }

}
