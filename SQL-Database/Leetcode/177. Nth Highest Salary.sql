CREATE FUNCTION getNthHighestSalary(@N INT) 
RETURNS INT 
AS
BEGIN
    DECLARE @result INT;

    WITH CTE AS (
        SELECT Salary,
               DENSE_RANK() OVER (ORDER BY Salary DESC) AS Rank
        FROM Employee
    )
    SELECT @result = Salary 
    FROM CTE
    WHERE Rank = @N;

    RETURN @result;
END;
