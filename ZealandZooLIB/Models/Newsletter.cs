using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models;

public partial class Newsletter
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;
}
