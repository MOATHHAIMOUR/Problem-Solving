/* Write your T-SQL query statement below */



Select player_id , MIN(event_date) as first_login  from Activity 
group by player_id
