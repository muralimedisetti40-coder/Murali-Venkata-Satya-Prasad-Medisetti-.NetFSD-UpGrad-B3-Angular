use custumers;
CREATE TABLE Products(
    Productid INT PRIMARY KEY IDENTITY(1,1),
    Productname VARCHAR(50),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);
GO
CREATE PROCEDURE sp_InsertProduct
@Productname VARCHAR(50),
@Category VARCHAR(50),
@Price DECIMAL(10,2)
AS
BEGIN
INSERT INTO products VALUES(@Productname,@Category,@Price);
END;
select * FROM products;
GO
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT ProductId, ProductName, Category, Price FROM Products
END
GO
CREATE PROCEDURE sp_UpdateProduct
@Productid INT,
@Productname VARCHAR(50),
@Category VARCHAR(50),
@Price DECIMAL(10,2)
AS
BEGIN
UPDATE products
SET
Productname=@Productname,
Category=@Category,
Price=@Price
WHERE Productid=@Productid;
END;
GO
CREATE PROCEDURE sp_DeleteProduct
@Productid INT
AS
BEGIN
DELETE FROM products WHERE Productid=@Productid;
END;