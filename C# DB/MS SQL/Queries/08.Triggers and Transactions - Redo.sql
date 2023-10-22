--1 Create Table Logs
USE Bank
GO

CREATE TABLE Logs
(
LogId INT PRIMARY KEY IDENTITY(1,1),
AccountId INT FOREIGN KEY REFERENCES  Accounts(Id),
OldSum DECIMAL(15,2),
NewSum DECIMAL(15,2)
)

GO
CREATE TRIGGER tr_AddLogsOnAccountUpdate
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs
	SELECT i.Id
		 , d.Balance
		 , i.Balance
	  FROM inserted AS i
	  JOIN deleted AS d
		ON i.Id = d.Id
	 WHERE i.Balance <> d.Balance
GO

--2 Create Table Emails
CREATE TABLE NotificationEmails
(
Id INT PRIMARY KEY IDENTITY(1,1),
Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
[Subject] NVARCHAR(100),
Body NVARCHAR(150)
)

GO
CREATE TRIGGER tr_CreateEmailOnLogsInsert
ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails
	SELECT i.AccountId
		 , CONCAT('Balance change for account: ', i.AccountId)
		 , CONCAT('On ', GETDATE(), ' your balance has changed from ', i.OldSum, ' to ', i.NewSum, '.')
	  FROM inserted AS i
GO

--3 Deposit Money
CREATE PROCEDURE usp_DepositMoney
(@accountId INT, @moneyAmount DECIMAL(15,4))
AS
BEGIN
	IF (@moneyAmount < 0)
		RETURN

	UPDATE Accounts
	   SET Balance += @moneyAmount
	 WHERE Id = @accountId

END
GO

BEGIN TRANSACTION

EXEC usp_DepositMoney 1, 10
SELECT * FROM Accounts WHERE Id = 1

ROLLBACK TRANSACTION

--4 Withdraw Money Procedure
GO
CREATE PROCEDURE usp_WithdrawMoney
(@accountId INT, @moneyAmount DECIMAL(15,4))
AS
BEGIN
	IF (@moneyAmount < 0)
	RETURN

	UPDATE Accounts
	   SET Balance -= @moneyAmount
	 WHERE Id = @accountId

END
GO

BEGIN TRANSACTION

EXEC usp_WithdrawMoney 5, 25
SELECT * FROM Accounts WHERE Id = 5

ROLLBACK TRANSACTION

--5 Money Transfer
GO
CREATE PROCEDURE usp_TransferMoney
(@senderId INT, @receiverId INT, @amount DECIMAL(15,4))
AS
BEGIN
	BEGIN TRANSACTION
		IF (@amount < 0)
		ROLLBACK TRANSACTION

		EXEC usp_WithdrawMoney @senderId, @amount
		IF ((SELECT Balance
			  FROM Accounts
			 WHERE Id = @senderId) < 0)
		ROLLBACK TRANSACTION

		ELSE
		EXEC usp_DepositMoney @receiverId, @amount
	COMMIT TRANSACTION

END
GO

BEGIN TRANSACTION

EXEC usp_TransferMoney 5, 1, 5000
SELECT *
  FROM Accounts
 WHERE Id IN (5, 1)

ROLLBACK TRANSACTION