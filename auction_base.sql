USE [master]
GO
/****** Object:  Database [ADMIN_2]    Script Date: 2/11/2022 12:38:10 AM ******/
CREATE DATABASE [ADMIN_2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ADMIN_2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ADMIN_2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ADMIN_2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ADMIN_2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ADMIN_2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ADMIN_2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ADMIN_2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ADMIN_2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ADMIN_2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ADMIN_2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ADMIN_2] SET ARITHABORT OFF 
GO
ALTER DATABASE [ADMIN_2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ADMIN_2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ADMIN_2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ADMIN_2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ADMIN_2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ADMIN_2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ADMIN_2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ADMIN_2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ADMIN_2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ADMIN_2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ADMIN_2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ADMIN_2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ADMIN_2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ADMIN_2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ADMIN_2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ADMIN_2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ADMIN_2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ADMIN_2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ADMIN_2] SET  MULTI_USER 
GO
ALTER DATABASE [ADMIN_2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ADMIN_2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ADMIN_2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ADMIN_2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ADMIN_2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ADMIN_2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ADMIN_2] SET QUERY_STORE = OFF
GO
USE [ADMIN_2]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/11/2022 12:38:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[ProductCondition] [nvarchar](50) NOT NULL,
	[ActivationDate] [datetime] NOT NULL,
	[ProductPrice] [decimal](10, 2) NOT NULL,
	[AuctionStatus] [int] NOT NULL,
	[ProductDescription] [nvarchar](500) NOT NULL,
	[AuctionWinner] [nvarchar](50) NOT NULL,
	[IsProductSold] [bit] NOT NULL,
	[LastBidTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users2]    Script Date: 2/11/2022 12:38:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName2] [nvarchar](50) NOT NULL,
	[UserPass2] [nvarchar](50) NOT NULL,
	[IsAdmin2] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (1, N'fasadfdas', N'kkjkjhkghjk', N'new', CAST(N'2021-10-21T16:42:21.293' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'Veldo', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (2, N'iphone6', N'phones', N'new', CAST(N'2021-10-21T17:41:30.577' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'Veldo', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (5, N'iphone8', N'phones', N'new', CAST(N'2021-10-21T17:42:27.210' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'Veldo', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (13, N'dffsda', N'ddfffff', N'new', CAST(N'2021-10-21T17:48:24.190' AS DateTime), CAST(0.00 AS Decimal(10, 2)), 2, N'No details available.', N'None', 0, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (15, N'NFDFAS', N'DFAFAFASD', N'new', CAST(N'2021-10-21T18:57:28.007' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'Veldo', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (17, N'dfasfasfa', N'fasfadsfasdf', N'new', CAST(N'2021-10-21T19:44:46.200' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'Veldo', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (19, N'fasfasd', N'fsadfas', N'new', CAST(N'2021-10-21T21:38:46.813' AS DateTime), CAST(0.00 AS Decimal(10, 2)), 2, N'No details available.', N'None', 0, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (21, N'qqqqqqqqq', N'qqqqqqq', N'new', CAST(N'2021-10-21T21:39:06.210' AS DateTime), CAST(0.00 AS Decimal(10, 2)), 2, N'No details available.', N'None', 0, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (23, N'aaaaaaaaaaaaa', N'aaaaaaaaaa', N'new', CAST(N'2021-10-21T23:37:49.667' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'Veldo', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (25, N'dddddddddddd', N'ssssssssssssssss', N'new', CAST(N'2021-10-21T23:38:15.980' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'Veldo', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (28, N'kghkhjk', N'ffffffffff', N'new', CAST(N'2021-10-21T23:38:45.843' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'Veldo', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (30, N'jhjhgj', N'gfsdgsdfgsd', N'new', CAST(N'2021-10-22T00:02:35.547' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'None', 0, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (32, N'fdasfj', N'hhhhhhh', N'new', CAST(N'2021-10-22T11:41:30.450' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'None', 0, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (34, N'tztrz', N'gsdgfsdg', N'new', CAST(N'2021-10-22T11:44:15.750' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'None', 0, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (36, N'test new', N'phones', N'new', CAST(N'2022-01-18T13:14:27.550' AS DateTime), CAST(2.00 AS Decimal(10, 2)), 2, N'No details available.', N'user1', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (38, N'fdfas', N'fdafd', N'new', CAST(N'2022-01-18T13:30:40.260' AS DateTime), CAST(2.00 AS Decimal(10, 2)), 2, N'No details available.', N'user1', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (40, N'fdafsafdasf', N'dfsdafas', N'new', CAST(N'2022-02-10T17:14:22.757' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'None', 0, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (42, N'gfdgsdfgsdf', N'cyxvyxcvyxcv', N'new', CAST(N'2022-02-10T19:02:53.927' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'None', 0, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (44, N'bgggggg', N'dfd', N'new', CAST(N'2022-02-10T19:06:39.797' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 2, N'No details available.', N'None', 0, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (46, N'gggggg', N'fff', N'new', CAST(N'2022-02-10T19:38:57.547' AS DateTime), CAST(3.00 AS Decimal(10, 2)), 2, N'No details available.', N'user1', 1, CAST(N'2021-10-21T16:42:21.293' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (61, N'prvi', N'ffffffff', N'new', CAST(N'2022-02-10T22:13:51.810' AS DateTime), CAST(2.00 AS Decimal(10, 2)), 1, N'No details available.', N'user1', 1, CAST(N'2022-02-10T22:15:05.197' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (62, N'drugi', N'fffffff', N'new', CAST(N'2022-02-10T22:14:00.323' AS DateTime), CAST(2.00 AS Decimal(10, 2)), 1, N'No details available.', N'user1', 1, CAST(N'2022-02-10T22:15:08.140' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (63, N'treci', N'ffffff', N'new', CAST(N'2022-02-10T22:14:09.217' AS DateTime), CAST(2.00 AS Decimal(10, 2)), 1, N'No details available.', N'user1', 1, CAST(N'2022-02-10T22:15:11.913' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (64, N'cetvrti', N'ffffffff', N'new', CAST(N'2022-02-10T22:28:59.757' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 1, N'No details available.', N'None', 0, CAST(N'2022-02-10T22:28:59.757' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (65, N'peti', N'fffffff', N'new', CAST(N'2022-02-10T23:00:23.557' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 1, N'No details available.', N'None', 0, CAST(N'2022-02-10T23:00:23.557' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (66, N'sesti', N'aaaaa', N'new', CAST(N'2022-02-10T23:35:32.757' AS DateTime), CAST(1.00 AS Decimal(10, 2)), 0, N'No details available.', N'None', 0, CAST(N'2022-02-10T23:35:32.757' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (67, N'sedmi', N'aaaaaa', N'new', CAST(N'2022-02-10T23:46:02.420' AS DateTime), CAST(3.00 AS Decimal(10, 2)), 0, N'No details available.', N'user2', 1, CAST(N'2022-02-10T23:47:31.673' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (68, N'osmi', N'aaaaa', N'new', CAST(N'2022-02-11T00:11:39.647' AS DateTime), CAST(5.00 AS Decimal(10, 2)), 0, N'No details available.', N'user2', 1, CAST(N'2022-02-11T00:15:18.937' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Category], [ProductCondition], [ActivationDate], [ProductPrice], [AuctionStatus], [ProductDescription], [AuctionWinner], [IsProductSold], [LastBidTime]) VALUES (69, N'deveti', N'aaaa', N'new', CAST(N'2022-02-11T00:11:50.113' AS DateTime), CAST(4.00 AS Decimal(10, 2)), 0, N'No details available.', N'user1', 1, CAST(N'2022-02-11T00:14:39.617' AS DateTime))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users2] ON 

INSERT [dbo].[Users2] ([ID], [UserName2], [UserPass2], [IsAdmin2]) VALUES (1, N'admin1', N'BWNjjl2r1dWXwotIHAPiXg==', 1)
INSERT [dbo].[Users2] ([ID], [UserName2], [UserPass2], [IsAdmin2]) VALUES (2, N'user1', N'BWNjjl2r1dWXwotIHAPiXg==', 0)
INSERT [dbo].[Users2] ([ID], [UserName2], [UserPass2], [IsAdmin2]) VALUES (3, N'Veldo', N'R0uUuwe6QMc=', 1)
INSERT [dbo].[Users2] ([ID], [UserName2], [UserPass2], [IsAdmin2]) VALUES (4, N'user2', N'BWNjjl2r1dWXwotIHAPiXg==', 0)
INSERT [dbo].[Users2] ([ID], [UserName2], [UserPass2], [IsAdmin2]) VALUES (5, N'user3', N'BWNjjl2r1dWXwotIHAPiXg==', NULL)
SET IDENTITY_INSERT [dbo].[Users2] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Products__DD5A978A18143B42]    Script Date: 2/11/2022 12:38:10 AM ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [UQ__Products__DD5A978A18143B42] UNIQUE NONCLUSTERED 
(
	[ProductName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users2__CD1D5851B1EEBAA7]    Script Date: 2/11/2022 12:38:10 AM ******/
ALTER TABLE [dbo].[Users2] ADD UNIQUE NONCLUSTERED 
(
	[UserName2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ADMIN_2] SET  READ_WRITE 
GO
