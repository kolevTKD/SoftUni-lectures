GO
USE [SoftUni]
GO

--1
SELECT TOP (5) 
	     [e].[EmployeeID]
	   , [e].[JobTitle]
	   , [e].[AddressID]
	   , [a].[AddressText]
    FROM [Employees] AS [e]
   LEFT JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
ORDER BY [e].[AddressID]

--2
SELECT TOP (50)
		 [e].[FirstName]
	   , [e].[LastName]
	   , [t].[Name]
	   , [a].[AddressText]
	FROM [Employees] AS [e]
	JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
	JOIN [Towns] AS [t] ON [a].[TownID] = [t].[TownID]
ORDER BY [e].[FirstName]
	   , [e].[LastName]

--3
  SELECT [e].[EmployeeID]
       , [e].[FirstName]
	   , [e].[LastName]
	   , [d].[Name]
	  AS [DepartmentName]
	FROM [Employees] AS [e]
	JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
   WHERE [d].[Name] IN ('Sales')
ORDER BY [e].[EmployeeID]

--4
SELECT TOP (5)
           [e].[EmployeeID]
		 , [e].[FirstName]
		 , [e].[Salary]
		 , [d].[Name]
		AS [DepartmentName]
	  FROM [Employees] AS [e]
	  JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
	 WHERE [e].[Salary] > 15000
  ORDER BY [d].[DepartmentID]

--5
SELECT TOP (3)
	       [e].[EmployeeID]
		 , [e].[FirstName]
	  FROM [Employees] AS [e]
 LEFT JOIN [EmployeesProjects] AS [ep] 
	    ON [e].[EmployeeID] = [ep].[EmployeeID]
	 WHERE [ep].[ProjectID] IS NULL
  ORDER BY [e].[EmployeeID]

--6
   SELECT [e].[FirstName]
	    , [e].[LastName]
	    , [e].[HireDate]
	    , [d].[Name]
	   AS [DeptName]
     FROM [Employees] AS [e]
LEFT JOIN [Departments] AS [d]
	   ON [e].[DepartmentID] = [d].[DepartmentID]
	WHERE [e].[HireDate] > '1.1.1999' AND 
		  [d].[Name] IN ('Sales', 'Finance')
 ORDER BY [e].[HireDate]

--7
SElECT TOP (5)
		   [e].[EmployeeID]
	     , [e].[FirstName]
	     , [p].[Name] AS [ProjectName]
      FROM [Employees] AS [e]
INNER JOIN [EmployeesProjects] AS [ep]
	    ON [e].[EmployeeID] = [ep].[EmployeeID]
INNER JOIN [Projects] AS [p]
	    ON [p].[ProjectID] = [ep].[ProjectID]
	 WHERE [p].[StartDate] > '08.13.2002' AND 
		   [p].[EndDate] IS NULL
  ORDER BY [e].[EmployeeID]

--8
    SELECT [e].[EmployeeID]
	     , [e].[FirstName]
	     , CASE
			 WHEN YEAR([p].[StartDate]) >= 2005 THEN NULL
			 ELSE [p].[Name]
		   END AS [ProjectName]
      FROM [Employees] AS [e]
INNER JOIN [EmployeesProjects] AS [ep]
		ON [e].[EmployeeID] = [ep].[EmployeeID]
INNER JOIN [Projects] AS [p]
		ON [p].[ProjectID] = [ep].[ProjectID]
	 WHERE [e].[EmployeeID] = 24

--9
    SELECT [e].[EmployeeID]
	     , [e].[FirstName]
	     , [e].[ManagerID]
	     , [m].[FirstName] AS [ManagerName]
      FROM [Employees] AS [e]
INNER JOIN [Employees] AS [m]
		ON [e].[ManagerID] = [m].[EmployeeID]
     WHERE [m].[EmployeeID] IN (3, 7)
  ORDER BY [e].[EmployeeID]

--10
SELECT TOP (50) 
		   [e].[EmployeeID]
	     , CONCAT_WS(' ', [e].[FirstName], [e].[LastName]) AS [EmployeeName]
	     , CONCAT_WS(' ', [m].[FirstName], [m].[LastName]) AS [ManagerName]
	     , [d].[Name] AS [DepartmentName]
      FROM [Employees] AS [e]
INNER JOIN [Employees] AS [m]
		ON [e].[ManagerID] = [m].[EmployeeID]
 LEFT JOIN [Departments] AS [d]
		ON [e].[DepartmentID] = [d].[DepartmentID]
  ORDER BY [e].[EmployeeID]

--11
  

SELECT MIN([a].[AverageSalary]) 
    AS [MinAverageSalary]
  FROM (
	      SELECT [e].[DepartmentID]
	           , AVG([e].[Salary]) AS [AverageSalary]
			FROM [Employees] AS [e]
		GROUP BY [e].[DepartmentID]
	   ) AS [a]

GO
USE [Geography]
GO

--12
	SELECT [mc].[CountryCode]
		 , [m].[MountainRange]
		 , [p].[PeakName]
	     , [p].[Elevation]
      FROM [MountainsCountries] AS [mc]
INNER JOIN [Countries] AS [c]
		ON [c].[CountryCode] = [mc].CountryCode
INNER JOIN [Mountains] AS [m]
		ON [mc].[MountainId] = [m].[Id]
INNER JOIN [Peaks] AS [p]
		ON [m].[Id] = [p].[MountainId]
	 WHERE [c].[CountryName] = 'Bulgaria' AND
		   [p].[Elevation] > 2835
  ORDER BY [p].[Elevation] DESC

--13
  SELECT [mc].[CountryCode]
	   , COUNT([mc].[MountainID]) 
	  AS [MountainRanges]
    FROM [MountainsCountries] AS [mc]
   WHERE [mc].[CountryCode] IN
	     (
	      SELECT [c].[CountryCode]
            FROM [Countries] AS [c]
           WHERE [c].[CountryName] IN ('United States', 'Russia', 'Bulgaria')
	     )
GROUP BY [mc].[CountryCode]

--14
SELECT 
   TOP (5) [c].[CountryName]
	     , [r].[RiverName]
      FROM [Countries] AS [c]
 LEFT JOIN [CountriesRivers] AS [cr]
	    ON [c].[CountryCode] = [cr].[CountryCode]
 LEFT JOIN [Rivers] AS [r]
	    ON [cr].[RiverId] = [r].[Id]
     WHERE [c].[ContinentCode] IN
		   (
		    SELECT [co].[ContinentCode]
			  FROM [Continents] AS [co]
			 WHERE [ContinentName] = 'Africa'
		   )
  ORDER BY [c].[CountryName]

--15*
SELECT [ContinentCode]
	 , [CurrencyCode]
	 , [CurrencyUsage]
  FROM (
		SELECT *
			 , DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC)
			AS [CurrencyRank]
		  FROM (
				  SELECT [c].[ContinentCode]
					   , [c].[CurrencyCode]
					   , COUNT(*) AS [CurrencyUsage]
				    FROM [Countries] AS [c]
				GROUP BY [c].[ContinentCode]
					   , [c].[CurrencyCode]
				  HAVING COUNT(*) > 1
			   )
			AS [CurrencyUsageSubquery]
	   )
	AS [CurrencyRankingSubquery]
 WHERE [CurrencyRank] = 1

--16
SELECT COUNT([c].[CountryCode]) 
    AS [Count]
  FROM [Countries] AS [c]
 WHERE [c].[CountryCode] NOT IN
	   (
          SELECT [mc].[CountryCode] 
		    FROM [MountainsCountries] AS [mc]
		GROUP BY [mc].[CountryCode]
	   )

--17
SELECT 
  TOP (5) [c].[CountryName]
		, MAX([p].[Elevation]) AS [HighestPeakElevation]
		, MAX([r].[Length]) AS [LongestRiverLength]
     FROM [Countries] AS [c]
LEFT JOIN [CountriesRivers] AS [cr]
	   ON [cr].[CountryCode] = [c].[CountryCode]
LEFT JOIN [Rivers] AS [r]
	   ON [cr].[RiverId] = [r].[Id]
LEFT JOIN [MountainsCountries] AS [mc]
	   ON [mc].[CountryCode] = [c].[CountryCode]
LEFT JOIN [Mountains] AS [m]
	   ON [mc].[MountainId] = [m].[Id]
LEFT JOIN [Peaks] AS [p]
	   ON [p].[MountainId] = [m].[Id]
 GROUP BY [c].[CountryName]
 ORDER BY [HighestPeakElevation] DESC
		, [LongestRiverLength] DESC
		, [c].[CountryName]

--18
  SELECT 
 TOP (5) [CountryName] 
	  AS [Country]
	   , ISNULL([PeakName], '(no highest peak)')
	  AS [Highest Peak Name]
	   , ISNULL([Elevation], 0)
	  AS [Highest Peak Elevation]
	   , ISNULL([MountainRange], '(no mountain)')
	  AS [Mountain]
    FROM (
             SELECT [c].[CountryName]
          		  , [p].[PeakName]
          		  , [p].[Elevation]
          		  , [m].[MountainRange]
          		  , DENSE_RANK() OVER(PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation])
          	     AS [PeakRank]
               FROM [Countries] AS [c]
          LEFT JOIN [MountainsCountries] AS [mc]
          	     ON [mc].[CountryCode] = [c].[CountryCode]
          LEFT JOIN [Mountains] AS [m]
          	     ON [mc].[MountainId] = [m].[Id]
          LEFT JOIN [Peaks] AS [p]
          	     ON [p].[MountainId] = [m].[Id]
		 )
	  AS [PeakRankingSubquery]
ORDER BY [Country]
	   , [Highest Peak Name]