using Azure.Identity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;


namespace ZealandZooLIB.Services
{
    public class StorageItemRepoService : IRepositoryService
    { 
        public List<BaseModel> GetAll()
        {
            SqlConnection conn = new SqlConnection(Secret.GetSecret());
            conn.Open();

            string sql = "SELECT" +
                                "[Id]" +
                                "[Name]" +
                                "[Type]" +
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
            string queryString = "INSERT INTO StorageItem VALUES(@Name, @Type, @Price)";
            using SqlConnection createCmd = new SqlConnection(Secret.GetSecret());
            {
                createCmd.Open();
                SqlCommand command = new SqlCommand(@queryString, createCmd);
                StorageItem item = (StorageItem) model;

                command.Parameters.AddWithValue("@Name", item.Name);

                //try
                //{
                //    command.Parameters.AddWithValue("@Type", ItemType.SoftDrink.ToString());
                //}
                //catch (Exception ex)
                //{
                //    throw new ArgumentException("Type ikke gyldig");
                //}

                int itemTypeValue;
                if (Enum.TryParse(item.Type.ToString(), out itemTypeValue))
                {
                    command.Parameters.AddWithValue("@Type", itemTypeValue);
                }
                else
                {
                    throw new ArgumentException("Type ikke gyldig");
                }
                command.Parameters.AddWithValue("@Price", item.Price);
                
                int rows = command.ExecuteNonQuery();
                if (rows != 1)
                {
                    throw new ArgumentException("Varer ikke oprettet");
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
                                "[Id]" +
                                "[Name]" +
                                "[Type]" + 
                                "[Price]" +
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
            item.Type = (ItemType)reader.GetInt32(2);
            item.Price = reader.GetInt32(3);

            return item;
        }
    }

}
