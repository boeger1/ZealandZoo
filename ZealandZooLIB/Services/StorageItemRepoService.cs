using System.Data.SqlClient;
using ZealandZooLIB.Models;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services;

public class StorageItemRepoService : EventRepoService
{
	public List<BaseModel> GetAll()
	{
		var conn = new SqlConnection(Secret.GetSecret());
		conn.Open();

		var sql = "SELECT" +
		          "[Id]," +
		          "[Name]," +
		          "[Item_Type]," +
		          "[Price]" +
		          "FROM" +
		          "[bullerbob_dk_db_zealandzoo].[dbo].[StorageItem]";

		var cmd = new SqlCommand(sql, conn);

		var reader = cmd.ExecuteReader();

		var items = new List<BaseModel>();
		while (reader.Read()) items.Add(ReadStorageItem(reader));

		conn.Close();

		return items;
	}


	public BaseModel Create(BaseModel model)
	{
		var queryString = "INSERT INTO StorageItem VALUES (@Name, @Item_Type, @Price)";
		using var createCmd = new SqlConnection(Secret.GetSecret());
		{
			createCmd.Open();
			var command = new SqlCommand(queryString, createCmd);
			var item = (StorageItem)model;

			command.Parameters.AddWithValue("@Name", item.Name);
			command.Parameters.AddWithValue("@Item_Type", item.Item_Type.ToString());
			command.Parameters.AddWithValue("@Price", item.Price);


			var rows = command.ExecuteNonQuery();
			if (rows != 1) throw new ArgumentException("Vare ikke oprettet");

			return model;
		}
	}

	public BaseModel Delete(int id)
	{
		throw new NotImplementedException();
	}


	public BaseModel GetById(int id)
	{
		var conn = new SqlConnection(Secret.GetSecret());
		conn.Open();

		var sql = "SELECT" +
		          "[Id]," +
		          "[Name]," +
		          "[Item_Type]," +
		          "[Price]," +
		          "FROM" +
		          "[bullerbob_dk_db_zealandzoo].[dbo].[StorageItem]" +
		          "WHERE" +
		          $"[Id] = {id}";

		var cmd = new SqlCommand(sql, conn);

		var reader = cmd.ExecuteReader();

		var items = new List<StorageItem>();
		while (reader.Read()) items.Add(ReadStorageItem(reader));

		conn.Close();

		return items[0];
	}

	public BaseModel Update(int id, BaseModel model)
	{
		throw new NotImplementedException();
	}

	private StorageItem ReadStorageItem(SqlDataReader reader)
	{
		var item = new StorageItem();

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