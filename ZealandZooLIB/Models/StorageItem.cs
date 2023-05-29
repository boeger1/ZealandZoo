namespace ZealandZooLIB.Models;

public class StorageItem : BaseModel
{
    //Bella
    public StorageItem()
    {
        Id = 0;
        Name = "default";
        Price = 0;
        Item_Type = ItemType.SoftDrink;
        Quantity = 0;
    }

    //Bella
    public StorageItem(int id, string name, ItemType item_type, double price, int quantity)
    {
        Id = id;
        Name = name;
        Item_Type = item_type;
        Price = price;
        Quantity = quantity;
    }
    //Bella
    public int Id { get; set; }
    public string Name { get; set; }

    public double Price { get; set; }

    public ItemType Item_Type { get; set; }

    public int Quantity { get; set; }
}