    using System.Data.SqlClient;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services;

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
                            "[Price]," +
                            "[Quantity]" +
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
        using SqlConnection conn = new SqlConnection(Secret.GetSecret());
        {
            conn.Open();
            SqlCommand command = new SqlCommand(queryString, conn);
            StorageItem item = (StorageItem)model;

            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Item_Type", item.Item_Type.ToString());
            command.Parameters.AddWithValue("@Price", item.Price);
            command.Parameters.AddWithValue("@Quantity", item.Quantity);



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
        StorageItem deleteItem = (StorageItem)GetById(id);

        string queryString = "DELETE FROM StorageItem WHERE id = @Id";

        using SqlConnection conn = new SqlConnection(Secret.GetSecret());
        {
            SqlCommand command = new SqlCommand(queryString, conn);
            command.Connection.Open();
            command.Parameters.AddWithValue("@Id", id);

            int rows = command.ExecuteNonQuery();

            return deleteItem;
        }


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
                            "[Quantity]" +
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

        if (items.Count > 0)
        {
            return items[0];
        }
        else
        {
            throw new ArgumentException("Vare ikke fundet");
        }
        
    }


    public BaseModel Update(int id, BaseModel model)
    {
        string queryString = "UPDATE StorageItem" + "SET Name = @Name, Item_Type = @Item_Type, Price = @Price, Quantity = @Quantity" + "WHERE Id = @Id";

        using SqlConnection conn = new SqlConnection(Secret.GetSecret());
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryString, conn);
            StorageItem item = (StorageItem)model;
            cmd.Parameters.AddWithValue("@Name", item.Name);
            cmd.Parameters.AddWithValue("@Item_Type", item.Item_Type.ToString());
            cmd.Parameters.AddWithValue("@Price", item.Price);
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);



            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                model.Id = id;
            }
            else
            {
                throw new ArgumentException("Vare ikke opdateret");
            }

            return model;

        }

    }


    public BaseModel UpdateQuantity(int id, BaseModel model)
    {
        string queryString = "UPDATE StorageItem SET Quantity = @Quantity WHERE Id = @Id";

        using SqlConnection conn = new SqlConnection(Secret.GetSecret());
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(queryString, conn);
            StorageItem item = (StorageItem)model;
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
            cmd.Parameters.AddWithValue("@Id", id);



            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                model.Id = id;
            }
            else
            {
                throw new ArgumentException("Antal ikke opdateret");
            }

            return model;

        }
    }

    public async Task UpdateAsync(StorageItem item)
    {
        using (var connection = new SqlConnection(Secret.GetSecret()))
        {
            await connection.OpenAsync();
            StorageItem StorageItem = item;

            string queryString = "UPDATE StorageItem SET Quantity = @Quantity WHERE Id = @Id";
            using (var command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                command.Parameters.AddWithValue("@Id", item.Id);

                await command.ExecuteNonQueryAsync();

            }
        }

    }






    private StorageItem ReadStorageItem(SqlDataReader reader)
    {
        StorageItem item = new StorageItem();

        item.Id = reader.GetInt32(0);
        item.Name = reader.GetString(1);
        item.Item_Type = reader.IsDBNull(2) ? ItemType.Snack : Enum.Parse<ItemType>(reader.GetString(2));
        item.Price = reader.GetDouble(3);
        item.Quantity = reader.GetInt32(4);

        return item;
    }
}