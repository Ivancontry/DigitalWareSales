USE [master]
GO
/****** Object:  Database [SysSalesBD]    Script Date: 7/06/2022 1:30:14 a.m. ******/
CREATE DATABASE [SysSalesBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SysSalesBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SysSalesBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SysSalesBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SysSalesBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SysSalesBD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SysSalesBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SysSalesBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SysSalesBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SysSalesBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SysSalesBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SysSalesBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [SysSalesBD] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SysSalesBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SysSalesBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SysSalesBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SysSalesBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SysSalesBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SysSalesBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SysSalesBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SysSalesBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SysSalesBD] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SysSalesBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SysSalesBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SysSalesBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SysSalesBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SysSalesBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SysSalesBD] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SysSalesBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SysSalesBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SysSalesBD] SET  MULTI_USER 
GO
ALTER DATABASE [SysSalesBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SysSalesBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SysSalesBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SysSalesBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SysSalesBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SysSalesBD] SET QUERY_STORE = OFF
GO
USE [SysSalesBD]
GO
/****** Object:  Schema [SysSales]    Script Date: 7/06/2022 1:30:14 a.m. ******/
CREATE SCHEMA [SysSales]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/06/2022 1:30:14 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 7/06/2022 1:30:14 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Identification] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[BirthDay] [datetime2](7) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [SysSales].[Category]    Script Date: 7/06/2022 1:30:14 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SysSales].[Category](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [SysSales].[InvoiceDetail]    Script Date: 7/06/2022 1:30:14 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SysSales].[InvoiceDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](max) NULL,
	[ProductId] [bigint] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Price] [decimal](17, 2) NOT NULL,
	[Total] [decimal](17, 2) NOT NULL,
	[InvoiceMasterId] [bigint] NOT NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [SysSales].[InvoiceMaster]    Script Date: 7/06/2022 1:30:14 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SysSales].[InvoiceMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientId] [bigint] NOT NULL,
	[DateCancel] [datetime2](7) NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NULL,
 CONSTRAINT [PK_InvoiceMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [SysSales].[Product]    Script Date: 7/06/2022 1:30:14 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SysSales].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Price] [decimal](17, 2) NOT NULL,
	[CategoryId] [bigint] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220607044514_InitialCreate', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Id], [Identification], [Name], [Phone], [BirthDay], [Address], [Email], [CreatedAt], [Status]) VALUES (1, N'10650145781', N'Helmer Fuentes', N'3204817032', CAST(N'1995-04-21T00:00:00.0000000' AS DateTime2), N'Diagonal 21 #56-12', N'helmer@gmail.com', CAST(N'2022-06-07T01:21:24.7108337' AS DateTime2), N'AC')
INSERT [dbo].[Clients] ([Id], [Identification], [Name], [Phone], [BirthDay], [Address], [Email], [CreatedAt], [Status]) VALUES (2, N'1065135735', N'Duvan Guia', N'31046599041', CAST(N'1998-02-15T00:00:00.0000000' AS DateTime2), N'Calle 16 #24-65', N'duvan@gmail.com', CAST(N'2022-06-07T01:21:24.7108326' AS DateTime2), N'AC')
INSERT [dbo].[Clients] ([Id], [Identification], [Name], [Phone], [BirthDay], [Address], [Email], [CreatedAt], [Status]) VALUES (3, N'1003195636', N'Ivan Contreras', N'3004558041', CAST(N'1999-05-15T00:00:00.0000000' AS DateTime2), N'Mz C Casa 19 San Jeronimo', N'ivancontry.13@gmail.com', CAST(N'2022-06-07T01:21:24.7105001' AS DateTime2), N'AC')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [SysSales].[Category] ON 

INSERT [SysSales].[Category] ([Id], [Date], [Name], [Code], [CreatedAt], [Status]) VALUES (1, CAST(N'2022-06-07T01:21:24.3473331' AS DateTime2), N'Ropa', N'Clo-002', CAST(N'2022-06-07T01:21:24.3473340' AS DateTime2), N'AC')
INSERT [SysSales].[Category] ([Id], [Date], [Name], [Code], [CreatedAt], [Status]) VALUES (2, CAST(N'2022-06-07T01:21:24.3473366' AS DateTime2), N'Calzado', N'Foo-003', CAST(N'2022-06-07T01:21:24.3473368' AS DateTime2), N'AC')
INSERT [SysSales].[Category] ([Id], [Date], [Name], [Code], [CreatedAt], [Status]) VALUES (3, CAST(N'2022-06-07T01:21:24.3405675' AS DateTime2), N'Tecnología', N'Tec-001', CAST(N'2022-06-07T01:21:24.3423474' AS DateTime2), N'AC')
SET IDENTITY_INSERT [SysSales].[Category] OFF
GO
SET IDENTITY_INSERT [SysSales].[InvoiceDetail] ON 

INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (1, N'AC', 11, CAST(2.00 AS Decimal(18, 2)), CAST(2100000.00 AS Decimal(17, 2)), CAST(4200000.00 AS Decimal(17, 2)), 1)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (2, N'AC', 11, CAST(1.00 AS Decimal(18, 2)), CAST(2100000.00 AS Decimal(17, 2)), CAST(2100000.00 AS Decimal(17, 2)), 11)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (3, N'AC', 1, CAST(7.00 AS Decimal(18, 2)), CAST(80000.00 AS Decimal(17, 2)), CAST(560000.00 AS Decimal(17, 2)), 10)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (4, N'AC', 4, CAST(5.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(17, 2)), CAST(250000.00 AS Decimal(17, 2)), 9)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (5, N'AC', 11, CAST(6.00 AS Decimal(18, 2)), CAST(2100000.00 AS Decimal(17, 2)), CAST(12600000.00 AS Decimal(17, 2)), 8)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (6, N'AC', 11, CAST(2.00 AS Decimal(18, 2)), CAST(2100000.00 AS Decimal(17, 2)), CAST(4200000.00 AS Decimal(17, 2)), 12)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (7, N'AC', 10, CAST(7.00 AS Decimal(18, 2)), CAST(2800000.00 AS Decimal(17, 2)), CAST(19600000.00 AS Decimal(17, 2)), 6)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (8, N'AC', 9, CAST(2.00 AS Decimal(18, 2)), CAST(1800000.00 AS Decimal(17, 2)), CAST(3600000.00 AS Decimal(17, 2)), 5)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (9, N'AC', 5, CAST(15.00 AS Decimal(18, 2)), CAST(180000.00 AS Decimal(17, 2)), CAST(2700000.00 AS Decimal(17, 2)), 4)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (10, N'AC', 8, CAST(10.00 AS Decimal(18, 2)), CAST(150000.00 AS Decimal(17, 2)), CAST(1500000.00 AS Decimal(17, 2)), 7)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (11, N'AC', 6, CAST(2.00 AS Decimal(18, 2)), CAST(130000.00 AS Decimal(17, 2)), CAST(260000.00 AS Decimal(17, 2)), 3)
INSERT [SysSales].[InvoiceDetail] ([Id], [Status], [ProductId], [Amount], [Price], [Total], [InvoiceMasterId]) VALUES (12, N'AC', 6, CAST(16.00 AS Decimal(18, 2)), CAST(130000.00 AS Decimal(17, 2)), CAST(2080000.00 AS Decimal(17, 2)), 2)
SET IDENTITY_INSERT [SysSales].[InvoiceDetail] OFF
GO
SET IDENTITY_INSERT [SysSales].[InvoiceMaster] ON 

INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (1, 1, NULL, CAST(4200000.00 AS Decimal(18, 2)), CAST(N'2000-04-12T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (2, 2, NULL, CAST(2080000.00 AS Decimal(18, 2)), CAST(N'2000-06-05T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (3, 2, NULL, CAST(260000.00 AS Decimal(18, 2)), CAST(N'2000-02-05T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (4, 2, NULL, CAST(2700000.00 AS Decimal(18, 2)), CAST(N'2000-01-28T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (5, 3, NULL, CAST(3600000.00 AS Decimal(18, 2)), CAST(N'2000-02-08T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (6, 3, NULL, CAST(19600000.00 AS Decimal(18, 2)), CAST(N'2000-02-01T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (7, 2, NULL, CAST(1500000.00 AS Decimal(18, 2)), CAST(N'2000-02-01T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (8, 3, NULL, CAST(12600000.00 AS Decimal(18, 2)), CAST(N'2000-06-05T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (9, 1, NULL, CAST(250000.00 AS Decimal(18, 2)), CAST(N'2000-02-13T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (10, 1, NULL, CAST(560000.00 AS Decimal(18, 2)), CAST(N'2000-03-17T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (11, 1, NULL, CAST(2100000.00 AS Decimal(18, 2)), CAST(N'2000-03-13T00:00:00.0000000' AS DateTime2), N'AP')
INSERT [SysSales].[InvoiceMaster] ([Id], [ClientId], [DateCancel], [Total], [CreatedAt], [Status]) VALUES (12, 3, NULL, CAST(4200000.00 AS Decimal(18, 2)), CAST(N'2000-02-05T00:00:00.0000000' AS DateTime2), N'AP')
SET IDENTITY_INSERT [SysSales].[InvoiceMaster] OFF
GO
SET IDENTITY_INSERT [SysSales].[Product] ON 

INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (1, N'AC', CAST(N'2022-06-07T01:21:24.3473352' AS DateTime2), N'Pantalon Negro', N'Pan-01', CAST(8.00 AS Decimal(18, 2)), CAST(80000.00 AS Decimal(17, 2)), 1)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (2, N'AC', CAST(N'2022-06-07T01:21:24.3473359' AS DateTime2), N'Short', N'Sho-17', CAST(20.00 AS Decimal(18, 2)), CAST(30000.00 AS Decimal(17, 2)), 1)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (3, N'AC', CAST(N'2022-06-07T01:21:24.3473356' AS DateTime2), N'Blusa azul', N'Blo-11', CAST(20.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(17, 2)), 1)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (4, N'AC', CAST(N'2022-06-07T01:21:24.3473361' AS DateTime2), N'Camisa', N'Shi-11', CAST(15.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(17, 2)), 1)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (5, N'AC', CAST(N'2022-06-07T01:21:24.3473370' AS DateTime2), N'Zapato Negro', N'Zap-14', CAST(0.00 AS Decimal(18, 2)), CAST(180000.00 AS Decimal(17, 2)), 2)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (6, N'AC', CAST(N'2022-06-07T01:21:24.3473375' AS DateTime2), N'Zapato Blanco', N'Zap-19', CAST(2.00 AS Decimal(18, 2)), CAST(130000.00 AS Decimal(17, 2)), 2)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (7, N'AC', CAST(N'2022-06-07T01:21:24.3473378' AS DateTime2), N'Zapato Rojo', N'Zap-21', CAST(20.00 AS Decimal(18, 2)), CAST(1450000.00 AS Decimal(17, 2)), 2)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (8, N'AC', CAST(N'2022-06-07T01:21:24.3473372' AS DateTime2), N'Zapato Azul', N'Zap-15', CAST(10.00 AS Decimal(18, 2)), CAST(150000.00 AS Decimal(17, 2)), 2)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (9, N'AC', CAST(N'2022-06-07T01:21:24.3468151' AS DateTime2), N'Acer Aspire 15', N'Acer-15', CAST(18.00 AS Decimal(18, 2)), CAST(1800000.00 AS Decimal(17, 2)), 3)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (10, N'AC', CAST(N'2022-06-07T01:21:24.3472810' AS DateTime2), N'Lenovo', N'Len-15', CAST(13.00 AS Decimal(18, 2)), CAST(2800000.00 AS Decimal(17, 2)), 3)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (11, N'AC', CAST(N'2022-06-07T01:21:24.3472833' AS DateTime2), N'HP', N'HP-15', CAST(9.00 AS Decimal(18, 2)), CAST(2100000.00 AS Decimal(17, 2)), 3)
INSERT [SysSales].[Product] ([Id], [Status], [Date], [Name], [Code], [Amount], [Price], [CategoryId]) VALUES (12, N'AC', CAST(N'2022-06-07T01:21:24.3472838' AS DateTime2), N'Mac', N'Mac-15', CAST(20.00 AS Decimal(18, 2)), CAST(3100000.00 AS Decimal(17, 2)), 3)
SET IDENTITY_INSERT [SysSales].[Product] OFF
GO
/****** Object:  Index [IX_InvoiceDetail_InvoiceMasterId]    Script Date: 7/06/2022 1:30:15 a.m. ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDetail_InvoiceMasterId] ON [SysSales].[InvoiceDetail]
(
	[InvoiceMasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvoiceDetail_ProductId]    Script Date: 7/06/2022 1:30:15 a.m. ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDetail_ProductId] ON [SysSales].[InvoiceDetail]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvoiceMaster_ClientId]    Script Date: 7/06/2022 1:30:15 a.m. ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceMaster_ClientId] ON [SysSales].[InvoiceMaster]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_CategoryId]    Script Date: 7/06/2022 1:30:15 a.m. ******/
CREATE NONCLUSTERED INDEX [IX_Product_CategoryId] ON [SysSales].[Product]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [SysSales].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_InvoiceMaster_InvoiceMasterId] FOREIGN KEY([InvoiceMasterId])
REFERENCES [SysSales].[InvoiceMaster] ([Id])
GO
ALTER TABLE [SysSales].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_InvoiceMaster_InvoiceMasterId]
GO
ALTER TABLE [SysSales].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [SysSales].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [SysSales].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Product_ProductId]
GO
ALTER TABLE [SysSales].[InvoiceMaster]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceMaster_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [SysSales].[InvoiceMaster] CHECK CONSTRAINT [FK_InvoiceMaster_Clients_ClientId]
GO
ALTER TABLE [SysSales].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [SysSales].[Category] ([Id])
GO
ALTER TABLE [SysSales].[Product] CHECK CONSTRAINT [FK_Product_Category_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [SysSalesBD] SET  READ_WRITE 
GO
