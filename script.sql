USE [master]
GO
/****** Object:  Database [prn221_petworld]    Script Date: 2/26/2022 3:03:09 PM ******/
CREATE DATABASE [prn221_petworld]

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [prn221_petworld].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [prn221_petworld] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [prn221_petworld] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [prn221_petworld] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [prn221_petworld] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [prn221_petworld] SET ARITHABORT OFF 
GO
ALTER DATABASE [prn221_petworld] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [prn221_petworld] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [prn221_petworld] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [prn221_petworld] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [prn221_petworld] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [prn221_petworld] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [prn221_petworld] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [prn221_petworld] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [prn221_petworld] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [prn221_petworld] SET  DISABLE_BROKER 
GO
ALTER DATABASE [prn221_petworld] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [prn221_petworld] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [prn221_petworld] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [prn221_petworld] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [prn221_petworld] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [prn221_petworld] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [prn221_petworld] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [prn221_petworld] SET RECOVERY FULL 
GO
ALTER DATABASE [prn221_petworld] SET  MULTI_USER 
GO
ALTER DATABASE [prn221_petworld] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [prn221_petworld] SET DB_CHAINING OFF 
GO
ALTER DATABASE [prn221_petworld] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [prn221_petworld] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [prn221_petworld] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'prn221_petworld', N'ON'
GO
USE [prn221_petworld]
GO
/****** Object:  Table [dbo].[AccessoryDetail]    Script Date: 2/26/2022 3:03:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessoryDetail](
	[AccessoryId] [int] NOT NULL,
	[AccessoryName] [nvarchar](200) NOT NULL,
	[Price] [money] NOT NULL,
	[Image] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Accessory] PRIMARY KEY CLUSTERED 
(
	[AccessoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2/26/2022 3:03:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[ShippedDate] [datetime] NOT NULL,
	[Freight] [money] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 2/26/2022 3:03:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail1] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetDetail]    Script Date: 2/26/2022 3:03:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetDetail](
	[PetId] [int] NOT NULL,
	[PetName] [nvarchar](100) NOT NULL,
	[Price] [money] NOT NULL,
	[Weight] [float] NOT NULL,
	[Vaccinated] [bit] NOT NULL,
	[Gender] [bit] NOT NULL,
	[Age] [float] NOT NULL,
	[Sterilized] [bit] NOT NULL,
	[IsRescued] [bit] NOT NULL,
	[Image] [nvarchar](200) NULL,
 CONSTRAINT [PK_Pet] PRIMARY KEY CLUSTERED 
(
	[PetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2/26/2022 3:03:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[UnitsInStock] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/26/2022 3:03:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetail]    Script Date: 2/26/2022 3:03:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetail] ON [dbo].[OrderDetail]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccessoryDetail]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryDetail_Product] FOREIGN KEY([AccessoryId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[AccessoryDetail] CHECK CONSTRAINT [FK_AccessoryDetail_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[PetDetail]  WITH CHECK ADD  CONSTRAINT [FK_PetDetail_Product] FOREIGN KEY([PetId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[PetDetail] CHECK CONSTRAINT [FK_PetDetail_Product]
GO
USE [master]
GO
ALTER DATABASE [prn221_petworld] SET  READ_WRITE 
GO
