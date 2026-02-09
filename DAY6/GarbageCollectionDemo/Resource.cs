using System.Runtime.Versioning;

namespace DAY6
{
    public class Resource
    {
        public string Name {get;set;}

        public Resource(string name)
        {
          Name =name;
          Console.WriteLine($"{Name}created");  
        }
        ~Resource()//Destructor(finalizer)
        {
            Console.WriteLine($"{Name}destroyed by GC");
        }
    }
}