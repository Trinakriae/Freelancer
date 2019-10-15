CREATE TABLE [dbo].[Invoice]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Status] INT NOT NULL, 
    [IdCustomer] INT NOT NULL, 
    [Description] NVARCHAR(50) NULL
)
