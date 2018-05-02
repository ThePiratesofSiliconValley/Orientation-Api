USE [OrientationAPI]
GO

/****** Object:  Table [dbo].[EmployeeTraining]    Script Date: 4/30/2018 6:09:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeTraining](
	[EmployeeTrainingId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[TrainingId] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeTraining] PRIMARY KEY CLUSTERED 
(
	[EmployeeTrainingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmployeeTraining]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeTraining_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO

ALTER TABLE [dbo].[EmployeeTraining] CHECK CONSTRAINT [FK_EmployeeTraining_Employees]
GO

ALTER TABLE [dbo].[EmployeeTraining]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeTraining_EmployeeTraining] FOREIGN KEY([EmployeeTrainingId])
REFERENCES [dbo].[EmployeeTraining] ([EmployeeTrainingId])
GO

ALTER TABLE [dbo].[EmployeeTraining] CHECK CONSTRAINT [FK_EmployeeTraining_EmployeeTraining]
GO


