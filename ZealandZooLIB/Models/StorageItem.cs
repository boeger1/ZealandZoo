using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models
{

    public class StorageItem : BaseModel
    {

        public string Name { get; set; }

        public double Price { get; set; }

        public ItemType Type { get; set; }

        public StorageItem() : base()
        {
            Name = "default";
            Price = 0;
            Type = ItemType.SoftDrink;
        }

        

        public StorageItem(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}