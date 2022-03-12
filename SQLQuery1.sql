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
--select * from [Product]
--Insert pet
INSERT INTO [Product] VALUES (N'Husky', 1, 1, '12000000', 1, N'Image\husky1.jpg')
INSERT INTO [Product] VALUES (N'Husky', 1, 1, '9999000', 1,  N'Image\husky2.jpg')
INSERT INTO [Product] VALUES (N'Husky', 1, 1, '8000000', 1,  N'Image\husky3.jpg')

INSERT INTO [Product] VALUES (N'Pitbull', 1, 1, '68000000', 1, N'Image\pitbull1.jpg')
INSERT INTO [Product] VALUES (N'Pitbull', 1, 1, '53000000', 1, N'Image\pitbull2.jpg')

INSERT INTO [Product] VALUES (N'Phú Quốc', 1, 1, , 1, )

INSERT INTO [Product] VALUES (N'Poodle', 1, 1, '7000000', 1, N'Image\poodle1.jpg')
INSERT INTO [Product] VALUES (N'Poodle', 1, 1, '12500000', 1, N'Image\poodle1.jpg')
INSERT INTO [Product] VALUES (N'Poodle', 1, 1, '6700000', 1, N'Image\poodle1.jpg')
INSERT INTO [Product] VALUES (N'Poodle', 1, 1, '5300000', 1, N'Image\poodle1.jpg')

INSERT INTO [Product] VALUES (N'Maine coon', 2, 1, '12500000', 1, N'Image\mainecoon1.jpg')
INSERT INTO [Product] VALUES (N'Maine coon', 2, 1, '15500000', 1, N'Image\mainecoon2.jpg')

INSERT INTO [Product] VALUES (N'Anh lông ngắn', 2, 1, '16000000', 1, N'Image\anhngan1.jpg')
INSERT INTO [Product] VALUES (N'Anh lông ngắn', 2, 1, '13300000', 1, N'Image\anhngan2.jpg')

INSERT INTO [Product] VALUES (N'Anh lông dài', 2, 1, '6700000', 1, N'Image\anhdai1.jpg')

INSERT INTO [Product] VALUES (N'Ba tư', 2, 1, '12800000', 1, N'Image\batu1.jpg')

INSERT INTO [Product] VALUES (N'Bò sát', 3, 1, '320000', 1, N'Image\bosat1.jpg')
INSERT INTO [Product] VALUES (N'Bò sát', 3, 1, '3500000', 1, N'Image\bosat2.jpg')
INSERT INTO [Product] VALUES (N'Bò sát', 3, 1, '800000', 1, N'Image\bosat3.jpg')

INSERT INTO [Product] VALUES (N'Cá', 3, 1, '12500000', 1, N'Image\mainecoon1.jpg')
INSERT INTO [Product] VALUES (N'Cá', 3, 1, '12500000', 1, N'Image\mainecoon1.jpg')
INSERT INTO [Product] VALUES (N'Cá', 3, 1, '12500000' , 1, N'Image\mainecoon1.jpg')

INSERT INTO [Product] VALUES (N'Hamster', 3, 1, '125000', 1, N'Image\hamster1.jpg')
INSERT INTO [Product] VALUES (N'Hamster', 3, 1, '50000', 1, N'Image\hamster2.jpg')

--Insert accessory
INSERT INTO [Product] VALUES (N'Xương Gặm Orgo Sạch Răng', 4, 0, '20000', 20, N'Image\thucan1.jpg')
INSERT INTO [Product] VALUES (N'Hạt Smartheart Gold Puppy 1kg', 4, 0, '119000', 13, N'Image\thucan2.jpg')
INSERT INTO [Product] VALUES (N'Hạt mềm Zenith', 4, 0, '450000', 1, N'Image\thucan3.jpg')

INSERT INTO [Product] VALUES (N'Cần câu cho mèo', 8, 0, '35000', 21, N'Image\toy1.jpg')
INSERT INTO [Product] VALUES (N'Ống cào móng', 8, 0, '60000', 3, N'Image\toy2.jpg')
INSERT INTO [Product] VALUES (N'Xương cao su', 8, 0, '25000', 12, N'Image\toy3.jpg')
INSERT INTO [Product] VALUES (N'Đĩa bay vải', 8, 0, '45000', 7, N'Image\toy4.jpg')
