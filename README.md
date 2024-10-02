## Серсис: Прокат автомобилей

### Функциональные требования:

- Аутентификация пользователя;
- Управление пользователями (CRUD);
- Система ролей;
- Журналирование действий пользователя;
- Просмотр информации о машине
- Добавление машины в корзину
- Заказ всех машин из корзины
- Добавление/удаление машины в списке доступных
- Фильтраци машин по типу кузова, классу и марке
- Система штрафов для пользователей

### Сущности базы данных:

- **Users**
    - id: UUID (PK)
    - username: varchar(15), NOT NULL
    - email: varchar(40), NOT NULL
    - password\_hash: varchar(64), NOT NULL
    - role_id: int (FK)

- **Roles**
    - id: Int (PK)
    - role: enum("visitor", "admin", "employee"), NOT NULL

- **Logs**
    - id: Int (PK)
    - user\_id: UUID (FK)
    - datetime: datetime, NOT NULL
    - action: enum("create", "update", "delete"), NOT NULL
    - table\_name: varchar(20), NOT NULL
    - comment: varchar(100), NOT NULL

- **Employees**
    - id: Int (PK)
    - user\_id: UUID (FK)
    - first\_name: varchar(30), NOT NULL
    - last\_name: varchar(30), NOT NULL
    - phone\_number: varchar(12)
    - post: varchar(20), NOT NULL

- **Car\_brands**
    - id: Int (PK)
    - name: varchar(20), NOT NULL
    - description: text, NOT NULL
    - logo: image

- **Car\_classes** CHECK exp_required >= 0
    - id: Int (PK)
    - name: enum("econom", "premium", "sport"), NOT NULL
    - exp_required: int, NOT NULL

- **Car\_bodytypes**
    - id: Int (PK)
    - name: varchar(20), NOT NULL

- **Car** CHECK (price > 0 AND rent_price > 0)
    - id: Int (PK)
    - brand\_id: Int (FK)
    - class\_id: Int (FK)
    - bodytype\_id: Int (FK)
    - model: varchar(20), NOT NULL
    - registration_number: varchar(10), NOT NULL
    - price: float(9, 2), NOT NULL
    - rent_price: float(6, 2), NOT NULL
    - manufacture_year: int, NOT NULL

- **Orders** CHECK (price > 0 AND end > start)
    - id: Int (PK)
    - start: datetime, NOT NULL
    - end: datetime, NOT NULL
    - price: float(10, 2), NOT NULL
    - cloed: boolean, NOT NULL
    - user_id: UUID (FK)

- **Cars orders** 
    - id: Int (PK)
    - car\_id: Int (FK)
    - order\_id: Int (FK)

- **Penaltys** CHECK penalty > 0
    - id: Int (PK)
    - penalty: float(10, 2), NOT NULL
    - details: varchar(100)
    - payed: boolean, NOT NULL
    - order_id: int (FK)
    - user_id: UUID (FK)

### Ненормализованная схема БД:
![Scheme](./DB.drawio.svg)