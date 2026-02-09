using EmployeeDemo;

namespace ExtensionMethodsDemo
{
    public static class EmployeeExtension
    {
        public static int DoubleTheAge(this Employee employee)
        {
            return employee.Age * 2;
        }
    }
}
