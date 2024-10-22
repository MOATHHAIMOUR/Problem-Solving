/* Write your T-SQL query statement below */

With CTE AS (
select E.id,E.name as Employee,E.salary,D.name,
DENSE_RANK() OVER (PARTITION BY D.id order by E.salary DESC) AS HightSaleryPerDepartmentRanked
from Employee E 
inner join Department D
on E.departmentId = D.id
)
Select CTE.name as Department , CTE.Employee,CTE.salary from CTE 
where HightSaleryPerDepartmentRanked = 1
