--1 Employee Address
USE SoftUni
GO

SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
  FROM Employees AS e
 INNER JOIN Addresses AS a
    ON e.AddressID = a.AddressID
 ORDER BY a.AddressID

--2 Addresses with Towns
SELECT TOP(50) e.FirstName, e.LastName, t.[Name] AS [Town], a.AddressText
  FROM Employees AS e
 INNER JOIN Addresses AS a
    ON e.AddressID = a.AddressID
 INNER JOIN Towns AS t
    ON t.TownID = a.TownID
 ORDER BY e.FirstName
		, e.LastName

--3 Sales Employee
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
  FROM Employees AS e
 INNER JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
 WHERE d.[Name] = 'Sales'
 ORDER BY e.EmployeeID

--4 Employee Departments
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
  FROM Employees AS e
 INNER JOIN Departments AS d
    ON e.DepartmentID = d.DepartmentID
 WHERE e.Salary > 15000
 ORDER BY d.DepartmentID

--5 Employees Without Project
SELECT TOP(3) e.EmployeeID, e.FirstName
  FROM Employees AS e
  LEFT JOIN EmployeesProjects AS ep
    ON e.EmployeeID = ep.EmployeeID
 WHERE ep.ProjectID IS NULL
 ORDER BY e.EmployeeID

--6 Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS [DeptName]
  FROM Employees AS e
 INNER JOIN Departments AS d
    ON e.DepartmentID = d.DepartmentID
 WHERE e.HireDate > '1999-01-01'
   AND d.[Name] IN ('Sales', 'Finance')
 ORDER BY e.HireDate

--7 Employees With Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name]
  FROM Employees AS e
 INNER JOIN EmployeesProjects AS ep
    ON e.EmployeeID = ep.EmployeeID
 INNER JOIN Projects AS p
    ON ep.ProjectID = p.ProjectID
 WHERE p.StartDate > '2002-08-13'
   AND p.EndDate IS NULL
 ORDER BY e.EmployeeID

--8 Employee 24
SELECT *
  FROM (
		SELECT e.EmployeeID, e.FirstName,
		  CASE
			   WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
			   ELSE p.[Name]
			   END
			AS [ProjectName]
		  FROM Employees AS e
		 INNER JOIN EmployeesProjects AS ep
			ON e.EmployeeID = ep.EmployeeID
		 INNER JOIN Projects AS p
			ON ep.ProjectID = p.ProjectID
	    ) AS [All Projects]
  WHERE EmployeeID = 24

--9 Employee Manager - Self Join/ Join On Self-Referencing table
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS [ManagerName]
  FROM Employees AS e
 INNER JOIN Employees AS m
    ON e.ManagerID = m.EmployeeID
 WHERE m.EmployeeID IN (3, 7)
 ORDER BY e.EmployeeID

--10 Employees Summary
SELECT TOP(50) e.EmployeeID
	 , CONCAT_WS(' ', e.FirstName, e.LastName) AS [EmployeeName]
	 , CONCAT_WS(' ', m.FirstName, m.LastName) AS [ManagerName]
	 , d.[Name] AS [DepartmentName]
  FROM Employees AS e
 INNER JOIN Employees AS m
    ON e.ManagerID = m.EmployeeID
 INNER JOIN Departments AS d
    ON e.DepartmentID = d.DepartmentID
 ORDER BY e.EmployeeID

--11 Min Average Salary
SELECT MIN(sq.AvgSalary) AS [MinAverageSalary]
  FROM (
		SELECT AVG(Salary)
			AS [AvgSalary]
		  FROM Employees
		 GROUP BY DepartmentID
	   ) AS [sq]

--12 Highest Peaks in Bulgaria
USE [Geography]
GO

SELECT c.CountryCode
	 , m.MountainRange
	 , p.PeakName
	 , p.Elevation
  FROM Countries AS c
  LEFT JOIN MountainsCountries AS mc
    ON c.CountryCode = mc.CountryCode
 INNER JOIN Mountains AS m
    ON mc.MountainId = m.Id
 INNER JOIN Peaks AS p
    ON m.Id = p.MountainId
 WHERE c.CountryCode = 'BG'
   AND p.Elevation > 2835
 ORDER BY p.Elevation DESC

--13 Count Mountain Ranges
SELECT c.CountryCode
	 , (
		SELECT COUNT(MountainId)
		  FROM MountainsCountries
		 WHERE CountryCode = c.CountryCode
	   ) AS [MountainRanges]
  FROM Countries AS c
 INNER JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
 WHERE c.CountryCode IN ('US', 'RU', 'BG')
 GROUP BY c.CountryCode

--14 Countries With or Without Rivers
SELECT TOP(5) c.CountryName
	 , r.RiverName
  FROM Countries AS c
  LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers AS r
	ON cr.RiverId = r.Id
 INNER JOIN Continents AS co
	ON c.ContinentCode = co.ContinentCode
 WHERE co.ContinentName = 'Africa'
 ORDER BY c.CountryName

--15* Continents and Currencies

--16 Countries Without Any Mountains
SELECT COUNT(*)
  FROM Countries

SELECT 