USE [master]
GO
/****** Object:  Database [SeerviceCom]    Script Date: 29.05.2024 23:24:50 ******/
CREATE DATABASE [SeerviceCom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SeerviceCom', FILENAME = N'D:\SQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\SeerviceCom.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SeerviceCom_log', FILENAME = N'D:\SQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\SeerviceCom_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SeerviceCom] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SeerviceCom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SeerviceCom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SeerviceCom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SeerviceCom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SeerviceCom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SeerviceCom] SET ARITHABORT OFF 
GO
ALTER DATABASE [SeerviceCom] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SeerviceCom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SeerviceCom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SeerviceCom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SeerviceCom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SeerviceCom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SeerviceCom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SeerviceCom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SeerviceCom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SeerviceCom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SeerviceCom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SeerviceCom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SeerviceCom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SeerviceCom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SeerviceCom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SeerviceCom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SeerviceCom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SeerviceCom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SeerviceCom] SET  MULTI_USER 
GO
ALTER DATABASE [SeerviceCom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SeerviceCom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SeerviceCom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SeerviceCom] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SeerviceCom] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SeerviceCom] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SeerviceCom] SET QUERY_STORE = OFF
GO
USE [SeerviceCom]
GO
/****** Object:  Table [dbo].[ApplicationUs]    Script Date: 29.05.2024 23:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationDateTime] [datetime] NOT NULL,
	[StatusID] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Comid] [int] NOT NULL,
	[DoneAplDateTime] [datetime] NULL,
	[Detailid] [int] NULL,
	[Worid] [int] NULL,
	[DateTimeWorker] [datetime] NULL,
 CONSTRAINT [PK_ApplicationUs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detail]    Script Date: 29.05.2024 23:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DetailName] [nvarchar](50) NOT NULL,
	[DTypeID] [int] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailType]    Script Date: 29.05.2024 23:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NameType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DetailType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 29.05.2024 23:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DetailId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ShopId] [int] NOT NULL,
	[PurchaseDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 29.05.2024 23:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shops]    Script Date: 29.05.2024 23:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shops](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ShopName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Shops] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 29.05.2024 23:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storage]    Script Date: 29.05.2024 23:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DetailId] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Storage_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 29.05.2024 23:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Roleid] [int] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ApplicationUs] ON 

INSERT [dbo].[ApplicationUs] ([id], [ApplicationDateTime], [StatusID], [Description], [Comid], [DoneAplDateTime], [Detailid], [Worid], [DateTimeWorker]) VALUES (1008, CAST(N'2024-05-15T15:23:48.447' AS DateTime), 3, N'Не включаеться пк', 1, CAST(N'2024-05-15T15:25:14.587' AS DateTime), 2, 4, CAST(N'2024-05-15T03:24:39.370' AS DateTime))
INSERT [dbo].[ApplicationUs] ([id], [ApplicationDateTime], [StatusID], [Description], [Comid], [DoneAplDateTime], [Detailid], [Worid], [DateTimeWorker]) VALUES (1010, CAST(N'2024-05-15T20:57:58.900' AS DateTime), 3, N'завис', 13, CAST(N'2024-05-15T21:02:55.320' AS DateTime), 8, 4, CAST(N'2024-05-15T09:02:27.223' AS DateTime))
INSERT [dbo].[ApplicationUs] ([id], [ApplicationDateTime], [StatusID], [Description], [Comid], [DoneAplDateTime], [Detailid], [Worid], [DateTimeWorker]) VALUES (1011, CAST(N'2024-05-16T14:24:06.207' AS DateTime), 3, N'Не включаеться комп', 3, CAST(N'2024-05-16T14:25:58.733' AS DateTime), 1, 4, CAST(N'2024-05-16T02:25:35.463' AS DateTime))
INSERT [dbo].[ApplicationUs] ([id], [ApplicationDateTime], [StatusID], [Description], [Comid], [DoneAplDateTime], [Detailid], [Worid], [DateTimeWorker]) VALUES (1013, CAST(N'2024-05-29T17:22:30.800' AS DateTime), 4, N'hhh', 12, NULL, NULL, 4, CAST(N'2024-05-29T05:22:43.533' AS DateTime))
SET IDENTITY_INSERT [dbo].[ApplicationUs] OFF
GO
SET IDENTITY_INSERT [dbo].[Detail] ON 

INSERT [dbo].[Detail] ([id], [DetailName], [DTypeID], [Description]) VALUES (1, N'Aerocool mx200 500w', 2, NULL)
INSERT [dbo].[Detail] ([id], [DetailName], [DTypeID], [Description]) VALUES (2, N'Samsung 4gb', 4, NULL)
INSERT [dbo].[Detail] ([id], [DetailName], [DTypeID], [Description]) VALUES (3, N'AppData 500 гб', 3, NULL)
INSERT [dbo].[Detail] ([id], [DetailName], [DTypeID], [Description]) VALUES (4, N'Samsung 500 гб', 5, NULL)
INSERT [dbo].[Detail] ([id], [DetailName], [DTypeID], [Description]) VALUES (7, N'Intel core i5', 1, N'eg')
INSERT [dbo].[Detail] ([id], [DetailName], [DTypeID], [Description]) VALUES (8, N'Видеокарта Nvidia gtx1050', 6, NULL)
SET IDENTITY_INSERT [dbo].[Detail] OFF
GO
SET IDENTITY_INSERT [dbo].[DetailType] ON 

INSERT [dbo].[DetailType] ([id], [NameType]) VALUES (1, N'Процессор')
INSERT [dbo].[DetailType] ([id], [NameType]) VALUES (2, N'Блок питания')
INSERT [dbo].[DetailType] ([id], [NameType]) VALUES (3, N'Жесткий диск')
INSERT [dbo].[DetailType] ([id], [NameType]) VALUES (4, N'Оперативная память')
INSERT [dbo].[DetailType] ([id], [NameType]) VALUES (5, N'SSD диск')
INSERT [dbo].[DetailType] ([id], [NameType]) VALUES (6, N'Видеокарта')
SET IDENTITY_INSERT [dbo].[DetailType] OFF
GO
SET IDENTITY_INSERT [dbo].[Purchase] ON 

INSERT [dbo].[Purchase] ([id], [DetailId], [Quantity], [ShopId], [PurchaseDateTime]) VALUES (8, 3, 3, 2, CAST(N'2024-05-27T09:40:51.500' AS DateTime))
INSERT [dbo].[Purchase] ([id], [DetailId], [Quantity], [ShopId], [PurchaseDateTime]) VALUES (9, 1, 10, 1, CAST(N'2024-05-27T09:41:09.630' AS DateTime))
INSERT [dbo].[Purchase] ([id], [DetailId], [Quantity], [ShopId], [PurchaseDateTime]) VALUES (10, 2, 10, 3, CAST(N'2024-05-27T09:41:20.780' AS DateTime))
INSERT [dbo].[Purchase] ([id], [DetailId], [Quantity], [ShopId], [PurchaseDateTime]) VALUES (11, 2, 10, 4, CAST(N'2024-05-27T09:41:48.400' AS DateTime))
SET IDENTITY_INSERT [dbo].[Purchase] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [Role]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([id], [Role]) VALUES (2, N'User')
INSERT [dbo].[Role] ([id], [Role]) VALUES (3, N'Worker')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Shops] ON 

INSERT [dbo].[Shops] ([id], [ShopName]) VALUES (1, N'ДНС')
INSERT [dbo].[Shops] ([id], [ShopName]) VALUES (2, N'Эльдорадо')
INSERT [dbo].[Shops] ([id], [ShopName]) VALUES (3, N'Ситилинк')
INSERT [dbo].[Shops] ([id], [ShopName]) VALUES (4, N'МВидео')
SET IDENTITY_INSERT [dbo].[Shops] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([id], [Status]) VALUES (1, N'В обработке')
INSERT [dbo].[Status] ([id], [Status]) VALUES (3, N'Выполненна')
INSERT [dbo].[Status] ([id], [Status]) VALUES (4, N'Передано специалисту')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Storage] ON 

INSERT [dbo].[Storage] ([id], [DetailId], [Quantity]) VALUES (3, 2, 30)
INSERT [dbo].[Storage] ([id], [DetailId], [Quantity]) VALUES (5, 7, 3)
INSERT [dbo].[Storage] ([id], [DetailId], [Quantity]) VALUES (6, 3, 3)
INSERT [dbo].[Storage] ([id], [DetailId], [Quantity]) VALUES (7, 1, 10)
SET IDENTITY_INSERT [dbo].[Storage] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [UserName], [Roleid], [Login], [Password]) VALUES (1, N'Денис', 1, N'1', N'1')
INSERT [dbo].[User] ([id], [UserName], [Roleid], [Login], [Password]) VALUES (2, N'Ирина Агутина', 2, N'2', N'2')
INSERT [dbo].[User] ([id], [UserName], [Roleid], [Login], [Password]) VALUES (4, N'Игорь Смирнов', 3, N'3', N'3')
INSERT [dbo].[User] ([id], [UserName], [Roleid], [Login], [Password]) VALUES (5, N'Олег Шишов', 3, N'5', N'5')
INSERT [dbo].[User] ([id], [UserName], [Roleid], [Login], [Password]) VALUES (6, N'Илья Иванов', 3, N'6', N'6')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[ApplicationUs]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUs_Detail] FOREIGN KEY([Detailid])
REFERENCES [dbo].[Detail] ([id])
GO
ALTER TABLE [dbo].[ApplicationUs] CHECK CONSTRAINT [FK_ApplicationUs_Detail]
GO
ALTER TABLE [dbo].[ApplicationUs]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUs_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([id])
GO
ALTER TABLE [dbo].[ApplicationUs] CHECK CONSTRAINT [FK_ApplicationUs_Status]
GO
ALTER TABLE [dbo].[ApplicationUs]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUs_User] FOREIGN KEY([Worid])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[ApplicationUs] CHECK CONSTRAINT [FK_ApplicationUs_User]
GO
ALTER TABLE [dbo].[Detail]  WITH CHECK ADD  CONSTRAINT [FK_Detail_DetailType] FOREIGN KEY([DTypeID])
REFERENCES [dbo].[DetailType] ([id])
GO
ALTER TABLE [dbo].[Detail] CHECK CONSTRAINT [FK_Detail_DetailType]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Detail] FOREIGN KEY([DetailId])
REFERENCES [dbo].[Detail] ([id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Detail]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Shops] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shops] ([id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Shops]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_Detail1] FOREIGN KEY([DetailId])
REFERENCES [dbo].[Detail] ([id])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_Detail1]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([Roleid])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [SeerviceCom] SET  READ_WRITE 
GO
