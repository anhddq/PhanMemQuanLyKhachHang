USE [master]
GO
/****** Object:  Database [QLKH]    Script Date: 6/30/2017 12:39:48 AM ******/
CREATE DATABASE [QLKH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLKH', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLKH.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLKH_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLKH_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLKH] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKH] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKH] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLKH] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLKH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKH] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLKH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKH] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLKH] SET  MULTI_USER 
GO
ALTER DATABASE [QLKH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKH] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKH] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLKH]
GO
/****** Object:  StoredProcedure [dbo].[sp_ChucVu_Delete]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ChucVu_Delete]
	@id int
AS
	BEGIN
		DELETE FROM ChucVu WHERE id = @id
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_ChucVu_getByTop]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ChucVu_getByTop]
@Top nvarchar(10),
@Where nvarchar(MAX),
@Order nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop=' ('+ @Top +') '
	if len(@Top)=0
		BEGIN
			Select @strTop=' 100 percent '
		END
	Select @SQL= 'SELECT top '+ @strTop +' * FROM [ChucVu] '
	if len(@Where)>0
		BEGIN
			Select @SQL= @SQL + ' Where ' + @Where
		END
	if len(@Order)>0
		BEGIN
			Select @SQL=@SQL +' Order by '+@Order
		END
	EXEC(@SQL)




GO
/****** Object:  StoredProcedure [dbo].[sp_ChucVu_Insert]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ChucVu_Insert]
	@name nvarchar(50)
AS
	BEGIN
		INSERT INTO ChucVu VALUES (@name,'')
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_ChucVu_Update]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ChucVu_Update]
	@id int,
	@name nvarchar(50)
AS
	BEGIN
		UPDATE ChucVu SET
		Name = @name
	WHERE id = @id
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHang_Delete]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KhachHang_Delete]
	@id int
AS
	BEGIN
		DELETE FROM KhachHang WHERE id = @id
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHang_getByTop]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_KhachHang_getByTop]
@Top nvarchar(10),
@Where nvarchar(MAX),
@Order nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop=' ('+ @Top +') '
	if len(@Top)=0
		BEGIN
			Select @strTop=' 100 percent '
		END
	Select @SQL= 'SELECT top '+ @strTop +' * FROM [KhachHang] '
	if len(@Where)>0
		BEGIN
			Select @SQL= @SQL + ' Where ' + @Where
		END
	if len(@Order)>0
		BEGIN
			Select @SQL=@SQL +' Order by '+@Order
		END
	EXEC(@SQL)




GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHang_Insert]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KhachHang_Insert]
	@name nvarchar(50),
	@address nvarchar(500) = null,
	@phone varchar(50) = null,
	@email varchar(50) = null
AS
	BEGIN
		INSERT INTO KhachHang VALUES (@name,@address,@phone,@email,'')
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHang_Update]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KhachHang_Update]
	@id int,
	@name nvarchar(50),
	@address nvarchar(500),
	@phone varchar(50),
	@email varchar(50)
AS
	BEGIN
		UPDATE KhachHang SET
		Name = @name,
		address = @address,
		Phone = @phone,
		Email = @email
	WHERE id = @id
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVien_Delete]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_NhanVien_Delete]
	@id int
AS
	BEGIN
		DELETE FROM NhanVien WHERE id = @id
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVien_getByTop]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_NhanVien_getByTop]
@Top nvarchar(10),
@Where nvarchar(MAX),
@Order nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop=' ('+ @Top +') '
	if len(@Top)=0
		BEGIN
			Select @strTop=' 100 percent '
		END
	Select @SQL= 'SELECT top '+ @strTop +' * FROM [ViewNhanVien] '
	if len(@Where)>0
		BEGIN
			Select @SQL= @SQL + ' Where ' + @Where
		END
	if len(@Order)>0
		BEGIN
			Select @SQL=@SQL +' Order by '+@Order
		END
	EXEC(@SQL)




GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVien_Insert]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_NhanVien_Insert]
	@name nvarchar(50),
	@address nvarchar(100) = null,
	@phone varchar(50) = null,
	@machucvu int = null
AS
	BEGIN
		INSERT INTO NhanVien VALUES (@name,@address,@phone,@machucvu,'')
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVien_Update]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_NhanVien_Update]
	@id int,
	@name nvarchar(50),
	@address nvarchar(100) = null,
	@phone varchar(50) = null,
	@machucvu int = null
AS
	BEGIN
		UPDATE NhanVien SET
		Name = @name,
		Address = @address,
		Phone = @phone,
		MaChucVu = @machucvu
	WHERE id = @id
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuHen_Delete]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhieuHen_Delete]
	@maphieuhen int
AS
	BEGIN
		DELETE FROM PhieuHen WHERE MaPhieuHen = @maphieuhen
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuHen_getByTop]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_PhieuHen_getByTop]
@Top nvarchar(10),
@Where nvarchar(MAX),
@Order nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop=' ('+ @Top +') '
	if len(@Top)=0
		BEGIN
			Select @strTop=' 100 percent '
		END
	Select @SQL= 'SELECT top '+ @strTop +' * FROM [ViewPhieuHen] '
	if len(@Where)>0
		BEGIN
			Select @SQL= @SQL + ' Where ' + @Where
		END
	if len(@Order)>0
		BEGIN
			Select @SQL=@SQL +' Order by '+@Order
		END
	EXEC(@SQL)




GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuHen_Insert]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhieuHen_Insert]
	@maphieuyc int,
	@pagiaiquyet nvarchar(max) = null,
	@thoigianhen datetime = null,
	@douutien int = null,
	@tinhtrang bit = null,
	@manv int = null
AS
	BEGIN
		INSERT INTO PhieuHen VALUES (@maphieuyc,@pagiaiquyet,@thoigianhen,@douutien,@tinhtrang,@manv)
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuHen_Update]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhieuHen_Update]
	@maphieuhen int,
	@maphieuyc int,
	@pagiaiquyet nvarchar(max),
	@thoigianhen datetime,
	@douutien int,
	@tinhtrang bit,
	@manv int
AS
	BEGIN
		UPDATE PhieuHen SET
		MaPhieuYC = @maphieuyc,
		PAGiaiQuyet = @pagiaiquyet,
		ThoiGianHen = @thoigianhen,
		DoUuTien = @douutien,
		TinhTrang = @tinhtrang,
		MaNV = @manv
	WHERE MaPhieuHen = @maphieuhen
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuYeuCau_Delete]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhieuYeuCau_Delete]
	@maphieuyc int
AS
	BEGIN
		DELETE FROM PhieuYeuCau WHERE MaPhieuYC = @maphieuyc
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuYeuCau_getByTop]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_PhieuYeuCau_getByTop]
@Top nvarchar(10),
@Where nvarchar(MAX),
@Order nvarchar(200)
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop=' ('+ @Top +') '
	if len(@Top)=0
		BEGIN
			Select @strTop=' 100 percent '
		END
	Select @SQL= 'SELECT top '+ @strTop +' * FROM [ViewPhieuYeuCau] '
	if len(@Where)>0
		BEGIN
			Select @SQL= @SQL + ' Where ' + @Where
		END
	if len(@Order)>0
		BEGIN
			Select @SQL=@SQL +' Order by '+@Order
		END
	EXEC(@SQL)




GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuYeuCau_Insert]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhieuYeuCau_Insert]
	@makhachhang int,
	@yeucau nvarchar(max) = null,
	@tgnhan datetime = null,
	@manv int = null
AS
	BEGIN
		INSERT INTO PhieuYeuCau VALUES (@makhachhang,@yeucau,@tgnhan,@manv)
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuYeuCau_Update]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhieuYeuCau_Update]
	@maphieuyc int,
	@makhachhang int,
	@yeucau nvarchar(max) = null,
	@tgnhan datetime = null,
	@manv int = null
AS
	BEGIN
		UPDATE PhieuYeuCau SET
		MaKhachHang = @makhachhang,
		YeuCau = @yeucau,
		TGNhan = @tgnhan,
		MaNhanVien = @manv
	WHERE MaPhieuYC = @maphieuyc
	END


GO
/****** Object:  StoredProcedure [dbo].[sp_TaiKhoan_Delete]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TaiKhoan_Delete]
	@username varchar(50)
AS
	BEGIN
		DELETE FROM TaiKhoan WHERE Username = @username
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_TaiKhoan_getByTop]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_TaiKhoan_getByTop]
@Top nvarchar(10) = '',
@Where nvarchar(MAX) = '',
@Order nvarchar(200) = ''
AS
	Declare @SQL as nvarchar(500)
	Declare @strTop as nvarchar(100)
	Select @strTop=' ('+ @Top +') '
	if len(@Top)=0
		BEGIN
			Select @strTop=' 100 percent '
		END
	Select @SQL= 'SELECT top '+ @strTop +' * FROM [ViewTaiKhoan] '
	if len(@Where)>0
		BEGIN
			Select @SQL= @SQL + ' Where ' + @Where
		END
	if len(@Order)>0
		BEGIN
			Select @SQL=@SQL +' Order by '+@Order
		END
	EXEC(@SQL)




GO
/****** Object:  StoredProcedure [dbo].[sp_TaiKhoan_Insert]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TaiKhoan_Insert]
	@username varchar(50),
	@password varchar(50),
	@quyen varchar(50),
	@idnhanvien int
AS
	BEGIN
		INSERT INTO TaiKhoan VALUES (@username,@password,@quyen,@idnhanvien)
	END



GO
/****** Object:  StoredProcedure [dbo].[sp_TaiKhoan_Update]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TaiKhoan_Update]
	@username varchar(50),
	@password varchar(50) = null,
	@quyen varchar(50) = null,
	@idnhanvien int
AS
	BEGIN
		if @password is null
		Begin
			UPDATE TaiKhoan SET
			Quyen = @quyen,
			IDNhanVien = @idnhanvien
			WHERE Username = @username
		end
		else
		begin
			UPDATE TaiKhoan SET
			Password = @password,
			Quyen = @quyen,
			IDNhanVien = @idnhanvien
			WHERE Username = @username
		end
	END


GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign]
(
 @strInput NVARCHAR(4000)
) 
RETURNS NVARCHAR(4000)
AS
Begin
 Set @strInput=rtrim(ltrim(lower(@strInput)))
 IF @strInput IS NULL RETURN @strInput
 IF @strInput = '' RETURN @strInput
 Declare @text nvarchar(50), @i int
 Set @text='-''`~!@#$%^&*()?><:|}{,./\"''='';–'
 Select @i= PATINDEX('%['+@text+']%',@strInput ) 
 while @i > 0
 begin
 set @strInput = replace(@strInput, substring(@strInput, @i, 1), '')
 set @i = patindex('%['+@text+']%', @strInput)
 End
 Set @strInput =replace(@strInput,' ',' ')
 
 DECLARE @RT NVARCHAR(4000)
 DECLARE @SIGN_CHARS NCHAR(136)
 DECLARE @UNSIGN_CHARS NCHAR (136)
 SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế
 ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý'
 +NCHAR(272)+ NCHAR(208)
 SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee
 iiiiiooooooooooooooouuuuuuuuuuyyyyy'
 DECLARE @COUNTER int
 DECLARE @COUNTER1 int
 SET @COUNTER = 1
 WHILE (@COUNTER <=LEN(@strInput))
 BEGIN 
 SET @COUNTER1 = 1
 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
 BEGIN
 IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) 
 = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
 BEGIN 
 IF @COUNTER=1
 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) 
 + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
 ELSE
 SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) 
 +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) 
 + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)
 BREAK
 END
 SET @COUNTER1 = @COUNTER1 +1
 END
 SET @COUNTER = @COUNTER +1
 End
 SET @strInput = replace(@strInput,'  ',' ')
 SET @strInput = replace(@strInput,'  ',' ')
 SET @strInput = replace(@strInput,'  ',' ')
 RETURN lower(@strInput)
End
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 6/30/2017 12:39:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChucVu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Alias] [varchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Alias] [varchar](100) NULL,
 CONSTRAINT [PK_tb_KhachHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [varchar](50) NULL,
	[MaChucVu] [int] NULL,
	[Alias] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuHen]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuHen](
	[MaPhieuHen] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuYC] [int] NULL,
	[PAGiaiQuyet] [nvarchar](max) NULL,
	[ThoiGianHen] [datetime] NULL,
	[DoUuTien] [int] NULL,
	[TinhTrang] [bit] NULL,
	[MaNV] [int] NULL,
 CONSTRAINT [PK_PhieuHen] PRIMARY KEY CLUSTERED 
(
	[MaPhieuHen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuYeuCau]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuYeuCau](
	[MaPhieuYC] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[YeuCau] [nvarchar](max) NULL,
	[TGNhan] [datetime] NULL,
	[MaNhanVien] [int] NULL,
 CONSTRAINT [PK_PhieuYeuCau] PRIMARY KEY CLUSTERED 
(
	[MaPhieuYC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Quyen] [varchar](50) NULL,
	[IDNhanVien] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ViewNhanVien]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[ViewNhanVien]
as
select NhanVien.*, ChucVu.Name as 'TenChucVu'
from NhanVien, ChucVu
where ChucVu.ID = NhanVien.MaChucVu
GO
/****** Object:  View [dbo].[ViewPhieuHen]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewPhieuHen]
AS
SELECT        dbo.PhieuHen.MaPhieuHen, dbo.PhieuHen.MaPhieuYC, dbo.PhieuHen.PAGiaiQuyet, dbo.PhieuHen.ThoiGianHen, dbo.PhieuHen.DoUuTien, dbo.PhieuHen.TinhTrang, dbo.PhieuHen.MaNV, dbo.NhanVien.Name AS TenNhanVien, 
                         dbo.PhieuYeuCau.MaKhachHang, dbo.KhachHang.Name AS TenKhachHang, dbo.KhachHang.Alias, dbo.PhieuYeuCau.YeuCau
FROM            dbo.PhieuHen INNER JOIN
                         dbo.NhanVien ON dbo.PhieuHen.MaNV = dbo.NhanVien.ID INNER JOIN
                         dbo.PhieuYeuCau ON dbo.PhieuHen.MaPhieuYC = dbo.PhieuYeuCau.MaPhieuYC INNER JOIN
                         dbo.KhachHang ON dbo.PhieuYeuCau.MaKhachHang = dbo.KhachHang.ID

GO
/****** Object:  View [dbo].[ViewPhieuYeuCau]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[ViewPhieuYeuCau]
as
select PhieuYeuCau.*, KhachHang.Name as 'TenKhachHang', NhanVien.Name as 'TenNhanVien',KhachHang.Alias
from PhieuYeuCau, KhachHang,NhanVien
where NhanVien.ID = PhieuYeuCau.MaNhanVien
and KhachHang.ID = PhieuYeuCau.MaKhachHang
GO
/****** Object:  View [dbo].[ViewTaiKhoan]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewTaiKhoan]
AS
SELECT        dbo.TaiKhoan.Username, dbo.TaiKhoan.Password, dbo.TaiKhoan.Quyen, dbo.TaiKhoan.IDNhanVien, dbo.NhanVien.Name AS TenNhanVien, dbo.NhanVien.Alias
FROM            dbo.TaiKhoan INNER JOIN
                         dbo.NhanVien ON dbo.TaiKhoan.IDNhanVien = dbo.NhanVien.ID

GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([ID], [Name], [Alias]) VALUES (1, N'Giám đốc', N'giam doc')
INSERT [dbo].[ChucVu] ([ID], [Name], [Alias]) VALUES (2, N'Nhân viên', N'nhan vien')
INSERT [dbo].[ChucVu] ([ID], [Name], [Alias]) VALUES (3, N'Quản lí', N'quan li')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([ID], [Name], [Address], [Phone], [Email], [Alias]) VALUES (1, N'Nguyễn Văn Hiếu', N'Hà Nội', N'01649346164', N'vanhieu2910@gmail.com', N'nguyen van hieu')
INSERT [dbo].[KhachHang] ([ID], [Name], [Address], [Phone], [Email], [Alias]) VALUES (4, N'Nguyễn Văn Long', N'Hà Nội', NULL, N'vandfh@gmail.com', N'nguyen van long')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [Name], [Address], [Phone], [MaChucVu], [Alias]) VALUES (1, N'Nguyễn Văn Hiếu', N'Hà Nội', N'01649346164', 1, N'nguyen van hieu')
INSERT [dbo].[NhanVien] ([ID], [Name], [Address], [Phone], [MaChucVu], [Alias]) VALUES (3, N'Nguyễn Thị Vân Giang', N'Nghệ An', N'0999999999', 1, N'nguyen thi van giang')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[PhieuHen] ON 

INSERT [dbo].[PhieuHen] ([MaPhieuHen], [MaPhieuYC], [PAGiaiQuyet], [ThoiGianHen], [DoUuTien], [TinhTrang], [MaNV]) VALUES (1, 1, N'Thay mới', CAST(0x0000A7A10152172C AS DateTime), 0, 0, 1)
SET IDENTITY_INSERT [dbo].[PhieuHen] OFF
SET IDENTITY_INSERT [dbo].[PhieuYeuCau] ON 

INSERT [dbo].[PhieuYeuCau] ([MaPhieuYC], [MaKhachHang], [YeuCau], [TGNhan], [MaNhanVien]) VALUES (1, 1, N'Thay lốp ô tô', CAST(0x0000A7A10151FC38 AS DateTime), 1)
INSERT [dbo].[PhieuYeuCau] ([MaPhieuYC], [MaKhachHang], [YeuCau], [TGNhan], [MaNhanVien]) VALUES (8, 4, N'Sửa hệ thống điều hòa', CAST(0x0000A7A10151FC74 AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[PhieuYeuCau] OFF
INSERT [dbo].[TaiKhoan] ([Username], [Password], [Quyen], [IDNhanVien]) VALUES (N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'Administrator', 1)
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[PhieuHen]  WITH CHECK ADD  CONSTRAINT [FK_PhieuHen_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[PhieuHen] CHECK CONSTRAINT [FK_PhieuHen_NhanVien]
GO
ALTER TABLE [dbo].[PhieuHen]  WITH CHECK ADD  CONSTRAINT [FK_PhieuHen_PhieuYeuCau] FOREIGN KEY([MaPhieuYC])
REFERENCES [dbo].[PhieuYeuCau] ([MaPhieuYC])
GO
ALTER TABLE [dbo].[PhieuHen] CHECK CONSTRAINT [FK_PhieuHen_PhieuYeuCau]
GO
ALTER TABLE [dbo].[PhieuYeuCau]  WITH CHECK ADD  CONSTRAINT [FK_PhieuYeuCau_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([ID])
GO
ALTER TABLE [dbo].[PhieuYeuCau] CHECK CONSTRAINT [FK_PhieuYeuCau_KhachHang]
GO
ALTER TABLE [dbo].[PhieuYeuCau]  WITH CHECK ADD  CONSTRAINT [FK_PhieuYeuCau_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[PhieuYeuCau] CHECK CONSTRAINT [FK_PhieuYeuCau_NhanVien]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
/****** Object:  Trigger [dbo].[GetAlias]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[GetAlias]
   ON  [dbo].[ChucVu]
   For INSERT, UPDATE
AS 
BEGIN
	declare @id int
	declare @alias nvarchar(50)
	select @id = inserted.id from inserted
	select @alias = inserted.Name from inserted
	update ChucVu set Alias = [dbo].[fuConvertToUnsign](@alias) where ChucVu.ID = @id
END

GO
/****** Object:  Trigger [dbo].[GetAliasKhachHang]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[GetAliasKhachHang]
   ON  [dbo].[KhachHang]
   For INSERT, UPDATE
AS 
BEGIN
	declare @id int
	declare @alias nvarchar(50)
	select @id = inserted.id from inserted
	select @alias = inserted.Name from inserted
	update KhachHang set Alias = [dbo].[fuConvertToUnsign](@alias) where KhachHang.ID = @id
END

GO
/****** Object:  Trigger [dbo].[GetAliasNhanVien]    Script Date: 6/30/2017 12:39:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[GetAliasNhanVien]
   ON  [dbo].[NhanVien]
   For INSERT, UPDATE
AS 
BEGIN
	declare @id int
	declare @alias nvarchar(50)
	select @id = inserted.id from inserted
	select @alias = inserted.Name from inserted
	update NhanVien set Alias = [dbo].[fuConvertToUnsign](@alias) where NhanVien.ID = @id
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -78
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PhieuHen"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "NhanVien"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PhieuYeuCau"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "KhachHang"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 268
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewPhieuHen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewPhieuHen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TaiKhoan"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "NhanVien"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewTaiKhoan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewTaiKhoan'
GO
USE [master]
GO
ALTER DATABASE [QLKH] SET  READ_WRITE 
GO
