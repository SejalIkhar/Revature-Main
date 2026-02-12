using System;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.Contracts;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ================================
            // DEPENDENCY INVERSION PRINCIPLE (DIP)
            // High-level module depends on abstractions (interfaces),
            // not on concrete classes using "new"
            // ================================
            var services = new ServiceCollection();

            services.AddScoped<IMessageReader, TwitterMessageReader>();
            services.AddScoped<IMessageWriter, InstagramMessageWriter>();
            services.AddScoped<IMessageWriter, PdfMessageWriter>();
            services.AddScoped<IMyLogger, ConsoleLogger>();
            services.AddScoped<App>();

            var serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetService<App>();

            app.Run();

            // Violation of DIP - new keyword in front of custom classes
            //MessageReader _reader = new MessageReader();
            //MessageWriter _writer = new MessageWriter();
            //App _app = new App(_reader, _writer);
            //_app.Run();

            // Console.WriteLine("Hello, World!");
        }
    }
    // ================================
    // SINGLE RESPONSIBILITY PRINCIPLE (SRP)
    // App class is only responsible for coordinating read & write
    // ================================

    public class App
    {
        IMessageReader _messageReader;
        IMessageWriter _messageWriter;
        // ================================
        // DEPENDENCY INVERSION PRINCIPLE (DIP)
        // App depends on interfaces, not concrete classes
        // ================================

        public App(IMessageReader reader, IMessageWriter writer)
        {
            _messageReader = reader;
            _messageWriter = writer;
        }

        public void Run()
        {
            _messageWriter.WriteMessage(_messageReader.ReadMessage());
        }
    }

    // Violation of Interface Segregation Principle
    //public interface IMessagesApp
    //{
    //    string ReadMessage();

    //    void WriteMessage(string message);
    //}
    public interface IMessageReader
    {
        string ReadMessage();
    }
    // ================================
    // SINGLE RESPONSIBILITY PRINCIPLE (SRP)
    // Reads message only
    // ================================
    public class MessageReader : IMessageReader
    {
        public string ReadMessage() => "Hello, World!";
    }
    // ================================
    // OPEN / CLOSED PRINCIPLE (OCP)
    // New message sources can be added
    // without modifying existing code
    // ================================
    public class TwitterMessageReader : IMessageReader
    {
        // twitter integration
        public string ReadMessage() => "Hello, From Twitter!";
    }
    // ================================
    // INTERFACE SEGREGATION PRINCIPLE (ISP)
    // Writer interface only writes
    // ================================
    public interface IMessageWriter
    {
        void WriteMessage(string message);
    }
    // ================================
    // SINGLE RESPONSIBILITY PRINCIPLE (SRP)
    // Writes message to console
    // ================================
    public class MessageWriter : IMessageWriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
    // ================================
    // SINGLE RESPONSIBILITY PRINCIPLE (SRP)
    // Logger only logs
    // ================================

    public interface IMyLogger
    {
        void Log();
    }

    public class ConsoleLogger : IMyLogger
    {
        public void Log()
        {
            Console.WriteLine("Entering Console");
        }
    }
    // ================================
    // OPEN / CLOSED PRINCIPLE (OCP)
    // New writer type without modifying App
    // ================================
    // LISKOV SUBSTITUTION PRINCIPLE (LSP)
    // Can replace IMessageWriter anywhere
    // ================================
    public class InstagramMessageWriter : IMessageWriter
    {
        IMyLogger _logger;
        public InstagramMessageWriter(IMyLogger logger)
        {
            _logger = logger;
        }
        public void WriteMessage(string message)
        {
            _logger.Log();
            Console.WriteLine($"{message} posted to instagram");
        }
    }
    // ================================
    // OPEN / CLOSED PRINCIPLE (OCP)
    // Another extension without modifying existing code
    // ================================
    public class PdfMessageWriter : IMessageWriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"PDF {message}");
        }
    }

    //public class MessagesApp : IMessagesApp
    //{
    //    public string ReadMessage() => "Hello World";
    //    public void WriteMessage(string message) => Console.WriteLine(message
    //}
}