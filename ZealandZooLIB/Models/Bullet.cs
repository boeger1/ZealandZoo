using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models;

public partial class Bullet : BaseModel
{
    public string Title { get; set; } = null!;

    public string ContentBullet { get; set; } = null!;
}
