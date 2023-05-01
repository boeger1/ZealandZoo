using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models;

public partial class ItemType
{
    public string Type { get; set; } = null!;

    public virtual ICollection<StorageItem> StorageItems { get; set; } = new List<StorageItem>();
}
