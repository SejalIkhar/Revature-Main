using System.Text;   // Import namespace for StringBuilder class

// var message = "How are you?";
// SRP
// Encrypt
// StringBuilder encryptedMessage = new StringBuilder(20);

// foreach (var ch in message)
// {
//     encryptedMessage.Append(ch + 1);
// RSA
// }

// Console.WriteLine($"Encrypted Message: {encryptedMessage.ToString()}");

// Zip

// var zippedMessage = encryptedMessage.ToString();

// Email

// Console.WriteLine($"Sending encrypted message: {zippedMessage}");

// Chain of Responsibility implementation starts here


// Creating object of encryption handler
var encryption = new RsaEncryption();

// Creating object of archival handler (used to store/archive message)
var archival = new Archival();

// Creating object of email handler (used to send message through email)
var email = new Email();

// Creating object of pdf handler (used to convert message into PDF)
var pdf = new Pdf();


// Creating list of handlers
// COR works by sending request through multiple handlers
List<IHandler> handlers = new List<IHandler> { email };


// Message which will be processed by handlers
var message = "How are you?";


// Loop through each handler in the chain
foreach (var handler in handlers)
{
    try
    {
        // Call Handle method of each handler
        // Each handler processes the message
        handler.Handle(message);
    }
    catch
    {
        // If any handler throws exception it will be ignored
        // (not recommended in real production code)
    }
}


// Interface defining a common contract for all handlers
interface IHandler
{
    // Every handler must implement this method
    void Handle(string message);
}


// Encryption handler class
class Encryption : IHandler
{
    public void Handle(string message)
    {
        // Create StringBuilder to store encrypted message
        StringBuilder encryptedMessage = new StringBuilder(20);

        // Loop through each character of message
        foreach (var ch in message)
        {
            // Simple encryption: shift character by +1
            encryptedMessage.Append(ch + 1);
        }
    }
}


// RSA Encryption handler (more advanced encryption)
class RsaEncryption : IHandler
{
    public void Handle(string message)
    {
        // Create StringBuilder for encrypted output
        StringBuilder encryptedMessage = new StringBuilder(20);

        // RSA encryption logic would go here
    }
}


// Archival handler
// Used to store the message in archive/storage
class Archival : IHandler
{
    public void Handle(string message)
    {
        // Print message indicating archival action
        Console.WriteLine($"Sending encrypted message: {message}");
    }
}


// Email handler
// Responsible for sending message through email
class Email : IHandler
{
    public void Handle(string message)
    {
        // Print message indicating email sending
        Console.WriteLine($"Sending encrypted message: {message}");
    }
}


// PDF handler
// Responsible for converting message into PDF format
class Pdf : IHandler
{
    public void Handle(string message)
    {
        // Print message indicating PDF generation
        Console.WriteLine($"Sending encrypted message: {message}");
    }
}


// Cloud storage handler
// Responsible for saving message to cloud storage
class CloudSave : IHandler
{
    public void Handle(string message)
    {
        // Print message indicating cloud save action
        Console.WriteLine($"Sending encrypted message: {message}");
    }
}