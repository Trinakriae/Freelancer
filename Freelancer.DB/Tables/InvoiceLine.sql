CREATE TABLE [dbo].[Invoice_Line]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdInvoice] INT NOT NULL, 
    [Amount] DECIMAL NOT NULL, 
    [Description] NVARCHAR(50) NULL
)
