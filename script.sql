use [master]

if db_id('prn221_petworld') is not null
begin
drop database [prn221_petworld]
end

create database [prn221_petworld]

use [prn221_petworld]

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL primary key,
	[UserName] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL
)


CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL primary key,
	[Title] [nvarchar](100) NOT NULL,
	[IsPet] [bit] DEFAULT 0,
)

CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL primary key,
	[ProductName] [nvarchar](100) NOT NULL,
	[CategoryId] [int] REFERENCES [dbo].[Category](CategoryId) NOT NULL,
	[IsPet] [bit] DEFAULT 0 NOT NULL,
	[Price] [money] DEFAULT 0 NOT NULL,
	[UnitsInStock] [int] DEFAULT 0 NOT NULL,
	[Image] [nvarchar](512) NULL
)

CREATE TABLE [dbo].[PetDetail](
	[PetId] [int] IDENTITY(1,1) NOT NULL primary key,
	[ProductId] [int] REFERENCES [dbo].[Product](ProductId) NOT NULL UNIQUE,
	[PetName] [nvarchar](100) NULL,
	[Weight] [float] DEFAULT 0 NOT NULL,
	[Vaccinated] [bit] DEFAULT 0 NOT NULL,
	[Gender] [bit] DEFAULT 0 NOT NULL,
	[Age] [float] DEFAULT 0 NOT NULL,
	[Sterilized] [bit] DEFAULT 0 NOT NULL,
	[IsRescued] [bit] DEFAULT 0 NOT NULL,
)

CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL Primary key,
	[UserId] [int] REFERENCES [dbo].[User](UserId) NOT NULL,
	[OrderDate] [datetime] DEFAULT GETDATE() NOT NULL,
	[ShippedDate] [datetime] NULL,
	[Freight] [money] DEFAULT 0 NOT NULL
)

CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL REFERENCES [dbo].[Order](OrderId),
	[ProductId] [int] NOT NULL REFERENCES [dbo].[Product](ProductId),
	[Price] [money] NOT NULL DEFAULT 0,
	[Quantity] [int] NOT NULL DEFAULT 0,
	PRIMARY KEY (OrderId, ProductId)
)

INSERT INTO [dbo].[User](UserName, Password, Role) VALUES (N'Admin@petworld.com', N'admin123', N'ADMIN')