--1
SELECT [FirstName]
     , [LastName] 
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'

--2
SELECT [FirstName]
     , [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'

--3
SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10) AND 
DATEPART(yyyy, [HireDate]) BETWEEN 1995 AND 2005

--4
SELECT [FirstName]
	 , [LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%'

--5
  SELECT [Name] 
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

--6
  SELECT * 
    FROM [Towns]
   WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

--7
  SELECT *
    FROM [Towns]
   WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

--8
GO
CREATE VIEW [V_EmployeesHiredAfter2000]
		 AS
		    (
				SELECT [FirstName]
					 , [LastName]
				  FROM [Employees]
				 WHERE YEAR([HireDate]) > 2000
			)
GO
SELECT * FROM [V_EmployeesHiredAfter2000]
GO

--9
SELECT [FirstName]
	 , [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5

--10
  SELECT [EmployeeID],
	     [FirstName],
	     [LastName],
	     [Salary],
		 DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) 
	  AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--11*
SELECT *
  FROM (
		 SELECT [EmployeeID]
			  , [FirstName]
			  , [LastName]
			  , [Salary]
			  , DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) 
			 AS [Rank]
		   FROM [Employees]
		  WHERE [Salary] BETWEEN 10000 AND 50000
	   ) AS [RankingSubquery]
   WHERE [Rank] = 2
ORDER BY [Salary] DESC

--12
GO
USE [Geography]
GO

  SELECT [CountryName]
	  AS [Country Name]
	   , [IsoCode]
	  AS [ISO Code]
    FROM [Countries]
   WHERE LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [IsoCode]

----12 Second Method
  SELECT [CountryName]
	  AS [Country Name]
	   , [IsoCode]
	  AS [ISO Code]
    FROM [Countries]
   WHERE LEN([CountryName]) - LEN(REPLACE(LOWER([CountryName]), 'a', '')) >= 3
ORDER BY [ISO Code]

--13
SELECT [PeakName],
	   [RiverName],
	   LOWER(CONCAT(SUBSTRING([p].[PeakName], 1, LEN([p].[PeakName]) - 1), [r].[RiverName])) AS [Mix]
  FROM [Peaks]
    AS [p],
	   [Rivers]
	AS [r]
 WHERE RIGHT(LOWER([p].[PeakName]), 1) = LEFT(LOWER([r].[RiverName]), 1)
 ORDER BY [Mix]

--14
GO
USE [Diablo]
GO

  SELECT TOP(50) [Name],
	     FORMAT([Start], 'yyyy-MM-dd') AS [Start]
    FROM [Games]
   WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start],
		 [Name]

--15
  SELECT [Username],
         RIGHT([Email], ABS(LEN([Email]) - CHARINDEX('@', [Email]))) 
	  AS [Email Provider]
    FROM [Users]
ORDER BY [Email Provider],
		 [Username]

--16
  SELECT [Username]
       , [IpAddress]
	  AS [IP Address]
    FROM [Users]
   WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username]

--17
  SELECT [Name] 
      AS [Game],
    CASE 
         WHEN DATEPART(hh, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
	     WHEN DATEPART(hh, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
	     ELSE 'Evening'
     END AS [Part of the Day],
	CASE
		 WHEN [Duration] <= 3 THEN 'Extra Short'
		 WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
		 WHEN [Duration] > 6 THEN 'Long'
		 ELSE 'Extra Long'
     END AS [Duration]
    FROM [Games]
ORDER BY [Game]
	   , [Duration]
	   , [Part of the Day]

--18
GO
USE [Orders]
GO

SELECT [ProductName]
	 , [OrderDate]
     , DATEADD(dd, 3, [OrderDate])
	AS [Pay Due]
	 , DATEADD(mm, 1, [OrderDate])
	AS [Deliver Due]
  FROM [Orders]

--19
GO
USE [MyFirstDB2023]
GO

CREATE TABLE [People]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL
)

INSERT INTO [People]
	 VALUES ('Victor', '2000-12-07')
		  , ('Steven', '1992-09-10')
		  , ('Stephen', '1910-09-19')
		  , ('John', '2010-01-06')

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
