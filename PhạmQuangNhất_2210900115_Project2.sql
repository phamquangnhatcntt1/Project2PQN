USE [PhamQuangNhat-2210900115]
GO
/****** Object:  Table [dbo].[KHACH_HANG]    Script Date: 10/29/2024 8:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACH_HANG](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[Ho_ten] [varchar](100) NULL,
	[Tai_khoan] [varchar](50) NOT NULL,
	[Mat_khau] [varchar](32) NULL,
	[Dia_chi] [varchar](200) NULL,
	[Dien_thoai] [varchar](30) NULL,
	[Email] [varchar](50) NOT NULL,
	[Ngay_sinh] [datetime] NULL,
	[Ngay_cap_nhat] [datetime] NULL,
	[Gioi_tinh] [tinyint] NULL,
	[Tich_diem] [int] NOT NULL,
	[Trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHAN_VIEN]    Script Date: 10/29/2024 8:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAN_VIEN](
	[MaNhanVien] [int] NOT NULL,
	[TenNhanVien] [varchar](100) NOT NULL,
	[ChucVu] [varchar](50) NULL,
	[SoDienThoai] [varchar](30) NULL,
	[Email] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIM]    Script Date: 10/29/2024 8:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIM](
	[MaPhim] [int] NOT NULL,
	[TenPhim] [varchar](100) NOT NULL,
	[ThoiLuong] [int] NOT NULL,
	[TheLoai] [varchar](50) NULL,
	[DaoDien] [varchar](100) NULL,
	[MoTa] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhim] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG_CHIEU]    Script Date: 10/29/2024 8:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG_CHIEU](
	[MaPhong] [int] NOT NULL,
	[TenPhong] [varchar](50) NOT NULL,
	[SoGhe] [int] NOT NULL,
	[LoaiPhong] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUAN_TRI]    Script Date: 10/29/2024 8:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUAN_TRI](
	[Tai_khoan] [varchar](50) NOT NULL,
	[Mat_khau] [varchar](32) NOT NULL,
	[Trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Tai_khoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUAT_CHIEU]    Script Date: 10/29/2024 8:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUAT_CHIEU](
	[MaSuatChieu] [int] NOT NULL,
	[MaPhong] [int] NOT NULL,
	[MaPhim] [int] NOT NULL,
	[ThoiGianBatDau] [datetime] NOT NULL,
	[ThoiGianKetThuc] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSuatChieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VE]    Script Date: 10/29/2024 8:37:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VE](
	[MaVe] [int] NOT NULL,
	[MaSuatChieu] [int] NOT NULL,
	[MaKhachHang] [int] NOT NULL,
	[SoGhe] [int] NOT NULL,
	[GiaVe] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaVe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KHACH_HA__52AE88F504B36FA3]    Script Date: 10/29/2024 8:37:36 PM ******/
ALTER TABLE [dbo].[KHACH_HANG] ADD UNIQUE NONCLUSTERED 
(
	[Tai_khoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KHACH_HANG] ADD  DEFAULT (getdate()) FOR [Ngay_cap_nhat]
GO
ALTER TABLE [dbo].[KHACH_HANG] ADD  DEFAULT ((0)) FOR [Tich_diem]
GO
ALTER TABLE [dbo].[SUAT_CHIEU]  WITH CHECK ADD FOREIGN KEY([MaPhim])
REFERENCES [dbo].[PHIM] ([MaPhim])
GO
ALTER TABLE [dbo].[SUAT_CHIEU]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG_CHIEU] ([MaPhong])
GO
ALTER TABLE [dbo].[VE]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KHACH_HANG] ([MaKH])
GO
ALTER TABLE [dbo].[VE]  WITH CHECK ADD FOREIGN KEY([MaSuatChieu])
REFERENCES [dbo].[SUAT_CHIEU] ([MaSuatChieu])
GO
