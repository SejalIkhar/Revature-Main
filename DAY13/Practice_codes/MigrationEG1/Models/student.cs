public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }

    public List<Enrollment> Enrollments { get; set; } = new();
}
