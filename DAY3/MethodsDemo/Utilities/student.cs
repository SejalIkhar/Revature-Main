namespace Utilities
{
    public class Student
    {
        public string Name { get; }
        public int Age { get; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int DoubleTheAge() => Age * 2;
    }
}
