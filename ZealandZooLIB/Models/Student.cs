namespace ZealandZooLIB.Models;

public class Student : BaseModel
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; } 

    public string? Email { get; set; } 

    public StudentType StudentType { get; set; } = StudentType.Student;

    public string? Phone { get; set; }
    public bool Subscribed { get; set; }
    public int ImageId { get; set; }
}

public enum StudentType
{
    Student,
    ZooStudent
}