CREATE DATABASE db_QLThuocDongY;
GO
USE db_QLThuocDongY;
GO
---
CREATE TABLE tb_product (
    id_product CHAR(20) PRIMARY KEY,      
    Product_Name NVARCHAR(50),             
    Prices INT,                      
    Quantity FLOAT,                       
    Type NVARCHAR(10),             
    Status NVARCHAR(20)   
);
---
CREATE TABLE tb_useraccount (
    id_user CHAR(20) PRIMARY KEY,       
    username NVARCHAR(20) UNIQUE,       
    email CHAR(50),                     
    FullName NVARCHAR(50),                 
    Pass CHAR(50)                    
);
---
CREATE TABLE tb_order (
    id_order CHAR(20) PRIMARY KEY,      
    id_user CHAR(20),
    Status NVARCHAR(50),
    order_date DATE,                         
    total_price INT,                         
    firstname NVARCHAR(50),
    lastname NVARCHAR(50),
    email CHAR(50),
    phone CHAR(20),
    detail_address NVARCHAR(50),
    payment_method char(20)
);
--- 
CREATE TABLE tb_orderdetail (
    id_order CHAR(20),   
    id_product CHAR(20),     
    Quantity FLOAT,         
    Price INT            
	PRIMARY KEY (id_order, id_product)
);
---
GO
INSERT INTO tb_product (id_product, Product_Name, Prices, Quantity, Type, Status) VALUES
('T005', N'Bạch chỉ', 30000, 25, N'gram', N'Còn hàng'),
('T006', N'Cam thảo', 20000, 40, N'gram', N'Còn hàng'),
('T007', N'Hoàng kỳ', 35000, 30, N'gram', N'Còn hàng'),
('T008', N'Táo nhân', 28000, 15, N'gram', N'Hết hàng'),
('T009', N'Nhân sâm', 150000, 10, N'gram', N'Ngừng kinh doanh');

---

INSERT INTO tb_useraccount (id_user, username, email, FullName, Pass) VALUES
('U001', N'jane_doe', 'janedoe_admin@gmail.com', N'Jane Doe', 'admin123'),
('U002', N'tran_thanh', 'tranthanh@gmail.com', N'Trấn Thành', '25102005'),
('U003', N'tran_anh', 'anh@gmail.com', N'Trần Anh', 'pass789');

---
INSERT INTO tb_order 
(id_order, id_user, order_date, total_price, firstname, lastname, email, phone, detail_address, Status, payment_method) 
VALUES
('D001', 'U001', '2024-03-01', 150000, N'Jane', N'Doe', 'janedoe_admin@gmail.com', '0123456789', N'123 Main St', N'Chờ xử lý', 0),
('D002', 'U002', '2024-03-05', 125000, N'Thành', N'Trấn', 'tranthanh@gmail.com', '0987654321', N'456 Binh Thanh', N'Đang giao', 1),
('D003', 'U003', '2024-03-10', 200000, N'Anh', N'Trần', 'anh@gmail.com', '0909090909', N'789 District 1', N'Đã giao', 0);

---
INSERT INTO tb_orderdetail(id_order, id_product, Quantity, Price) VALUES
('D001', 'T005', 10, 150000),
('D002', 'T006', 5, 125000),
('D003', 'T008', 20, 200000);

select * from tb_order
select * from tb_orderdetail

SELECT RTRIM(id_user) AS id_user, FullName, username, RTRIM(email) AS email, Pass FROM tb_useraccount