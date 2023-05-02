using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Describtion { get; set; }

    public DateTime DateTo { get; set; }

    public DateTime DateFrom { get; set; }

    public int MaxGuest { get; set; }

    public double Price { get; set; }
}
