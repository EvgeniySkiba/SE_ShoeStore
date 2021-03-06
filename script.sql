USE [master]
GO
/****** Object:  Database [ShoeStore]    Script Date: 12/18/2012 05:04:49 ******/
CREATE DATABASE [ShoeStore] ON  PRIMARY 
( NAME = N'ShoeStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ShoeStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ShoeStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ShoeStore_log.ldf' , SIZE = 4672KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ShoeStore] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShoeStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShoeStore] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ShoeStore] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ShoeStore] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ShoeStore] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ShoeStore] SET ARITHABORT OFF
GO
ALTER DATABASE [ShoeStore] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ShoeStore] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ShoeStore] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ShoeStore] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ShoeStore] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ShoeStore] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ShoeStore] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ShoeStore] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ShoeStore] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ShoeStore] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ShoeStore] SET  DISABLE_BROKER
GO
ALTER DATABASE [ShoeStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ShoeStore] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ShoeStore] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ShoeStore] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ShoeStore] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ShoeStore] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ShoeStore] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ShoeStore] SET  READ_WRITE
GO
ALTER DATABASE [ShoeStore] SET RECOVERY FULL
GO
ALTER DATABASE [ShoeStore] SET  MULTI_USER
GO
ALTER DATABASE [ShoeStore] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ShoeStore] SET DB_CHAINING OFF
GO
USE [ShoeStore]
GO
/****** Object:  Table [dbo].[Receipts]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[DateReceipts] [smalldatetime] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[OrderDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialType]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialType] [nvarchar](255) NULL,
 CONSTRAINT [PK_MaterialType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacture]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacture](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Country] [nvarchar](250) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](400) NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](255) NOT NULL,
	[ImagePrevUrl] [nvarchar](255) NULL,
	[CreationDate] [datetime] NULL,
	[Caption] [nvarchar](255) NULL,
	[IsTitle] [bit] NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DescriptionItem]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescriptionItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Decription] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductDecription] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColorType]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_ColorType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Size]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Size] [int] NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeasonalType]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeasonalType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_SeasonalType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeSex]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeSex](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SexName] [nvarchar](50) NULL,
 CONSTRAINT [PK_TypeSex] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeItem]    Script Date: 12/18/2012 05:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeItem] [nvarchar](255) NULL,
 CONSTRAINT [PK_TypeItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Test]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Test] @description nvarchar (max),
 @ident INT OUTPUT
AS
BEGIN

   insert into DescriptionItem values (@description) 
           --set @result = @@Identity
           set @ident =  @@Identity

END
GO
/****** Object:  Table [dbo].[Storage]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReceipsId] [int] NOT NULL,
	[OrdersId] [int] NOT NULL,
 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddDescriptionForProduct]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddDescriptionForProduct] @description nvarchar (max),
 @ident INT OUTPUT
AS
BEGIN
   insert into DescriptionItem values (@description) 
           set @ident =  @@Identity
END
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturedId] [int] NOT NULL,
	[SizeId] [int] NULL,
	[TypeSexId] [int] NULL,
	[Code] [nvarchar](255) NULL,
	[TypeItemId] [int] NULL,
	[Cost] [money] NULL,
	[Name] [nvarchar](255) NULL,
	[CountItem] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptProduct]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Count] [int] NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_ReceiptProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[ProductId] [int] NOT NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSize]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSize](
	[ProductId] [int] NOT NULL,
	[SizeID] [int] NOT NULL,
	[ProductCount] [int] NULL,
 CONSTRAINT [PK_ProductSize] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[SizeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSeason]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSeason](
	[ProductId] [int] NOT NULL,
	[SeasonId] [int] NOT NULL,
 CONSTRAINT [PK_ProductSeason] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[SeasonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductMaterial]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMaterial](
	[ProductID] [int] NOT NULL,
	[MaterialID] [int] NOT NULL,
 CONSTRAINT [PK_ProductMaterial] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[MaterialID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ProductID] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[ImageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDescription]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDescription](
	[ProductId] [int] NOT NULL,
	[DescriptionId] [int] NOT NULL,
 CONSTRAINT [PK_ProductDescription] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[DescriptionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductColor]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColor](
	[ProductId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
 CONSTRAINT [PK_ProductColor] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[ColorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[ReviewText] [nvarchar](max) NOT NULL,
	[CreationDate] [smalldatetime] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductById]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProductById] 
 @name nvarchar(255)
 ,@Code  nvarchar(255)
 ,@manufactureID int  
 ,@ColorID int 
 ,@MaterialID int
 ,@SizeID int 
 ,@SexID int
 ,@SesonID int
 ,@TypeID int
 ,@Desctiption nvarchar(max)
 ,@Cost decimal
 
 ,@ProductID int
 AS
BEGIN

UPDATE [Product]
   SET [Code] = @Code
      ,[Cost] = @Cost
      ,[Name] = @Name
      --,CountItem = @Count
      ,[TypeSexId] = @SexID
      ,[ManufacturedId] = @manufactureID
 WHERE Product.Id = @ProductID 


UPDATE DescriptionItem
Set Decription = @Desctiption
Where ID in  (
select Top 1 DescriptionID  
from ProductDescription
where ProductID = @ProductID )

UPDATE ProductColor
SET ColorId = @ColorID
WHERE  ProductId = @ProductId

UPDATE ProductMaterial
SET MaterialID = @MaterialID
WHERE  ProductId = @ProductId

---------------------------------------------------------------
/*
--UPDATE ProductSize
--SET SizeID = @SizeID
--WHERE  ProductId = @ProductId
*/

UPDATE ProductSeason
SET SeasonId = @SesonID
WHERE  ProductId = @ProductId


UPDATE ProductType
SET TypeID = @TypeID
WHERE  ProductId = @ProductId

END
GO
/****** Object:  StoredProcedure [dbo].[SetProductsSize]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SetProductsSize] @productId int, @sizeId int, @count int 
AS 
BEGIN

--Select * from ProductSize*/



Declare @countproduct int 

set @countproduct =(
select count(ProductId) 
from ProductSize 
where ProductId = @productid and SizeId = @sizeID )

if(@countproduct >0)
BEGIN


delete
from ProductSize
where ProductId = @productid and SizeId = @sizeID 

END

INSERT INTO [ShoeStore].[dbo].[ProductSize]
           ([ProductId]
           ,[SizeID]
           ,[ProductCount])
     VALUES
           (@productid
           ,@sizeid
           ,@count
           )
 


END 


/*

select * 
from ProductSize
where ProductId = 52  -- and SizeId = @sizeID 

select * 
from Size

*/

/*

select *
from ProductSize
where ProductId = 87 and SizeId = 11 


select * 
from size 

exec SetProductsSize 87 ,11, 5


*/
GO
/****** Object:  StoredProcedure [dbo].[InsertImage]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertImage] 
 @ImageUrl nvarchar(255)
 ,@imagePreviewPath nvarchar(255)
 ,@CreationDate smalldatetime
 ,@Caption nvarchar(255)
 ,@istitle bit
 ,@imageName nvarchar(255)
 ,@productId int 
,@NewImageId INT OUTPUT
	
AS
BEGIN
--	DECLARE @NewImageId INT 
/*
DECLARE @count int
SET @count = 
(SELECT COUNT (Image.ID) 
		FROM ProductImage INNER JOIN Image ON ProductImage.ImageID = Image.ID 
		WHERE ProductImage.ProductId = productId)		
		IF(@count >1)
		BEGIN
		UPDATE  [Image]
   SET [IsTitle] = 0
   WHERE ID in  ( select Image.ID 
		FROM ProductImage INNER JOIN Image ON ProductImage.ImageID = Image.ID 
		WHERE ProductImage.ProductId = productId )
		END 
	*/
	
	Update Image
	Set IsTitle = 0 	
	--select * 
	--from Image 
	where id in 
	
   (select Image.ID 
	FROM ProductImage INNER JOIN Image ON ProductImage.ImageID = Image.ID 
	Where ProductImage.ProductId = @productId 
	 )
	 
INSERT INTO Image(ImageUrl,[ImagePrevUrl],[CreationDate],[Caption],[IsTitle])
     VALUES (@ImageUrl, @imagePreviewPath, @CreationDate, @Caption, 1)     
     SET @NewImageId = @@identity
 
INSERT INTO ProductImage ([ProductID],[ImageId])
     VALUES (@productId,@NewImageId)
END
GO
/****** Object:  StoredProcedure [dbo].[GetRiviewById]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRiviewById]  @productID int 
AS
BEGIN
	SELECT UserName, ReviewText, CreationDate
	  FROM Review
	 WHERE ProductId = @productID
	 ORDER BY ID DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductTitleImage]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductTitleImage] @ProductId int-- , @ImageUrl varchar(255) output
AS 
BEGIN
 SELECT  Top (1 )  Image.ImageUrl
FROM         ProductImage INNER JOIN
                      Image ON ProductImage.ImageId = Image.ID
                      where ProductID = @ProductId AND Image.IsTitle = 1                     
                      END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsSize]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetProductsSize]
AS 
BEGIN
SELECT   Size.ID,  Size.Size
FROM         ProductSize INNER JOIN
                      Size ON ProductSize.SizeID = Size.ID
WHERE     (ProductSize.ProductId = 52)
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsInfoList]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--USE [ShoeStore]
--GO
--/****** Object:  StoredProcedure [dbo].[GetProductsInfoList]    Script Date: 12/17/2012 12:33:31 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

CREATE PROCEDURE [dbo].[GetProductsInfoList] 
AS
BEGIN

SELECT  
		Product.ID
		,Product.Name AS Name
		,Manufacture.Name as Manufacture
		,MaterialType.MaterialType
		,ColorType.ColorName AS Color
	--	,Size.Size
		,TypeSex.SexName
		,TypeItem.TypeItem
		
		
FROM Product 
		 INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID  
		 INNER JOIN   ProductMaterial ON Product.ID = ProductMaterial.ProductID 
		 INNER JOIN  MaterialType On ProductMaterial.MaterialId = MaterialType.ID 
		 INNER JOIN ProductColor ON Product.ID = ProductColor.ProductId 
		 INNER JOIN ColorType ON ColorType.Id = ProductColor.COlorID
		-- INNER JOIN ProductSize ON ProductSize.ProductID = Product.ID
		-- INNER JOIN Size ON ProductSize.SizeID = Size.ID
		 INNER JOIN TypeSex ON Product.TypeSexId = TypeSex.ID  
		 INNER JOIN ProductSeason ON Product.ID = ProductSeason.ProductId  
		 INNER JOIN  SeasonalType ON ProductSeason.SeasonId = SeasonalType.ID
		 INNER JOIN ProductType ON Product.ID = ProductType.ProductId  
		 INNER JOIN  TypeItem ON ProductType.TypeID = TypeItem.ID
	
		
		 --NNER JOIN ProductImage ON Product.ID = ProductImage.ProductId 
		--INNER JOIN Image ON ProductImage.ImageID = Image.ID  And Image.IsTitle = 1 
		 
		--WHERE Product.ID = 4--@param
		 
	 END
		 
		--exec [GetProductsInfoList]
GO
/****** Object:  StoredProcedure [dbo].[GetProductsInfoById]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ----
-- Get product information 
--Do not change the order of the output parameters

CREATE PROCEDURE [dbo].[GetProductsInfoById] @ProductId int
AS
BEGIN

SELECT  
		Product.ID
		,Product.Name AS Name
		,Manufacture.ID as ManufactureID
		,MaterialType.ID AS MaterialId
		,ColorType.ID AS ColorId
	 --   , AS SizeID
		,TypeSex.Id AS SexID
		,SeasonalType.ID AS SeasonID
		,TypeItem.Id AS TypeID
		,Image.ImageUrl as ImageUrl
		,Product.Cost as Price
		,Product.Code as Code
		,DescriptionItem.Decription as DescriptionITem
		--,Product.CountItem as countItem
		
FROM Product 
		 INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID  
		 INNER JOIN   ProductMaterial ON Product.ID = ProductMaterial.ProductID 
		 INNER JOIN  MaterialType On ProductMaterial.MaterialId = MaterialType.ID 
		 INNER JOIN ProductColor ON Product.ID = ProductColor.ProductId 
		 INNER JOIN ColorType ON ColorType.Id = ProductColor.COlorID
	--	Right JOIN ProductSize ON ProductSize.ProductID = Product.ID
	--	 INNER JOIN Size ON ProductSize.SizeID = Size.ID
		 INNER JOIN TypeSex ON Product.TypeSexId = TypeSex.ID  
		 INNER JOIN ProductSeason ON Product.ID = ProductSeason.ProductId  
		 INNER JOIN  SeasonalType ON ProductSeason.SeasonId = SeasonalType.ID
		 INNER JOIN ProductType ON Product.ID = ProductType.ProductId  
		 INNER JOIN  TypeItem ON ProductType.TypeID = TypeItem.ID
		 
		Inner join   ProductDescription ON ProductDescription.ProductId = Product.Id 
		 Inner JOIN  DescriptionItem ON ProductDescription.DescriptionId = DescriptionItem.ID
		
		 Inner JOIN ProductImage ON Product.ID = ProductImage.ProductId 
		 Inner JOIN Image ON ProductImage.ImageID = Image.ID And Image.IsTitle = 1 
		 
		 WHERE Product.ID = 52--@ProductId
		 
		 END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsByType]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductsByType]  @typeId int	
AS
BEGIN

SELECT  
		Product.ID
		,Product.Name AS Name
		,Manufacture.Name as Manufacture
		,MaterialType.MaterialType
		,ColorType.ColorName AS Color
		,Size.Size
		,TypeSex.SexName
		,SeasonalType.Name AS Season
		,TypeItem.TypeItem
		,Image.ImageUrl
		
		
FROM Product 
		 INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID  
		 INNER JOIN   ProductMaterial ON Product.ID = ProductMaterial.ProductID 
		 INNER JOIN  MaterialType On ProductMaterial.MaterialId = MaterialType.ID 
		 INNER JOIN ProductColor ON Product.ID = ProductColor.ProductId 
		 INNER JOIN ColorType ON ColorType.Id = ProductColor.COlorID
		 INNER JOIN ProductSize ON ProductSize.ProductID = Product.ID
		 INNER JOIN Size ON ProductSize.SizeID = Size.ID
		 INNER JOIN TypeSex ON Product.TypeSexId = TypeSex.ID  
		 INNER JOIN ProductSeason ON Product.ID = ProductSeason.ProductId  
		 INNER JOIN  SeasonalType ON ProductSeason.SeasonId = SeasonalType.ID
		 INNER JOIN ProductType ON Product.ID = ProductType.ProductId  
		 INNER JOIN  TypeItem ON ProductType.TypeID = TypeItem.ID
	
		
		 INNER JOIN ProductImage ON Product.ID = ProductImage.ProductId 
		 INNER JOIN Image ON ProductImage.ImageID = Image.ID And Image.IsTitle = 1 
		 
		 WHERE TypeItem.Id = @typeId
		 
		 END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsBySize]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductsBySize]  @Size int, @ProductID int	
AS
BEGIN

SELECT  
		Product.ID
		,Product.Name AS Name
		,Manufacture.Name as Manufacture
		,MaterialType.MaterialType
		,ColorType.ColorName AS Color
		,Size.Size
		,TypeSex.SexName
		,SeasonalType.Name AS Season
		,TypeItem.TypeItem
		,Image.ImageUrl
		
		
FROM Product 
		 INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID  
		 INNER JOIN   ProductMaterial ON Product.ID = ProductMaterial.ProductID 
		 INNER JOIN  MaterialType On ProductMaterial.MaterialId = MaterialType.ID 
		 INNER JOIN ProductColor ON Product.ID = ProductColor.ProductId 
		 INNER JOIN ColorType ON ColorType.Id = ProductColor.COlorID
		 INNER JOIN ProductSize ON ProductSize.ProductID = Product.ID
		 INNER JOIN Size ON ProductSize.SizeID = Size.ID
		 INNER JOIN TypeSex ON Product.TypeSexId = TypeSex.ID  
		 INNER JOIN ProductSeason ON Product.ID = ProductSeason.ProductId  
		 INNER JOIN  SeasonalType ON ProductSeason.SeasonId = SeasonalType.ID
		 INNER JOIN ProductType ON Product.ID = ProductType.ProductId  
		 INNER JOIN  TypeItem ON ProductType.TypeID = TypeItem.ID
	
		
		 INNER JOIN ProductImage ON Product.ID = ProductImage.ProductId 
		 INNER JOIN Image ON ProductImage.ImageID = Image.ID And Image.IsTitle = 1 
		 
		 WHERE Size.Size = @Size 
		 AND  Product.ID = @ProductID
		 
		 END
		 
		 --  exec [GetProductsBySize] 39
GO
/****** Object:  StoredProcedure [dbo].[GetProductsBySex]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductsBySex]  @SexId int	
AS
BEGIN

SELECT  
		Product.ID
		,Product.Name AS Name
		,Manufacture.Name as Manufacture
		,MaterialType.MaterialType
		,ColorType.ColorName AS Color
		,Size.Size
		,TypeSex.SexName
		,SeasonalType.Name AS Season
		,TypeItem.TypeItem
		,Image.ImageUrl
		
FROM Product 
		 INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID  
		 INNER JOIN   ProductMaterial ON Product.ID = ProductMaterial.ProductID 
		 INNER JOIN  MaterialType On ProductMaterial.MaterialId = MaterialType.ID 
		 INNER JOIN ProductColor ON Product.ID = ProductColor.ProductId 
		 INNER JOIN ColorType ON ColorType.Id = ProductColor.COlorID
		 INNER JOIN ProductSize ON ProductSize.ProductID = Product.ID
		 INNER JOIN Size ON ProductSize.SizeID = Size.ID
		 INNER JOIN TypeSex ON Product.TypeSexId = TypeSex.ID  
		 INNER JOIN ProductSeason ON Product.ID = ProductSeason.ProductId  
		 INNER JOIN  SeasonalType ON ProductSeason.SeasonId = SeasonalType.ID
		 INNER JOIN ProductType ON Product.ID = ProductType.ProductId  
		 INNER JOIN  TypeItem ON ProductType.TypeID = TypeItem.ID
	
		
		 INNER JOIN ProductImage ON Product.ID = ProductImage.ProductId 
		 INNER JOIN Image ON ProductImage.ImageID = Image.ID And Image.IsTitle = 1 
		 
		 WHERE TypeSex.Id = @SexId
		 
		 END
GO
/****** Object:  StoredProcedure [dbo].[GetProductCount]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductCount] @ProductId int, @sizeID int 
AS
BEGIN

SELECT   ProductSize.ProductCount   
FROM         ProductSize INNER JOIN
                      Size ON ProductSize.SizeId = Size.ID
                      where ProductSize.ProductId =@ProductId AND Size.ID = @sizeID 

END
GO
/****** Object:  StoredProcedure [dbo].[GetProductByIdFullInfo]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductByIdFullInfo] @ProductId int
AS
BEGIN

SELECT  
		Product.ID
		,Product.Name AS Name
		,Manufacture.Name as Brand
		,TypeItem.TypeItem AS TypeItem --3
		,SeasonalType.Name AS SeasonalType		--4		
		,MaterialType.MaterialType AS Material 	--5
		,ColorType.ColorName AS Color			--6
		,Product.Code as Code 
		,Manufacture.Country AS Country			--8
		
		,Product.Cost as Price
		,Product.Name as Name					--10
		,Image.ImageUrl as ImageUrl
		,DescriptionItem.Decription as DescriptionItem
		--,Size.ID AS SizeID
		--,TypeSex.Id AS SexID
		
	
		
		
	
		
		
		
FROM Product 
		 INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID  
		 INNER JOIN   ProductMaterial ON Product.ID = ProductMaterial.ProductID 
		 INNER JOIN  MaterialType On ProductMaterial.MaterialId = MaterialType.ID 
		 INNER JOIN ProductColor ON Product.ID = ProductColor.ProductId 
		 INNER JOIN ColorType ON ColorType.Id = ProductColor.COlorID
		 INNER JOIN ProductSize ON ProductSize.ProductID = Product.ID
		-- INNER JOIN Size ON ProductSize.SizeID = Size.ID
		 INNER JOIN TypeSex ON Product.TypeSexId = TypeSex.ID  
		 INNER JOIN ProductSeason ON Product.ID = ProductSeason.ProductId  
		 INNER JOIN  SeasonalType ON ProductSeason.SeasonId = SeasonalType.ID
		 INNER JOIN ProductType ON Product.ID = ProductType.ProductId  
		 INNER JOIN  TypeItem ON ProductType.TypeID = TypeItem.ID
		 
		Left join   ProductDescription ON ProductDescription.ProductId = Product.Id 
		 Left JOIN  DescriptionItem ON ProductDescription.DescriptionId = DescriptionItem.ID
		
		 INNER JOIN ProductImage ON Product.ID = ProductImage.ProductId 
		 INNER JOIN Image ON ProductImage.ImageID = Image.ID And Image.IsTitle = 1 
		 
		 WHERE Product.ID = @ProductId
		 
		 END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductsInfoForWoman]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetAllProductsInfoForWoman] 
AS
BEGIN

SELECT  
		Product.ID
		,Product.Name AS Name
		,Manufacture.Name as Manufacture
		,MaterialType.MaterialType
		,ColorType.ColorName AS Color
		,Manufacture.Country
		,TypeSex.SexName
		,SeasonalType.Name AS Season
		,TypeItem.TypeItem
		,Image.ImageUrl
		,Product.Cost as Price
		,Product.Code as Code
		
FROM Product 
		 INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID  
		 INNER JOIN   ProductMaterial ON Product.ID = ProductMaterial.ProductID 
		 INNER JOIN  MaterialType On ProductMaterial.MaterialId = MaterialType.ID 
		 INNER JOIN ProductColor ON Product.ID = ProductColor.ProductId 
		 INNER JOIN ColorType ON ColorType.Id = ProductColor.COlorID
		-- INNER JOIN ProductSize ON ProductSize.ProductID = Product.ID
		 --INNER JOIN Size ON ProductSize.SizeID = Size.ID
		 INNER JOIN TypeSex ON Product.TypeSexId = TypeSex.ID  
		 INNER JOIN ProductSeason ON Product.ID = ProductSeason.ProductId  
		 INNER JOIN  SeasonalType ON ProductSeason.SeasonId = SeasonalType.ID
		 INNER JOIN ProductType ON Product.ID = ProductType.ProductId  
		 INNER JOIN  TypeItem ON ProductType.TypeID = TypeItem.ID
	
		
		 INNER JOIN ProductImage ON Product.ID = ProductImage.ProductId 
		 INNER JOIN Image ON ProductImage.ImageID = Image.ID And Image.IsTitle = 1 
		 
		 WHERE TypeSex.ID = 2
		 
		 END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductsInfoForMan]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProductsInfoForMan] 
AS
BEGIN

SELECT  
		Product.ID
		,Product.Name AS Name
		,Manufacture.Name as Manufacture
		,MaterialType.MaterialType
		,ColorType.ColorName AS Color
		,Manufacture.Country
		,TypeSex.SexName
		,SeasonalType.Name AS Season
		,TypeItem.TypeItem
		,Image.ImageUrl
		,Product.Cost as Price
		,Product.Code as Code
		
FROM Product 
		 INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID  
		 INNER JOIN   ProductMaterial ON Product.ID = ProductMaterial.ProductID 
		 INNER JOIN  MaterialType On ProductMaterial.MaterialId = MaterialType.ID 
		 INNER JOIN ProductColor ON Product.ID = ProductColor.ProductId 
		 INNER JOIN ColorType ON ColorType.Id = ProductColor.COlorID
	    --	INNER JOIN ProductSize ON ProductSize.ProductID = Product.ID
		-- INNER JOIN Size ON ProductSize.SizeID = Size.ID
		 INNER JOIN TypeSex ON Product.TypeSexId = TypeSex.ID  
		 INNER JOIN ProductSeason ON Product.ID = ProductSeason.ProductId  
		 INNER JOIN  SeasonalType ON ProductSeason.SeasonId = SeasonalType.ID
		 INNER JOIN ProductType ON Product.ID = ProductType.ProductId  
		 INNER JOIN  TypeItem ON ProductType.TypeID = TypeItem.ID
	
		
		 Inner JOIN ProductImage ON Product.ID = ProductImage.ProductId 
		 Inner JOIN Image ON ProductImage.ImageID = Image.ID And Image.isTitle = 1
		  
		 
		 WHERE TypeSex.ID = 1 -- man
		 
		 END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductsInfo]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProductsInfo] 
AS
BEGIN

SELECT  
		Product.ID
		,Product.Name AS Name
		,Manufacture.Name as Manufacture
		,MaterialType.MaterialType
		,ColorType.ColorName AS Color
		,Manufacture.Country
		,TypeSex.SexName
		,SeasonalType.Name AS Season
		,TypeItem.TypeItem
		,Image.ImageUrl
		,Product.Cost as Price
		,Product.Code as Code
		
FROM Product 
		 INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID  
		 INNER JOIN   ProductMaterial ON Product.ID = ProductMaterial.ProductID 
		 INNER JOIN  MaterialType On ProductMaterial.MaterialId = MaterialType.ID 
		 INNER JOIN ProductColor ON Product.ID = ProductColor.ProductId 
		 INNER JOIN ColorType ON ColorType.Id = ProductColor.COlorID
		-- INNER JOIN ProductSize ON ProductSize.ProductID = Product.ID
		 --INNER JOIN Size ON ProductSize.SizeID = Size.ID
		 INNER JOIN TypeSex ON Product.TypeSexId = TypeSex.ID  
		 INNER JOIN ProductSeason ON Product.ID = ProductSeason.ProductId  
		 INNER JOIN  SeasonalType ON ProductSeason.SeasonId = SeasonalType.ID
		 INNER JOIN ProductType ON Product.ID = ProductType.ProductId  
		 INNER JOIN  TypeItem ON ProductType.TypeID = TypeItem.ID
	
		
		 INNER JOIN ProductImage ON Product.ID = ProductImage.ProductId 
		 INNER JOIN Image ON ProductImage.ImageID = Image.ID And Image.IsTitle = 1 
		 
		-- WHERE Product.ID = @param
		 
		 END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[GetAllProducts] @Param int
	-- Add the parameters for the stored procedure here
AS
BEGIN

SELECT  
		Product.ID
		,Product.Name AS Name
		,Manufacture.Name as Manufacture
		,MaterialType.MaterialType
		,ColorType.ColorName AS Color
		,Size.Size
		,TypeSex.SexName
		,SeasonalType.Name AS Season
		,TypeItem.TypeItem
FROM Product 
		 INNER JOIN Manufacture ON Product.ManufacturedId = Manufacture.ID  
		 INNER JOIN   ProductMaterial ON Product.ID = ProductMaterial.ProductID 
		 INNER JOIN  MaterialType On ProductMaterial.MaterialId = MaterialType.ID 
		 INNER JOIN ProductColor ON Product.ID = ProductColor.ProductId 
		 INNER JOIN ColorType ON ColorType.Id = ProductColor.COlorID
		 INNER JOIN ProductSize ON ProductSize.ProductID = Product.ID
		 INNER JOIN Size ON ProductSize.SizeID = Size.ID
		 INNER JOIN TypeSex ON Product.TypeSexId = TypeSex.ID  
		 INNER JOIN ProductSeason ON Product.ID = ProductSeason.ProductId  
		 INNER JOIN  SeasonalType ON ProductSeason.SeasonId = SeasonalType.ID
		 INNER JOIN ProductType ON Product.ID = ProductType.ProductId  
		 INNER JOIN  TypeItem ON ProductType.TypeID = TypeItem.ID
		 
		-- WHERE Product.ID = @param

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSizeFromProduct]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteSizeFromProduct] @productId int 
AS 
BEGIN

--select * 
delete
from ProductSize 
where ProductId = @productid


END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductsImage]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProductsImage] @ProductId int 
AS 
BEGIN 
	DELETE
	  FROM ProductImage 
    	WHERE ProductId = ProductId

DELETE  FROM Image  
	WHERE Id IN (SELECT ImageId
				   FROM ProductImage 
				  WHERE ProductId = @ProductId ) 
END
GO
/****** Object:  StoredProcedure [dbo].[deleteProduct]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteProduct] @Id int 
--declare @Id int 
 --set @Id =  4 
 AS
 BEGIN 
 
  --select * 
delete
 from ProductType
WHERE  ProductId = @Id
 
-- select * 
delete
 From ProductSeason
WHERE  ProductId = @Id
 
-- select * 
delete
 From  ProductSize
WHERE  ProductId = @Id

-- Select * 
delete 
 From   ProductMaterial
WHERE  ProductId = @Id


-- select * 
delete
 From  ProductColor
WHERE  ProductId = @Id 

--SELECT * 
delete
FROM ProductDescription 
WHERE ProductId =@Id
 

 
 --select * 
 delete
 from Review
 where ProductId =  @Id 
 
 --select * 
 delete
 from ProductImage 
 where ProductId = @Id 

 --select *
 delete 
 from Product 
 where Id = @Id
 end
---------------------------------------------------------------
--SELECT * FROM ProductSize  where ProductId =@Id


--exec deleteProduct 40


--select * 
--from Product
GO
/****** Object:  StoredProcedure [dbo].[DeleteImage]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteImage] @ImageId INT
AS 
BEGIN 


DELETE
FROM Image
WHERE ID = @ImageId

DELETE
FROM  ProductImage
WHERE ImageId = @ImageId
END
GO
/****** Object:  StoredProcedure [dbo].[CreateReview]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateReview] @userName nvarchar(255),@Text nvarChar(max), @productID int 
AS
BEGIN
INSERT INTO [ShoeStore].[dbo].[Review]
           ([UserName]
           ,[ReviewText]
           ,[CreationDate]
           ,ProductId)
     VALUES(@UserName
           ,@Text
           ,GetDate()
           ,@productID
           )
END
GO
/****** Object:  StoredProcedure [dbo].[CreateProduct]    Script Date: 12/18/2012 05:05:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateProduct] @Name nvarchar(255), @ColorId int, @SizeId int, @SexId int, @MaterialTypeID int,
 @ManufactureID int,@SeasonId int, @typeID int, @cost money,@DescriptionText nvarchar(max), @Code nvarChar(255), @NewProductId int output
AS
BEGIN 

--declare @NewProductId  int 
declare @DestriptionID int 

---------------------------
INSERT INTO [Product]([ManufacturedId],TypeSexId, Code,Cost,Name )
VALUES (@ManufactureID,@SexId,@Code,@cost,@Name )

SET @NewProductId =  @@Identity
--SET @NewId = @NewProductId

INSERT INTO ProductColor VALUES (@NewProductId,@ColorId)

INSERT INTO ProductSize(ProductID,SizeId) VALUES (@NewProductId,@SizeId)

INSERT INTO ProductType Values (@NewProductId,@typeID)

INSERT INTO ProductMaterial Values (@NewProductId,@MaterialTypeID)

INSERT INTO ProductSeason Values (@NewProductId,@SeasonId)

INSERT INTO DescriptionItem values (@DescriptionText) 
SET @DestriptionID =  @@Identity

INSERT INTO productdescription VALUES (@NewProductId,@DestriptionID)

 
END
GO
/****** Object:  Default [DF_ReceiptProduct_Date]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ReceiptProduct] ADD  CONSTRAINT [DF_ReceiptProduct_Date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  ForeignKey [FK_Storage_Orders]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_Orders] FOREIGN KEY([OrdersId])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_Orders]
GO
/****** Object:  ForeignKey [FK_Storage_Receipts]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_Receipts] FOREIGN KEY([ReceipsId])
REFERENCES [dbo].[Receipts] ([ID])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_Receipts]
GO
/****** Object:  ForeignKey [FK_Product_Manufacturer]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer] FOREIGN KEY([ManufacturedId])
REFERENCES [dbo].[Manufacture] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Manufacturer]
GO
/****** Object:  ForeignKey [FK_Product_TypeSex]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_TypeSex] FOREIGN KEY([TypeSexId])
REFERENCES [dbo].[TypeSex] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_TypeSex]
GO
/****** Object:  ForeignKey [FK_ReceiptProduct_ReceiptProduct]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ReceiptProduct]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptProduct_ReceiptProduct] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ReceiptProduct] CHECK CONSTRAINT [FK_ReceiptProduct_ReceiptProduct]
GO
/****** Object:  ForeignKey [FK_ProductType_Product]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductType]  WITH CHECK ADD  CONSTRAINT [FK_ProductType_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductType] CHECK CONSTRAINT [FK_ProductType_Product]
GO
/****** Object:  ForeignKey [FK_ProductType_TypeItem]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductType]  WITH CHECK ADD  CONSTRAINT [FK_ProductType_TypeItem] FOREIGN KEY([TypeID])
REFERENCES [dbo].[TypeItem] ([ID])
GO
ALTER TABLE [dbo].[ProductType] CHECK CONSTRAINT [FK_ProductType_TypeItem]
GO
/****** Object:  ForeignKey [FK_ProductSize_Product]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductSize]  WITH CHECK ADD  CONSTRAINT [FK_ProductSize_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductSize] CHECK CONSTRAINT [FK_ProductSize_Product]
GO
/****** Object:  ForeignKey [FK_ProductSize_Size]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductSize]  WITH CHECK ADD  CONSTRAINT [FK_ProductSize_Size] FOREIGN KEY([SizeID])
REFERENCES [dbo].[Size] ([ID])
GO
ALTER TABLE [dbo].[ProductSize] CHECK CONSTRAINT [FK_ProductSize_Size]
GO
/****** Object:  ForeignKey [FK_ProductSeason_Product]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductSeason]  WITH CHECK ADD  CONSTRAINT [FK_ProductSeason_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductSeason] CHECK CONSTRAINT [FK_ProductSeason_Product]
GO
/****** Object:  ForeignKey [FK_ProductSeason_SeasonalType]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductSeason]  WITH CHECK ADD  CONSTRAINT [FK_ProductSeason_SeasonalType] FOREIGN KEY([SeasonId])
REFERENCES [dbo].[SeasonalType] ([ID])
GO
ALTER TABLE [dbo].[ProductSeason] CHECK CONSTRAINT [FK_ProductSeason_SeasonalType]
GO
/****** Object:  ForeignKey [FK_ProductMaterial_MaterialType]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductMaterial]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaterial_MaterialType] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[MaterialType] ([ID])
GO
ALTER TABLE [dbo].[ProductMaterial] CHECK CONSTRAINT [FK_ProductMaterial_MaterialType]
GO
/****** Object:  ForeignKey [FK_ProductMaterial_Product]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductMaterial]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaterial_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductMaterial] CHECK CONSTRAINT [FK_ProductMaterial_Product]
GO
/****** Object:  ForeignKey [FK_ProductImage_Image]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Image] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([ID])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Image]
GO
/****** Object:  ForeignKey [FK_ProductImage_Product]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product]
GO
/****** Object:  ForeignKey [FK_ProductDescription_ProductDescription]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductDescription]  WITH CHECK ADD  CONSTRAINT [FK_ProductDescription_ProductDescription] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductDescription] CHECK CONSTRAINT [FK_ProductDescription_ProductDescription]
GO
/****** Object:  ForeignKey [FK_ProductDescription_ProductDescription1]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductDescription]  WITH CHECK ADD  CONSTRAINT [FK_ProductDescription_ProductDescription1] FOREIGN KEY([DescriptionId])
REFERENCES [dbo].[DescriptionItem] ([ID])
GO
ALTER TABLE [dbo].[ProductDescription] CHECK CONSTRAINT [FK_ProductDescription_ProductDescription1]
GO
/****** Object:  ForeignKey [FK_ProductColor_ColorType]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductColor]  WITH CHECK ADD  CONSTRAINT [FK_ProductColor_ColorType] FOREIGN KEY([ColorId])
REFERENCES [dbo].[ColorType] ([ID])
GO
ALTER TABLE [dbo].[ProductColor] CHECK CONSTRAINT [FK_ProductColor_ColorType]
GO
/****** Object:  ForeignKey [FK_ProductColor_Product]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[ProductColor]  WITH CHECK ADD  CONSTRAINT [FK_ProductColor_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductColor] CHECK CONSTRAINT [FK_ProductColor_Product]
GO
/****** Object:  ForeignKey [FK_Review_Product]    Script Date: 12/18/2012 05:05:00 ******/
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Product]
GO
