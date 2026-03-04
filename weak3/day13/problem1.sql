
--The store manager wants a simple report showing customer orders along with their order dates and status.
-- This report will help track pending and completed orders.

CREATE DATABASE custumers;
USE custumers;
CREATE TABLE Customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);
SELECT * FROM Customers;
CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);
SELECT * FROM Orders;
INSERT INTO Customers VALUES (1, 'Ravi', 'Kumar'),
(2, 'Anita', 'Sharma'),
 (3, 'Rahul', 'Reddy'),
 (4, 'Sneha', 'Patel');

INSERT INTO Orders VALUES (101, 1, '2026-03-01', 1), 
 (102, 1, '2026-02-25', 4),
 (103, 2, '2026-02-20', 2),
 (104, 3, '2026-03-03', 1),
 (105, 4, '2026-01-15', 4),
(106, 2, '2026-02-10', 3);  

SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM Customers c
INNER JOIN Orders o
    ON c.customer_id = o.customer_id
WHERE o.order_status = 1 
   OR o.order_status = 4
ORDER BY o.order_date DESC;

