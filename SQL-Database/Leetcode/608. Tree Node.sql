Select T1.id, 
case 
when T1.p_id is null then 'Root'
when EXISTS((select * from tree T2 where T1.id =  T2.p_id)) then 'Inner'
else 'Leaf'
end as type
from tree T1
