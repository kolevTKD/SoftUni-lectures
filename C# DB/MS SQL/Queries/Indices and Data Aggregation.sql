GO
USE [Gringotts]
GO
--1
SELECT COUNT(*)
  FROM [WizzardDeposits]

--2
SELECT MAX([MagicWandSize])
	AS [LongestMagicWand]
  FROM [WizzardDeposits]

--3
  SELECT [DepositGroup]
	   , MAX([MagicWandSize]) 
	  AS [LongestMagicWand]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--4
SELECT 
  TOP(2) [DepositGroup]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize]) ASC

--5
  SELECT [DepositGroup]
	   , SUM([DepositAmount])
	  AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--6
  SELECT [DepositGroup]
	   , SUM([DepositAmount])
	  AS [TotalSum]
	FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

--7
  SELECT [DepositGroup]
	   , SUM([DepositAmount])
	  AS [TotalSum]
	FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

--8
  SELECT [DepositGroup]
	   , [MagicWandCreator]
	   , MIN([DepositCharge])
	  AS [MinDepositCharge]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]
	   , [MagicWandCreator]
ORDER BY [MagicWandCreator] 
	   , [DepositGroup]

--9
SELECT [AgeGroup]
	 , COUNT(*)
	AS [WizardCount]
  FROM (
		SELECT [Age],
			   CASE
					  WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
					  WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
					  WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
					  WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
					  WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
					  WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
					  WHEN [Age] > 60 THEN '[61+]'
					  END
			AS [AgeGroup]
		  FROM [WizzardDeposits]
		 )
	  AS [AgeGroupsQuery]
GROUP BY [AgeGroup]

--10
  SELECT LEFT([FirstName], 1)
	  AS [FirstLetter]
    FROM [WizzardDeposits]
   WHERE [DepositGroup] = 'Troll Chest'
GROUP BY LEFT([FirstName], 1)

--11
SELECT * FROM [WizzardDeposits]

SELECT [DepositGroup]
	 , [IsDepositExpired]
	 , AVG([DepositInterest])
	AS [AverageInterest]
  FROM [WizzardDeposits]
 WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup]
	   , [IsDepositExpired]
ORDER BY [DepositGroup] DESC
	   , [IsDepositExpired]