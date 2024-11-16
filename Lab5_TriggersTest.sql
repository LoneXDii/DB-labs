SELECT * FROM logs;

SELECT * FROM orders;
SELECT * FROM cars;
SELECT * FROM cars_orders;

INSERT INTO Cars_orders (car_id, order_id) 
VALUES (1, 5),
       (2, 5),
       (3, 5),
       (4, 4),
       (5, 4);
       
DELETE FROM cars_orders
WHERE id = 8;

SELECT * FROM users;
SELECT * FROM employees;
SELECT * FROM roles;

INSERT INTO Employees (user_id, first_name, last_name, phone_number, post) 
VALUES ('550e8400-e29b-41d4-a716-446655440003', 'A', 'B', '1234567890', 'Manager');