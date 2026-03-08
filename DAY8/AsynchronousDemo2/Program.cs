using System.Diagnostics;

// // Regular FLow
// var url = "download";

// var _client = new HttpClient();

// Opporunitiy for optimization
// var post = _client.GetStringAsync(url);

// Console.WriteLine(post);

// Gives a new thread from thread pool
// CPU Heavy actvity
Task<int> longAdditionTask = Task.Run(()=> LongAddition());

int LongAddition()
{
    var sum = 0;
    for(int i = 0; i < 500_000_000; i++)
    {
        sum += i;
    }
    return sum;
}

void PrintMessage()
{
    Console.WriteLine("Hello from a method!");
}

// Fire and Forget
// Gives a new thread from thread pool
// I/O Heavy actvity
Task task = new Task(PrintMessage);

// Task<int> taskWithResult = new Task<int>(CheckEmployeeCount);
Task<int> taskWithResult = new Task<int>(() =>
{
    // SELECT COUNT(*) FROM Customers
    // _context.Customers.Count();
    Console.WriteLine("Hello from a method!");
    return 42;
});

task.Start();

// NEVER DO THIS
// task.Wait();
// var x = task.Result;

var result = await taskWithResult;

int CheckEmployeeCount()
{
    Console.WriteLine("Hello from a method!");
    return 42;
}



try
{
    await DemonstrateExceptions();
}
catch (AggregateException ex)
{
    Console.WriteLine($"Aggregate Exception: {ex.Message}");
}


async Task DemonstrateExceptions()
{
    using var _client = new HttpClient();

    var urls = new[]
    {
        "https://jsonplaceholder.typicode.com/posts/1",   // valid
        "https://this-does-not-exist.invalid/post/1",       // will fail
        "https://this-does-not-exist.invalid/post/2",       // will fail
        "https://jsonplaceholder.typicode.com/posts/3"    // valid
    };

    var tasks = urls.Select(url => _client.GetStringAsync(url)).ToList();

    try
    {
        Console.WriteLine($"Count: {tasks.Count}");

        // NEVER DO THIS:
        // Task.WaitAll(tasks.ToArray());
        await Task.WhenAll(tasks);
        var stockValue = await Task.WhenAny(tasks);

        // Console.WriteLine($"All {results.Length} succeeded.");
    }
    catch (HttpRequestException ex)
    {
        // Only the first exception is re-thrown by await
        Console.WriteLine($"At least one failed: {ex.Message}");

        // Inspect the Task directly for all exceptions
        foreach (var task in tasks.Where(t => t.IsFaulted))
        {
            Console.WriteLine($"  - {task.Exception?.InnerException?.Message}");
        }
    }

    foreach (var task in tasks)
    {

        if (task.IsCompletedSuccessfully)
        {
            Console.WriteLine($"Success: {task.Result.Length} chars");
        }
        else if (task.IsFaulted)
        {
            Console.WriteLine($"Failed: {task.Exception?.InnerException?.Message}");
        }
    }
}



async Task<int> Demos()
{

    await TaskParallelDemoAsync();
    await TaskDemoAsync();
    ThreadDemo();

    return await Task.FromResult(0);
}

async Task TaskParallelDemoAsync()
{
    using var _client = new HttpClient();

    var urls = Enumerable.Range(1, 10)
        .Select(i => $"https://jsonplaceholder.typicode.com/posts/{i}")
        .ToList();

    var stopwatch = Stopwatch.StartNew();

    var downloadTasks = urls.Select(async url =>
    {
        var threadBefore = Thread.CurrentThread.ManagedThreadId;

        string content = await _client.GetStringAsync(url);

        var threadAfter = Thread.CurrentThread.ManagedThreadId;

        Console.WriteLine($"Thread Before: {threadBefore} downloading {url}. ({content.Length} chars) [Thread After {threadAfter}]");

        return content;

    });

    string[] results = await Task.WhenAll(downloadTasks);

    stopwatch.Stop();
    Console.WriteLine($"\nTotal time: {stopwatch.ElapsedMilliseconds}ms");
}

async Task TaskDemoAsync()
{
    using var _client = new HttpClient();

    var urls = Enumerable.Range(1, 10)
        .Select(i => $"https://jsonplaceholder.typicode.com/posts/{i}")
        .ToList();

    var stopwatch = Stopwatch.StartNew();

    foreach (var url in urls)
    {
        var threadBefore = Thread.CurrentThread.ManagedThreadId;

        Console.Write($"[Thread {threadBefore}] Fetching {url}... ");

        // ConfigureAwait(false) tells the compiler that we don't care about resuming on the original context (thread)
        // ConfigureAwait(true) (or omitting it) tells the compiler to resume on the original context (thread)
// [XXX - Must match] Fetching https://jsonplaceholder.typicode.com/posts/1... done. (292 chars) [XXX - Must match]
        string content = await _client.GetStringAsync(url).ConfigureAwait(true);

        var threadAfter = Thread.CurrentThread.ManagedThreadId;

        Console.WriteLine($"done. ({content.Length} chars) [Thread {threadAfter}]");
    }

    stopwatch.Stop();
    Console.WriteLine($"\nTotal time: {stopwatch.ElapsedMilliseconds}ms");
}


void ThreadDemo()
{
    using var _client = new HttpClient();

    var urls = Enumerable.Range(1, 10)
        .Select(i => $"https://jsonplaceholder.typicode.com/posts/{i}")
        .ToList();

    var stopwatch = Stopwatch.StartNew();

    foreach (var url in urls)
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;

        Console.Write($"[Thread {threadId}] Fetching {url}... ");

        var response = _client.GetAsync(url).Result;
        var content = response.Content.ReadAsStringAsync().Result;

        Console.WriteLine($"done. ({content.Length} chars)");
    }

    stopwatch.Stop();
    Console.WriteLine($"\nTotal time: {stopwatch.ElapsedMilliseconds}ms");

}