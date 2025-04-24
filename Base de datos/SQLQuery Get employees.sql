USE [StoreSample]
GO

/****** Object:  View [HR].[GetEmployees]    Script Date: 24/04/2025 3:24:22 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [HR].[GetEmployees]
  WITH SCHEMABINDING
AS

SELECT 
	Empid,
	CONCAT_WS(' ', firstname, lastname) AS FullName 
FROM HR.Employees
GO


