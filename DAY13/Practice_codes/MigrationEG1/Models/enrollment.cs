public class Enrollment
{
    public int EnrollmentId { get; set; }
    public string Course { get; set; } = "";
    public decimal Fees { get; set; }

    // Foreign Key
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}
