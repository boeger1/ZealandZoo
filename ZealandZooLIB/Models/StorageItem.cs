using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models;

public partial class StorageItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ItemType TypeNavigation { get; set; } = null!;
}
