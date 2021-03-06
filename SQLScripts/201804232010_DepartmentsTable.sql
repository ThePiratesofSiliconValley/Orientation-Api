/*
   Monday, April 23, 20188:09:21 PM
   User: 
   Server: DESKTOP-FLN7PJC
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
CREATE TABLE dbo.Tmp_Departments
	(
	DepartmentId int NOT NULL IDENTITY (1, 1),
	DepartmentName nvarchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Departments SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Departments ON
GO
IF EXISTS(SELECT * FROM dbo.Departments)
	 EXEC('INSERT INTO dbo.Tmp_Departments (DepartmentId, DepartmentName)
		SELECT DepartmentId, DepartmentName FROM dbo.Departments WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Departments OFF
GO
DROP TABLE dbo.Departments
GO
EXECUTE sp_rename N'dbo.Tmp_Departments', N'Departments', 'OBJECT' 
GO
ALTER TABLE dbo.Departments ADD CONSTRAINT
	PK_Departments PRIMARY KEY CLUSTERED 
	(
	DepartmentId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Departments', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Departments', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Departments', 'Object', 'CONTROL') as Contr_Per 