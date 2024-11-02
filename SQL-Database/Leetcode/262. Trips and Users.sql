/* Write your T-SQL query statement below */
WITH CTE AS (Select request_at,
sum(
	case when status like 'cancelled%' 
			and clintes.banned = 'No'
			and drivers.banned = 'No'
	then 1 
	else 0 
	end) as canceldUnPannedRequests,
sum(
	case when clintes.banned = 'No'
			  and 
			  drivers.banned = 'No'
	then 1 
	else 0 
	end) as UnPannedRequests
from Trips T
inner join users clintes  on  clintes.users_id = T.client_id
inner join Users drivers  on  drivers.users_id = T.driver_id
where T.request_at between '2013-10-01' and '2013-10-03'
group by request_at 
) 
Select * from (
SELECT 
    CTE.request_at AS Day,
    ROUND(
        CASE 
            WHEN CTE.UnPannedRequests = 0 THEN NULL
            ELSE CAST(CTE.canceldUnPannedRequests AS FLOAT) / CAST(CTE.UnPannedRequests AS FLOAT)
        END, 
    2) AS [Cancellation Rate]
FROM CTE
)R1 
where R1.[Cancellation Rate] is not null
