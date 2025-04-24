USE [StoreSample]
GO

/****** Object:  View [Sales].[DatePrediction]    Script Date: 24/04/2025 3:23:30 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [Sales].[DatePrediction]
WITH SCHEMABINDING
AS
SELECT  
	Cliente.custid AS IdCliente,
    Cliente.companyname AS CustomerName,
    MAX(Orden.orderdate) AS LastOrderDate,		
    CAST((MAX(CAST(Orden.orderdate AS FLOAT)) + (MAX(CAST(Orden.orderdate AS FLOAT)) - MIN(CAST(Orden.orderdate AS FLOAT))) / (COUNT(*) - 1)) AS DATETIME) AS NextPredictedOrder
FROM Sales.Orders AS Orden
INNER JOIN Sales.Customers AS Cliente ON Orden.custid = Cliente.custid
GROUP BY Cliente.custid, Cliente.companyname
HAVING COUNT(*) > 1;
GO


