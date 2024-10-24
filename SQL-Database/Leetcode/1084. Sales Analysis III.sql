

WITH CTE AS (Select P.product_name,P.product_id,S.sale_date from Product P
inner join  Sales S on S.product_id = P.product_id 
)

Select distinct CTE.product_id,CTE.product_name FROM CTE
where CTE.product_id not in (
-- all products ids that i dont want
Select CTE.product_id FROM CTE
where CTE.sale_date < '2019-01-01' or CTE.sale_date > '2019-03-31'
)
