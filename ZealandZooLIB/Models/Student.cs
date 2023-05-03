using System;
using System.Collections.Generic;

namespace ZealandZooLIB.Models;

public class Student : BaseModel
{

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
