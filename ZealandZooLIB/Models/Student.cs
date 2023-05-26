﻿namespace ZealandZooLIB.Models;

public class Student : BaseModel
{
    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }
    public bool Subscribed { get; set; }
    public int ImageId { get; set; }
}