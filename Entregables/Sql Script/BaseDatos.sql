USE [master]
GO
/****** Object:  Database [NttDataTest]    Script Date: 10/4/2022 16:21:32 ******/
CREATE DATABASE [NttDataTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NttDataTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NttDataTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NttDataTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NttDataTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NttDataTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NttDataTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NttDataTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NttDataTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NttDataTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NttDataTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NttDataTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [NttDataTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NttDataTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NttDataTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NttDataTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NttDataTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NttDataTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NttDataTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NttDataTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NttDataTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NttDataTest] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NttDataTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NttDataTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NttDataTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NttDataTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NttDataTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NttDataTest] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NttDataTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NttDataTest] SET RECOVERY FULL 
GO
ALTER DATABASE [NttDataTest] SET  MULTI_USER 
GO
ALTER DATABASE [NttDataTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NttDataTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NttDataTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NttDataTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NttDataTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NttDataTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NttDataTest', N'ON'
GO
ALTER DATABASE [NttDataTest] SET QUERY_STORE = OFF
GO
USE [NttDataTest]
GO
/****** Object:  User [nuo]    Script Date: 10/4/2022 16:21:33 ******/
CREATE USER [nuo] FOR LOGIN [nuo] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/4/2022 16:21:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbCliente]    Script Date: 10/4/2022 16:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonaId] [int] NOT NULL,
	[Contrasenia] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_tbCliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbCuenta]    Script Date: 10/4/2022 16:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCuenta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](50) NOT NULL,
	[TipoCuentaId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_tbCuenta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbMovimiento]    Script Date: 10/4/2022 16:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbMovimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[CuentaId] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[SaldoInicial] [decimal](18, 2) NOT NULL,
	[TipoMovimiento] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_tbMovimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbPersona]    Script Date: 10/4/2022 16:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbPersona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Genero] [nvarchar](1) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](200) NULL,
	[Telefono] [nvarchar](20) NULL,
 CONSTRAINT [PK_tbPersona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbTipoCuenta]    Script Date: 10/4/2022 16:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTipoCuenta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [nvarchar](max) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_tbTipoCuenta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220408200003_MigracionInicial', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220410173724_Migracion1', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220410181733_Migracion2', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220410190911_Migracion3', N'5.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220410192301_Migracion4', N'5.0.15')
GO
SET IDENTITY_INSERT [dbo].[tbCliente] ON 

INSERT [dbo].[tbCliente] ([Id], [PersonaId], [Contrasenia], [Estado]) VALUES (1, 1, N'1234', 1)
INSERT [dbo].[tbCliente] ([Id], [PersonaId], [Contrasenia], [Estado]) VALUES (2, 2, N'5678', 1)
INSERT [dbo].[tbCliente] ([Id], [PersonaId], [Contrasenia], [Estado]) VALUES (3, 3, N'1245', 1)
SET IDENTITY_INSERT [dbo].[tbCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[tbCuenta] ON 

INSERT [dbo].[tbCuenta] ([Id], [Numero], [TipoCuentaId], [ClienteId], [Saldo], [Estado]) VALUES (1, N'478758', 1, 1, CAST(2000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tbCuenta] ([Id], [Numero], [TipoCuentaId], [ClienteId], [Saldo], [Estado]) VALUES (2, N'225487', 2, 2, CAST(100.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tbCuenta] ([Id], [Numero], [TipoCuentaId], [ClienteId], [Saldo], [Estado]) VALUES (3, N'495878', 1, 3, CAST(0.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tbCuenta] ([Id], [Numero], [TipoCuentaId], [ClienteId], [Saldo], [Estado]) VALUES (4, N'496825', 1, 2, CAST(540.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[tbCuenta] ([Id], [Numero], [TipoCuentaId], [ClienteId], [Saldo], [Estado]) VALUES (5, N'585545', 2, 1, CAST(1000.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[tbCuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[tbPersona] ON 

INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (1, N'José Lema', N'M', 25, N'0912345678', N'Otavalo sn y principal', N'098254785')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (2, N'Marianela Montalvo', N'F', 23, N'0987654321', N'Amazonas y NNUU', N'097548965')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (3, N'Juan Osorio ', N'M', 26, N'0976543218', N'13 junio y Equinoccial', N'098874587')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (4, N'Luis Pita', N'M', 30, N'0912345678', N'isla trinitaria', N'0982617189')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (5, N'Luis Pita', N'M', 30, N'0912345678', N'isla trinitaria', N'0982617189')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (6, N'Luis Pita', N'M', 30, N'0912345678', N'Isla Trinitaria', N'0982617189')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (7, N'Luis Pita', N'M', 30, N'0912345678', N'isla trinitaria', N'0982617189')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (8, N'Luis Pita', N'M', 30, N'0912345678', N'Isla Trinitaria', N'0982617189')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (14, N'Luis Pita', N'M', 34, N'0912345678', N'Trinipuerto', N'0983457829')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (15, N'Luis Pita', N'M', 34, N'0912345678', N'Trinipuerto', N'0983457829')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (17, N'Luis Pita', N'M', 30, N'2312312312', N'isla trinitaria', N'0982617189')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (18, N'Luis Pita', N'M', 30, N'092222222', N'Isla Trinitaria por el trinipuerto', N'0982617189')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (21, N'Luis Pita', N'M', 30, N'2312312312', N'Isla Trinitaria', N'0982617189')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (23, N'Luis Pita', N'M', 30, N'0982637282', N'isla trinitaria', N'0982617189')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (24, N'Luis Pita', N'F', 30, N'0909090909', N'Etapa Galaxia', N'0980980980')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (25, N'Luis Pita', N'F', 30, N'0909090909', N'Etapa Galaxia', N'0980980980')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (27, N'Luis Pita', N'M', 30, N'2312312312', N'Isla Trinitaria', N'0982617189')
INSERT [dbo].[tbPersona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (30, N'Luis Pita', N'M', 30, N'0982621728', N'Isla Trinitaria', N'0987532910')
SET IDENTITY_INSERT [dbo].[tbPersona] OFF
GO
SET IDENTITY_INSERT [dbo].[tbTipoCuenta] ON 

INSERT [dbo].[tbTipoCuenta] ([Id], [Valor], [Estado]) VALUES (1, N'Ahorro', 1)
INSERT [dbo].[tbTipoCuenta] ([Id], [Valor], [Estado]) VALUES (2, N'Corriente', 1)
SET IDENTITY_INSERT [dbo].[tbTipoCuenta] OFF
GO
/****** Object:  Index [IX_tbCliente_PersonaId]    Script Date: 10/4/2022 16:21:33 ******/
CREATE NONCLUSTERED INDEX [IX_tbCliente_PersonaId] ON [dbo].[tbCliente]
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbCuenta_ClienteId]    Script Date: 10/4/2022 16:21:33 ******/
CREATE NONCLUSTERED INDEX [IX_tbCuenta_ClienteId] ON [dbo].[tbCuenta]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbCuenta_TipoCuentaId]    Script Date: 10/4/2022 16:21:33 ******/
CREATE NONCLUSTERED INDEX [IX_tbCuenta_TipoCuentaId] ON [dbo].[tbCuenta]
(
	[TipoCuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbMovimiento] ADD  DEFAULT (N'') FOR [TipoMovimiento]
GO
ALTER TABLE [dbo].[tbCliente]  WITH CHECK ADD  CONSTRAINT [FK_tbCliente_tbPersona_PersonaId] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[tbPersona] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbCliente] CHECK CONSTRAINT [FK_tbCliente_tbPersona_PersonaId]
GO
ALTER TABLE [dbo].[tbCuenta]  WITH CHECK ADD  CONSTRAINT [FK_tbCuenta_tbCliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[tbCliente] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbCuenta] CHECK CONSTRAINT [FK_tbCuenta_tbCliente_ClienteId]
GO
ALTER TABLE [dbo].[tbCuenta]  WITH CHECK ADD  CONSTRAINT [FK_tbCuenta_tbTipoCuenta_TipoCuentaId] FOREIGN KEY([TipoCuentaId])
REFERENCES [dbo].[tbTipoCuenta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbCuenta] CHECK CONSTRAINT [FK_tbCuenta_tbTipoCuenta_TipoCuentaId]
GO
ALTER TABLE [dbo].[tbMovimiento]  WITH CHECK ADD  CONSTRAINT [FK_tbMovimiento_tbCuenta_CuentaId] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[tbCuenta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbMovimiento] CHECK CONSTRAINT [FK_tbMovimiento_tbCuenta_CuentaId]
GO
USE [master]
GO
ALTER DATABASE [NttDataTest] SET  READ_WRITE 
GO
