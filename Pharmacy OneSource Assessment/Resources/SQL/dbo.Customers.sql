CREATE TABLE [dbo].[Customers] (
    [Email]             NVARCHAR (50) NOT NULL,
    [FirstName]         NVARCHAR (50) NOT NULL,
    [LastName]          NVARCHAR (50) NOT NULL,
    [BillingAddressId]  INT           NOT NULL,
    [ShippingAddressId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC),
    CONSTRAINT [FK_Customers_BillingAddress_Addresses] FOREIGN KEY ([BillingAddressId]) REFERENCES [dbo].[Addresses] ([Id]),
    CONSTRAINT [FK_Customers_ShippingAddress_Addresses] FOREIGN KEY ([ShippingAddressId]) REFERENCES [dbo].[Addresses] ([Id])
);

