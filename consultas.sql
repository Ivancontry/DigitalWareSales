/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [Name],[Price] FROM [SysSalesBD].[SysSales].[Product]

SELECT * FROM [SysSalesBD].[SysSales].[Product] WHERE Amount = 5

SELECT DISTINCT(CLIENT.Name) FROM [SysSalesBD].[dbo].[Clients] AS CLIENT INNER JOIN [SysSalesBD].[SysSales].[InvoiceMaster] AS INVOICEMASTER  
ON CLIENT.ID = INVOICEMASTER.ClientId 
WHERE INVOICEMASTER.CreatedAt >= '2000-02-01' AND INVOICEMASTER.CreatedAt <= '2000-05-25' AND DATEDIFF(YEAR,CLIENT.BirthDay,GETDATE())<35


SELECT PRODUCT.Name,SUM(INVOICEDETAIL.Total) AS TOTAL FROM [SysSalesBD].[SysSales].[Product] AS PRODUCT 
INNER JOIN [SysSalesBD].[SysSales].[InvoiceDetail] AS INVOICEDETAIL ON PRODUCT.Id = INVOICEDETAIL.ProductId
INNER JOIN [SysSalesBD].[SysSales].[InvoiceMaster] AS INVOICEMASTER ON INVOICEDETAIL.InvoiceMasterId = INVOICEMASTER.Id
WHERE YEAR(INVOICEMASTER.CreatedAt) = 2000 GROUP BY PRODUCT.Name

SELECT CLIENT.Name,	MAX(INVOICEMASTER.CreatedAt) LastOrderDate,
	dateadd(
		DAY,
		DATEDIFF(Day, MIN(INVOICEMASTER.CreatedAt), MAX(INVOICEMASTER.CreatedAt)) / COUNT(*),
		MAX(INVOICEMASTER.CreatedAt)
	) NextPredictedOrder
FROM [SysSalesBD].[SysSales].[InvoiceMaster] AS INVOICEMASTER 
	inner join [SysSalesBD].[dbo].[Clients] AS CLIENT on INVOICEMASTER.ClientId = CLIENT.ID
GROUP BY CLIENT.Name;