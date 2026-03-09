CREATE DATABASE sprocedure;

use sprocedure;
CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(100)
);
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    list_price DECIMAL(10,2)
);
CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_date DATE,
    order_status INT,
    shipped_date DATE,
    
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);
CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(5,2),

    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
INSERT INTO stores VALUES
(1,'Store A','Hyderabad'),
(2,'Store B','Chennai');

INSERT INTO products VALUES
(101,'Laptop',50000),
(102,'Mobile',20000),
(103,'Keyboard',1000);

INSERT INTO orders VALUES
(1,1,'2024-05-01',4,'2024-05-03'),
(2,2,'2024-05-05',3,NULL);

INSERT INTO order_items VALUES
(1,1,101,2,50000,0.10),
(2,1,103,3,1000,0.05),
(3,2,102,1,20000,0.00);

SELECT * from order_items;


--Level-2 Problem 1: Stored Procedures and User-Defined Functions

--Create a stored procedure to generate total sales amount per store.
CREATE PROCEDURE usp_totalsalesperstore
AS
BEGIN
SELECT s.store_id,s.store_name,SUM(oi.quantity*oi.list_price)As totalsales
from stores s
JOIN orders o ON  o.store_id=s.store_id 
join order_items oi ON o.order_id=oi.order_id 
group by s.store_id,s.store_name;
END;

EXEC usp_totalsalesperstore;


-- Create a stored procedure to retrieve orders by date range.
CREATE PROCEDURE usp_getodersperdate
@start_date DATE,
@end_date DATE
 AS
 BEGIN
 SELECT * FROM orders WHERE order_date BETWEEN @start_date AND @end_date;
 END;

 DECLARE @date1 DATE='2024-01-01';
 DECLARE @date2 DATE='2024-12-31';
 EXEC usp_getodersperdate @date1,@date2;

--Create a scalar function to calculate total price after discount.
CREATE FUNCTION fn_CalculateDiscountPrice
(
    @price DECIMAL(10,2),
    @discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
DECLARE @final_price DECIMAL(10,2)
SET @final_price = @price * (1 - ISNULL(@discount,0))
RETURN @final_price
END;

SELECT dbo.fn_CalculateDiscountPrice(1000,0.10) AS FinalPrice;

--Create a table-valued function to return top 5 selling products.
CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
SELECT TOP 5
    product_id,
    SUM(quantity) AS total_sold
FROM order_items
GROUP BY product_id
ORDER BY total_sold DESC
);
SELECT * FROM fn_Top5SellingProducts();

CREATE TABLE stocks(
    product_id INT PRIMARY KEY,
    quantity INT,
    FOREIGN KEY(product_id) REFERENCES products(product_id)
);

INSERT INTO stocks VALUES
(101,10),
(102,20),
(103,50);





--Level-2 Problem 2: Stock Auto-Update Trigger
ALTER TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
BEGIN TRY
IF EXISTS(
SELECT 1
FROM inserted i
JOIN stocks s
ON i.product_id = s.product_id
WHERE s.quantity < i.quantity
)
BEGIN
RAISERROR('Insufficient Stock',16,1)
ROLLBACK TRANSACTION
RETURN
END
UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
THROW
END CATCH
END;

INSERT INTO order_items VALUES (4,1,101,5,50000,0);

---Level-2 Problem 3: Order Status Validation Trigger
ALTER TRIGGER trg_OrderStatusValidation
ON orders
AFTER UPDATE
AS
BEGIN
BEGIN TRY

IF EXISTS(
    SELECT 1
    FROM inserted
    WHERE order_status = 4
    AND shipped_date IS NULL
)
BEGIN
    RAISERROR('Shipped date cannot be NULL when order is completed',16,1);
    RETURN;
END
END TRY
BEGIN CATCH
    THROW;
END CATCH
END;

UPDATE orders
SET order_status = 4, shipped_date = NULL
WHERE order_id = 1;


---Level-2 Problem 3: Cursor-Based Revenue Calculation
CREATE PROCEDURE usp_CursorRevenueCalculation
AS
BEGIN
BEGIN TRY
    BEGIN TRANSACTION
    DECLARE @order_id INT
    DECLARE @store_id INT
    DECLARE @revenue DECIMAL(10,2)
    -- Temporary table to store results
    CREATE TABLE #TempRevenue
    (
        store_id INT,
        order_id INT,
        revenue DECIMAL(10,2)
    )
    -- Cursor to fetch completed orders
    DECLARE order_cursor CURSOR FOR
    SELECT order_id, store_id
    FROM orders
    WHERE order_status = 4
    OPEN order_cursor
    FETCH NEXT FROM order_cursor INTO @order_id, @store_id
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Calculate revenue per order
        SELECT @revenue =
        SUM(quantity * list_price * (1 - discount))
        FROM order_items
        WHERE order_id = @order_id
        -- Store result
        INSERT INTO #TempRevenue
        VALUES(@store_id, @order_id, @revenue)
        FETCH NEXT FROM order_cursor INTO @order_id, @store_id
    END
    CLOSE order_cursor
    DEALLOCATE order_cursor
    -- Store wise revenue summary
    SELECT 
        store_id,
        SUM(revenue) AS total_revenue
    FROM #TempRevenue
    GROUP BY store_id
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    PRINT ERROR_MESSAGE()
END CATCH
END;
