SELECT * FROM users;

SELECT email FROM users
WHERE role_id = 2;

SELECT start, end, price FROM orders
WHERE user_id = "550e8400-e29b-41d4-a716-446655440000";

SELECT email, username FROM users
WHERE role_id IN (1, 2);

INSERT INTO car_brands (name) 
VALUES ('TEST');

SET SQL_SAFE_UPDATES = 0;

UPDATE car_brands
SET name='CHANGED'
WHERE name="TEST";

DELETE FROM car_brands
WHERE name = 'CHANGED';