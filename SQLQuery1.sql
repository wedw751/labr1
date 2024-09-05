CREATE TABLE [dbo].[Payment] (
    PaymentID INT NOT NULL PRIMARY KEY IDENTITY,
    CustomerID INT NOT NULL,
    PaymentAmount DECIMAL(10, 2) NOT NULL,
    PaymentDate DATE NOT NULL,
);