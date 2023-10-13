USE SoftUni
GO

--1 Find Names of All Employees by First Name
SELECT FirstName, LastName
  FROM Employees
 WHERE FirstName LIKE 'Sa%'

--2 Find Names of All Employees by Last Name
 SELECT FirstName, LastName
   FROM Employees
  WHERE LastName LIKE '%ei%'

--3 Find First Names of All Employees
SELECT FirstName
  FROM Employees
 WHERE DepartmentID IN (3, 10)
   AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--4 Find All Employees Except Engineers
SELECT FirstName, LastName
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'

--5 Find Towns With Name Length
  SELECT [Name]
    FROM Towns
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name] ASC

--6 Find Towns Starting With
  SELECT *
    FROM Towns
   WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name] ASC

--7 Find Towns Not Starting With
  SELECT *
    FROM Towns
   WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name] ASC

--8 Create View Employees Hired After 2000 Year
GO
CREATE VIEW [V_EmployeesHiredAfter2000]
	AS
	   (
	   SELECT FirstName, LastName
	     FROM Employees
		WHERE YEAR(HireDate) > 2000
	   )
GO

--9 Length of Last Name
SELECT FirstName, LastName
  FROM Employees
 WHERE LEN(LastName) = 5

--10 Rank Employees by Salary
	  SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
        FROM Employees
	   WHERE Salary >= 10000
	     AND Salary <= 50000
	ORDER BY Salary DESC

--11 Find All Employees with Rank 2
SELECT *
  FROM (
			   SELECT EmployeeID, FirstName, LastName, Salary,
		 DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
			     FROM Employees
			    WHERE Salary >= 10000
				  AND Salary <= 50000
	   ) AS SubQuery
   WHERE [Rank] = 2
ORDER BY Salary DESC

--12 Countries Holding 'A' 3 or More Times
USE [Geography]
GO

  SELECT CountryName AS [Country Name]
	   , IsoCode AS [ISO Code]
    FROM Countries
   WHERE LEN(CountryName) - LEN(REPLACE(UPPER(CountryName), 'A', '')) >= 3
ORDER BY IsoCode

--13 Mix of Peak and River Names
SELECT p.PeakName, r.RiverName,
LOWER(CONCAT(p.PeakName, SUBSTRING(r.RiverName, 2, LEN(r.RiverName) - 1))) 
      AS [Mix]
    FROM Peaks AS p
    JOIN Rivers AS r
      ON RIGHT(LOWER(p.PeakName), 1) = LEFT(LOWER(r.RiverName), 1)
ORDER BY Mix

--14 Games from 2011 and 2012 Year
USE Diablo
GO

  SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd')
	  AS [Start]
    FROM Games
   WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start] ASC
	   , [Name] ASC

--15 User Email Providers
  SELECT Username,
SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
	  AS [Email Provider]
    FROM Users
ORDER BY [Email Provider] ASC
	   , Username ASC

--16 Get Users with IP Address Like Pattern
  SELECT Username, IpAddress
	  AS [IP Address]
    FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--17 Show All Games with Duration and Part of the Day
SELECT [Name] AS Game,
  CASE 
	   WHEN DATEPART(hh, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
	   WHEN DATEPART(hh, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
	   WHEN DATEPART(hh, [Start]) BETWEEN 18 AND 23 THEN 'Evening'
   END AS [Part of the Day],
  CASE
	   WHEN Duration <= 3 THEN 'Extra Short'
	   WHEN Duration <= 6 THEN 'Short'
	   WHEN Duration > 6 THEN 'Long'
	   WHEN Duration IS NULL THEN 'Extra Long'
   END AS [Duration]
  FROM Games
 ORDER BY [Name] ASC
		, [Duration] ASC
		, [Part of the Day] ASC
 
--18 Orders Table
USE Orders
GO

SELECT ProductName, OrderDate,
DATEADD(dd, 3, OrderDate) AS [Pay Due],
DATEADD(mm, 1, OrderDate) AS [Deliver Due]
  FROM Orders

--19 People Table (Already created and populated the required table.)
USE MyFirstDB2023
GO

SELECT [Name]
	 , DATEDIFF(yyyy, [Birthdate], GETDATE()) 
	AS [Age in Years],
	   DATEDIFF(mm, [Birthdate], GETDATE())
	AS [Age in Months],
	   DATEDIFF(dd, [Birthdate], GETDATE())
	AS [Age in Days],
	   DATEDIFF(mi, [Birthdate], GETDATE())
	AS [Age in Minutes]
  FROM [People]