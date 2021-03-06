/*
   Tuesday, April 24, 20188:05:22 PM
   User: 
   Server: (local)
   Database: OrientationAPI
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Computers
	(
	ComputerID int NOT NULL IDENTITY (1, 1),
	ComputerManufacturer nvarchar(50) NOT NULL,
	ComputerMake nvarchar(50) NOT NULL,
	PurchaseDate date NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Computers SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Computers ON
GO
IF EXISTS(SELECT * FROM dbo.Computers)
	 EXEC('INSERT INTO dbo.Tmp_Computers (ComputerID, ComputerManufacturer, ComputerMake, PurchaseDate)
		SELECT ComputerID, ComputerManufacturer, ComputerMake, CONVERT(date, PurchaseDate) FROM dbo.Computers WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Computers OFF
GO
DROP TABLE dbo.Computers
GO
EXECUTE sp_rename N'dbo.Tmp_Computers', N'Computers', 'OBJECT' 
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Computers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Computers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Computers', 'Object', 'CONTROL') as Contr_Per 