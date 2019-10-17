CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [IdUser] INT NOT NULL, 
    [IdCustomer] INT NOT NULL
)
