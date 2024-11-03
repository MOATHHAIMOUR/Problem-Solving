/* Write your T-SQL query statement below */
SELECT 
    DISTINCT id,
    Jan_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Jan'),
    Feb_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Feb'),
    Mar_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Mar'),
    Apr_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Apr'),
    May_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'May'),
    Jun_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Jun'),
    Jul_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Jul'),
    Aug_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Aug'),
    Sep_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Sep'),
    Oct_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Oct'),
    Nov_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Nov'),
    Dec_Revenue = (SELECT revenue FROM Department D1 WHERE D1.id = D.id AND D1.month = 'Dec')
FROM Department D;
