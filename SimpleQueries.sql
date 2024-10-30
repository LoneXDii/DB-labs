USE carrentdb;

-- Users CRUD
INSERT INTO Users (id, username, email, password_hash, role_id) 
VALUES ('some-uuid', 'username', 'email@example.com', 'hashed_password', 1);

SELECT * FROM Users;

SELECT username, email FROM users
WHERE role_id = 1; 

UPDATE Users 
SET username = 'new_username' 
WHERE id = 'some-uuid';

DELETE FROM Users 
WHERE id = 'some-uuid';

-- Logs CRUD
INSERT INTO Logs (user_id, datetime, action, table_name, comment) 
VALUES ('550e8400-e29b-41d4-a716-446655440000', NOW(), 'create', 'Users', 'User created');

SELECT * FROM Logs;

UPDATE Logs SET comment = 'Updated comment' WHERE id = 1;

DELETE FROM Logs WHERE id = 1;

-- Employess CRUD
INSERT INTO Employees (user_id, first_name, last_name, phone_number, post) 
VALUES ('550e8400-e29b-41d4-a716-446655440000', 'John', 'Doe', '1234567890', 'Manager');

SELECT * FROM Employees;

UPDATE Employees SET phone_number = '0987654321' 
WHERE id = 1;

DELETE FROM Employees 
WHERE id = 1;

-- Car_brands CRUD
INSERT INTO Car_brands (name) 
VALUES ('Toyota'), ('Ford');

SELECT * FROM Car_brands;

UPDATE Car_brands SET name = 'Honda' 
WHERE id = 1;

DELETE FROM Car_brands 
WHERE id = 1;

-- Car_classes CRUD
INSERT INTO Car_classes (name, exp_required) 
VALUES ('econom', 0), ('premium', 2);

SELECT * FROM Car_classes;

UPDATE Car_classes 
SET exp_required = 1 
WHERE id = 1;

-- Car_bodytypes CRUD
INSERT INTO Car_bodytypes (name) 
VALUES ('Sedan'), ('SUV');

SELECT * FROM Car_bodytypes;

UPDATE Car_bodytypes 
SET name = 'Hatchback' 
WHERE id = 1;

DELETE FROM Car_bodytypes 
WHERE id = 1;

-- Cars CRUD
INSERT INTO Cars (brand_id, class_id, bodytype_id, model, registration_number, price, rent_price, manufacture_year) 
VALUES (1, 1, 1, 'ModelX', 'ABC123', 30000.00, 150.00, 2020);

SELECT * FROM Cars;

UPDATE Cars 
SET model = 'ModelY' 
WHERE id = 1;

DELETE FROM Cars 
WHERE id = 1;

-- Orders CRUD
INSERT INTO Orders (start, end, price, closed, user_id) 
VALUES (NOW(), DATE_ADD(NOW(), INTERVAL 7 DAY), 350.00, FALSE, 'some-uuid');

SELECT * FROM Orders;

UPDATE Orders 
SET closed = TRUE 
WHERE id = 1;

DELETE FROM Orders 
WHERE id = 1;

-- Cars_orders CRUD
INSERT INTO Cars_orders (car_id, order_id) 
VALUES (1, 1);

SELECT * FROM Cars_orders;

UPDATE Cars_orders 
SET car_id = 2 
WHERE id = 1;

DELETE FROM Cars_orders 
WHERE id = 1;

-- Penaltys CRUD
INSERT INTO Penaltys (penalty, details, payed, order_id, user_id) 
VALUES (100.00, 'Late return', FALSE, 1, '550e8400-e29b-41d4-a716-446655440000');

SELECT * FROM Penaltys;

UPDATE Penaltys 
SET payed = TRUE 
WHERE id = 1;

DELETE FROM Penaltys 
WHERE id = 1;