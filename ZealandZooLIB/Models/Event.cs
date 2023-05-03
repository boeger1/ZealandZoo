using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models;

public class Event : BaseModel
{
    public string? Name { get; set; }

    public string? Describtion { get; set; }

    public DateTime DateTo { get; set; }

    public DateTime DateFrom { get; set; }

    public int MaxGuest { get; set; }

    public double Price { get; set; }
}
