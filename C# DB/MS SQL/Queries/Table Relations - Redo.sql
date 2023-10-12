CREATE DATABASE TableRelations
GO

USE TableRelations
GO

--1 One-To-One Relationship
CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY IDENTITY(101, 1),
	PassportNumber NVARCHAR(100) NOT NULL
)

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(100) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE NOT NULL
)

INSERT INTO Passports
VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

--2 One-To-Many Relationship
CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(150) NOT NULL,
	EstablishedOn DATETIME2 NOT NULL
)

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(150) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers
VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO Models
VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

--3 Many-To-Many Relationship
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(150)
)

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--4 Self-Referencing
CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(150) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--5 Online Store Database
CREATE DATABASE OnlineStore
GO

USE OnlineStore
GO

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(150)
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(150),
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(150)
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(150),
	Birthday DATETIME2,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY(1,1),
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
	PRIMARY KEY(OrderID, ItemID)
)

--6 University Database
CREATE DATABASE University
GO

USE University
GO

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(150)
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY(1,1),
	StudentNumber NVARCHAR(50),
	StudentName NVARCHAR(150),
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY(1,1),
	PaymentDate DATETIME2,
	PaymentAmount DECIMAL(15,2),
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY(1,1),
	SubjectName NVARCHAR(150)
)

CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	PRIMARY KEY(StudentID, SubjectID)
)

--9* Peaks in Rila
USE Geography
GO

  SELECT m.MountainRange, p.PeakName, p.Elevation
    FROM Mountains AS m
    JOIN Peaks AS p 
	  ON m.Id = p.MountainId
   WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC