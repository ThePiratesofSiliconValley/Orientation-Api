/*
   Monday, April 23, 20187:47:48 PM
   User: sa
   Server: BCI17LT328
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
CREATE TABLE dbo.TrainingPrograms
	(
	TrainingId int NOT NULL IDENTITY (1, 1),
	TrainingName nvarchar(50) NOT NULL,
	StartDay date NOT NULL,
	EndDay date NOT NULL,
	MaxAttendees int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TrainingPrograms SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TrainingPrograms', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TrainingPrograms', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TrainingPrograms', 'Object', 'CONTROL') as Contr_Per 
