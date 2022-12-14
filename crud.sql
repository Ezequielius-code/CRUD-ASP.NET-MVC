USE [master]
GO
/****** Object:  Database [CRUDWebNetCore]    Script Date: 26/8/2022 19:33:57 ******/
CREATE DATABASE [CRUDWebNetCore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRUDWebNetCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CRUDWebNetCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CRUDWebNetCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CRUDWebNetCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CRUDWebNetCore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRUDWebNetCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRUDWebNetCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRUDWebNetCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRUDWebNetCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CRUDWebNetCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRUDWebNetCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET RECOVERY FULL 
GO
ALTER DATABASE [CRUDWebNetCore] SET  MULTI_USER 
GO
ALTER DATABASE [CRUDWebNetCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRUDWebNetCore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRUDWebNetCore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRUDWebNetCore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRUDWebNetCore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CRUDWebNetCore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CRUDWebNetCore', N'ON'
GO
ALTER DATABASE [CRUDWebNetCore] SET QUERY_STORE = OFF
GO
USE [CRUDWebNetCore]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 26/8/2022 19:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[poblacion] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Editar]    Script Date: 26/8/2022 19:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Editar](
@id int,
@nombre nvarchar(50),
@direccion nvarchar(50),
@poblacion nvarchar(50),
@telefono nvarchar(50))
as
begin
	update Clientes set nombre = @nombre, direccion = @direccion, poblacion = @poblacion, telefono = @telefono where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[Eliminar]    Script Date: 26/8/2022 19:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Eliminar](@id int)
as
begin
	delete from Clientes where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[GetCliente]    Script Date: 26/8/2022 19:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetCliente](@id int)
as
begin
	select * from Clientes where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[Guardar]    Script Date: 26/8/2022 19:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Guardar](
@nombre nvarchar(50),
@direccion nvarchar(50),
@poblacion nvarchar(50),
@telefono nvarchar(50))
as
begin
	insert into Clientes(nombre,direccion,poblacion,telefono) values (@nombre,@direccion,@poblacion,@telefono)
end
GO
/****** Object:  StoredProcedure [dbo].[Listar]    Script Date: 26/8/2022 19:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Listar]
as
begin
	select * from Clientes
end
GO
USE [master]
GO
ALTER DATABASE [CRUDWebNetCore] SET  READ_WRITE 
GO
