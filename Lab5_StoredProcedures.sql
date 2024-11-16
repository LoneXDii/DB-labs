DELIMITER //

-- Получение всех машин по классу
CREATE PROCEDURE get_cars_by_class(
    IN p_class_id INT
)
BEGIN
    SELECT * FROM cars WHERE class_id = p_class_id;
END 
//

-- Получение всех заказов пользователя
CREATE PROCEDURE get_orders_by_user(
    IN p_user_id CHAR(36)
)
BEGIN
    SELECT * FROM orders WHERE user_id = p_user_id;
END 
//

-- Прибыль от завершенных заказов за промежуток времени
CREATE PROCEDURE calculate_total_profit(
    IN p_start_date DATETIME,
    IN p_end_date DATETIME,
    OUT total_profit FLOAT
)
BEGIN
    SELECT SUM(price) INTO total_profit
    FROM orders
    WHERE closed = TRUE AND start >= p_start_date AND end <= p_end_date;
END 
//

-- Добавление штрафов за задержку заказов
CREATE PROCEDURE update_penalties_for_delayed_orders()
BEGIN
    DECLARE v_order_id INT;
    DECLARE v_user_id CHAR(36);
    DECLARE v_current_time DATETIME DEFAULT NOW();
    DECLARE v_penalty_amount FLOAT DEFAULT 50.00;

    DECLARE order_cursor CURSOR FOR
        SELECT id, user_id FROM orders WHERE closed = FALSE AND end < v_current_time;

    DECLARE CONTINUE HANDLER FOR NOT FOUND SET v_order_id = NULL;

    OPEN order_cursor;

    read_loop: LOOP
        FETCH order_cursor INTO v_order_id, v_user_id;
        IF v_order_id IS NULL THEN
            LEAVE read_loop;
        END IF;

        -- Добавляем штраф
        INSERT INTO penaltys (penalty, details, payed, order_id, user_id)
        VALUES (v_penalty_amount, 'delay in return', FALSE, v_order_id, v_user_id);
    END LOOP;

    CLOSE order_cursor;
END //

-- Самый активный пользователь за промежуток времени
CREATE PROCEDURE most_active_user(
    IN p_start_date DATETIME,
    IN p_end_date DATETIME,
    OUT p_user_id CHAR(36),
    OUT p_order_count INT
)
BEGIN
    SELECT user_id, COUNT(*) AS order_count
    INTO p_user_id, p_order_count
    FROM orders
    WHERE start BETWEEN p_start_date AND p_end_date
    GROUP BY user_id
    ORDER BY order_count DESC
    LIMIT 1;
END //