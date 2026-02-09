// See https://aka.ms/new-console-template for more information
var acc = new BankAccount(100);
acc.Withdraw(150);

Console.WriteLine(acc.Balance);      // -50
Console.WriteLine(acc.IsOverdrawn);  // true

