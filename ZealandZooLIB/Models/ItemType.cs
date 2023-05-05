using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models
{
    public enum ItemType {Alcohol, SoftDrink, Snack }

    public class ItemTypeEnum : StorageItem
    {
        public ItemType EnumType { get; set; }

        public ItemTypeEnum(string name, ItemType type, double price):base(name, price)
        {
            EnumType = type;

        }

        
    }
}
