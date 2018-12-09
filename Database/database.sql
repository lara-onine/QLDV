USE [master]
GO
/****** Object:  Database [QLDoanVien]    Script Date: 12/9/2018 10:38:02 PM ******/
CREATE DATABASE [QLDoanVien]
 CONTAINMENT = NONE

GO
ALTER DATABASE [QLDoanVien] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLDoanVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLDoanVien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLDoanVien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLDoanVien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLDoanVien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLDoanVien] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLDoanVien] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLDoanVien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLDoanVien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLDoanVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLDoanVien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLDoanVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLDoanVien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLDoanVien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLDoanVien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLDoanVien] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLDoanVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLDoanVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLDoanVien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLDoanVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLDoanVien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLDoanVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLDoanVien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLDoanVien] SET RECOVERY FULL 
GO
ALTER DATABASE [QLDoanVien] SET  MULTI_USER 
GO
ALTER DATABASE [QLDoanVien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLDoanVien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLDoanVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLDoanVien] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLDoanVien] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLDoanVien', N'ON'
GO
ALTER DATABASE [QLDoanVien] SET QUERY_STORE = OFF
GO
USE [QLDoanVien]
GO
/****** Object:  Table [dbo].[KhoaHoc]    Script Date: 12/9/2018 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoaHoc](
	[ma_khoa_hoc] [int] IDENTITY(1,1) NOT NULL,
	[ten_khoa_hoc] [nvarchar](50) NULL,
	[user_name] [varchar](50) NOT NULL,
	[ngay_tao] [datetime] NULL,
 CONSTRAINT [PK_KhoaHoc] PRIMARY KEY CLUSTERED 
(
	[ma_khoa_hoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 12/9/2018 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[ma_khoa] [int] IDENTITY(1,1) NOT NULL,
	[ten_khoa] [nvarchar](150) NULL,
	[ngay_tao] [datetime] NOT NULL,
	[user_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[ma_khoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[getKhoaHoc]    Script Date: 12/9/2018 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getKhoaHoc]( @makhoahoc int, @maKhoa int )
returns table
as
return
SELECT
	Khoa.ma_khoa
	,[Khoa].ten_khoa
	,KhoaHoc.ma_khoa_hoc
	  ,[KhoaHoc].ten_khoa_hoc
  FROM [QLDoanVien].[dbo].Khoa_KhoaHoc
  INNER JOIN Khoa on Khoa_KhoaHoc.ma_khoa = Khoa.ma_khoa
  INNER JOIN KhoaHoc on Khoa_KhoaHoc.ma_khoa_hoc = KhoaHoc.ma_khoa_hoc
  where KhoaHoc.ma_khoa_hoc = @makhoahoc and Khoa.ma_khoa = @maKhoa
GO
/****** Object:  Table [dbo].[ChiPhi]    Script Date: 12/9/2018 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiPhi](
	[ma_gd] [int] IDENTITY(1,1) NOT NULL,
	[ngay_gd] [datetime] NULL,
	[so_tien] [float] NULL,
	[ma_sv] [varchar](50) NULL,
 CONSTRAINT [PK_ChiPhi] PRIMARY KEY CLUSTERED 
(
	[ma_gd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 12/9/2018 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[ma_lop] [int] IDENTITY(1,1) NOT NULL,
	[ten_lop] [nvarchar](150) NULL,
	[user_name] [varchar](50) NOT NULL,
	[ma_nganh] [int] NOT NULL,
	[ma_khoa_hoc] [int] NULL,
	[ngay_tao] [datetime] NOT NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[ma_lop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nganh]    Script Date: 12/9/2018 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[ma_nganh] [int] IDENTITY(1,1) NOT NULL,
	[ten_nganh] [nvarchar](150) NULL,
	[user_name] [varchar](50) NOT NULL,
	[ngay_tao] [datetime] NOT NULL,
	[ma_khoa] [int] NOT NULL,
 CONSTRAINT [PK_Nganh] PRIMARY KEY CLUSTERED 
(
	[ma_nganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/9/2018 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 12/9/2018 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[ma_sv] [varchar](50) NOT NULL,
	[pass] [varchar](255) NULL,
	[ho_ten] [nvarchar](150) NULL,
	[dia_chi] [nvarchar](150) NULL,
	[sdt] [varchar](20) NULL,
	[la_doanvien] [bit] NULL,
	[la_hoivien] [bit] NULL,
	[ma_lop] [int] NOT NULL,
	[role_id] [int] NOT NULL,
	[da_dong_hp_dp] [bit] NULL,
	[da_xoa] [bit] NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[ma_sv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuKien]    Script Date: 12/9/2018 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuKien](
	[ma_sk] [int] IDENTITY(1,1) NOT NULL,
	[tieu_de] [nvarchar](255) NULL,
	[dia_diem] [nvarchar](255) NULL,
	[noi_dung] [ntext] NULL,
	[thoi_gian] [datetime] NULL,
	[user_name] [varchar](50) NULL,
	[thoi_gian_tao] [datetime] NULL,
 CONSTRAINT [PK_SuKien] PRIMARY KEY CLUSTERED 
(
	[ma_sk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/9/2018 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_name] [varchar](50) NOT NULL,
	[pass] [varchar](255) NULL,
	[full_name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phone] [varchar](20) NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Khoa] ON 
GO
INSERT [dbo].[Khoa] ([ma_khoa], [ten_khoa], [ngay_tao], [user_name]) VALUES (1, N'Khoa Công nghệ thông tin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), N'admin')
GO
INSERT [dbo].[Khoa] ([ma_khoa], [ten_khoa], [ngay_tao], [user_name]) VALUES (3, N'Khoa Cơ khí', CAST(N'2018-12-05T10:00:00.000' AS DateTime), N'admin')
GO
INSERT [dbo].[Khoa] ([ma_khoa], [ten_khoa], [ngay_tao], [user_name]) VALUES (4, N'Khoa Điện', CAST(N'2018-12-05T10:00:00.000' AS DateTime), N'admin')
GO
INSERT [dbo].[Khoa] ([ma_khoa], [ten_khoa], [ngay_tao], [user_name]) VALUES (5, N'Khoa Du Lịch', CAST(N'2018-12-05T10:00:00.000' AS DateTime), N'admin')
GO
SET IDENTITY_INSERT [dbo].[Khoa] OFF
GO
SET IDENTITY_INSERT [dbo].[KhoaHoc] ON 
GO
INSERT [dbo].[KhoaHoc] ([ma_khoa_hoc], [ten_khoa_hoc], [user_name], [ngay_tao]) VALUES (1, N'DH K10 (2015 - 2019)', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[KhoaHoc] ([ma_khoa_hoc], [ten_khoa_hoc], [user_name], [ngay_tao]) VALUES (2, N'DH K11 (2016 - 2020)', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[KhoaHoc] ([ma_khoa_hoc], [ten_khoa_hoc], [user_name], [ngay_tao]) VALUES (3, N'DH K12 (2017 - 2021)', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[KhoaHoc] ([ma_khoa_hoc], [ten_khoa_hoc], [user_name], [ngay_tao]) VALUES (4, N'DH K13 (2018 - 2022)', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[KhoaHoc] ([ma_khoa_hoc], [ten_khoa_hoc], [user_name], [ngay_tao]) VALUES (5, N'CD K18 (2017-2020)', N'admin', CAST(N'2018-12-05T14:04:08.137' AS DateTime))
GO
INSERT [dbo].[KhoaHoc] ([ma_khoa_hoc], [ten_khoa_hoc], [user_name], [ngay_tao]) VALUES (6, N'DH K14 (2010-2020)', N'admin', CAST(N'2018-12-05T18:21:28.613' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[KhoaHoc] OFF
GO
SET IDENTITY_INSERT [dbo].[Lop] ON 
GO
INSERT [dbo].[Lop] ([ma_lop], [ten_lop], [user_name], [ma_nganh], [ma_khoa_hoc], [ngay_tao]) VALUES (8, N'HTTT1', N'admin', 3, 1, CAST(N'2018-12-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Lop] ([ma_lop], [ten_lop], [user_name], [ma_nganh], [ma_khoa_hoc], [ngay_tao]) VALUES (9, N'HTTT2', N'admin', 3, 1, CAST(N'2018-12-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Lop] ([ma_lop], [ten_lop], [user_name], [ma_nganh], [ma_khoa_hoc], [ngay_tao]) VALUES (10, N'HTTT3', N'admin', 3, 1, CAST(N'2018-12-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Lop] ([ma_lop], [ten_lop], [user_name], [ma_nganh], [ma_khoa_hoc], [ngay_tao]) VALUES (11, N'HTTT4', N'admin', 3, 1, CAST(N'2018-12-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Lop] ([ma_lop], [ten_lop], [user_name], [ma_nganh], [ma_khoa_hoc], [ngay_tao]) VALUES (12, N'KHMT1', N'admin', 4, 1, CAST(N'2018-12-05T10:00:00.000' AS DateTime))
GO
INSERT [dbo].[Lop] ([ma_lop], [ten_lop], [user_name], [ma_nganh], [ma_khoa_hoc], [ngay_tao]) VALUES (13, N'KHMT2', N'admin', 4, 1, CAST(N'2018-12-05T10:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Lop] OFF
GO
SET IDENTITY_INSERT [dbo].[Nganh] ON 
GO
INSERT [dbo].[Nganh] ([ma_nganh], [ten_nganh], [user_name], [ngay_tao], [ma_khoa]) VALUES (3, N'Ngành Hệ thống thông tin', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Nganh] ([ma_nganh], [ten_nganh], [user_name], [ngay_tao], [ma_khoa]) VALUES (4, N'Ngành Khoa học máy tính', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Nganh] ([ma_nganh], [ten_nganh], [user_name], [ngay_tao], [ma_khoa]) VALUES (5, N'Ngành Công nghệ thông tin', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Nganh] ([ma_nganh], [ten_nganh], [user_name], [ngay_tao], [ma_khoa]) VALUES (6, N'Ngành Công nghệ chế tạo máy', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), 3)
GO
INSERT [dbo].[Nganh] ([ma_nganh], [ten_nganh], [user_name], [ngay_tao], [ma_khoa]) VALUES (7, N'Ngành Công nghệ kỹ thuật cơ khí', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), 3)
GO
INSERT [dbo].[Nganh] ([ma_nganh], [ten_nganh], [user_name], [ngay_tao], [ma_khoa]) VALUES (8, N'Ngành Công nghệ kỹ thuật cơ điện tử', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), 3)
GO
INSERT [dbo].[Nganh] ([ma_nganh], [ten_nganh], [user_name], [ngay_tao], [ma_khoa]) VALUES (9, N'Ngành Công nghệ kỹ thuật nhiệt', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), 4)
GO
INSERT [dbo].[Nganh] ([ma_nganh], [ten_nganh], [user_name], [ngay_tao], [ma_khoa]) VALUES (10, N'Ngành Công nghệ kỹ thuật điện, điện tử', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), 4)
GO
INSERT [dbo].[Nganh] ([ma_nganh], [ten_nganh], [user_name], [ngay_tao], [ma_khoa]) VALUES (11, N'Ngành Điện công nghiệp', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), 4)
GO
INSERT [dbo].[Nganh] ([ma_nganh], [ten_nganh], [user_name], [ngay_tao], [ma_khoa]) VALUES (12, N'Ngành Kỹ thuật phần mềm', N'admin', CAST(N'2018-12-05T10:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Nganh] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (2, N'User')
GO
INSERT [dbo].[Role] ([role_id], [role_name]) VALUES (3, N'Student')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360012', N'1234', N'Vũ Văn Chính', N'', N'343346448', 1, 1, 8, 3, 1, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360032', N'1234', N'Phạm Chí Công', N'', N'983247164', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360043', N'1234', N'Nguyễn Huy Anh', N'', N'979073926', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360046', N'1234', N'Nguyễn Viết Chinh', N'', N'348453550', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360050', N'1234', N'Phạm Tiến Đạt', N'', N'384780097', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360058', N'1234', N'Nguyễn Ngọc Cương', N'', N'357590225', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360103', N'1234', N'Ngô Nguyễn Chí Công', N'', N'826190902', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360119', N'1234', N'Nguyễn Ngọc Duy', N'', N'964958654', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360196', N'1234', N'Dương Tiến Đạt', N'Tổ dân phố Ngọa Long - Phường Minh Khai - Quận Bắc Từ Liêm - Hà Nội', N'336515294', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360199', N'1234', N'Nguyễn Văn Đức', N'', N'1678744439', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360208', N'1234', N'Thiều Khắc Bắc', N'', N'969472370', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360305', N'1234', N'Nguyễn Việt Đức', N'', N'965975206', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360314', N'1234', N'Nguyễn Quốc Cường', N'', N'965918681', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360350', N'1234', N'Lô Minh Đức', N'Xã Thanh Kỳ - Huyện Như Thanh - Tỉnh Thanh Hóa', N'328832983', 1, 1, 8, 3, 1, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360393', N'1234', N'Phạm Vũ Đạt', N'', N'981232072', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360424', N'1234', N'Nguyễn Thị Cúc', N'', N'989392930', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360460', N'1234', N'Bùi Quang Đông', N'', N'334222959', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360461', N'1234', N'Trần Xuân Bình', N'', N'989034101', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360545', N'1234', N'Lã Qúi Anh', N'', N'354284054', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'1041360548', N'1234', N'Lê Văn Dũng', N'', N'377569648', 1, 1, 8, 3, 0, 0)
GO
INSERT [dbo].[SinhVien] ([ma_sv], [pass], [ho_ten], [dia_chi], [sdt], [la_doanvien], [la_hoivien], [ma_lop], [role_id], [da_dong_hp_dp], [da_xoa]) VALUES (N'test', N'1234', N'test', N'test', N'test', 1, 0, 13, 3, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[SuKien] ON 
GO
INSERT [dbo].[SuKien] ([ma_sk], [tieu_de], [dia_diem], [noi_dung], [thoi_gian], [user_name], [thoi_gian_tao]) VALUES (1, N'Sự kiện đầu tiên trong tháng 12', N'Hà Nội', N'Chơi chơi thôi. Cũng chẳng có gì nhiều đâu', CAST(N'2018-12-10T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-12-09T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[SuKien] ([ma_sk], [tieu_de], [dia_diem], [noi_dung], [thoi_gian], [user_name], [thoi_gian_tao]) VALUES (2, N'Hello tháng 12', N'Hội trường A11', N'Chào đón tháng 12 đến với nhiều hoạt động vui nhộn và ý nghĩa', CAST(N'2018-12-25T00:00:00.000' AS DateTime), N'admin', CAST(N'2018-12-09T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[SuKien] OFF
GO
INSERT [dbo].[User] ([user_name], [pass], [full_name], [address], [phone], [role_id]) VALUES (N'admin', N'81dc9bdb52d04dc20036dbd8313ed055', N'Nguyễn Văn Trường', N'', N'', 1)
GO
INSERT [dbo].[User] ([user_name], [pass], [full_name], [address], [phone], [role_id]) VALUES (N'GK_003', N'81dc9bdb52d04dc20036dbd8313ed055', N'Nguyễn Đăng Khoa', N'Hà Nội', N'0988654675', 2)
GO
ALTER TABLE [dbo].[Khoa] ADD  CONSTRAINT [DF_Khoa_ngay_tao]  DEFAULT (getdate()) FOR [ngay_tao]
GO
ALTER TABLE [dbo].[KhoaHoc] ADD  CONSTRAINT [DF_KhoaHoc_ngay_tao]  DEFAULT (getdate()) FOR [ngay_tao]
GO
ALTER TABLE [dbo].[Lop] ADD  CONSTRAINT [DF_Lop_ngay_tao]  DEFAULT (getdate()) FOR [ngay_tao]
GO
ALTER TABLE [dbo].[Nganh] ADD  CONSTRAINT [DF_Nganh_ngay_tao]  DEFAULT (getdate()) FOR [ngay_tao]
GO
ALTER TABLE [dbo].[SinhVien] ADD  CONSTRAINT [DF_SinhVien_da_dong_hp_dp]  DEFAULT ((0)) FOR [da_dong_hp_dp]
GO
ALTER TABLE [dbo].[ChiPhi]  WITH CHECK ADD  CONSTRAINT [FK_ChiPhi_SinhVien] FOREIGN KEY([ma_sv])
REFERENCES [dbo].[SinhVien] ([ma_sv])
GO
ALTER TABLE [dbo].[ChiPhi] CHECK CONSTRAINT [FK_ChiPhi_SinhVien]
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [FK_Lop_KhoaHoc] FOREIGN KEY([ma_khoa_hoc])
REFERENCES [dbo].[KhoaHoc] ([ma_khoa_hoc])
GO
ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [FK_Lop_KhoaHoc]
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [FK_Lop_Nganh] FOREIGN KEY([ma_nganh])
REFERENCES [dbo].[Nganh] ([ma_nganh])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [FK_Lop_Nganh]
GO
ALTER TABLE [dbo].[Nganh]  WITH CHECK ADD  CONSTRAINT [FK_Nganh_Khoa] FOREIGN KEY([ma_khoa])
REFERENCES [dbo].[Khoa] ([ma_khoa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Nganh] CHECK CONSTRAINT [FK_Nganh_Khoa]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Lop] FOREIGN KEY([ma_lop])
REFERENCES [dbo].[Lop] ([ma_lop])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Lop]
GO
ALTER TABLE [dbo].[SuKien]  WITH CHECK ADD  CONSTRAINT [FK_SuKien_User] FOREIGN KEY([user_name])
REFERENCES [dbo].[User] ([user_name])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SuKien] CHECK CONSTRAINT [FK_SuKien_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [QLDoanVien] SET  READ_WRITE 
GO
