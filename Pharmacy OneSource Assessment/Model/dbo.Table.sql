CREATE TABLE [dbo].[Products]
(
	[ProductCode] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [TaxCode] NVARCHAR(50) NULL DEFAULT 'A_GEN_DOM', 
    [Description] TEXT NULL DEFAULT 'No description.', 
    [Category] NVARCHAR(50) NULL DEFAULT 'Other', 
    [Stock] INT NULL DEFAULT 0  
)

GO

CREATE INDEX [IX_Products_Price] ON [dbo].[Products] ([Price])

GO


CREATE INDEX [IX_Products_Name] ON [dbo].[Products] ([Name])

GO
