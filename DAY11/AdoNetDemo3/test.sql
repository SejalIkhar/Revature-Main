CREATE TABLE dbo.ADO_table
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50),
    Age INT
);

INSERT INTO dbo.ADO_table (Name, Age) VALUES
('Sejal',21),
('Amit',30),
('Neha',26);

SELECT * FROM dbo.ADO_table;
