-- Сумма неоплаченных штрафов пользователя
SELECT SUM(penalty) FROM penaltys
WHERE payed = FALSE
GROUP BY user_id
HAVING user_id = '550e8400-e29b-41d4-a716-446655440000';

-- Информация о всех машинах
SELECT car_brands.name, cars.model, cars.registration_number, car_bodytypes.name, car_classes.name
FROM cars
	LEFT JOIN car_brands ON cars.brand_id = car_brands.id
    LEFT JOIN car_bodytypes ON cars.bodytype_id = car_bodytypes.id
    LEFT JOIN car_classes ON cars.class_id = car_classes.id;

-- Список машин, для которых нет активных заказов
SELECT car_brands.name, cars.model, cars.registration_number
FROM cars
	LEFT JOIN car_brands ON cars.brand_id = car_brands.id
	LEFT JOIN cars_orders ON cars.id = cars_orders.car_id
	LEFT JOIN orders ON cars_orders.order_id = orders.id AND orders.closed = FALSE
WHERE orders.id IS NULL;

-- Список пользователей, у которых сумма всех заказов больше средней для всех пользователей
SELECT users.username, users.email
FROM users
WHERE users.id IN (
    SELECT orders.user_id
    FROM orders
    WHERE orders.price > (
        SELECT AVG(price)
        FROM orders
    )
);

-- Список пользователей, чья сумма штрафов больше средней суммы штрафов пользователей
SELECT users.username, users.email, SUM(penaltys.penalty) AS total_penalty
FROM users
	JOIN penaltys ON users.id = penaltys.user_id
WHERE users.id IN (
    SELECT orders.user_id
    FROM orders
)
GROUP BY users.id
HAVING total_penalty > (
    SELECT AVG(penalty)
    FROM penaltys
);

-- Вывод информации об общей сумме заказов с ранжированием для каждой роли
SELECT users.username, users.email, SUM(orders.price) AS total_spent, roles.role,
    RANK() OVER (PARTITION BY users.role_id ORDER BY SUM(orders.price) DESC) AS rank_within_role
FROM users
	JOIN orders ON users.id = orders.user_id
    LEFT JOIN roles ON roles.id = users.role_id
GROUP BY users.id
ORDER BY users.role_id, rank_within_role;

-- Список пользователей, у которых есть заказы на сумму больше 300
SELECT username, email
FROM users
WHERE EXISTS (
    SELECT 1
    FROM orders
    WHERE orders.user_id = users.id AND orders.price > 350
);

-- Список заказов с присвоением им категории по их сумме
SELECT orders.id, orders.price,
       CASE 
           WHEN orders.price < 350 THEN 'Low'
           WHEN orders.price BETWEEN 350 AND 400 THEN 'Medium'
           ELSE 'High'
       END AS price_category
FROM orders;

SELECT users.email, cars.model AS car_model
FROM users
LEFT JOIN orders ON users.id = orders.user_id
LEFT JOIN cars_orders ON orders.id = cars_orders.order_id
LEFT JOIN cars ON cars_orders.car_id = cars.id
WHERE cars.model IS NOT NULL
ORDER BY users.email;
