USE StoreSample;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spAddNewOrder
	/* Columnas de la Orden */
	@EmployeeId INT,
	@Shipperid INT,
	@Shipname NVARCHAR(40),
	@Shipaddress NVARCHAR(60),
	@Shipcity NVARCHAR(15),
	@Orderdate DATETIME,
	@Requireddate DATETIME,
	@Shippeddate DATETIME,
	@Freight MONEY,
	@Shipcountry NVARCHAR(15),

	/* Columnas de la OrdenDetails */	
	@Productid INT,
	@Unitprice MONEY,
	@Qty SMALLINT,
	@Discount NUMERIC
AS

BEGIN	
	SET NOCOUNT ON;
	
	INSERT INTO StoreSample.Sales.Orders (empid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, freight, shipcountry)
	VALUES (@EmployeeId, @Shipperid, @Shipname,	@Shipaddress, @Shipcity, @Orderdate, @Requireddate, @Shippeddate, @Freight,	@Shipcountry)

	DECLARE @orderId INT = IDENT_CURRENT('StoreSample.Sales.Orders');

	INSERT INTO StoreSample.Sales.OrderDetails (orderid, productid, unitprice, qty, discount)
	VALUES(@orderId, @Productid, @Unitprice, @Qty, @Discount)
	
END
GO
