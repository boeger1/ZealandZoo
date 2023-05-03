using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models;

public partial class StorageItem : BaseModel
{

public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ItemType TypeNavigation { get; set; } = null!;
}
