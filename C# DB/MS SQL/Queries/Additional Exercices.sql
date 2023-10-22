--1 Number of Users for Email Provider
USE Diablo
GO

  SELECT [Email Provider]
	   , COUNT(*)
	  AS [Number Of Users]
    FROM (
		  SELECT RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
			  AS [Email Provider]
		    FROM Users
	     ) AS [sq]
GROUP BY [Email Provider]
ORDER BY [Number Of Users] DESC
	   , [Email Provider]

--2 All Users in Games
    SELECT g.[Name] AS [Game]
		 , gt.[Name] AS [Game Type]
		 , u.Username
		 , ug.[Level]
		 , ug.Cash
		 , c.[Name] AS [Character]
	  FROM Games AS g
INNER JOIN GameTypes AS gt
		ON g.GameTypeId = gt.Id
INNER JOIN UsersGames AS ug
		ON g.Id = ug.GameId
INNER JOIN Users AS u
		ON ug.UserId = u.Id
INNER JOIN Characters AS c
		ON ug.CharacterId = c.Id
  ORDER BY ug.[Level] DESC
		 , u.Username
		 , g.[Name]

--3 Users in Games with Their Items



































    SELECT u.Username
	     , g.[Name] AS [Game]
	     , COUNT(i.[Name]) AS [Items Count]
	     , SUM(i.Price) AS [Items Price]
      FROM Users AS u
LEFT JOIN UsersGames AS ug
		ON u.Id = ug.UserId
LEFT JOIN Games AS g
		ON ug.GameId = g.Id
LEFT JOIN UserGameItems AS ugi
		ON ug.GameId = ugi.UserGameId
LEFT JOIN Items AS i
		ON ugi.ItemId = i.Id
	 WHERE u.Username = 'skippingside'
  GROUP BY u.Username
		 , g.[Name]
	--HAVING COUNT(i.Id) >= 10
  ORDER BY COUNT(i.[Name]) DESC
		 , SUM(i.Price) DESC
		 , u.Username
