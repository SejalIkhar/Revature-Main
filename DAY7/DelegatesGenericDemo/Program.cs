// See https://aka.ms/new-console-template for more information
namespace DelegatesDemo;
//event handlers
public class onClickEventArgs : EventArgs
{
    public string buttonName {get; set;}
}

public class Button
{
    public delegate void onClickHandler();

    public event onClickHandler OnClick;

    public void click()
    {
        OnClick?.Invoke();
    }
}

//till here
class Program
{
    static void Main(string[] args)
    {
        //DelegatesDemoApp app = new DelegatesDemoApp();
        //app.Run();
        //app.HigherOrderFunction();
        Button button=new Button();
        button.OnClick += () => Console.WriteLine("Bell Rings");
        button.OnClick += () => Console.WriteLine("Charge for electricity");
        button.OnClick += () => Console.WriteLine("Open the door");

        button.click();
    }
}

//void Add(int a, int b)
// delegate void MathOperation(int a, int b);
//int Add(int a, int b)
delegate int MathOperation(int a, int b);

// Generic Delegate

// delegate TResult GenericTwoParameterFunction<TFirst, TSecond, TResult>(TFirst a, TSecond b);

delegate void GenericTwoParameterAtion<TFirst, TSecond>(TFirst a, TSecond b);

class DelegatesDemoApp
{
    //Event program
    public void HigherOrderFunction()
    {
        var result = CalculatorArea(AreaofTriangle);
        Console.WriteLine($"Area:{result}");
    }

    int CalculatorArea(Func<int,int,int>areaFunction)
    {
        return areaFunction(5,10);
    }
    int AreaofRectangle(int length,int width)
    {
        return length*width;
    }
    int AreaofTriangle(int baseLength,int height)
    {
        return (baseLength*height)/2;
    }
    //till here
    delegate int MathOperation(int a, int b);
     public void LambdaExpressionDemo()
{
    Func<int, int> f;

    f = (int x) => x * x;

    var result = f(5);

    Console.WriteLine($"result: {result}");
}

public void AnonymousMethodDemo()
{
    // Using an anonymous method with a delegate
    MathOperation operation = delegate (int a, int b)
    {
        Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
        return a + b;
    };

    operation(5, 3);
}

    void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public void Run()
    {
        // MathOperation operation = Add;
        // // GenericTwoParameterFunction<int, int, int> genericOperation = Add;
        // Func<int, int, int> genericOperation = Add;

        // Action<string> action = PrintMessage;
        // action("Hello from Action delegate!");

        // Predicate<int> predicate = IsEven;
        // int testNumber = 4;

        // Console.WriteLine($"Is {testNumber} even? {predicate(testNumber)}");

        // return;

        // Func<string, string, string> stringOperation = Concatenate;

        // var x = stringOperation("Hello, ", "World!");
        // Console.WriteLine($"Concatenation result: {x}");

        // // Multicast delegate: adding more methods to the invocation list
        // genericOperation += Subtract;
        // genericOperation += Multiply;
        // genericOperation += Divide;

        // genericOperation -= Subtract; // Removing the Subtract method from the invocation list

        // var result = genericOperation(5, 3);
        // Console.WriteLine($"Final result: {result}");
        LambdaExpressionDemo();
    }


    public string Concatenate(string a, string b)
    {
        string result = a + b;
        Console.WriteLine($"Concatenating '{a}' and '{b}' results in: '{result}'");
        return result;
    }

    public int Add(int a, int b)
    {
        Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        Console.WriteLine($"The difference between {a} and {b} is: {a - b}");
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        Console.WriteLine($"The product of {a} and {b} is: {a * b}");
        return a * b;
    }

    public int Divide(int a, int b)
    {
        if (b != 0)
        {
            Console.WriteLine($"The quotient of {a} and {b} is: {a / b}");
            return a / b;
        }
        else
        {
            Console.WriteLine("Cannot divide by zero.");
        }
        return 0;
    }
}
