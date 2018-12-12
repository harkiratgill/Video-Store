USE [master]
GO
/****** Object:  Database [RENT]    Script Date: 12/12/2018 2:11:49 PM ******/
CREATE DATABASE [RENT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RENT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RENT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RENT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RENT.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RENT] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RENT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RENT] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [RENT] SET ANSI_NULLS ON 
GO
ALTER DATABASE [RENT] SET ANSI_PADDING ON 
GO
ALTER DATABASE [RENT] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [RENT] SET ARITHABORT ON 
GO
ALTER DATABASE [RENT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RENT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RENT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RENT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RENT] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [RENT] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [RENT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RENT] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [RENT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RENT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RENT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RENT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RENT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RENT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RENT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RENT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RENT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RENT] SET RECOVERY FULL 
GO
ALTER DATABASE [RENT] SET  MULTI_USER 
GO
ALTER DATABASE [RENT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RENT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RENT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RENT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RENT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RENT] SET QUERY_STORE = OFF
GO
USE [RENT]
GO
/****** Object:  Table [dbo].[Coustmer]    Script Date: 12/12/2018 2:11:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coustmer](
	[CustID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](10) NULL,
	[LastName] [nchar](10) NULL,
	[Address] [nchar](20) NULL,
	[Phone] [nchar](12) NULL,
 CONSTRAINT [PK_Coustmer] PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 12/12/2018 2:11:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MoviedID] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [nchar](3) NULL,
	[Title] [nchar](10) NULL,
	[Year] [nchar](5) NULL,
	[Rental_Cost] [money] NULL,
	[Plot] [ntext] NULL,
	[Genre] [nchar](5) NULL,
	[copies] [int] NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MoviedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentedMovies]    Script Date: 12/12/2018 2:11:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentedMovies](
	[RMID] [int] IDENTITY(1,1) NOT NULL,
	[MovieIDFK] [int] NULL,
	[CustIDFK] [int] NULL,
	[DateRented] [datetime] NULL,
	[DateReturned] [datetime] NULL,
	[isout] [int] NOT NULL,
 CONSTRAINT [PK_RentedMovies] PRIMARY KEY CLUSTERED 
(
	[RMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userdata]    Script Date: 12/12/2018 2:11:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userdata](
	[UserName] [varchar](20) NULL,
	[Password] [varchar](20) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Coustmer] ON 

INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (2004, N'jean      ', N'gill      ', N'sjhd                ', N'dscds       ')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (2005, N'hdjd      ', N'sdfsdfsd  ', N'sdfsdfdsf           ', N'sad         ')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (2006, N'asd       ', N'asdaas    ', N'asd                 ', N'asd         ')
SET IDENTITY_INSERT [dbo].[Coustmer] OFF
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MoviedID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (1, N'6  ', N'ghf       ', N'678  ', 567.0000, N'fgh', N'gtj  ', 4)
INSERT [dbo].[Movies] ([MoviedID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (2, N'6  ', N'sdfghjkl  ', N'678  ', 2.0000, N'bkj', N'gtj  ', 9)
INSERT [dbo].[Movies] ([MoviedID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (3, N'2  ', N'jumangi   ', N'1998 ', 2.0000, N'sdsd', N'basic', 29)
INSERT [dbo].[Movies] ([MoviedID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (4, N'3  ', N'hhh       ', N'2913 ', 5.0000, N'net', N'bad  ', 64)
INSERT [dbo].[Movies] ([MoviedID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (5, N'w  ', N'gill      ', N'1991 ', 2.0000, N'sd', N'bad  ', 0)
SET IDENTITY_INSERT [dbo].[Movies] OFF
SET IDENTITY_INSERT [dbo].[RentedMovies] ON 

INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (1, 3, 2004, CAST(N'2018-11-12T00:00:00.000' AS DateTime), CAST(N'2018-12-12T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (2, 2, 1002, CAST(N'2018-11-12T00:00:00.000' AS DateTime), CAST(N'2018-12-12T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (3, 4, 1002, CAST(N'2018-11-12T00:00:00.000' AS DateTime), CAST(N'2018-12-12T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (4, 3, 1002, CAST(N'2018-11-12T00:00:00.000' AS DateTime), CAST(N'2018-12-12T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (5, 4, 2004, CAST(N'2018-12-12T00:00:00.000' AS DateTime), CAST(N'2018-12-12T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (6, 4, 2004, CAST(N'2018-12-12T00:00:00.000' AS DateTime), CAST(N'2018-12-12T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (7, 5, 2004, CAST(N'2018-12-12T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (8, 4, 2006, CAST(N'2018-12-12T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (9, 5, 2006, CAST(N'2018-12-12T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (10, 2, 2005, CAST(N'2018-12-12T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (11, 3, 2006, CAST(N'2018-12-12T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (12, 3, 2006, CAST(N'2018-12-12T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (13, 3, 2006, CAST(N'2018-12-12T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (14, 3, 2006, CAST(N'2018-12-12T00:00:00.000' AS DateTime), NULL, 0)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (15, 2, 2006, CAST(N'2018-12-12T00:00:00.000' AS DateTime), CAST(N'2018-12-12T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[RentedMovies] OFF
INSERT [dbo].[userdata] ([UserName], [Password]) VALUES (N'username_txt.Text', N'password_txt.Text')
INSERT [dbo].[userdata] ([UserName], [Password]) VALUES (N'username_txt.Text', N'password_txt.Text')
INSERT [dbo].[userdata] ([UserName], [Password]) VALUES (N'username_txt.Text', N'password_txt.Text')
INSERT [dbo].[userdata] ([UserName], [Password]) VALUES (N'121', N'121')
INSERT [dbo].[userdata] ([UserName], [Password]) VALUES (N'gill', N'123456')
INSERT [dbo].[userdata] ([UserName], [Password]) VALUES (N'gill', N'123456')
ALTER TABLE [dbo].[RentedMovies] ADD  CONSTRAINT [DF_RentedMovies_isout]  DEFAULT ((0)) FOR [isout]
GO
ALTER TABLE [dbo].[RentedMovies]  WITH CHECK ADD  CONSTRAINT [FK_RentedMovies_Coustmer] FOREIGN KEY([MovieIDFK])
REFERENCES [dbo].[Movies] ([MoviedID])
GO
ALTER TABLE [dbo].[RentedMovies] CHECK CONSTRAINT [FK_RentedMovies_Coustmer]
GO
ALTER TABLE [dbo].[RentedMovies]  WITH CHECK ADD  CONSTRAINT [FK_RentedMovies_RentedMovies] FOREIGN KEY([RMID])
REFERENCES [dbo].[RentedMovies] ([RMID])
GO
ALTER TABLE [dbo].[RentedMovies] CHECK CONSTRAINT [FK_RentedMovies_RentedMovies]
GO
USE [master]
GO
ALTER DATABASE [RENT] SET  READ_WRITE 
GO
