with q1 as (
select *, id - row_number() over(order by id) as id_diff
from stadium
where people > 99
)
select id, visit_date, people
from q1
where id_diff in (select id_diff from q1 group by id_diff having count(*) >= 3)
order by visit_date
