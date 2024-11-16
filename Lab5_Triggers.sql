DELIMITER //
-- Устанавливает время завершения заказа при его закрытии
CREATE TRIGGER set_order_end_time
BEFORE UPDATE ON orders
FOR EACH ROW
BEGIN
    IF NEW.closed = TRUE AND OLD.closed = FALSE THEN
        SET NEW.end = NOW();
    END IF;
END;
//

-- Меняет роль пользователя на сотрудник при создании сотрудника в бд
CREATE TRIGGER set_user_role_id_while_creating_employee
AFTER INSERT ON employees
FOR EACH ROW
BEGIN
    UPDATE users
    SET role_id = (SELECT id FROM Roles WHERE role = 'employee')
    WHERE id = NEW.user_id;
END;
//

-- Увеличение цены заказа при добавлении машины в заказ
CREATE TRIGGER update_order_price_on_car_added
AFTER INSERT ON Cars_orders
FOR EACH ROW
BEGIN
    DECLARE car_price FLOAT(10, 2);

    SELECT rent_price INTO car_price
    FROM cars
    WHERE id = NEW.car_id;

    UPDATE orders
    SET price = price + car_price
    WHERE id = NEW.order_id;
END;
//

-- Уменьшение цены заказа при удалении машины из заказа
CREATE TRIGGER update_order_price_on_car_delete
BEFORE DELETE ON Cars_orders
FOR EACH ROW
BEGIN
    DECLARE car_price FLOAT(10, 2);

    SELECT rent_price INTO car_price
    FROM cars
    WHERE id = OLD.car_id;

    UPDATE orders
    SET price = price - car_price
    WHERE id = OLD.order_id;
END;
//

-- Триггеры для логов
CREATE TRIGGER log_users_insert
AFTER INSERT ON users
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'create', 'users', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_users_update
AFTER UPDATE ON users
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'update', 'users', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_users_delete
BEFORE DELETE ON users
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'delete', 'users', CONCAT('Entity id = ', OLD.id));
END;
//

CREATE TRIGGER log_roles_insert
AFTER INSERT ON roles
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'create', 'roles', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_roles_update
AFTER UPDATE ON roles
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'update', 'roles', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_roles_delete
BEFORE DELETE ON roles
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'delete', 'roles', CONCAT('Entity id = ', OLD.id));
END;
//

CREATE TRIGGER log_employees_insert
AFTER INSERT ON employees
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'create', 'employees', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_employees_update
AFTER UPDATE ON employees
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'update', 'employees', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_employees_delete
BEFORE DELETE ON employees
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'delete', 'employees', CONCAT('Entity id = ', OLD.id));
END;
//

CREATE TRIGGER log_car_brands_insert
AFTER INSERT ON car_brands
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'create', 'car_brands', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_car_brands_update
AFTER UPDATE ON car_brands
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'update', 'car_brands', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_car_brands_delete
BEFORE DELETE ON car_brands
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'delete', 'car_brands', CONCAT('Entity id = ', OLD.id));
END;
//

CREATE TRIGGER log_car_classes_insert
AFTER INSERT ON car_classes
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'create', 'car_classes', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_car_classes_update
AFTER UPDATE ON car_classes
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'update', 'car_classes', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_car_classes_delete
BEFORE DELETE ON car_classes
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'delete', 'car_classes', CONCAT('Entity id = ', OLD.id));
END;
//

CREATE TRIGGER log_car_bodytypes_insert
AFTER INSERT ON car_bodytypes
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'create', 'car_bodytypes', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_car_bodytypes_update
AFTER UPDATE ON car_bodytypes
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'update', 'car_bodytypes', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_car_bodytypes_delete
BEFORE DELETE ON car_bodytypes
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'delete', 'car_bodytypes', CONCAT('Entity id = ', OLD.id));
END;
//

CREATE TRIGGER log_cars_insert
AFTER INSERT ON cars
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'create', 'cars', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_cars_update
AFTER UPDATE ON cars
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'update', 'cars', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_cars_delete
BEFORE DELETE ON cars
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'delete', 'cars', CONCAT('Entity id = ', OLD.id));
END;
//

CREATE TRIGGER log_cars_orders_insert
AFTER INSERT ON cars_orders
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'create', 'cars_orders', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_cars_orders_delete
BEFORE DELETE ON cars_orders
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'delete', 'cars_orders', CONCAT('Entity id = ', OLD.id));
END;
//

CREATE TRIGGER log_penaltys_insert
AFTER INSERT ON penaltys
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'create', 'penaltys', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_penaltys_update
AFTER UPDATE ON penaltys
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'update', 'penaltys', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_penaltys_delete
BEFORE DELETE ON penaltys
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'delete', 'penaltys', CONCAT('Entity id = ', OLD.id));
END;
//

CREATE TRIGGER log_orders_insert
AFTER INSERT ON orders
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'create', 'orders', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_orders_update
AFTER UPDATE ON orders
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'update', 'orders', CONCAT('Entity id = ', NEW.id));
END;
//

CREATE TRIGGER log_orders_delete
BEFORE DELETE ON orders
FOR EACH ROW
BEGIN
    INSERT INTO logs (datetime, action, table_name, comment)
    VALUES (NOW(), 'delete', 'orders', CONCAT('Entity id = ', OLD.id));
END;
//