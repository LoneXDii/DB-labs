USE carrentdb;

CREATE TABLE Roles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    role ENUM('visitor', 'admin', 'employee') NOT NULL
);

-- select * from Users;

CREATE TABLE Users (
    id VARCHAR(36) NOT NULL DEFAULT (UUID()),
    username VARCHAR(15) NOT NULL,
    email VARCHAR(40) NOT NULL,
    password_hash VARCHAR(64) NOT NULL,
    role_id INT,
    FOREIGN KEY (role_id) REFERENCES Roles(id)
    ON DELETE SET NULL,
    UNIQUE (id)
);

CREATE TABLE Logs (
    id INT AUTO_INCREMENT PRIMARY KEY,
    datetime DATETIME NOT NULL,
    action ENUM('create', 'update', 'delete') NOT NULL,
    table_name VARCHAR(20) NOT NULL,
    comment longtext
);

CREATE TABLE Employees (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id VARCHAR(36),
    first_name VARCHAR(30) NOT NULL,
    last_name VARCHAR(30) NOT NULL,
    phone_number VARCHAR(12),
    post VARCHAR(20) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(id)
    ON DELETE CASCADE
);

CREATE TABLE Car_brands (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20) NOT NULL
);

CREATE TABLE Car_classes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name ENUM('econom', 'premium', 'sport') NOT NULL,
    exp_required INT NOT NULL CHECK (exp_required >= 0)
);

CREATE TABLE Car_bodytypes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20) NOT NULL
);

CREATE TABLE Cars (
    id INT AUTO_INCREMENT PRIMARY KEY,
    brand_id INT,
    class_id INT,
    bodytype_id INT,
    model VARCHAR(20) NOT NULL,
    registration_number VARCHAR(10) NOT NULL,
    price FLOAT(9, 2) NOT NULL CHECK (price > 0),
    rent_price FLOAT(6, 2) NOT NULL CHECK (rent_price > 0),
    manufacture_year INT NOT NULL,
    FOREIGN KEY (brand_id) REFERENCES Car_brands(id)
    ON DELETE CASCADE,
    FOREIGN KEY (class_id) REFERENCES Car_classes(id)
    ON DELETE CASCADE,
    FOREIGN KEY (bodytype_id) REFERENCES Car_bodytypes(id)
    ON DELETE CASCADE
);

CREATE TABLE Orders (
    id INT AUTO_INCREMENT PRIMARY KEY,
    start DATETIME NOT NULL,
    end DATETIME NOT NULL,
    price FLOAT(10, 2) NOT NULL CHECK (price >= 0),
    closed BOOLEAN NOT NULL,
    user_id VARCHAR(36),
    FOREIGN KEY (user_id) REFERENCES Users(id)
    ON DELETE CASCADE
);

CREATE TABLE Cars_orders (
    id INT AUTO_INCREMENT PRIMARY KEY,
    car_id INT,
    order_id INT,
    FOREIGN KEY (car_id) REFERENCES Cars(id)
    ON DELETE CASCADE,
    FOREIGN KEY (order_id) REFERENCES Orders(id)
    ON DELETE CASCADE
);

CREATE TABLE Penaltys (
    id INT AUTO_INCREMENT PRIMARY KEY,
    penalty FLOAT(10, 2) NOT NULL CHECK (penalty > 0),
    details VARCHAR(100),
    payed BOOLEAN NOT NULL,
    order_id INT,
    user_id CHAR(36),
    FOREIGN KEY (order_id) REFERENCES Orders(id)
    ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES Users(id)
    ON DELETE CASCADE
);