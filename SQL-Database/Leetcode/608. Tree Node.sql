Select T1.id, 
case 
when T1.p_id is null then 'Root'
when EXISTS((select * from tree T2 where T1.id =  T2.p_id)) then 'Inner'
else 'Leaf'
end as type
from tree T1



--OR 

Select T1.p_id, 
case 
when T1.p_id is null then 'Root'
when EXISTS((select * from tree T2 where T1.id in (T2.p_id))) then 'Inner'
else 'Leafe'
end as nodeType
from tree T1
