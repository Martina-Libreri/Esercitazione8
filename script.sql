USE [master]
GO
/****** Object:  Database [EroiVSMostri]    Script Date: 3/19/2021 3:27:58 PM ******/
CREATE DATABASE [EroiVSMostri]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EroiVSMostri', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EroiVSMostri.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EroiVSMostri_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EroiVSMostri_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EroiVSMostri] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EroiVSMostri].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EroiVSMostri] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EroiVSMostri] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EroiVSMostri] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EroiVSMostri] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EroiVSMostri] SET ARITHABORT OFF 
GO
ALTER DATABASE [EroiVSMostri] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EroiVSMostri] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EroiVSMostri] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EroiVSMostri] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EroiVSMostri] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EroiVSMostri] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EroiVSMostri] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EroiVSMostri] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EroiVSMostri] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EroiVSMostri] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EroiVSMostri] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EroiVSMostri] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EroiVSMostri] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EroiVSMostri] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EroiVSMostri] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EroiVSMostri] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EroiVSMostri] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EroiVSMostri] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EroiVSMostri] SET  MULTI_USER 
GO
ALTER DATABASE [EroiVSMostri] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EroiVSMostri] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EroiVSMostri] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EroiVSMostri] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EroiVSMostri] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EroiVSMostri] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EroiVSMostri] SET QUERY_STORE = OFF
GO
USE [EroiVSMostri]
GO
/****** Object:  Table [dbo].[Arma]    Script Date: 3/19/2021 3:27:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arma](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[ClasseID] [int] NOT NULL,
	[Danni] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classe]    Script Date: 3/19/2021 3:27:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Valore] [bit] NULL,
	[Nome] [varchar](30) NULL,
 CONSTRAINT [PK__Classe__3214EC27BA4A03B0] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroe]    Script Date: 3/19/2021 3:27:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[GiocatoreID] [int] NOT NULL,
	[ClasseID] [int] NOT NULL,
	[LivelloID] [int] NOT NULL,
	[ArmaID] [int] NOT NULL,
	[PuntiAccumulati] [int] NULL,
	[Vittoria] [bit] NULL,
	[TempoDiGioco] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Giocatore]    Script Date: 3/19/2021 3:27:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giocatore](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[Ruolo] [varchar](255) NULL,
 CONSTRAINT [PK__Giocator__3214EC27A7A1E741] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Livello]    Script Date: 3/19/2021 3:27:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Livello](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Num] [int] NOT NULL,
	[PuntiVita] [int] NULL,
 CONSTRAINT [PK__Livello__3214EC27F9AF1DDE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mostro]    Script Date: 3/19/2021 3:27:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[ClasseID] [int] NOT NULL,
	[LivelloID] [int] NOT NULL,
	[ArmaID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arma] ON 

INSERT [dbo].[Arma] ([ID], [Nome], [ClasseID], [Danni]) VALUES (1, N'Spada', 2, 10)
INSERT [dbo].[Arma] ([ID], [Nome], [ClasseID], [Danni]) VALUES (2, N'Pistola', 2, 15)
INSERT [dbo].[Arma] ([ID], [Nome], [ClasseID], [Danni]) VALUES (3, N'Bastone', 3, 8)
INSERT [dbo].[Arma] ([ID], [Nome], [ClasseID], [Danni]) VALUES (4, N'Lancia', 5, 10)
INSERT [dbo].[Arma] ([ID], [Nome], [ClasseID], [Danni]) VALUES (5, N'Fuoco', 4, 20)
INSERT [dbo].[Arma] ([ID], [Nome], [ClasseID], [Danni]) VALUES (6, N'Bacchetta', 1, 20)
INSERT [dbo].[Arma] ([ID], [Nome], [ClasseID], [Danni]) VALUES (7, N'Pietra', 3, 5)
INSERT [dbo].[Arma] ([ID], [Nome], [ClasseID], [Danni]) VALUES (8, N'MagiaNera', 4, 25)
INSERT [dbo].[Arma] ([ID], [Nome], [ClasseID], [Danni]) VALUES (9, N'MagiaBianca', 1, 20)
SET IDENTITY_INSERT [dbo].[Arma] OFF
GO
SET IDENTITY_INSERT [dbo].[Classe] ON 

INSERT [dbo].[Classe] ([ID], [Valore], [Nome]) VALUES (1, 1, N'Mago')
INSERT [dbo].[Classe] ([ID], [Valore], [Nome]) VALUES (2, 1, N'Guerriero')
INSERT [dbo].[Classe] ([ID], [Valore], [Nome]) VALUES (3, 0, N'Orco')
INSERT [dbo].[Classe] ([ID], [Valore], [Nome]) VALUES (4, 0, N'SignoreDelMale')
INSERT [dbo].[Classe] ([ID], [Valore], [Nome]) VALUES (5, 0, N'Cultista')
SET IDENTITY_INSERT [dbo].[Classe] OFF
GO
SET IDENTITY_INSERT [dbo].[Eroe] ON 

INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (2, N'Ercole', 1, 2, 1, 1, 0, 0, CAST(N'00:00:00' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (3, N'Zeus', 3, 1, 2, 9, 40, 0, CAST(N'00:00:11.1397724' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (5, N'Root', 3, 2, 1, 1, 0, 0, CAST(N'00:00:00' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (9, N'Wood', 1, 1, 1, 6, 10, 0, CAST(N'00:00:04.9410023' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (14, N'dpeo', 1, 2, 2, 2, 10, 0, CAST(N'00:00:00' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (20, N'R', 2, 1, 2, 9, 40, 0, CAST(N'00:00:07.3406011' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (23, N'Ser', 7, 1, 1, 6, 0, 0, CAST(N'00:00:00' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (24, N'Frof', 8, 2, 1, 1, 0, 0, CAST(N'00:00:00' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (25, N'Eracle', 9, 1, 1, 9, 0, 0, CAST(N'00:00:00' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (28, N'Er', 10, 1, 1, 6, 0, 0, CAST(N'00:00:00' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (29, N'tre', 11, 1, 1, 6, 0, 0, CAST(N'00:00:00' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (30, N'rt', 12, 1, 1, 9, 0, 0, CAST(N'00:00:00' AS Time))
INSERT [dbo].[Eroe] ([ID], [Nome], [GiocatoreID], [ClasseID], [LivelloID], [ArmaID], [PuntiAccumulati], [Vittoria], [TempoDiGioco]) VALUES (31, N'Ro', 5, 2, 1, 1, 0, 0, CAST(N'00:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Eroe] OFF
GO
SET IDENTITY_INSERT [dbo].[Giocatore] ON 

INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (1, N'Aldo', N'Utente')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (2, N'Martina', N'Utente')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (3, N'Sara', N'Utente')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (4, N'Marco', N'Utente')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (5, N'Max', N'Admin')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (6, N'Mastina', N'Utente')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (7, N'Giulia', N'Utente')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (8, N'Mari', N'Utente')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (9, N'Mar', N'Utente')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (10, N'Dario', N'Utente')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (11, N'G', N'Utente')
INSERT [dbo].[Giocatore] ([ID], [Nome], [Ruolo]) VALUES (12, N'g', N'Utente')
SET IDENTITY_INSERT [dbo].[Giocatore] OFF
GO
SET IDENTITY_INSERT [dbo].[Livello] ON 

INSERT [dbo].[Livello] ([ID], [Num], [PuntiVita]) VALUES (1, 1, 20)
INSERT [dbo].[Livello] ([ID], [Num], [PuntiVita]) VALUES (2, 2, 40)
INSERT [dbo].[Livello] ([ID], [Num], [PuntiVita]) VALUES (3, 3, 60)
INSERT [dbo].[Livello] ([ID], [Num], [PuntiVita]) VALUES (4, 4, 80)
INSERT [dbo].[Livello] ([ID], [Num], [PuntiVita]) VALUES (5, 5, 100)
SET IDENTITY_INSERT [dbo].[Livello] OFF
GO
SET IDENTITY_INSERT [dbo].[Mostro] ON 

INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [LivelloID], [ArmaID]) VALUES (1, N'Troll', 3, 2, 4)
INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [LivelloID], [ArmaID]) VALUES (2, N'Voldemort', 4, 1, 5)
INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [LivelloID], [ArmaID]) VALUES (3, N'Tor', 3, 1, 4)
INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [LivelloID], [ArmaID]) VALUES (4, N'Eran', 5, 1, 3)
INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [LivelloID], [ArmaID]) VALUES (5, N'Minotauro', 3, 2, 7)
INSERT [dbo].[Mostro] ([ID], [Nome], [ClasseID], [LivelloID], [ArmaID]) VALUES (6, N'tyu', 5, 4, 4)
SET IDENTITY_INSERT [dbo].[Mostro] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Arma__7D8FE3B262939CEF]    Script Date: 3/19/2021 3:27:58 PM ******/
ALTER TABLE [dbo].[Arma] ADD UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Eroe__7D8FE3B21BA4E81C]    Script Date: 3/19/2021 3:27:58 PM ******/
ALTER TABLE [dbo].[Eroe] ADD UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Mostro__7D8FE3B28CD0AA2A]    Script Date: 3/19/2021 3:27:58 PM ******/
ALTER TABLE [dbo].[Mostro] ADD UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Arma]  WITH CHECK ADD FOREIGN KEY([ClasseID])
REFERENCES [dbo].[Classe] ([ID])
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD FOREIGN KEY([ArmaID])
REFERENCES [dbo].[Arma] ([ID])
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD FOREIGN KEY([ClasseID])
REFERENCES [dbo].[Classe] ([ID])
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD FOREIGN KEY([GiocatoreID])
REFERENCES [dbo].[Giocatore] ([ID])
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD FOREIGN KEY([LivelloID])
REFERENCES [dbo].[Livello] ([ID])
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD FOREIGN KEY([ArmaID])
REFERENCES [dbo].[Arma] ([ID])
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD FOREIGN KEY([ClasseID])
REFERENCES [dbo].[Classe] ([ID])
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD FOREIGN KEY([LivelloID])
REFERENCES [dbo].[Livello] ([ID])
GO
USE [master]
GO
ALTER DATABASE [EroiVSMostri] SET  READ_WRITE 
GO
