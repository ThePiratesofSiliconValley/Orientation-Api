USE [master]
GO
/****** Object:  Database [OrientationAPI]    Script Date: 4/8/2018 1:18:58 PM ******/
CREATE DATABASE [OrientationAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrientationAPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\OrientationAPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrientationAPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\OrientationAPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OrientationAPI] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrientationAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrientationAPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrientationAPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrientationAPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrientationAPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrientationAPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrientationAPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OrientationAPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrientationAPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrientationAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrientationAPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrientationAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrientationAPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrientationAPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrientationAPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrientationAPI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OrientationAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrientationAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrientationAPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrientationAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrientationAPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrientationAPI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OrientationAPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrientationAPI] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OrientationAPI] SET  MULTI_USER 
GO
ALTER DATABASE [OrientationAPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrientationAPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrientationAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrientationAPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OrientationAPI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OrientationAPI] SET QUERY_STORE = OFF
GO
USE [OrientationAPI]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [OrientationAPI]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/8/2018 1:18:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderLine]    Script Date: 4/8/2018 1:18:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLine](
	[OrderLineId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED 
(
	[OrderLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/8/2018 1:18:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[TotalProducts] [int] NULL,
	[TotalPrice] [money] NULL,
	[PaymentTypeId] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PmtType]    Script Date: 4/8/2018 1:18:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PmtType](
	[PmtType] [nvarchar](50) NOT NULL,
	[PmtTypeId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AcctNumber] [bigint] NOT NULL,
 CONSTRAINT [PK_PmtType] PRIMARY KEY CLUSTERED 
(
	[PmtTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 4/8/2018 1:18:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](200) NOT NULL,
	[ProductDescription] [nvarchar](500) NULL,
	[ProductPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (123, N'Ben', N'Harrington', N'123 gofuckyourself lane', N'Nashville', N'TN', N'37211', N'6154532234')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (124, N'Ben1', N'Harrington1', N'124 gofuckyourself lane', N'Nashville', N'TN', N'37211', N'6154524534')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (125, N'Ben2', N'Harrington2', N'125 gofuckyourself lane', N'Nashville', N'TN', N'37211', N'6154524534')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (126, N'Ben3', N'Harrington3', N'126 gofuckyourself lane', N'Nashville', N'TN', N'37211', N'6154524534')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (127, N'Ben4', N'Harrington4', N'126 gofuckyourself lane', N'Nashville', N'TN', N'37211', N'6154524534')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (345, N'Ben', N'Harringt', N'fuck you', N'David', N'Dassau', N'youasshole', N'615gofuckyourself')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (346, N'Ben', N'Harrington', N'2418 Anson Lane', N'Nashville', N'TN', N'37211', N'3095322490')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (347, N'Dude', N'Duderton', N'345 i hate you', N'nashville', N'tn', N'37211', N'3095420394')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (348, N'joe', N'blow', N'123 i hate everyone', N'nashville', N'tn', N'37261', N'30923454823')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (349, N'bro', N'harbone', N'haks;ag', N'alkj;lkasjf', N'asd;lkfj;salkjf', N'3847', N'1837492')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (350, N'duder', N'duderbro', N'al;kfjalks;fj', N'as;lkfj;laskjf', N'as;lasdf', N'37261', N'309123483')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (351, N'Dude', N'Bro', N'Homie', N'asl;kjl;ksaja', N'flak;js;kl', N'134234', N'129871208947')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (352, N'new dude', N'duder duder', N'1234 al;jfl;jfa;lj', N'a;lssj', N'as;klfj', N'a;f', N'as;lkj')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (353, N'Nathan', N'Gonzalez', N'123 stupidstreet', N'morontown', N'TN', N'37210', N'6154442233')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (354, N'Martin', N'Cross', N'123 Bro street', N'Nasvhille', N'TN', N'37210', N'6152234453')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (355, N'Ed', N'The Horse', N'1234 The Barn Drive', N'Oakland', N'CA', N'12345', N'9991234567')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (356, N'David', N'Dassau', N'456 Dirty Daddy Lane', N'Nashville', N'TN', N'37211', N'6151123344')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Phone]) VALUES (357, N'Test', N'User', N'9 Lea Ave. ', N'Nashville', N'TN', N'37210', N'8005854401')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[OrderLine] ON 

INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (1, 17, 123, 4)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (2, 18, 124, 4)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (3, 19, 125, 6)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (4, 20, 123, 4)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (5, 21, 123, 4)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (6, 22, 123, 5)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (7, 23, 124, 5)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (8, 23, 123, 5)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (9, 23, 123, 5)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (10, 24, 124, 4)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (11, 25, 124, 3)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (12, 25, 126, 9)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (13, 26, 126, 3)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (14, 27, 126, 5)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (15, 29, 126, 3)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (16, 30, 126, 12)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (17, 31, 125, 44)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (18, 32, 123, 2)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (19, 32, 126, 1)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (20, 33, 126, 12)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (21, 34, 126, 2)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (22, 35, 127, 2)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (23, 35, 127, 14)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (24, 36, 124, 14)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (25, 37, 127, 2)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (26, 37, 125, 1)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (27, 38, 131, 1)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (28, 39, 126, 12)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (29, 40, 127, 3)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (30, 41, 132, 15)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (31, 42, 133, 3)
INSERT [dbo].[OrderLine] ([OrderLineId], [OrderId], [ProductId], [Quantity]) VALUES (32, 43, 123, 2)
SET IDENTITY_INSERT [dbo].[OrderLine] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (2, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (3, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (4, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (5, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (6, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (7, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (8, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (9, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (10, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (11, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (12, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (13, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (14, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (15, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (16, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (17, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (18, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (19, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (20, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (21, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (22, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (23, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (24, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (25, 347, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (26, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (27, 123, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (29, 351, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (30, 351, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (31, 351, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (32, 351, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (33, 351, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (34, 350, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (35, 353, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (36, 353, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (37, 347, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (38, 351, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (39, 351, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (40, 351, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (41, 348, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (42, 348, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalProducts], [TotalPrice], [PaymentTypeId]) VALUES (43, 357, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[PmtType] ON 

INSERT [dbo].[PmtType] ([PmtType], [PmtTypeId], [CustomerId], [AcctNumber]) VALUES (N'visa', 2, 353, 1111222233334444)
INSERT [dbo].[PmtType] ([PmtType], [PmtTypeId], [CustomerId], [AcctNumber]) VALUES (N'Visa', 3, 347, 3333333333334444)
INSERT [dbo].[PmtType] ([PmtType], [PmtTypeId], [CustomerId], [AcctNumber]) VALUES (N'vida', 4, 351, 1111222233334444)
INSERT [dbo].[PmtType] ([PmtType], [PmtTypeId], [CustomerId], [AcctNumber]) VALUES (N'Amex', 5, 357, 1111222233334444)
SET IDENTITY_INSERT [dbo].[PmtType] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (123, N'shitty product', N'this is a shitty product', 15.9900, 24, 123)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (124, N'Cool New Product Name', N'stupid product', 15.9900, 24, 123)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (125, N'Nathan''s face', N'a stupid face for sale', 15.9900, 24, 123)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (126, N'Litmobile', N'this is a shitty product', 28.9900, 24, 123)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (127, N'Bullshit Sandwich', N'This is a sandwich made of bullshit', 24.9900, 12, 353)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (128, N'Dumb Shit Sandwich', N'Sandwich made of dumb shit', 24.9900, 12, 354)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (129, N'toys', N'play with me', 23.1200, 7, 348)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (131, N'12', N'this is obviously the shittiest product in the world...', 5.9900, 1, 351)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (132, N'dumber shit', N'this is shittier', 24.8500, 145, 351)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (133, N'Nathan''s children', N'his kids', 1.0000, 3, 351)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductPrice], [Quantity], [CustomerId]) VALUES (134, N'Millenium Falcon', N'This is a badass space ship', 1111.9500, 2, 357)
SET IDENTITY_INSERT [dbo].[Products] OFF
ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Orders1] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderLine] CHECK CONSTRAINT [FK_OrderLine_Orders1]
GO
ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderLine] CHECK CONSTRAINT [FK_OrderLine_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[PmtType]  WITH CHECK ADD  CONSTRAINT [FK_PmtType_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[PmtType] CHECK CONSTRAINT [FK_PmtType_CustomerId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Customer]
GO
USE [master]
GO
ALTER DATABASE [OrientationAPI] SET  READ_WRITE 
GO
