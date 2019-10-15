CREATE TABLE [dbo].[Allocated_Time]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdUser] INT NOT NULL, 
    [IdProject] INT NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NULL, 
    [IdInvoice] INT NULL
)
