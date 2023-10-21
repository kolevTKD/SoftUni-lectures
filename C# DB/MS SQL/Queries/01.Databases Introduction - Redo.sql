--1 Create Database
CREATE DATABASE Minions
GO

USE Minions
GO

--2 Create Tables
CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50),
	Age TINYINT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(100)
)

--3 Alter Minions Table
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--4 Insert Records in Both Tables
INSERT INTO Towns
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--5 Truncate Table Minions
TRUNCATE TABLE Minions

--6 Drop All Tables
DROP TABLE Minions
GO

DROP TABLE Towns
GO

--7 Create Table People
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height FLOAT(2),
	[Weight] FLOAT(2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Gender, Birthdate)
VALUES
('a', 'm', '01-01-2000'),
('a', 'm', '01-01-2000'),
('a', 'm', '01-01-2000'),
('a', 'm', '01-01-2000'),
('a', 'm', '01-01-2000')

--8 Create Table Users
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users (Username, [Password])
VALUES
('asdfg1', 'password'),
('asdfg2', 'password'),
('asdfg3', 'password'),
('asdfg4', 'password'),
('asdfg5', 'password')

--9 Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC076C3760D1;

ALTER TABLE Users
ADD CONSTRAINT PK_User PRIMARY KEY (Id, Username)

--10 Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_PassLen CHECK(LEN([Password]) >= 5)

--11 Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

--12 Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_User

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT UC_Username UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsnLen CHECK(LEN(Username) >= 3)

--13 Movies Database
CREATE DATABASE Movies
GO

USE Movies
GO

CREATE TABLE Directors
(
	Id INT PRIMARY KEY,
	DirectorName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors
VALUES
(1, 'Alex Pina', 'Money Heist TV Series.'),
(2, 'Matt Duffer', 'Stranger Things TV Series.'),
(3, 'Michael Morris', 'Locke & Key TV Series.'),
(4, 'Chuck Patton', 'TMNT 2003 TV Animation Series.'),
(5, 'Tim Burton', 'Wednesday TV Series.')

CREATE TABLE Genres
(
	Id INT PRIMARY KEY,
	GenreName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres
VALUES
(1, 'Crime Drama, Drama, Triller, Crime', 'Money Heist'),
(2, 'Horror, Triller, Drama, Supernatural, Mystery', 'Stranger Things'),
(3, 'Horror, Drama, Mystery', 'Locke & Key'),
(4, 'Science Fiction, Comedy, Superhero, Animation', 'TMNT 2003'),
(5, 'Fantasy, Comedy Horror, Supernatural', 'Wednesday')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories
VALUES
(1, 'Crime Drama TV Series', NULL),
(2, 'Supernatural TV Series', NULL),
(3, 'Mystery TV Series', NULL),
(4, 'Animation TV Series', NULL),
(5, 'Fantasy TV Series', NULL)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY,
	Title NVARCHAR(150) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME2 NOT NULL,
	[Length] TIME NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating FLOAT(1) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Movies
VALUES
(1, 'Money Heist', 1, '05-02-2017', '01:10:00', 1, 1, 8.2, 'Trending TV Series in Spain.'),
(2, 'Stranger Things', 2, '07-15-2016', '00:55:00', 2, 2, 8.7, 'Currently releasing a new season.'),
(3, 'Locke & Key', 3, '02-07-2020', '00:50:00', 3, 3, 7.3, 'No information for further season releases.'),
(4, 'TMNT 2003', 4, '02-08-2003', '00:20:00', 4, 4, 7.8, 'Animation for Grown-Ups.'),
(5, 'Wednesday', 5, '11-23-2022', '00:52:00', 5, 5, 8.2, 'Continuation of Addams Family TV Series.')

--14 Car Rental Database
CREATE DATABASE CarRental
COLLATE Cyrillic_General_CI_AS
GO

USE CarRental
GO

CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName NVARCHAR(150) NOT NULL,
	DailyRate FLOAT(1),
	WeeklyRate FLOAT(1),
	MonthlyRate FLOAT(1),
	WeekendRate FLOAT(1)
)

INSERT INTO Categories
VALUES
(1, 'Sports Cars', 150.00, 900.00, 4200.00, 280.00),
(2, 'Family Cars', 120.00, 800.00, 3300.00, 220.00),
(3, 'Delivery Buses', 140.00, 950.00, 4150.00, 270.00)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY,
	PlateNumber NVARCHAR(20) NOT NULL,
	Manufacturer NVARCHAR(100) NOT NULL,
	Model NVARCHAR(100) NOT NULL,
	CarYear DATETIME2,
	CategoryId INT NOT NULL,
	Doors VARCHAR(10),
	Picture VARBINARY(MAX),
	Condition NVARCHAR(100),
	Available BIT
)

INSERT INTO Cars
VALUES
(1, 'CB2018KP', 'Honda', 'CR-V', '01-01-2007', 2, '4,5', NULL, 'Very Good', 1),
(2, 'СВ8680НТ', 'Citroen', 'Jumper', '01-01-2018', 3, '4', NULL, 'Medium', 0),
(3, 'CB7526HA', 'Nissan', 'GT-R R35', '01-01-2018', 1, '2,3', NULL, 'Perfect', 1)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY,
	FirstName NVARCHAR(150) NOT NULL,
	LastName NVARCHAR(150) NOT NULL,
	Title NVARCHAR(100),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees
VALUES
(1, 'Martin', 'Kolev', 'CEO', 'Fav Car Nissan GT-R R35'),
(2, 'Emil', 'Kolev', 'Deputy CEO', 'N/A'),
(3, 'Ivelina', 'Stamenova-Koleva', 'House Maid', 'Учи Италиански')

CREATE TABLE Customers
(
	Id INT PRIMARY KEY,
	DriverLicenceNumber NVARCHAR(100) NOT NULL,
	FullName NVARCHAR(150) NOT NULL,
	[Address] NVARCHAR(150),
	City NVARCHAR(100),
	ZIPCode NVARCHAR(100),
	Notes NVARCHAR(MAX),
)

INSERT INTO Customers
VALUES
(1, 'ND123456', 'Никола Донев', 'Lulin 5', 'София', '1000', 'Black Belt Candidate'),
(2, 'AD123456', 'Александър Донев', 'Lulin 5', 'София', '1000', 'Black Belt Candidate'),
(3, 'KK123456', 'Константин Кръстев', 'Zone B5', 'София', '1000', '1-st Degree black belt')

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel REAL,
	KilometrageStart DECIMAL(15,3) NOT NULL,
	KilometrageEnd DECIMAL(15,3) NOT NULL,
	TotalKilometrage DECIMAL(15,3) NOT NULL,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays SMALLINT NOT NULL,
	RateApplied VARCHAR(30) NOT NULL,
	TaxRate DECIMAL(15,3) NOT NULL,
	OrderStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders
VALUES
(1, 1, 1, 1, 40.00, 0.000, 0.840, 225.840, '01-02-2023', '01-06-2023', 5, 'WeeklyRate', 800.00, 'Returned', NULL),
(2, 2, 2, 2, 25.00, 0.000, 0.250, 150.250, '01-17-2023', '01-18-2023', 1, 'DailyRate', 140.00, 'Returned', NULL),
(3, 3, 3, 3, 50.00, 0.000, 2.540, 117.540, '01-19-2023', '02-19-2023', 31, 'MonthlyRate', 4200.00, 'In Use', NULL)

--15
CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Employees
VALUES
(1, 'Natela', 'Miteva', 'CEO', 'Red belt with black stripe.'),
(2, 'Teodora', 'Mazarova', 'Deputy CEO', 'Yellow belt with green stripe.'),
(3, 'Nelly', 'Mladenova', 'Receptionist', 'Blue belt with red stripe.')

CREATE TABLE Customers(
AccountNumber VARCHAR(100) PRIMARY KEY NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(20) NOT NULL,
EmergencyName NVARCHAR(50) NOT NULL,
EmergencyNumber VARCHAR(20) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Customers
VALUES
('123456ND', 'Никола', 'Донев', '0899999999', 'Rositza Doneva', '0988888888', 'Trainer-Helper'),
('123456AD', 'Александър', 'Донев', '0799999999', 'Valentin Donev', '0977777777', 'Trainer-Helper'),
('123456DS', 'Даниел', 'Стаев', '0699999999', 'Evelina Staeva', '0966666666', 'Basketball trainee')

CREATE TABLE RoomStatus(
RoomStatus VARCHAR(30) PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus
VALUES
('Occupied', 'Fisherman'),
('Free', 'N/A'),
('Pending', 'To be freed and cleaned.')

CREATE TABLE RoomTypes(
RoomType VARCHAR(30) PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes
VALUES
('Room', 'For up to 2 persons.'),
('Studio', 'For up to 10 persons.'),
('Apartment', 'For up to 5 persons')

CREATE TABLE BedTypes(
BedType VARCHAR(30) PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes
VALUES
('Cot', 'For babies.'),
('Double bed', 'For couples'),
('Foldable sofa', 'For emergencies')

CREATE TABLE Rooms(
RoomNumber VARCHAR(10) PRIMARY KEY,
RoomType VARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
BedType VARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
Rate DECIMAL(15,2) NOT NULL,
RoomStatus VARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Rooms
VALUES
('101', 'Room', 'Double bed', 60.00, 'Occupied', 'Suitable for 2 people.'),
('102', 'Studio', 'Cot', 180.00, 'Free', 'Suitable for up to 3 families.'),
('201', 'Apartment', 'Foldable sofa', 120.00, 'Pending', 'Suitable for 2 small families.')

CREATE TABLE Payments(
Id INT PRIMARY KEY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATETIME2 NOT NULL,
AccountNumber VARCHAR(100) FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied DATETIME2 NOT NULL,
LastDateOccupied DATETIME2 NOT NULL,
TotalDays SMALLINT,
AmountCharged DECIMAL(15,2),
TaxRate DECIMAL(15, 2) NOT NULL,
TaxAmount DECIMAL(15, 2) NOT NULL,
PaymentTotal DECIMAL(15, 2) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Payments
VALUES
(1, 1, '01-18-2023', '123456ND', '01-16-2023', '01-19-2023', 4, 240.00, 0.2, 240.00 * 0.2, 240.00 + (240.00 * 0.2), 'First Customer'),
(2, 2, '02-18-2023', '123456AD', '02-14-2023', '02-19-2023', 6, 1080.00, 0.2, 1080 * 0.2, 1080.00 + (1080.00 * 0.2), 'Second Customer'),
(3, 3, '01-19-2023', '123456DS', '01-17-2023', '01-19-2023', 3, 360.00, 0.2, 360.00 * 0.2, 360.00 + (360.00 * 0.2), 'Third Customer')

CREATE TABLE Occupancies(
Id INT PRIMARY KEY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
DateOccupied DATETIME2,
AccountNumber VARCHAR(100) FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
RoomNumber VARCHAR(10) FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
RateApplied DECIMAL(15, 2) NOT NULL,
PhoneCharge DECIMAL(15, 2),
Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies
VALUES
(1, 1, '01-18-2023', '123456ND', '101', 240.00, NULL, 'N/A'),
(2, 2, '02-18-2023', '123456AD', '102', 1080.00, NULL, 'N/A'),
(3, 3, '01-10-2023', '123456DS', '201', 360.00, NULL, 'N/A')

--16 Create SoftUni Database
CREATE DATABASE SoftUni
GO

USE SoftUni
GO

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(150) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	AddressText NVARCHAR(200) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(250),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATETIME2,
	Salary DECIMAL(15,2),
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--18 Basic Insert
INSERT INTO Towns
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02-01-2013', 3500.00, NULL),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03-02-2004', 4000.00, NULL),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08-28-2016', 525.25, NULL),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12-09-2007', 3000.00, NULL),
('Peter', 'Pan', 'Pan', 'Intern', 3, '08-28-2016', 599.88, NULL)

--19 Basic Select All Fields
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--20 Basic Select All Fields and Order Them
SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--21 Basic Select Some Fields
  SELECT [Name] FROM Towns
ORDER BY [Name] ASC

  SELECT [Name] FROM Departments
ORDER BY [Name] ASC

  SELECT FirstName, LastName, JobTitle, Salary
    FROM Employees
ORDER BY Salary DESC

--22 Increase Employees Salary
UPDATE Employees
   SET Salary *= 1.1

SELECT Salary
  FROM Employees

--23 Decrease Tax Rate
USE Hotel

UPDATE Payments
   SET TaxRate -= 0.03

SELECT TaxRate
  FROM Payments

--24 Delete All Records
DELETE
  FROM Occupancies