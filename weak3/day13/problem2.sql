
--The sales team wants a product listing categorized by product category along with brand details to understand product distribution.

USE custumers;

CREATE TABLE brand(
 brand_id int PRIMARY KEY,
 brand_name VARCHAR(50)
);
 CREATE TABLE categories(
    category_id INT PRIMARY key,
    category_name VARCHAR(50)
 );
 CREATE table products(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
   brand_id INT,
    category_id INT,
    model_year INT,
    last_price DECIMAL(10,2),
   FOREIGN key(brand_id) REFERENCES brand(brand_id),
    FOREIGN key(category_id) REFERENCES categories(category_id)
 );
 INSERT into brand VALUES(1,'apple'),
 (2,'puma'),
 (3,'hp');
SELECT * from brand;
INSERT into categories VALUES(1,'mobile'),
(2,'footwear'),
(3,'laptop');
SELECT * from categories;
INSERT INTO products VALUES
(101, 'iPhone 14', 1, 1, 2023, 999.00),
(102, 'Puma Shoes', 2, 2, 2022, 650.00),
(103, 'HP Pavilion', 3, 3, 2023, 850.00),
(105, 'Puma Slippers', 2, 2, 2023, 300.00),
(106, 'HP Laptop Pro', 3, 3, 2024, 1200.00);
SELECT * from products;


SELECT p.product_name,
       b.brand_name,
       c.category_name,
       p.model_year,
       p.last_price
       from products p INNER JOIN brand b ON p.brand_id=b.brand_id INNER JOIN categories c ON p.category_id=c.category_id
       WHERE p.last_price>500
       ORDER BY p.model_year ASC;