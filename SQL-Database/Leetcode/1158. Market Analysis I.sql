/* Write your T-SQL query statement below */
SELECT
U.user_id as buyer_id ,
U.join_date as join_date,
Sum(case when YEAR(O.order_date) = '2019' then 1 else 0 end) as orders_in_2019  
FROM USERS U 
left JOIN ORDERS O ON O.buyer_id = U.user_id
group by  U.user_id,U.join_date
