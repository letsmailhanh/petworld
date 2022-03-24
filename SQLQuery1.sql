INSERT INTO [User] VALUES (N'admin', N'0123456789', N'admin@gmai.com', N'Ha Noi', N'admin', N'admin')

INSERT INTO [User] VALUES (N'hanh', N'0123456789', N'hanh@gmai.com', N'Ha Noi', N'hanh', N'staff')
INSERT INTO [User] VALUES (N'thuan', N'0123456789', N'thuan@gmai.com', N'Ha Noi', N'thuan', N'staff')

INSERT INTO [User] VALUES (N'huyen', N'0121212121', N'huyen@gmai.com', N'Ninh Binh', N'huyen', N'customer')
INSERT INTO [User] VALUES (N'test1', N'0121212121', N'test1@gmai.com', N'Phú Thọ', N'test1', N'customer')
INSERT INTO [User] VALUES (N'test2', N'0121212121', N'test2@gmai.com', N'Binh Thuận', N'test2', N'customer')

--Insert category
--select * from [Category]
--Pet category
INSERT INTO [Category] VALUES (N'Chó cảnh', 1)
INSERT INTO [Category] VALUES (N'Mèo cảnh', 1)
INSERT INTO [Category] VALUES (N'Thú kiểng', 1)

--Accessory
INSERT INTO [Category] VALUES (N'Thức ăn', 0)
INSERT INTO [Category] VALUES (N'Dụng cụ vệ sinh', 0)
INSERT INTO [Category] VALUES (N'Lồng, chuồng', 0)
INSERT INTO [Category] VALUES (N'Quần áo', 0)
INSERT INTO [Category] VALUES (N'Đồ chơi', 0)
INSERT INTO [Category] VALUES (N'Thuốc', 0)
INSERT INTO [Category] VALUES (N'Khác', 0)

--Insert product
--select * from [Product] where [IsPet] = 1
--Insert pet
INSERT INTO [Product] VALUES (N'Husky', 1, 1, '12000000', 1, N'/Image/husky1.jpg')
INSERT INTO [Product] VALUES (N'Husky', 1, 1, '9999000', 1,  N'/Image/husky2.jpg')
INSERT INTO [Product] VALUES (N'Husky', 1, 1, '8000000', 1,  N'/Image/husky3.jpg')

INSERT INTO [Product] VALUES (N'Pitbull', 1, 1, '68000000', 1, N'/Image/pitbull1.jpg')
INSERT INTO [Product] VALUES (N'Pitbull', 1, 1, '53000000', 1, N'/Image/pitbull2.jpg')

INSERT INTO [Product] VALUES (N'Poodle', 1, 1, '7000000', 1, N'/Image/poodle1.jpg')
INSERT INTO [Product] VALUES (N'Poodle', 1, 1, '12500000', 1, N'/Image/poodle2.jpg')
INSERT INTO [Product] VALUES (N'Poodle', 1, 1, '6700000', 1, N'/Image/poodle3.jpg')
INSERT INTO [Product] VALUES (N'Poodle', 1, 1, '5300000', 1, N'/Image/poodle4.jpg')

INSERT INTO [Product] VALUES (N'Maine coon', 2, 1, '12500000', 1, N'/Image/mainecoon1.jpg')
INSERT INTO [Product] VALUES (N'Maine coon', 2, 1, '15500000', 1, N'/Image/mainecoon2.jpg')

INSERT INTO [Product] VALUES (N'Anh lông ngắn', 2, 1, '16000000', 1, N'/Image/anhngan1.jpg')
INSERT INTO [Product] VALUES (N'Anh lông ngắn', 2, 1, '13300000', 1, N'/Image/anhngan2.jpg')

INSERT INTO [Product] VALUES (N'Anh lông dài', 2, 1, '6700000', 1, N'/Image/anhdai1.jpg')

INSERT INTO [Product] VALUES (N'Ba tư', 2, 1, '12800000', 1, N'/Image/batu1.jpg')

INSERT INTO [Product] VALUES (N'Bò sát', 3, 1, '320000', 1, N'/Image/bosat1.jpg')
INSERT INTO [Product] VALUES (N'Bò sát', 3, 1, '3500000', 1, N'/Image/bosat2.jpg')
INSERT INTO [Product] VALUES (N'Bò sát', 3, 1, '800000', 1, N'/Image/bosat3.jpg')

INSERT INTO [Product] VALUES (N'Cá', 3, 1, '12500000', 1, N'/Image/mainecoon1.jpg')
INSERT INTO [Product] VALUES (N'Cá', 3, 1, '12500000', 1, N'/Image/mainecoon1.jpg')
INSERT INTO [Product] VALUES (N'Cá', 3, 1, '12500000' , 1, N'/Image/mainecoon1.jpg')

INSERT INTO [Product] VALUES (N'Hamster', 3, 1, '125000', 1, N'/Image/hamster1.jpg')
INSERT INTO [Product] VALUES (N'Hamster', 3, 1, '50000', 1, N'/Image/hamster2.jpg')

--Insert accessory
INSERT INTO [Product] VALUES (N'Xương Gặm Orgo Sạch Răng', 4, 0, '20000', 20, N'/Image/thucan1.jpg')
INSERT INTO [Product] VALUES (N'Hạt Smartheart Gold Puppy 1kg', 4, 0, '119000', 13, N'/Image/thucan2.jpg')
INSERT INTO [Product] VALUES (N'Hạt mềm Zenith', 4, 0, '450000', 1, N'/Image/thucan3.jpg')

INSERT INTO [Product] VALUES (N'Cần câu cho mèo', 8, 0, '35000', 21, N'/Image/toy1.jpg')
INSERT INTO [Product] VALUES (N'Ống cào móng', 8, 0, '60000', 3, N'/Image/toy2.jpg')
INSERT INTO [Product] VALUES (N'Xương cao su', 8, 0, '25000', 12, N'/Image/toy3.jpg')
INSERT INTO [Product] VALUES (N'Đĩa bay vải', 8, 0, '45000', 7, N'/Image/toy4.jpg')

INSERT INTO [Product] VALUES(N'Balo trong suốt cho chó mèo', 6, 0, '290000', 10, N'/Image/balo1.jpg')
INSERT INTO [Product] VALUES(N'nNhà cây cho mèo', 6, 0, '1650000', 5, N'/Image/nha1.jpg')

INSERT INTO [Product] VALUES(N'Áo tai thỏ', 5, 0, '172000', 3, N'/Image/ao1.jpg')
INSERT INTO [Product] VALUES(N'Áo ba lỗ', 5, 0, '120000', 15, N'/Image/ao2.jpg')
INSERT INTO [Product] VALUES(N'Áo cosplay cảnh sát', 5, 0, '260000', 5, N'/Image/ao3.jpg')

--Insert pet detail
--select * from [Product] inner join [PetDetail] on [Product].ProductId = [PetDetail].ProductId
--select * from [PetDetail]
INSERT INTO [PetDetail] VALUES(1, N'Beo', 16.5, 1, 1, 2, 1, 0)
INSERT INTO [PetDetail] VALUES(2, N'Sữa', 17, 1, 0, 3, 1, 0)
INSERT INTO [PetDetail] VALUES(3, N'Yoda', 23.5, 0, 1, 3, 1, 0)
INSERT INTO [PetDetail] VALUES(4, N'Chaco', 20, 0, 0, 4, 0, 0)
INSERT INTO [PetDetail] VALUES(5, N'Bỏng', 17, 1, 1, 1, 0, 1)
INSERT INTO [PetDetail] VALUES(6, N'Bo', 2, 1, 0, 4, 1, 1)
INSERT INTO [PetDetail] VALUES(7, N'Su', 1.7, 1, 1, 3, 1, 0)
INSERT INTO [PetDetail] VALUES(8, N'Momo', 2.5, 1, 0, 2, 1, 1)
INSERT INTO [PetDetail] VALUES(9, N'Tí', 3.5, 1, 0, 2, 0, 0)
INSERT INTO [PetDetail] VALUES(10, N'Nhọ', 3.6, 0, 0, 3, 1, 0)
INSERT INTO [PetDetail] VALUES(11, N'Nho', 4.2, 1, 0, 4, 1, 0)
INSERT INTO [PetDetail] VALUES(12, N'Chả', 3.7, 0, 1, 1, 1, 1)
INSERT INTO [PetDetail] VALUES(13, N'Lucas', 5.1, 1, 1, 3, 1, 0 )
INSERT INTO [PetDetail] VALUES(14, N'Rosa', 4.8, 1, 0, 2, 0, 1)
INSERT INTO [PetDetail] VALUES(15, N'Đậu phụ', 3.8, 0, 1, 2, 1, 1)

INSERT INTO [PetDetail] VALUES(16, N'Hung', 4.2, 0, 1, 1, 0, 0)
INSERT INTO [PetDetail] VALUES(17, N'Lếu', 3.3, 0, 1, 1, 0, 0)
INSERT INTO [PetDetail] VALUES(18, N'Bi', 1.2, 0, 1, 1, 0, 0)
INSERT INTO [PetDetail] VALUES(19, N'Cá chép Nhật', 8, 0, 1, 1, 0, 0)
INSERT INTO [PetDetail] VALUES(20, N'Lau kiếng', 1.2, 0, 1, 1, 0, 0)
INSERT INTO [PetDetail] VALUES(21, N'Tai tượng', 23, 0, 1, 1, 0, 0)
INSERT INTO [PetDetail] VALUES(22, N'Tún', 0.12, 0, 1, 1, 0, 0)
INSERT INTO [PetDetail] VALUES(23, N'Tếu', 0.14, 0, 1, 1, 0, 0)

--Insert order
--select * from [Order]

--Status: 0: unconfirmed, 1: confirm, 2: shipping, 3: shipped
INSERT INTO [Order] (UserId, OrderDate, ShippedDate, Status) VALUES (4, '2022/02/21', '2022/03/01', 3)
INSERT INTO [Order] (UserId, OrderDate, ShippedDate, Status) VALUES (5, '2022/02/25', '2022/03/05', 3)
INSERT INTO [Order] (UserId, OrderDate, ShippedDate, Status) VALUES (6, '2022/01/31', '2022/02/10', 3)
INSERT INTO [Order] (UserId, OrderDate, ShippedDate, Status) VALUES (4, '2022/03/06', '2022/03/11', 3)
INSERT INTO [Order] (UserId, OrderDate, ShippedDate, Status) VALUES (4, '2022/03/07', '2022/03/09', 3)
INSERT INTO [Order] (UserId, OrderDate, ShippedDate, Status) VALUES (5, '2022/03/03', '2022/03/10', 3)

--Insert order detail
--select * from [OrderDetail]
INSERT INTO [OrderDetail] VALUES(1, 12, '16000000', 1)
INSERT INTO [OrderDetail] VALUES(1, 28, '60000', 2)
INSERT INTO [OrderDetail] VALUES(1, 26, '45000', 3)
INSERT INTO [OrderDetail] VALUES(1, 11, '15500000', 1)

INSERT INTO [OrderDetail] VALUES(2, 35, '260000', 2)
INSERT INTO [OrderDetail] VALUES(2, 34, '120000', 1)

INSERT INTO [OrderDetail] VALUES(3, 10, '12500000', 1)

INSERT INTO [OrderDetail] VALUES(4, 3, '8000000', 1)
INSERT INTO [OrderDetail] VALUES(4, 24, '20000', 5)

INSERT INTO [OrderDetail] VALUES(5, 26, '450000', 8)

INSERT INTO [OrderDetail] VALUES(6, 5, '53000000', 1)
INSERT INTO [OrderDetail] VALUES(6, 4, '68000000', 1)
INSERT INTO [OrderDetail] VALUES(6, 32, '1650000', 7)