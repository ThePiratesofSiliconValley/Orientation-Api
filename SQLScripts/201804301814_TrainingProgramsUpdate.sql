/*
   Monday, April 30, 20186:13:31 PM
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
ALTER TABLE dbo.TrainingPrograms ADD CONSTRAINT
	PK_TrainingPrograms PRIMARY KEY CLUSTERED 
	(
	TrainingId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TrainingPrograms SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TrainingPrograms', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TrainingPrograms', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TrainingPrograms', 'Object', 'CONTROL') as Contr_Per 