SET @start_date = '2024-01-01 00:00:00';
SET @end_date = '2024-12-31 23:59:59';
SET @active_user_id = NULL;
SET @order_count = NULL;

CALL most_active_user(@start_date, @end_date, @active_user_id, @order_count);

SELECT orders.id AS order_id, orders.start, orders.end, orders.price, cars.model, cars.registration_number
FROM orders
	JOIN cars_orders ON orders.id = cars_orders.order_id
	JOIN cars ON cars_orders.car_id = cars.id
WHERE orders.user_id = @active_user_id;