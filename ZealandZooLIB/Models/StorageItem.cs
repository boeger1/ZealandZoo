﻿using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models
{
   

    public class StorageItem : BaseModel
    {

        public string Name { get; set; }

        public double Price { get; set; }

        public ItemType Item_Type { get; set; }

        public StorageItem() : base()
        {
            Name = "default";
            Price = 0;
            Item_Type = ItemType.SoftDrink;
        }

        

        public StorageItem(string name, ItemType item_type, double price)
        {
            Name = name;
            Item_Type = item_type;
            Price = price;
        }
    }
}