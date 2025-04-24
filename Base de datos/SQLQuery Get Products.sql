USE [StoreSample]
GO

/****** Object:  View [Production].[GetProducts]    Script Date: 24/04/2025 3:25:09 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [Production].[GetProducts]
  WITH SCHEMABINDING
AS

SELECT 
	Productid,
	Productname
FROM Production.Products 
GO


