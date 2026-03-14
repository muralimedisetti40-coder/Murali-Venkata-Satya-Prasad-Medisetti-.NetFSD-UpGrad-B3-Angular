use day7;
CREATE TABLE Books (
    BookID  INT IDENTITY(1,1) PRIMARY KEY,
    Title   NVARCHAR(150) NOT NULL,
    Stock   INT NOT NULL CHECK (Stock >= 0),
    Price   DECIMAL(10,2) NOT NULL
);
CREATE TABLE Orders1 (
    OrderID    INT IDENTITY(1,1) PRIMARY KEY,
    BookID     INT NOT NULL,
    Quantity   INT NOT NULL CHECK (Quantity > 0),
    OrderDate  DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);
GO
CREATE PROCEDURE sp_AddNewBook
@Title VARCHAR(150),
@Stock INT,
@Price DECIMAL(10,2)
AS
BEGIN
BEGIN TRY
INSERT into Books(Title,Stock,Price) VALUES(@Title,@Stock,@Price);
PRINT'book added sucessfully'; 
END TRY
BEGIN CATCH
PRINT ERROR_MESSAGE();
END CATCH
END

GO
CREATE PROCEDURE sp_PlaceOrder 
@BookId INT,
@Quantity INT
AS
SET XACT_ABORT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION
 IF NOT EXISTS( SELECT 1 FROM Books
WHERE BookID=@BookId AND stock>=@Quantity)
BEGIN
 RAISERROR('not enough of stock or book not found',16,1);
END
UPDATE Books SET Stock-=@Quantity
WHERE BookID=@BookId;
INSERT INTO Orders1(BookID,Quantity)VALUES(@BookId,@Quantity);
COMMIT TRANSACTION;
PRINT('order placed sucessfully');
END TRY
BEGIN CATCH
if @@TRANCOUNT>0
    ROLLBACK TRANSACTION;
print('error '+CAST(ERROR_NUMBER() AS VARCHAR) +':'+ERROR_MESSAGE());
END CATCH
END


EXEC sp_AddNewBook 'SQL Fundamentals', 10, 450.00;
EXEC sp_AddNewBook 'C# Programming Guide', 5, 650.00;
EXEC sp_AddNewBook 'JavaScript for Beginners', 8, 500.00;
EXEC sp_AddNewBook 'Data Structures in Java', 6, 700.00;
EXEC sp_AddNewBook 'Python Essentials', 12, 550.00;
EXEC sp_PlaceOrder 1, 2;
SELECT * FROM Books;
select* from Orders1;

EXEC sp_PlaceOrder 2, 20;

EXEC sp_PlaceOrder 10, 1;