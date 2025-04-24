USE [StoreSample]
GO

/****** Object:  View [Sales].[GetClientOrders]    Script Date: 24/04/2025 3:24:01 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE VIEW [Sales].[GetClientOrders]
  WITH SCHEMABINDING
AS

SELECT 
	Orderid,
	custid,
	Requireddate,
	Shippeddate,
	Shipname,
	Shipaddress,
	Shipcity  
FROM Sales.Orders
GO


