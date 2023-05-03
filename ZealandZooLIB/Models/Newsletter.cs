using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models;

public partial class Newsletter : BaseModel
{
    public string Content { get; set; } = null!;
}
