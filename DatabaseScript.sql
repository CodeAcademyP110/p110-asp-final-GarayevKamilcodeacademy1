USE [master]
GO
/****** Object:  Database [AspNetFinalCodeAcademy]    Script Date: 8/13/2019 8:20:00 PM ******/
CREATE DATABASE [AspNetFinalCodeAcademy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AspNetFinalCodeAcademy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\AspNetFinalCodeAcademy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AspNetFinalCodeAcademy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\AspNetFinalCodeAcademy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AspNetFinalCodeAcademy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET ARITHABORT OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET  MULTI_USER 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AspNetFinalCodeAcademy', N'ON'
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET QUERY_STORE = OFF
GO
USE [AspNetFinalCodeAcademy]
GO
/****** Object:  Table [dbo].[Advertisements]    Script Date: 8/13/2019 8:20:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisements](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[RefreshDate] [datetime] NULL,
	[CityID] [int] NULL,
	[CarID] [int] NULL,
	[VIP] [bit] NOT NULL,
	[PhotoDirectory] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 8/13/2019 8:20:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 8/13/2019 8:20:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [decimal](7, 2) NOT NULL,
	[ModelID] [int] NULL,
	[EngineCapacity] [int] NULL,
	[ColorID] [int] NULL,
	[Mileage] [decimal](8, 2) NULL,
	[FuelType] [nvarchar](100) NULL,
	[Transmission] [nvarchar](100) NULL,
	[About] [nvarchar](max) NULL,
	[Year] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 8/13/2019 8:20:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 8/13/2019 8:20:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Models]    Script Date: 8/13/2019 8:20:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[BrandID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 8/13/2019 8:20:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[PhotoDirectory] [varchar](1000) NULL,
	[Title] [nvarchar](500) NOT NULL,
	[TextDirectory] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 8/13/2019 8:20:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PhotoDirectory] [varchar](1000) NULL,
	[HexNumber] [varchar](100) NULL,
	[CarID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/13/2019 8:20:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[NormalizedName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/13/2019 8:20:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[NormalizedUserName] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[Password] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Advertisements] ON 

INSERT [dbo].[Advertisements] ([ID], [CreationDate], [RefreshDate], [CityID], [CarID], [VIP], [PhotoDirectory]) VALUES (2, CAST(N'2019-08-11T13:25:26.363' AS DateTime), NULL, 1, 6, 1, N'https://turbo.azstatic.com/uploads/f460x343/2019%2F01%2F30%2F11%2F58%2F34%2Fafcc9d40-7c7d-448f-a7f7-b9f5fc2a5d1e%2F23118_52j_bhYOFSyf5vjlzKv4UQ.jpg')
INSERT [dbo].[Advertisements] ([ID], [CreationDate], [RefreshDate], [CityID], [CarID], [VIP], [PhotoDirectory]) VALUES (3, CAST(N'2019-08-13T01:13:49.417' AS DateTime), NULL, 1, 13, 0, NULL)
INSERT [dbo].[Advertisements] ([ID], [CreationDate], [RefreshDate], [CityID], [CarID], [VIP], [PhotoDirectory]) VALUES (4, CAST(N'2019-08-13T19:17:53.260' AS DateTime), NULL, 1, 14, 1, NULL)
INSERT [dbo].[Advertisements] ([ID], [CreationDate], [RefreshDate], [CityID], [CarID], [VIP], [PhotoDirectory]) VALUES (5, CAST(N'2019-08-13T19:19:07.220' AS DateTime), NULL, 1, 15, 0, NULL)
SET IDENTITY_INSERT [dbo].[Advertisements] OFF
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([ID], [Name]) VALUES (1, N'LandRover')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (2, N'Mercedes')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (3, N'BMW')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (4, N'Mitsubishi')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (5, N'Suzuki')
INSERT [dbo].[Brands] ([ID], [Name]) VALUES (6, N'Audi')
SET IDENTITY_INSERT [dbo].[Brands] OFF
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([ID], [Name], [Price], [ModelID], [EngineCapacity], [ColorID], [Mileage], [FuelType], [Transmission], [About], [Year]) VALUES (6, N'Land Rover Discovery', CAST(26700.00 AS Decimal(7, 2)), 1, 2700, 5, CAST(23100.00 AS Decimal(8, 2)), N'benzin', N'mexanik', N'masin ela veziyyetdedir', 2006)
INSERT [dbo].[Cars] ([ID], [Name], [Price], [ModelID], [EngineCapacity], [ColorID], [Mileage], [FuelType], [Transmission], [About], [Year]) VALUES (8, N' ', CAST(15000.00 AS Decimal(7, 2)), 1, 1800, 4, CAST(50000.00 AS Decimal(8, 2)), N'benzin', N'avtomat', N'wgerwyretwe', 2000)
INSERT [dbo].[Cars] ([ID], [Name], [Price], [ModelID], [EngineCapacity], [ColorID], [Mileage], [FuelType], [Transmission], [About], [Year]) VALUES (9, N' ', CAST(15000.00 AS Decimal(7, 2)), 1, 1800, 4, CAST(150000.00 AS Decimal(8, 2)), N'benzin', N'avtomat', N'123', 2000)
INSERT [dbo].[Cars] ([ID], [Name], [Price], [ModelID], [EngineCapacity], [ColorID], [Mileage], [FuelType], [Transmission], [About], [Year]) VALUES (10, N' ', CAST(15000.00 AS Decimal(7, 2)), 1, 1800, 4, CAST(150000.00 AS Decimal(8, 2)), N'benzin', N'avtomat', N'123', 2000)
INSERT [dbo].[Cars] ([ID], [Name], [Price], [ModelID], [EngineCapacity], [ColorID], [Mileage], [FuelType], [Transmission], [About], [Year]) VALUES (11, N' ', CAST(15000.00 AS Decimal(7, 2)), 1, 1800, 4, CAST(150000.00 AS Decimal(8, 2)), N'benzin', N'avtomat', N'123', 2000)
INSERT [dbo].[Cars] ([ID], [Name], [Price], [ModelID], [EngineCapacity], [ColorID], [Mileage], [FuelType], [Transmission], [About], [Year]) VALUES (12, N' ', CAST(15000.00 AS Decimal(7, 2)), 1, 1800, 4, CAST(150000.00 AS Decimal(8, 2)), N'benzin', N'avtomat', N'123', 2000)
INSERT [dbo].[Cars] ([ID], [Name], [Price], [ModelID], [EngineCapacity], [ColorID], [Mileage], [FuelType], [Transmission], [About], [Year]) VALUES (13, N' ', CAST(15000.00 AS Decimal(7, 2)), 1, 1800, 4, CAST(150000.00 AS Decimal(8, 2)), N'benzin', N'avtomat', N'123', 2000)
INSERT [dbo].[Cars] ([ID], [Name], [Price], [ModelID], [EngineCapacity], [ColorID], [Mileage], [FuelType], [Transmission], [About], [Year]) VALUES (14, N' ', CAST(15000.00 AS Decimal(7, 2)), 2, 1200, 3, CAST(150000.00 AS Decimal(8, 2)), N'benzin', N'avtomat', N'hgdhjfjkfmgfkjfvgvjvghvjvhvh chfchjcm', 2008)
INSERT [dbo].[Cars] ([ID], [Name], [Price], [ModelID], [EngineCapacity], [ColorID], [Mileage], [FuelType], [Transmission], [About], [Year]) VALUES (15, N' ', CAST(30000.00 AS Decimal(7, 2)), 3, 6500, 4, CAST(150000.00 AS Decimal(8, 2)), N'benzin', N'avtomat', N'gsjhhjgksf', 2009)
SET IDENTITY_INSERT [dbo].[Cars] OFF
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([ID], [Name]) VALUES (1, N'Baki')
SET IDENTITY_INSERT [dbo].[Cities] OFF
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([ID], [Name]) VALUES (1, N'yasil')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (2, N'sari')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (3, N'qirmizi')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (4, N'goy')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (5, N'ag')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (6, N'qara')
INSERT [dbo].[Colors] ([ID], [Name]) VALUES (7, N'benovseyi')
SET IDENTITY_INSERT [dbo].[Colors] OFF
SET IDENTITY_INSERT [dbo].[Models] ON 

INSERT [dbo].[Models] ([ID], [Name], [BrandID]) VALUES (1, N'Dicovery', 1)
INSERT [dbo].[Models] ([ID], [Name], [BrandID]) VALUES (2, N'Mercedes', 2)
INSERT [dbo].[Models] ([ID], [Name], [BrandID]) VALUES (3, N'528', 3)
INSERT [dbo].[Models] ([ID], [Name], [BrandID]) VALUES (4, N'Pajero', 4)
INSERT [dbo].[Models] ([ID], [Name], [BrandID]) VALUES (5, N'E 220', 2)
INSERT [dbo].[Models] ([ID], [Name], [BrandID]) VALUES (6, N'G 350', 2)
INSERT [dbo].[Models] ([ID], [Name], [BrandID]) VALUES (7, N'GSF 250 Bandit', 5)
INSERT [dbo].[Models] ([ID], [Name], [BrandID]) VALUES (8, N'A4', 6)
INSERT [dbo].[Models] ([ID], [Name], [BrandID]) VALUES (9, N'E 240', 2)
INSERT [dbo].[Models] ([ID], [Name], [BrandID]) VALUES (10, N'ML 270', 2)
SET IDENTITY_INSERT [dbo].[Models] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([ID], [CreationDate], [PhotoDirectory], [Title], [TextDirectory]) VALUES (1, CAST(N'2019-08-13T09:46:37.650' AS DateTime), N'https://turbo.azstatic.com/uploads/f352x352/2019%2F01%2F08%2F17%2F32%2F45%2Fba01c2b3-79ac-4b35-b015-fc7e629a4ddf%2F078automobiles.jpg', N'x?b?r basligi', N'C:\Users\magay\source\repos\CodeAcademyProject\Resources\xeber_basligi')
INSERT [dbo].[News] ([ID], [CreationDate], [PhotoDirectory], [Title], [TextDirectory]) VALUES (2, CAST(N'2019-08-13T09:46:37.650' AS DateTime), N'https://turbo.azstatic.com/uploads/f352x352/2017%2F12%2F22%2F11%2F30%2F19%2F259%2Fphoto_2017-12-22_11-28-22.jpg', N'x?b?r basligi2', N'C:\Users\magay\source\repos\CodeAcademyProject\Resources\xeber_basligi2')
INSERT [dbo].[News] ([ID], [CreationDate], [PhotoDirectory], [Title], [TextDirectory]) VALUES (3, CAST(N'2019-08-13T09:46:37.650' AS DateTime), N'https://turbo.azstatic.com/uploads/f352x352/2019%2F02%2F01%2F16%2F09%2F10%2Fa6041f19-a243-4a71-8d8e-249c4f70c79e%2F050carslogo.png', N'x?b?r basligi3', N'C:\Users\magay\source\repos\CodeAcademyProject\Resources\xeber_basligi3')
INSERT [dbo].[News] ([ID], [CreationDate], [PhotoDirectory], [Title], [TextDirectory]) VALUES (4, CAST(N'2019-08-13T09:46:37.650' AS DateTime), N'https://turbo.azstatic.com/uploads/f352x352/2018%2F10%2F22%2F12%2F29%2F37%2Fcac1bc11-9b36-451f-aa81-1c79e30b03e5%2Faylogo.jpg', N'x?b?r basligi4', N'C:\Users\magay\source\repos\CodeAcademyProject\Resources\xeber_basligi4')
INSERT [dbo].[News] ([ID], [CreationDate], [PhotoDirectory], [Title], [TextDirectory]) VALUES (5, CAST(N'2019-08-13T09:46:37.650' AS DateTime), N'https://turbo.azstatic.com/uploads/f352x352/2018%2F03%2F28%2F15%2F28%2F45%2F3d6d6738-8a33-4c03-9cc9-d5f1c504db9f%2Fbrabuslogo.jpg', N'x?b?r basligi5', N'C:\Users\magay\source\repos\CodeAcademyProject\Resources\xeber_basligi5')
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName]) VALUES (1, N'Admin', N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [RoleID], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [Password], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled]) VALUES (1, 1, N'kamil', N'kamil', N'qarayev@gmail.com', N'qarayev@gmail.com', 1, N'000', N'000', N'012 555 55 55', 0, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApplicationRole_NormalizedName]    Script Date: 8/13/2019 8:20:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationRole_NormalizedName] ON [dbo].[Roles]
(
	[NormalizedName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApplicationUser_NormalizedEmail]    Script Date: 8/13/2019 8:20:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_NormalizedEmail] ON [dbo].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApplicationUser_NormalizedUserName]    Script Date: 8/13/2019 8:20:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_NormalizedUserName] ON [dbo].[Users]
(
	[NormalizedUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Advertisements]  WITH CHECK ADD FOREIGN KEY([CarID])
REFERENCES [dbo].[Cars] ([ID])
GO
ALTER TABLE [dbo].[Advertisements]  WITH CHECK ADD FOREIGN KEY([CityID])
REFERENCES [dbo].[Cities] ([ID])
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD FOREIGN KEY([ColorID])
REFERENCES [dbo].[Colors] ([ID])
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD FOREIGN KEY([ModelID])
REFERENCES [dbo].[Models] ([ID])
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brands] ([ID])
GO
ALTER TABLE [dbo].[Photos]  WITH CHECK ADD FOREIGN KEY([CarID])
REFERENCES [dbo].[Cars] ([ID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([Id])
GO
USE [master]
GO
ALTER DATABASE [AspNetFinalCodeAcademy] SET  READ_WRITE 
GO
