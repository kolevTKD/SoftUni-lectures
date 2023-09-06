CREATE DATABASE Accounting
GO

USE Accounting
GO

CREATE TABLE Countries
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses
(
Id INT PRIMARY KEY IDENTITY,
StreetName NVARCHAR(20) NOT NULL,
StreetNumber INT,
PostCode INT NOT NULL,
City VARCHAR(25) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Vendors
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) NOT NULL,
NumberVAT NVARCHAR(15) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Clients
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) NOT NULL,
NumberVAT NVARCHAR(15) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Products
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(35) NOT NULL,
Price DECIMAL(18, 2) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
VendorId INT FOREIGN KEY REFERENCES Vendors(Id) NOT NULL
)

CREATE TABLE Invoices
(
Id INT PRIMARY KEY IDENTITY,
Number INT NOT NULL UNIQUE,
IssueDate DATETIME2 NOT NULL,
DueDate DATETIME2 NOT NULL,
Amount DECIMAL(18, 2) NOT NULL,
Currency VARCHAR(5) NOT NULL,
ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
)

CREATE TABLE ProductsClients
(
ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
PRIMARY KEY (ProductId, ClientId)
)

---------------------------------------
INSERT INTO Products
VALUES ('SCANIA Oil Filter XD01', 78.69, 1, 1),
	   ('MAN Air Filter XD01', 97.38, 1, 5),
	   ('DAF Light Bulb 05FG87', 55.00, 2, 13),
	   ('ADR Shoes 47-47.5', 49.85, 3, 5),
	   ('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices
VALUES (1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
	   (1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
	   (1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)

UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE YEAR(IssueDate) = 2022 AND MONTH(IssueDate) = 11

UPDATE Addresses
SET StreetName = 'Industriestr'
  , StreetNumber = 79
  , PostCode = 2353
  , City = 'Guntramsdorf'
  , CountryId = 1
WHERE Addresses.Id IN (
		SELECT Id
		  FROM Clients
		 WHERE [Name] LIKE '%CO%' --DA SE DOOPRAVI AKO IMA VREME
			)

UPDATE Clients
SET NULL
WHERE NumberVAT LIKE 'IT%'

DELETE
  FROM ProductsClients
WHERE ClientId = (
		SELECT Id
		  FROM Clients
		 WHERE NumberVAT LIKE 'IT%'
)

DELETE
  FROM Invoices
 WHERE ClientId = (
		SELECT Id
		  FROM Clients
		 WHERE NumberVAT LIKE 'IT%'
 )

DELETE FROM Clients
WHERE NumberVAT LIKE 'IT%'

-----------------------------------------------------

SELECT Number
	 , Currency
  FROM Invoices
ORDER BY Amount DESC
	   , DueDate

SELECT p.Id
	 , p.[Name]
	 , p.Price
	 , c.[Name]
	AS CategoryName
  FROM Products AS p
JOIN Categories AS c ON c.Id = p.CategoryId
WHERE c.[Name] IN ('ADR', 'Others')
ORDER BY p.Price DESC

SELECT * FROM Clients
SELECT * FROM Products
SELECT * FROM PRODUCTSClients

SELECT cl.Id
	 , cl.[Name] AS Client
	 , CONCAT_WS(', ', a.StreetName, a.StreetNumber, a.City, a.PostCode, c.[Name]) AS [Address]
  FROM Clients AS cl
JOIN Addresses AS a ON cl.AddressId = a.Id
JOIN Countries AS c ON a.CountryId = c.Id
JOIN ProductsClients AS pc ON cl.Id = pc.ClientId
WHERE pc.ClientId IS NULL
ORDER BY cl.[Name] 



