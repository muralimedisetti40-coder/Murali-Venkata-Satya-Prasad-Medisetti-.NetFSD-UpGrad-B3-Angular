--The inventory manager wants to compare stock availability and total quantity sold for each product.

USE custumers;
CREATE TABLE products1(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50)
);
CREATE TABLE store1(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);
CREATE TABLE stocks(
    store_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (store_id) REFERENCES store1(store_id),
    FOREIGN KEY (product_id) REFERENCES products1(product_id)
);

CREATE TABLE order_items1(
    item_id INT PRIMARY KEY,
    store_id INT,
    product_id INT,
    item_quantity INT,
    FOREIGN KEY (store_id) REFERENCES store1(store_id),
    FOREIGN KEY (product_id) REFERENCES products1(product_id)
);

INSERT INTO products1 VALUES
(1,'iPhone'),
(2,'Laptop'),
(3,'Shoes');

INSERT INTO store1 VALUES
(1,'palakollu'),
(2,'bhimavaram');

INSERT INTO stocks VALUES
(1,1,50),
(1,2,30),
(1,3,20),
(2,1,40),
(2,2,25),
(2,3,10);
INSERT INTO order_items1 VALUES
(1,1,1,5),   
(2,2,3,3),  
(3,1,1,2),   
(4,2,2,4);   

SELECT p.product_name,s1.store_name,s.quantity AS totalquantity,isnull(SUM(oi.item_quantity),0) AS totalquantitysold 
FROM stocks s
INNER JOIN products1 p 
    ON s.product_id = p.product_id
INNER JOIN store1 s1
    ON s1.store_id = s.store_id
LEFT JOIN order_items1 oi 
    ON s.store_id = oi.store_id 
    AND s.product_id = oi.product_id
 GROUP BY 
    p.product_name,
    s1.store_name,
    s.quantity
ORDER BY p.product_name;
