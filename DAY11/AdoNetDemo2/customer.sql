CREATE DATABASE Customer;
GO

USE CrmDb;

CREATE TABLE Customers(
    Id INT PRIMARY KEY,
    Name NVARCHAR(50),
    Age INT
);

INSERT INTO Customers VALUES (1, 'John', 30);
INSERT INTO Customers VALUES (2, 'Alice', 25);
INSERT INTO Customers VALUES (3, 'Bob', 40);

Select *from Customers;