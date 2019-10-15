CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [IdUser] NCHAR(10) NULL
)
