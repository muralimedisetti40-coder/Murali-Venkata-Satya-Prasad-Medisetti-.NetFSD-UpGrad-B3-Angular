--Level-1: Problem 1 – Product Analysis Using Nested Queries
use day4;
CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    model_year INT,
    list_price DECIMAL(10,2),
    category_id INT,
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO categories VALUES
(1, 'Sports Bike'),
(2, 'Cruiser'),
(3, 'Electric Bike');

INSERT INTO products VALUES
(1, 'Yamaha R15', 2022, 180000, 1),
(2, 'Kawasaki Ninja', 2023, 350000, 1),
(3, 'KTM RC 200', 2022, 210000, 1),
(4, 'Royal Enfield Classic', 2021, 190000, 2),
(5, 'Royal Enfield Meteor', 2023, 220000, 2),
(6, 'Bajaj Avenger', 2022, 160000, 2),
(7, 'Ola S1', 2023, 140000, 3),
(8, 'Ather 450X', 2023, 155000, 3),
(9, 'TVS iQube', 2022, 120000, 3);
 
SELECT 
    CONCAT(product_name,' (',model_year,')') AS product_details,
    list_price,   
    list_price - (
        SELECT AVG(p2.list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
    ) AS price_difference
FROM products p1
WHERE list_price > (
        SELECT AVG(p2.list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
);