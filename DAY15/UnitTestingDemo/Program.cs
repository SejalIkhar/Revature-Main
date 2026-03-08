// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

AddFunctionShouldReturn30ForInputs10And20();
AddFunctionShouldReturn40ForInputs20And20();
AddFunctionShouldReturn50ForInputs25And25();

void AddFunctionShouldReturn30ForInputs10And20()
{
    // Arrange
    var x = 10;
    var y = 20;
    var expectedResult = 30;

    // Act
    var actualResult = Add(x, y);

    // Assert
    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");

    if (actualResult == expectedResult)
        Console.WriteLine("Test Passed");
    else
        Console.WriteLine("Test Failed");
}

void AddFunctionShouldReturn40ForInputs20And20()
{
    // Arrange
    var x = 20;
    var y = 20;
    var expectedResult = 40;

    // Act
    var actualResult = Add(x, y);

    // Assert
    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");

    if (actualResult == expectedResult)
        Console.WriteLine("Test Passed");
    else
        Console.WriteLine("Test Failed");
}

void AddFunctionShouldReturn50ForInputs25And25()
{
    // Arrange
    var x = 25;
    var y = 25;
    var expectedResult = 50;

    // Act
    var actualResult = Add(x, y);

    // Assert
    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");

    if (actualResult == expectedResult)
        Console.WriteLine("Test Passed");
    else
        Console.WriteLine("Test Failed");
}

int Add(int x, int y)
{
    return x + y;
}
