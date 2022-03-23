USE [master]
GO
/****** Object:  Database [POS_DB]    Script Date: 23/03/2022 4:00:21 PM ******/
CREATE DATABASE [POS_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'POS_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\POS_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'POS_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\POS_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [POS_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [POS_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [POS_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [POS_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [POS_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [POS_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [POS_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [POS_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [POS_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [POS_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [POS_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [POS_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [POS_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [POS_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [POS_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [POS_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [POS_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [POS_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [POS_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [POS_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [POS_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [POS_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [POS_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [POS_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [POS_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [POS_DB] SET  MULTI_USER 
GO
ALTER DATABASE [POS_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [POS_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [POS_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [POS_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [POS_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [POS_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'POS_DB', N'ON'
GO
ALTER DATABASE [POS_DB] SET QUERY_STORE = OFF
GO
USE [POS_DB]
GO
/****** Object:  Table [dbo].[GRN]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRN](
	[GRNNo] [int] NULL,
	[Date] [date] NULL,
	[Time] [datetime] NULL,
	[Total] [float] NULL,
	[Valid] [varchar](50) NULL,
	[UserID] [varchar](50) NULL,
	[CDate] [date] NULL,
	[CTime] [datetime] NULL,
	[CUserID] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRNDetails]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRNDetails](
	[GRNNo] [int] NULL,
	[ProductID] [varchar](50) NULL,
	[FullCode] [varchar](50) NULL,
	[Price] [float] NULL,
	[Qty] [float] NULL,
	[Dis] [float] NULL,
	[SubTot] [float] NULL,
	[Date] [datetime] NULL,
	[Type] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvID] [int] NOT NULL,
	[CustID] [varchar](50) NULL,
	[UserID] [varchar](50) NULL,
	[Date] [float] NULL,
	[Time] [datetime] NULL,
	[GrossTot] [float] NULL,
	[Discount] [float] NULL,
	[Total] [float] NULL,
	[Valid] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[BillType] [varchar](50) NULL,
	[SCharge] [float] NULL,
	[BCate] [varchar](50) NULL,
	[TID] [varchar](50) NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoicedProduct]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoicedProduct](
	[InvID] [int] NULL,
	[ProductID] [int] NULL,
	[ProductFullcode] [varchar](20) NULL,
	[SPrice] [float] NULL,
	[DiscountAmount] [float] NULL,
	[DiscountPercentage] [float] NULL,
	[Qty] [float] NULL,
	[SubTotal] [float] NULL,
	[Type] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewCustomer]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewCustomer](
	[CusID] [int] NULL,
	[R_InvID] [varchar](50) NULL,
	[NICNo] [varchar](50) NULL,
	[Fname] [varchar](50) NULL,
	[MobNo] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Country] [varchar](max) NULL,
	[Company] [varchar](50) NULL,
	[Date] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] NOT NULL,
	[UPC] [varchar](50) NULL,
	[ProductName] [varchar](50) NOT NULL,
	[ProductFullcode] [varchar](50) NOT NULL,
	[CPrice] [float] NULL,
	[SPrice] [float] NULL,
	[WSPrice] [float] NULL,
	[CSPrice] [float] NULL,
	[MRP] [float] NULL,
	[Type] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[ReOrder_Level] [float] NULL,
	[EffectiveDate] [datetime] NULL,
	[UnitOfMeasure] [varchar](50) NULL,
	[UnitPerCase] [float] NULL,
	[SysUser] [varchar](50) NULL,
 CONSTRAINT [PK_Product_1] PRIMARY KEY CLUSTERED 
(
	[ProductFullcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[SettingID] [varchar](50) NULL,
	[Value] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[ProductID] [int] NULL,
	[ProductFullcode] [varchar](50) NULL,
	[Qty] [float] NULL,
	[Date] [date] NULL,
	[Type] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockDayEnd]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockDayEnd](
	[ProductID] [varchar](50) NULL,
	[Qty] [float] NULL,
	[Date] [date] NULL,
	[Time] [datetime] NULL,
	[Type] [varchar](50) NULL,
	[StockType] [varchar](50) NULL,
	[Avg_Price] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupID] [nchar](10) NULL,
	[Name] [nchar](10) NULL,
	[Address] [nchar](10) NULL,
	[Tp] [nchar](10) NULL,
	[Mobile] [nchar](10) NULL,
	[Email] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccess]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccess](
	[UserID] [varchar](50) NULL,
	[Authen] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserD]    Script Date: 23/03/2022 4:00:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserD](
	[UserID] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Type] [varchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (1, N'1', N'1', 20211224, CAST(N'2021-12-24T15:57:39.527' AS DateTime), 5130, 250, 4880, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (2, N'1', N'1', 20211224, CAST(N'2021-12-24T16:00:19.853' AS DateTime), 4840, 250, 4590, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (3, N'1', N'1', 20211224, CAST(N'2021-12-24T16:05:09.573' AS DateTime), 4990, 170, 4820, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (4, N'1', N'1', 20211224, CAST(N'2021-12-24T16:08:49.947' AS DateTime), 5835, 150, 5685, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (5, N'1', N'1', 20211226, CAST(N'2021-12-26T09:00:56.423' AS DateTime), 1730, 250, 1480, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (6, N'1', N'1', 20211226, CAST(N'2021-12-26T09:02:01.503' AS DateTime), 285, 0, 285, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (7, N'1', N'1', 20211226, CAST(N'2021-12-26T09:08:36.270' AS DateTime), 650, 0, 650, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (8, N'1', N'1', 20211226, CAST(N'2021-12-26T09:09:31.350' AS DateTime), 425, 0, 425, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (9, N'1', N'1', 20211226, CAST(N'2021-12-26T09:16:48.467' AS DateTime), 145, 0, 145, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (10, N'1', N'1', 20211226, CAST(N'2021-12-26T09:22:44.437' AS DateTime), 145, 0, 145, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (11, N'1', N'1', 20211226, CAST(N'2021-12-26T09:22:48.627' AS DateTime), 140, 0, 140, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (12, N'1', N'1', 20211226, CAST(N'2021-12-26T09:22:52.560' AS DateTime), 140, 0, 140, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (13, N'1', N'1', 20211226, CAST(N'2021-12-26T09:24:25.520' AS DateTime), 185, 0, 185, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (14, N'1', N'1', 20211226, CAST(N'2021-12-26T09:44:37.063' AS DateTime), 140, 0, 140, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (15, N'1', N'1', 20211226, CAST(N'2021-12-26T09:44:39.343' AS DateTime), 0, 0, 0, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (16, N'1', N'1', 20211230, CAST(N'2021-12-30T16:10:45.557' AS DateTime), 1330, 0, 1330, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (17, N'1', N'1', 20211231, CAST(N'2021-12-31T09:30:29.293' AS DateTime), 185, 0, 185, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (18, N'1', N'1', 20211231, CAST(N'2021-12-31T10:46:13.480' AS DateTime), 1725, 0, 1725, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (19, N'1', N'1', 20211231, CAST(N'2021-12-31T10:48:43.387' AS DateTime), 2800, 100, 2700, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (20, N'1', N'1', 20211231, CAST(N'2021-12-31T16:13:08.637' AS DateTime), 1850, 0, 1850, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (21, N'1', N'1', 20220103, CAST(N'2022-01-03T09:34:57.907' AS DateTime), 3300, 100, 3200, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (22, N'1', N'1', 20220103, CAST(N'2022-01-03T09:37:51.560' AS DateTime), 335, 0, 335, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (23, N'1', N'1', 20220103, CAST(N'2022-01-03T10:59:21.393' AS DateTime), 3480, 0, 3480, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (24, N'1', N'1', 20220103, CAST(N'2022-01-03T11:08:51.553' AS DateTime), 3490, 55, 3435, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (25, N'1', N'1', 20220103, CAST(N'2022-01-03T12:23:09.803' AS DateTime), 17065, 1545, 15520, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (26, N'1', N'1', 20220103, CAST(N'2022-01-03T12:29:09.100' AS DateTime), -14000, 0, -14000, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (27, N'1', N'1', 20220103, CAST(N'2022-01-03T12:30:06.483' AS DateTime), -14000, 0, -14000, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (28, N'1', N'1', 20220103, CAST(N'2022-01-03T12:30:48.330' AS DateTime), -14000, 0, -14000, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (29, N'1', N'1', 20220210, CAST(N'2022-02-10T23:29:28.460' AS DateTime), 6500, 205, 6295, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (30, N'1', N'1', 20220210, CAST(N'2022-02-10T23:30:21.377' AS DateTime), -1880, 0, -1880, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (31, N'1', N'1', 20220212, CAST(N'2022-02-12T22:08:32.997' AS DateTime), 14500, 0, 14500, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (32, N'1', N'1', 20220212, CAST(N'2022-02-12T22:16:39.810' AS DateTime), 14000, 0, 14000, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (33, N'1', N'1', 20220212, CAST(N'2022-02-12T22:18:40.477' AS DateTime), 1740, 0, 1740, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (34, N'1', N'1', 20220212, CAST(N'2022-02-12T22:19:27.233' AS DateTime), 1850, 0, 1850, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (35, N'1', N'1', 20220212, CAST(N'2022-02-12T22:24:02.647' AS DateTime), 3500, 0, 3500, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (36, N'1', N'1', 20220212, CAST(N'2022-02-12T22:24:40.820' AS DateTime), 1850, 0, 1850, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (37, N'1', N'1', 20220212, CAST(N'2022-02-12T22:25:27.117' AS DateTime), -27750, 0, -27750, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (38, N'1', N'1', 20220212, CAST(N'2022-02-12T22:28:21.757' AS DateTime), -3500, 100, -3600, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (39, N'1', N'1', 20220220, CAST(N'2022-02-20T11:51:21.150' AS DateTime), 24040, 0, 24040, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (40, N'1', N'1', 20220220, CAST(N'2022-02-20T11:52:39.187' AS DateTime), 24040, 0, 24040, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (41, N'1', N'1', 20220220, CAST(N'2022-02-20T11:57:54.840' AS DateTime), 3125, 0, 3125, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (42, N'1', N'1', 20220220, CAST(N'2022-02-20T12:24:54.637' AS DateTime), 1920, 0, 1920, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (43, N'1', N'1', 20220220, CAST(N'2022-02-20T12:30:04.580' AS DateTime), 13505, 100, 13405, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (44, N'1', N'1', 20220220, CAST(N'2022-02-20T17:44:11.487' AS DateTime), 185, 0, 185, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (45, N'1', N'1', 20220221, CAST(N'2022-02-21T23:20:11.837' AS DateTime), 1850, 100, 1750, N'YES', N'Print', N'', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (46, N'1', N'1', 20220222, CAST(N'2022-02-22T10:57:12.037' AS DateTime), 4750, 400, 4350, N'YES', N'Print', N'Invoice', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (47, N'1', N'1', 20220222, CAST(N'2022-02-22T11:11:25.230' AS DateTime), 1850, 350, 1500, N'YES', N'Print', N'Return', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (48, N'1', N'1', 20220223, CAST(N'2022-02-23T17:09:12.903' AS DateTime), 2645, 0, 2645, N'YES', N'Print', N'Invoice', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (49, N'1', N'1', 20220223, CAST(N'2022-02-23T20:30:08.670' AS DateTime), 2390, 100, 2290, N'YES', N'Print', N'Return', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (50, N'1', N'1', 20220226, CAST(N'2022-02-26T15:16:53.977' AS DateTime), 5735, 300, 5435, N'YES', N'Print', N'Invoice', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (51, N'1', N'1', 20220228, CAST(N'2022-02-28T10:24:51.637' AS DateTime), 1415, 100, 1315, N'YES', N'Print', N'Invoice', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (52, N'1', N'1', 20220316, CAST(N'2022-03-16T14:08:25.147' AS DateTime), 540, 3, 537, N'YES', N'Print', N'Invoice', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (53, N'1', N'1', 20220316, CAST(N'2022-03-16T14:09:39.850' AS DateTime), 685, 4, 681, N'YES', N'Print', N'Invoice', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (54, N'1', N'1', 20220316, CAST(N'2022-03-16T14:36:47.927' AS DateTime), 690, 0, 690, N'YES', N'Print', N'Invoice', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (55, N'1', N'1', 20220316, CAST(N'2022-03-16T14:37:13.873' AS DateTime), 410, 0, 410, N'YES', N'Print', N'Invoice', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (56, N'1', N'1', 20220316, CAST(N'2022-03-16T14:38:31.527' AS DateTime), 3115, 303.75, 2811.25, N'YES', N'Print', N'Invoice', 0, N'', N'')
GO
INSERT [dbo].[Invoice] ([InvID], [CustID], [UserID], [Date], [Time], [GrossTot], [Discount], [Total], [Valid], [Status], [BillType], [SCharge], [BCate], [TID]) VALUES (57, N'1', N'1', 20220320, CAST(N'2022-03-20T11:42:00.867' AS DateTime), 435, 8, 427, N'YES', N'Print', N'Invoice', 0, N'', N'')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (3, 1, NULL, 185, 170, 0, 10, 1680, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (4, 1, NULL, 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (4, 2, NULL, 145, 100, 0, 10, 1350, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (4, 3, NULL, 140, 0, 0, 20, 2800, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (9, 2, NULL, 145, 0, 0, 1, 145, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (13, 1, NULL, 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (14, 3, NULL, 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (18, 1, NULL, 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (18, 4, NULL, 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (18, 2, NULL, 140, 0, 0, 10, 1400, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (4, 4, NULL, 140, 50, 0, 10, 1350, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (5, 2, NULL, 145, 250, 0, 10, 1200, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (5, 3, NULL, 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (5, 4, NULL, 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (6, 2, NULL, 145, 0, 0, 1, 145, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (6, 3, NULL, 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (10, 2, NULL, 145, 0, 0, 1, 145, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (12, 4, NULL, 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (16, 2, NULL, 145, 0, 0, 1, 145, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (16, 2, NULL, 150, 0, 0, 1, 150, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (16, 2, NULL, 150, 0, 0, 1, 150, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (16, 2, NULL, 145, 0, 0, 1, 145, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (16, 1, NULL, 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (16, 1, NULL, 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (16, 1, NULL, 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (16, 1, NULL, 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (17, 1, NULL, 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (20, 1, NULL, 185, 0, 0, 10, 1850, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (8, 2, NULL, 145, 0, 0, 1, 145, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (8, 3, NULL, 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (8, 4, NULL, 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (19, 4, NULL, 140, 0, 0, 10, 1400, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (19, 3, NULL, 140, 100, 0, 10, 1300, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (11, 3, NULL, 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (22, 1, N'1160', 185, 1, 185, 0, 0, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (22, 2, N'2140', 150, 1, 150, 0, 0, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (23, 2, N'2140', 150, 0, 0, 12, 1800, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (23, 3, N'3130', 140, 0, 0, 12, 1680, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (24, 2, N'2140', 150, 5, 0, 10, 1450, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (25, 1, N'1160', 185, 5, 0, 9, 1620, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (25, 2, N'2130', 140, 15, 0, 100, 12500, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (25, 3, N'3130', 140, 0, 0, 10, 1400, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (29, 4, N'4130', 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (29, 4, N'4130', 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (29, 3, N'3130', 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (29, 4, N'4130', 140, 5, 0, 12, 1620, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (29, 2, N'2135', 145, 0, 0, 10, 1450, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (29, 2, N'2140', 150, 0, 0, 10, 1500, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (30, 4, N'4130', 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (30, 2, N'2135', 145, 0, 0, 12, 1740, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (33, 1, N'1160', 185, 0, 0, 10, 1850, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (38, 2, N'2130', 140, 0, 0, 15, 2100, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (38, 3, N'3130', 140, 10, 0, 10, 1300, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (44, 1, N'1160', 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (45, 1, N'1160', 185, 10, 0, 10, 1750, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (24, 1, N'1160', 185, 0, 0, 10, 1850, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (24, 3, N'3130', 140, 5, 0, 1, 135, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (26, 2, N'2130', 140, 0, 0, 100, 14000, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (27, 2, N'2130', 140, 0, 0, 100, 14000, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (28, 2, N'2130', 140, 0, 0, 100, 14000, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (36, 1, N'1160', 185, 0, 0, 10, 1850, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (42, 1, N'1160', 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (42, 2, N'2130', 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (42, 2, N'2135', 145, 0, 0, 1, 145, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (42, 2, N'2135', 145, 0, 0, 10, 1450, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (31, 2, N'2135', 145, 0, 0, 100, 14500, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (32, 4, N'4130', 140, 0, 0, 100, 14000, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (41, 3, N'3130', 140, 0, 0, 1, 140, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (41, 4, N'4130', 140, 0, 0, 20, 2800, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (41, 1, N'1160', 185, 0, 0, 1, 185, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (43, 1, N'1160', 185, 0, 0, 32, 5920, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (43, 2, N'2135', 145, 0, 0, 33, 4785, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (43, 3, N'3130', 140, 0, 0, 10, 1400, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (43, 3, N'3130', 140, 10, 0, 10, 1300, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (33, 2, N'2135', 145, 0, 0, 12, 1740, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (37, 1, N'1160', 185, 0, 0, 150, 27750, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (35, 3, N'3130', 140, 0, 0, 25, 3500, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (40, 1, N'1160', 185, 0, 0, 80, 14800, NULL)
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (46, 1, N'1160', 185, 0, 0, 10, 1850, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (46, 2, N'2135', 145, 20, 0, 20, 2500, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (47, 1, N'1160', 185, 35, 0, 10, 1500, N'Return')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 1, N'1160', 185, 0, 0, 1, 185, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 3, N'3130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 7, N'765', 85, 0, 0, 1, 85, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 5, N'560', 75, 0, 0, 1, 75, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 3, N'3130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 1, N'1160', 185, 0, 0, 1, 185, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 1, N'1160', 185, 0, 0, 1, 185, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 2, N'2140', 150, 0, 0, 1, 150, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 3, N'3130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 1, N'1160', 185, 0, 0, 1, 185, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 1, N'1160', 185, 0, 0, 1, 185, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 2, N'2140', 150, 0, 0, 1, 150, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 3, N'3130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 3, N'3130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 6, N'6110', 130, 0, 0, 1, 130, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 2, N'2140', 150, 0, 0, 1, 150, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 3, N'3130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (48, 3, N'3130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (49, 4, N'4130', 140, 0, 0, 1, 140, N'Return')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (49, 7, N'765', 85, 0, 0, 10, 850, N'Return')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (49, 3, N'3130', 140, 10, 0, 10, 1300, N'Return')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (52, 2, N'10000002140', 150, 0, 0, 1, 150, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (52, 5, N'1000000560', 75, 0, 0, 1, 75, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (52, 9, N'10000009100', 108, 2, 0, 1, 108, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (52, 8, N'1000000855', 64, 1, 0, 1, 64, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (52, 6, N'10000006120', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (55, 3, N'10000003130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (55, 14, N'10000014100', 120, 0, 0, 1, 120, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (55, 2, N'10000002140', 150, 0, 0, 1, 150, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (56, 2, N'10000002140', 150, 10, 0, 10, 1400, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (56, 3, N'10000003130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (56, 4, N'10000004130', 140, 20, 0, 10, 1200, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (56, 5, N'1000000560', 75, 3.75, 5, 1, 71.25, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (57, 8, N'1000000855', 64, 1, 0, 1, 64, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (50, 1, N'1160', 175, 10, 0, 10, 1750, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (50, 1, N'1160', 175, 15, 0, 10, 1700, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (50, 1, N'1160', 185, 0, 0, 1, 185, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (50, 1, N'1160', 185, 5, 0, 10, 1800, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (51, 4, N'10000004130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (51, 8, N'1000000855', 65, 0, 0, 1, 65, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (51, 12, N'10000012100', 110, 0, 0, 1, 110, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (51, 9, N'10000009100', 110, 10, 0, 10, 1000, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (53, 1, N'10000001160', 185, 0, 0, 1, 185, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (53, 3, N'10000003130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (57, 9, N'10000009100', 108, 5, 0, 1, 105, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (57, 10, N'10000010250', 258, 2, 0, 1, 258, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (53, 9, N'10000009100', 108, 2, 0, 1, 108, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (53, 9, N'10000009100', 108, 2, 0, 1, 108, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (53, 6, N'10000006120', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (54, 1, N'10000001160', 185, 0, 0, 1, 185, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (54, 2, N'10000002140', 150, 0, 0, 1, 150, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (54, 3, N'10000003130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (54, 4, N'10000004130', 140, 0, 0, 1, 140, N'Invoice')
GO
INSERT [dbo].[InvoicedProduct] ([InvID], [ProductID], [ProductFullcode], [SPrice], [DiscountAmount], [DiscountPercentage], [Qty], [SubTotal], [Type]) VALUES (54, 5, N'1000000560', 75, 0, 0, 1, 75, N'Invoice')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (1, N'4791111114439', N'White Sugar', N'10000001160', 160, 185, 175, 195, 185, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (2, N'4791047011444', N'Rice Nadu', N'10000002130', 130, 140, 138, 144, 140, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (2, N'4791047011444', N'Rice Nadu', N'10000002135', 135, 145, 137, 145, 145, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (2, N'4791047011444', N'Rice Nadu', N'10000002140', 140, 150, 142, NULL, 150, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (3, N'4792210103003', N'Rice Red Nadu', N'10000003130', 130, 140, 132, NULL, 140, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (4, N'4791111114439', N'Rice Red Kakulu', N'10000004130', 130, 140, 133, NULL, 140, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (5, N'4792081260713', N'Munchee Chocalate', N'1000000560', 60, 75, 65, NULL, 75, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (6, N'4792210112746', N'Munchee Milk Shorties', N'10000006110', 110, 130, 112, NULL, 130, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (6, N'4792210112746', N'Munchee Milk Shorties', N'10000006120', 120, 140, 122, NULL, 140, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (7, N'4791085292386', N'Maliban Chocalate', N'1000000765', 65, 85, 66, NULL, 85, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (7, N'4791085292386', N'Maliban Chocalate', N'1000000770', 70, 90, 72, NULL, 90, N'A', N'A', 20, CAST(N'2022-02-27T00:00:00.000' AS DateTime), N'EA', 1, N'1')
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (8, N'4791010002066', N'Denta Confort Medium', N'1000000855', 55, 64, 63, NULL, 65, NULL, NULL, NULL, CAST(N'2022-02-27T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (9, N'4792149011226', N'Raigam Cuttlefish Soya', N'10000009100', 100, 108, 108, NULL, 110, NULL, NULL, NULL, CAST(N'2022-02-27T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (10, N'8888101430115', N'Munchee CreamCracker 500g', N'10000010250', 250, 258, 255, NULL, 260, NULL, NULL, NULL, CAST(N'2022-02-27T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (11, N'4796002019008', N'Lanka Soy Kiri Malu', N'1000001162', 62, 68, 65, NULL, 70, NULL, NULL, NULL, CAST(N'2022-02-27T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (12, N'4792173020010', N'Wijaya Curry Powdwe 100g', N'10000012100', 100, 110, NULL, NULL, 110, NULL, NULL, NULL, CAST(N'2022-02-27T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (13, N'4792173680863', N'Wijaya Meat Curry Powder 100g', N'10000013170', 170, 180, NULL, NULL, 180, NULL, NULL, NULL, CAST(N'2022-02-27T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductID], [UPC], [ProductName], [ProductFullcode], [CPrice], [SPrice], [WSPrice], [CSPrice], [MRP], [Type], [Category], [ReOrder_Level], [EffectiveDate], [UnitOfMeasure], [UnitPerCase], [SysUser]) VALUES (14, N'4792173010011', N'Wijaya Chilly Powder 100g', N'10000014100', 100, 120, NULL, NULL, 120, NULL, NULL, NULL, CAST(N'2022-02-27T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Setting] ([SettingID], [Value]) VALUES (N'InvoiceStockAvailable', N'0')
GO
INSERT [dbo].[Setting] ([SettingID], [Value]) VALUES (N'ChangePriceType', N'1')
GO
INSERT [dbo].[Stock] ([ProductID], [ProductFullcode], [Qty], [Date], [Type]) VALUES (1, N'10000001160', 9811, NULL, N'10000001160')
GO
INSERT [dbo].[Stock] ([ProductID], [ProductFullcode], [Qty], [Date], [Type]) VALUES (2, N'10000002130', 19899, NULL, N'0')
GO
INSERT [dbo].[Stock] ([ProductID], [ProductFullcode], [Qty], [Date], [Type]) VALUES (2, N'10000002135', 19847, NULL, N'0')
GO
INSERT [dbo].[Stock] ([ProductID], [ProductFullcode], [Qty], [Date], [Type]) VALUES (2, N'10000002140', 19964, NULL, N'0')
GO
USE [master]
GO
ALTER DATABASE [POS_DB] SET  READ_WRITE 
GO
