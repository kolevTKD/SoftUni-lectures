--1 Employees with Salary Above 35000
USE SoftUni
GO

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName
 	     , LastName
      FROM Employees 
     WHERE Salary > 35000
END
GO

EXEC usp_GetEmployeesSalaryAbove35000

--2 Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber
(@suppliedNumber DECIMAL(18,2))
AS
BEGIN
	SELECT FirstName
		 , LastName
	  FROM Employees
	 WHERE Salary >= @suppliedNumber
END
GO

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3 Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith
(@townName NVARCHAR(100))
AS
BEGIN
	SELECT [Name]
	  FROM Towns
	 WHERE LOWER([Name]) LIKE LOWER(CONCAT(@townName, '%'))
END
GO

EXEC usp_GetTownsStartingWith 'b'

--4 Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown
(@townName NVARCHAR(100))
AS
BEGIN
	    SELECT e.FirstName
		     , e.LastName
	      FROM Employees AS e
	INNER JOIN Addresses AS a
			ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t
			ON a.TownID = t.TownID
		 WHERE t.[Name] = @townName
END
GO

EXEC usp_GetEmployeesFromTown 'Sofia'
	
--5 Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel
(@Salary DECIMAL(18,4))
RETURNS NVARCHAR(15)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10);

	IF (@Salary < 30000)
		SET @salaryLevel = 'Low'
	ELSE IF (@Salary BETWEEN 30000 AND 50000)
		SET @salaryLevel = 'Average'
	ELSE IF (@Salary > 50000)
		SET @salaryLevel = 'High'

	RETURN @salaryLevel;
END;

SELECT dbo.ufn_GetSalaryLevel(125500.00)
	AS [Salary Level]

--6 Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel
(@levelOfSalary NVARCHAR(15))
AS
BEGIN
	SELECT FirstName
		 , LastName
	  FROM Employees
	 WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary
END
GO

EXEC usp_EmployeesBySalaryLevel 'High'

--7 Define Function
CREATE FUNCTION ufn_IsWordComprised
(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @wordIndex INT = 1;

	WHILE(@wordIndex <= LEN(@word))
	BEGIN
		DECLARE @currentChar CHAR = SUBSTRING(@word, @wordIndex, 1)

		IF (CHARINDEX(@currentChar, @setOfLetters)) = 0
		BEGIN
			RETURN 0;
		END

		SET @wordIndex += 1;
	END

	RETURN 1;

END
GO

SELECT dbo.ufn_IsWordComprised ('pppp', 'Guy') AS [Result]

--8* Delete Employees and Departments
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment
(@departmentID INT)
AS
BEGIN
	--Defining table variable to store all the Ids of the employees that need to be deleted.
	DECLARE @employeesToDelete TABLE (Id INT);
	 INSERT INTO @employeesToDelete
		  SELECT EmployeeID
		    FROM Employees
		   WHERE DepartmentID = @departmentID

	--Deleting relation between the employee and the project they are working on.
	DELETE
	  FROM EmployeesProjects
	 WHERE EmployeeID IN (
						  SELECT Id
						    FROM @employeesToDelete
						 )

	--Deleting relation of the department of the employee and their manager as well.
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT
	
	UPDATE Departments
	   SET ManagerID = NULL
	 WHERE ManagerID IN (
						 SELECT Id
						   FROM @employeesToDelete
						)

	--Deleting self-reference between employees and managers.
	UPDATE Employees
	   SET ManagerID = NULL
	 WHERE ManagerID IN (
						 SELECT Id
						   FROM @employeesToDelete
						)

	--Deleting employees from the department that's required.
	DELETE
	  FROM Employees
	 WHERE DepartmentID = @departmentID

	 --Deleting the required department from the departments table.
	 DELETE
	   FROM Departments
	  WHERE DepartmentID = @departmentID

	  --Selecting the count of the people from the deleted department /should always return 0/
	  SELECT COUNT(*)
	    FROM  Employees
	   WHERE DepartmentID = @departmentID
END
GO

EXEC usp_DeleteEmployeesFromDepartment 1

--9 Find Full Name
USE Bank
GO

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT_WS(' ', FirstName, LastName)
		AS [Full Name]
	  FROM AccountHolders
END
GO

EXEC usp_GetHoldersFullName

--10 People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan
(@balance DECIMAL(15,2))
AS
BEGIN
	    SELECT ah.FirstName
	 	     , ah.LastName
	      FROM AccountHolders AS ah
	INNER JOIN Accounts AS a
 		    ON ah.Id = a.AccountHolderId
      GROUP BY AccountHolderId
 		     , FirstName
 		     , LastName
 	    HAVING SUM(a.Balance) > @balance
      ORDER BY FirstName ASC
 		     , LastName ASC
END
GO

EXEC usp_GetHoldersWithBalanceHigherThan 50000

--11 Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue
(@initialSum DECIMAL(15,2), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(15,4)
AS
BEGIN
	DECLARE @FutureValue DECIMAL(15,4);
		SET @FutureValue = @initialSum * (POWER(1 + @yearlyInterestRate, @numberOfYears));

		RETURN @FutureValue;
END
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--12 Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount
(@accountId INT, @yearlyInterestRate FLOAT)
AS
BEGIN
	SELECT a.Id AS [Account Id]
		 , ah.FirstName AS [First Name]
		 , ah.LastName AS [Last Name]
		 , SUM(a.Balance) AS [Current Balance]
		 , dbo.ufn_CalculateFutureValue(SUM(a.Balance), @yearlyInterestRate, 5) AS [Balance in 5 years]
      FROM AccountHolders AS ah
INNER JOIN Accounts AS a
		ON ah.Id = a.AccountHolderId
	 WHERE a.Id = @accountId
  GROUP BY a.Id
		 , ah.FirstName
		 , ah.LastName
END
GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1

--13* Scalar Function: Cash in User Games Odd Rows
USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames
(@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
	(
	 SELECT SUM(Cash)
		 AS [SumCash]
	   FROM (
			     SELECT g.[Name]
					  , ug.Cash
					  , ROW_NUMBER() OVER(ORDER BY ug.Cash DESC)
					 AS [RowNumber]
			       FROM Games AS g
			 INNER JOIN UsersGames AS ug
					 ON ug.GameId = g.Id
				  WHERE g.[Name] = @gameName
			)
		 AS [RankingSubquery]
	  WHERE RowNumber % 2 <> 0
	)
GO

SELECT * FROM dbo.ufn_CashInUsersGames ('Love in a Mist')