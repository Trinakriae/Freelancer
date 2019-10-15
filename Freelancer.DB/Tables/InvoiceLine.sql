CREATE TABLE [dbo].[Invoice_Line]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdInvoice] INT NOT NULL, 
    [Amount] DECIMAL NOT NULL, 
    [Description] NVARCHAR(50) NULL
)
