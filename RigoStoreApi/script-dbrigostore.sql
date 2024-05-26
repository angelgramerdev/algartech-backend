USE [master]
GO
/****** Object:  Database [dbrigostore]    Script Date: 26/05/2024 5:05:58 p. m. ******/
CREATE DATABASE [dbrigostore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbrigostore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbrigostore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbrigostore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbrigostore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbrigostore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbrigostore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbrigostore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbrigostore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbrigostore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbrigostore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbrigostore] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbrigostore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbrigostore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbrigostore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbrigostore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbrigostore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbrigostore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbrigostore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbrigostore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbrigostore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbrigostore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbrigostore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbrigostore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbrigostore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbrigostore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbrigostore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbrigostore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbrigostore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbrigostore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbrigostore] SET  MULTI_USER 
GO
ALTER DATABASE [dbrigostore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbrigostore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbrigostore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbrigostore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbrigostore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbrigostore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbrigostore] SET QUERY_STORE = OFF
GO
USE [dbrigostore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/05/2024 5:05:58 p. m. ******/
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
/****** Object:  Table [dbo].[orderproducts]    Script Date: 26/05/2024 5:05:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderproducts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[orderid] [int] NOT NULL,
	[productid] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 26/05/2024 5:05:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identification] [varchar](50) NOT NULL,
	[DeliveryAddress] [varchar](200) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 26/05/2024 5:05:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NOT NULL,
	[reference] [varchar](50) NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_products_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_OrderId]    Script Date: 26/05/2024 5:05:58 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Products_OrderId] ON [dbo].[orderproducts]
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[orderproducts]  WITH CHECK ADD  CONSTRAINT [FK_orderproducts_products] FOREIGN KEY([productid])
REFERENCES [dbo].[products] ([id])
GO
ALTER TABLE [dbo].[orderproducts] CHECK CONSTRAINT [FK_orderproducts_products]
GO
ALTER TABLE [dbo].[orderproducts]  WITH CHECK ADD  CONSTRAINT [FK_Products_Orders_OrderId] FOREIGN KEY([orderid])
REFERENCES [dbo].[orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orderproducts] CHECK CONSTRAINT [FK_Products_Orders_OrderId]
GO
/****** Object:  StoredProcedure [dbo].[calculate_total_order]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[calculate_total_order]
	-- Add the parameters for the stored procedure here
@orderid int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT sum(price) total from dbo.orderproducts where orderid=@orderid
END
GO
/****** Object:  StoredProcedure [dbo].[create_order]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_order] 
	-- Add the parameters for the stored procedure here
@identification nvarchar(50)=NULL,
@deliveryaddress nvarchar(200)=NULL,
@name nvarchar(200)=NULL,
@creationdate DateTime=NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @dni nvarchar(50),@deliveraddress nvarchar(200),@n nvarchar(200), @cdate DateTime

	set @dni=@identification
	set @deliveraddress=@deliveryaddress
	set @n=@name
	set @cdate=@creationdate

   Insert into dbo.Orders (Identification,DeliveryAddress,[Name],CreationDate) values(@dni, @deliveraddress, @n, @cdate)

END
GO
/****** Object:  StoredProcedure [dbo].[create_order_product]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_order_product] 
	-- Add the parameters for the stored procedure here

@name varchar(200),
@price decimal(10,2),
@orderid int,
@productid int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into dbo.orderproducts values(@name, @price, @orderid, @productid)
END
GO
/****** Object:  StoredProcedure [dbo].[create_product]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[create_product] 
	-- Add the parameters for the stored procedure here
@name varchar(200),
@reference varchar(50),
@price decimal(10,2)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into dbo.products values(@name, @reference,@price)
END
GO
/****** Object:  StoredProcedure [dbo].[delete_order]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[delete_order] 
	-- Add the parameters for the stored procedure here
@id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from dbo.orderproducts where orderid=@id
	delete from dbo.orders where Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[edit_order]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[edit_order] 
	-- Add the parameters for the stored procedure here
@id int,
@identification varchar(50),
@deliveryaddress varchar(200),
@name varchar(200)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update orders set Identification=@identification,  DeliveryAddress=@deliveryaddress, [Name]=@name where Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[get_order]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_order] 
	-- Add the parameters for the stored procedure here

@id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.orders where Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[get_order_products]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_order_products] 
	-- Add the parameters for the stored procedure here
@orderid int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT productid, [name], price from dbo.orderproducts where orderid=@orderid
END
GO
/****** Object:  StoredProcedure [dbo].[get_orders]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_orders] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.Orders
END
GO
/****** Object:  StoredProcedure [dbo].[get_product]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_product] 
	-- Add the parameters for the stored procedure here

@id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT price,[name] from dbo.products where id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[get_products]    Script Date: 26/05/2024 5:05:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[get_products] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.Products
END
GO
USE [master]
GO
ALTER DATABASE [dbrigostore] SET  READ_WRITE 
GO
