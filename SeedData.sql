USE carrentdb;

INSERT INTO Roles (role) 
VALUES ('visitor'),
	   ('admin'),
       ('employee');

INSERT INTO Users (id, username, email, password_hash, role_id) 
VALUES ('550e8400-e29b-41d4-a716-446655440000', 'john_doe', 'john@example.com', 'hashed_password_1', 1),
       ('550e8400-e29b-41d4-a716-446655440001', 'admin_user', 'admin@example.com', 'hashed_password_2', 2),
       ('550e8400-e29b-41d4-a716-446655440002', 'employee_user', 'employee@example.com', 'hashed_password_3', 3);

INSERT INTO Logs (user_id, datetime, action, table_name, comment) 
VALUES ('550e8400-e29b-41d4-a716-446655440000', NOW(), 'create', 'Users', 'User created'),
       ('550e8400-e29b-41d4-a716-446655440001', NOW(), 'update', 'Roles', 'Role updated'),
       ('550e8400-e29b-41d4-a716-446655440002', NOW(), 'delete', 'Employees', 'Employee deleted');

INSERT INTO Employees (user_id, first_name, last_name, phone_number, post) 
VALUES ('550e8400-e29b-41d4-a716-446655440002', 'Jane', 'Smith', '1234567890', 'Manager'),
       ('550e8400-e29b-41d4-a716-446655440000', 'Alice', 'Johnson', '0987654321', 'Clerk');

INSERT INTO Car_brands (name) 
VALUES ('Toyota'),
       ('Ford'),
       ('BMW'),
       ('Mercedes');


INSERT INTO Car_classes (name, exp_required) 
VALUES ('econom', 0),
       ('premium', 2),
       ('sport', 5);

INSERT INTO Car_bodytypes (name) 
VALUES ('sedan'),
       ('hatchback'),
       ('SUV'),
       ('coupe');

INSERT INTO Cars (brand_id, class_id, bodytype_id, model, registration_number, price, rent_price, manufacture_year) 
VALUES (1, 1, 1, 'Corolla', 'ABC123', 20000.00, 150.00, 2020),
       (2, 2, 2, 'Mustang', 'XYZ789', 30000.00, 250.00, 2021),
       (3, 3, 3, 'X5', 'LMN456', 60000.00, 400.00, 2022);

INSERT INTO Orders (start, end, price, closed, user_id) 
VALUES (NOW(), NOW() + INTERVAL 1 DAY, 150.00, FALSE, '550e8400-e29b-41d4-a716-446655440000'),
	   (NOW(), NOW() + INTERVAL 2 DAY, 300.00, FALSE, '550e8400-e29b-41d4-a716-446655440001');

INSERT INTO Cars_orders (car_id, order_id) 
VALUES (1, 1),
       (2, 2);

INSERT INTO Penaltys (penalty, details, payed, order_id, user_id) 
VALUES (50.00, 'Late return', FALSE, 1, '550e8400-e29b-41d4-a716-446655440000'),
       (100.00, 'Damage to vehicle', FALSE, 2, '550e8400-e29b-41d4-a716-446655440001');