USE [master]
GO
/****** Object:  Database [fireLearn]    Script Date: 29.12.2019 22:05:23 ******/
CREATE DATABASE [fireLearn]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'fireLearn', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\fireLearn.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'fireLearn_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\fireLearn_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [fireLearn] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [fireLearn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [fireLearn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [fireLearn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [fireLearn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [fireLearn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [fireLearn] SET ARITHABORT OFF 
GO
ALTER DATABASE [fireLearn] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [fireLearn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [fireLearn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [fireLearn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [fireLearn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [fireLearn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [fireLearn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [fireLearn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [fireLearn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [fireLearn] SET  DISABLE_BROKER 
GO
ALTER DATABASE [fireLearn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [fireLearn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [fireLearn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [fireLearn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [fireLearn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [fireLearn] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [fireLearn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [fireLearn] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [fireLearn] SET  MULTI_USER 
GO
ALTER DATABASE [fireLearn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [fireLearn] SET DB_CHAINING OFF 
GO
ALTER DATABASE [fireLearn] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [fireLearn] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [fireLearn] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [fireLearn] SET QUERY_STORE = OFF
GO
USE [fireLearn]
GO
/****** Object:  Table [dbo].[tblKelime]    Script Date: 29.12.2019 22:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKelime](
	[kelimeID] [int] IDENTITY(1,1) NOT NULL,
	[kelimeTR] [nvarchar](50) NULL,
	[kelimeING] [nvarchar](50) NULL,
	[kelimeTuru] [nvarchar](50) NULL,
	[kelimeDerece] [int] NULL,
	[kelimevideo] [varchar](100) NULL,
 CONSTRAINT [PK_tblKelime] PRIMARY KEY CLUSTERED 
(
	[kelimeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKurs]    Script Date: 29.12.2019 22:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKurs](
	[kursID] [int] IDENTITY(1,1) NOT NULL,
	[kursAdi] [nvarchar](50) NULL,
	[kursDerece] [int] NULL,
 CONSTRAINT [PK_tblKurs] PRIMARY KEY CLUSTERED 
(
	[kursID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTamamlanan]    Script Date: 29.12.2019 22:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTamamlanan](
	[tamamlanankursID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NULL,
	[kursID] [int] NULL,
 CONSTRAINT [PK_tblTamamlanan] PRIMARY KEY CLUSTERED 
(
	[tamamlanankursID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 29.12.2019 22:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblKelime]  WITH CHECK ADD  CONSTRAINT [FK_tblKelime_tblKurs] FOREIGN KEY([kelimeDerece])
REFERENCES [dbo].[tblKurs] ([kursID])
GO
ALTER TABLE [dbo].[tblKelime] CHECK CONSTRAINT [FK_tblKelime_tblKurs]
GO
ALTER TABLE [dbo].[tblTamamlanan]  WITH CHECK ADD  CONSTRAINT [FK_tblTamamlanan_tblKurs] FOREIGN KEY([kursID])
REFERENCES [dbo].[tblKurs] ([kursID])
GO
ALTER TABLE [dbo].[tblTamamlanan] CHECK CONSTRAINT [FK_tblTamamlanan_tblKurs]
GO
ALTER TABLE [dbo].[tblTamamlanan]  WITH CHECK ADD  CONSTRAINT [FK_tblTamamlanan_tblUsers] FOREIGN KEY([userID])
REFERENCES [dbo].[tblUsers] ([userId])
GO
ALTER TABLE [dbo].[tblTamamlanan] CHECK CONSTRAINT [FK_tblTamamlanan_tblUsers]
GO
USE [master]
GO
ALTER DATABASE [fireLearn] SET  READ_WRITE 
GO
