CREATE TABLE [dbo].[Allocated_Time]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdUser] INT NOT NULL, 
    [IdProject] INT NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL, 
    [IdInvoice] INT NULL, 
    [Description] NVARCHAR(50) NULL
)
