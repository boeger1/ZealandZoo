using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models;

public partial class Bullet
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string ContentBullet { get; set; } = null!;
}
