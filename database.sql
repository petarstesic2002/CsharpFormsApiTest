USE [master]
GO
/****** Object:  Database [CsharpFormsApiTestDb]    Script Date: 10/15/2024 2:51:21 PM ******/
CREATE DATABASE [CsharpFormsApiTestDb]
ALTER DATABASE [CsharpFormsApiTestDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CsharpFormsApiTestDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET  MULTI_USER 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET QUERY_STORE = OFF
GO
USE [CsharpFormsApiTestDb]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10/15/2024 2:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 10/15/2024 2:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/15/2024 2:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CreatedAt]) VALUES (1, N'Category 1', CAST(N'2024-10-14T21:04:15.783' AS DateTime))
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CreatedAt]) VALUES (2, N'Category2', CAST(N'2024-10-14T21:04:20.890' AS DateTime))
SET IDENTITY_INSERT [dbo].[Categories] OFF
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (2, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (3, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (3, 2)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (6, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (7, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (7, 2)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (8, 2)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (9, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (9, 2)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (10, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (10, 2)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (11, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (12, 1)
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (2, N'Product 1', CAST(19 AS Decimal(18, 0)), N'Description Test', 4, CAST(N'2024-10-14T21:05:34.817' AS DateTime))
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (3, N'Product 2', CAST(24 AS Decimal(18, 0)), N'Description 2', 5, CAST(N'2024-10-14T21:05:49.030' AS DateTime))
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (6, N'Test 1', CAST(11 AS Decimal(18, 0)), N'Test Desc', 2, CAST(N'2024-10-15T14:26:43.073' AS DateTime))
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (7, N'Test 2', CAST(22 AS Decimal(18, 0)), N'Test Desc', 3, CAST(N'2024-10-15T14:27:01.307' AS DateTime))
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (8, N'Test 3', CAST(33 AS Decimal(18, 0)), N'Test Desc', 45, CAST(N'2024-10-15T14:28:09.353' AS DateTime))
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (9, N'Test 4', CAST(33 AS Decimal(18, 0)), N'Test Desc', 34, CAST(N'2024-10-15T14:28:29.813' AS DateTime))
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (10, N'Test 5', CAST(43 AS Decimal(18, 0)), N'Test Desc', 3, CAST(N'2024-10-15T14:28:57.777' AS DateTime))
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (11, N'Test 6', CAST(12 AS Decimal(18, 0)), N'Test Desc', 5, CAST(N'2024-10-15T14:29:21.427' AS DateTime))
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [Description], [StockQuantity], [CreatedAt]) VALUES (12, N'Test 8', CAST(22 AS Decimal(18, 0)), N'Test Desc', 2, CAST(N'2024-10-15T14:30:08.940' AS DateTime))
SET IDENTITY_INSERT [dbo].[Products] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [CategoryName_Unique]    Script Date: 10/15/2024 2:51:22 PM ******/
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [CategoryName_Unique] UNIQUE NONCLUSTERED 
(
	[CategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [ProductName_Unique]    Script Date: 10/15/2024 2:51:22 PM ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [ProductName_Unique] UNIQUE NONCLUSTERED 
(
	[ProductName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_Categories]
GO
ALTER TABLE [dbo].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_Products]
GO
USE [master]
GO
ALTER DATABASE [CsharpFormsApiTestDb] SET  READ_WRITE 
GO
