USE [StoreSample]
GO

/****** Object:  View [Sales].[GetShippers]    Script Date: 24/04/2025 3:24:47 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [Sales].[GetShippers]
  WITH SCHEMABINDING
AS

SELECT 
	Shipperid,
	Companyname 
FROM Sales.Shippers
GO


