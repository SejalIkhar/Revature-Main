using var db = new AppDbContext();

// Students
var students = new List<Student>
{
    new Student { Name="Sejal", Age=22 },
    new Student { Name="Amit", Age=24 },
    new Student { Name="Neha", Age=23 },
    new Student { Name="Rahul", Age=25 },
    new Student { Name="Priya", Age=21 }
};

db.Students.AddRange(students);
db.SaveChanges();

// Enrollments (10 rows)
var enrollments = new List<Enrollment>
{
    new Enrollment { Course="C#", Fees=12000, StudentId=students[0].StudentId },
    new Enrollment { Course="SQL", Fees=8000, StudentId=students[0].StudentId },

    new Enrollment { Course="Java", Fees=10000, StudentId=students[1].StudentId },
    new Enrollment { Course="Python", Fees=11000, StudentId=students[1].StudentId },

    new Enrollment { Course="Web Dev", Fees=9000, StudentId=students[2].StudentId },
    new Enrollment { Course="Data Science", Fees=15000, StudentId=students[2].StudentId },

    new Enrollment { Course="AI", Fees=16000, StudentId=students[3].StudentId },
    new Enrollment { Course="Cloud", Fees=14000, StudentId=students[3].StudentId },

    new Enrollment { Course="ML", Fees=15000, StudentId=students[4].StudentId },
    new Enrollment { Course="DevOps", Fees=13000, StudentId=students[4].StudentId }
};

db.Enrollments.AddRange(enrollments);
db.SaveChanges();

Console.WriteLine("5 Students and 10 Enrollments inserted!");
