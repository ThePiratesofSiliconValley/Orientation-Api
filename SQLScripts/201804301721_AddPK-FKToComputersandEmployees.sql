/*
   Monday, April 30, 20185:21:32 PM
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
ALTER TABLE dbo.Computers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Computers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Computers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Computers', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Employees ADD
	ComputerId int NULL
GO
ALTER TABLE dbo.Employees ADD CONSTRAINT
	FK_Employees_Computers FOREIGN KEY
	(
	ComputerId
	) REFERENCES dbo.Computers
	(
	ComputerID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Employees SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Employees', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Employees', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Employees', 'Object', 'CONTROL') as Contr_Per 