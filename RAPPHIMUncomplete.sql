create database RapPhim;
use RapPhim;

CREATE TABLE TaiKhoan(TaiKhoan varchar (10) primary key, 
					MatKhau varchar (MAX), Quyen varchar (10));

CREATE TABLE PhongChieu(MaPhongChieu varchar (10) primary key, SoCho int,
						SoDay int, MayChieu nvarchar (MAX), AmThanh nvarchar (MAX),
						DienTich nvarchar (MAX), TinhTrang bit,
						ThietBiKhac nvarchar (MAX)); 	

CREATE TABLE LoaiVe(MaLoaiVe varchar (10) primary key, TenLoai nvarchar (MAX),
					HangGhe varchar (MAX), NgayBan nvarchar (MAX), DoiTuong varchar (MAX),
					Gia float);
	
CREATE TABLE NhanVien(MaNhanVien varchar (10) primary key,
					HoTenNhanVien nvarchar (MAX), NgaySinh date,
					GioiTinh bit, CMND varchar (MAX), SDT varchar (MAX),
					HinhAnh image, ChucVu nvarchar (MAX), DiaChi varchar (MAX));

create table TheLoai (MaTheLoai varchar (10) primary key, TenTheLoai nvarchar (MAX));
	
CREATE TABLE Phim(MaPhim varchar (10) primary key, TenPhim nvarchar (MAX),
				DaoDien nvarchar (MAX), MaTheLoai varchar (10),
				DienVien nvarchar (MAX), NoiDung nvarchar (MAX),
				Hinh image, Trailer nvarchar (MAX), NamSanXuat int,
				QuocGia nvarchar (MAX), ThoiLuong nvarchar (MAX),
				foreign key (MaTheLoai) references TheLoai (MaTheLoai));

CREATE TABLE LichChieu(MaLichChieu varchar (10) primary key,
					NgayChieu date, GioChieu nvarchar (MAX), MaPhongChieu varchar (10),
					MaPhim varchar (10),
					foreign key (MaPhongChieu) references PhongChieu (MaPhongChieu),
					foreign key (MaPhim) references Phim (MaPhim));
						
CREATE TABLE VeBan(MaVe varchar (10) primary key, MaLichChieu varchar (10), 
				MaLoaiVe varchar (10), SoLuong int, Ghe varchar (10),
				MaNhanVien varchar (10), Gia float,
				foreign key (MaLichChieu) references LichChieu (MaLichChieu),
				foreign key (MaLoaiVe) references LoaiVe (MaLoaiVe),
				foreign key (MaNhanVien) references NhanVien (MaNhanVien));

create table DichVu (MaDichVu varchar (10) primary key, 
					TenDichVu nvarchar (MAX), GiaDV float);

create table HoaDonDichVu (MaHoaDonDichVu varchar (10) primary key, 
							MaNhanVien varchar (10), MaDichVu varchar (10), 
							SoLuong int, DonGia float,
							foreign key (MaNhanVien) references NhanVien (MaNhanVien),
							foreign key (MaDichVu) references DichVu (MaDichVu));	


insert into TaiKhoan values ('NV01', '123', 'Admin');

insert into PhongChieu values ('PC01', 50, 5, N'Sony', N'Dolby', '50m2', 1, N'Không');

insert into LoaiVe values ('LV01', N'Vé học sinh', 'A, B, C, D, E', N'Thứ Hai/Thứ Ba/Thứ Tư/Thứ Năm', N'Học sinh', 50000);

insert into NhanVien values ('NV01', N'Lưu Hoàng Bắc', '11-18-1996', 1, '225603734', '01262567539', NULL, N'Admin' ,N'Khánh Hòa');

insert into TheLoai values ('TL01', N'Phim hành động');

insert into Phim values ('P01', N'Fast 7', N'Michale', 'TL01', N'Vin', N'Không có nội dung', NULL, 'K', 2015, N'Mỹ', 90);

insert into LichChieu values ('LC01', '11-18-2016', '18:00', 'PC01', 'P01');

insert into VeBan values ('MV01', 'LC01', 'LV01', 1, 'E1', 'NV01', 5000)
insert into VeBan values ('MV02', 'LC01', 'LV01', 2, 'A', 'NV01', 6000)

insert into DichVu values ('DV01', N'Bắp rang', 50000)

insert into HoaDonDichVu values('MHD01','NV01', 'DV01', 2, 100000)


---------------LỊCH CHIẾU
--THÊM LỊCH CHIẾU
GO
CREATE PROCEDURE [dbo].[spThemLichChieu]
@MaLichChieu varchar(10),
@NgayChieu date,
@GioChieu nvarchar(max),
@MaPhongChieu varchar(10),
@MaPhim varchar(10)
AS
BEGIN
	Insert into LichChieu values(@MaLichChieu,@NgayChieu,@GioChieu,@MaPhongChieu,@MaPhim)
END

--CẬP NHẬT LỊCH CHIẾU
GO
CREATE PROCEDURE [dbo].[spCapNhatLichChieu]
@MaLichChieu varchar(10),
@NgayChieu date,
@GioChieu nvarchar(max),
@MaPhongChieu varchar(10),
@MaPhim varchar(10)

AS
BEGIN
	Update LichChieu set MaLichChieu=@MaLichChieu,NgayChieu=@NgayChieu, 
	GioChieu = @GioChieu, MaPhongChieu = @MaPhongChieu, MaPhim = @MaPhim
  where MaLichChieu = @MaLichChieu
END

--XÓA LỊCH CHIẾU
GO
CREATE PROCEDURE [dbo].[spXoaLichChieu]
	@MaLichChieu varchar(10)
AS
BEGIN
	Delete From LichChieu where MaLichChieu=@MaLichChieu
END

/*========================================================================================*/
-------------LOẠI VÉ
--THÊM LOẠI VÉ
GO
CREATE PROCEDURE [dbo].[spThemLoaiVe]
@MaLoaiVe varchar(10),
@TenLoai nvarchar(max),
@HangGhe varchar(max),
@NgayBan nvarchar(max),
@DoiTuong varchar(max),
@Gia float
AS
BEGIN
	Insert into LoaiVe values(@MaLoaiVe,@TenLoai,@HangGhe,@NgayBan,@DoiTuong,@Gia)
END


--CẬP NHẬT LOẠI VÉ
GO
CREATE PROCEDURE [dbo].[spCapNhatLoaiVe]
@MaLoaiVe varchar(10),
@TenLoai nvarchar(max),
@HangGhe varchar(max),
@NgayBan nvarchar(max),
@DoiTuong varchar(max),
@Gia float

AS
BEGIN
	Update LoaiVe set MaLoaiVe=@MaLoaiVe,TenLoai=@TenLoai, 
	HangGhe = @HangGhe, NgayBan = @NgayBan, DoiTuong = @DoiTuong, Gia= @Gia
  where MaLoaiVe = @MaLoaiVe
END

--XÓA LOẠI VÉ
GO
CREATE PROCEDURE [dbo].[spXoaLoaiVe]
	@MaLoaiVe varchar(10)
AS
BEGIN
	Delete From LoaiVe where MaLoaiVe=@MaLoaiVe
END

/*/=============================================================================*/
----------NHÂN VIÊN
--THÊM NHÂN VIÊN
GO
CREATE PROCEDURE [dbo].[spThemNhanVien]
@MaNhanVien varchar(10),
@HoTenNhanVien nvarchar(max),
@NgaySinh date,
@GioiTinh bit,
@CMND varchar(max),
@SDT varchar(max),
@HinhAnh image,
@ChucVu nvarchar(max),
@DiaChi nvarchar(max)

AS
BEGIN
	Insert into NhanVien values(@MaNhanVien,@HoTenNhanVien,@NgaySinh,@GioiTinh,@CMND,@SDT,@HinhAnh,@ChucVu,@DiaChi)
END


--CẬP NHẬT NHÂN VIÊN
GO
CREATE PROCEDURE [dbo].[spCapNhatNhanVien]
@MaNhanVien varchar(10),
@HoTenNhanVien nvarchar(max),
@NgaySinh date,
@GioiTinh bit,
@CMND varchar(max),
@SDT varchar(max),
@HinhAnh image,
@ChucVu nvarchar(max),
@DiaChi nvarchar(max)

AS
BEGIN
	Update NhanVien set MaNhanVien=@MaNhanVien,HoTenNhanVien=@HoTenNhanVien, 
	NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, CMND = @CMND, SDT= @SDT,HinhAnh =@HinhAnh,ChucVu =@ChucVu,DiaChi=@DiaChi
  where MaNhanVien = @MaNhanVien
END

--XÓA NHÂN VIÊN
GO
CREATE PROCEDURE [dbo].[spXoaNhanVien]
	@MaNhanVien varchar(10)
AS
BEGIN
	Delete From NhanVien where MaNhanVien=@MaNhanVien
END


/*============================================================================*/
----------THỂ LOẠI
--THÊM THỂ LOẠI
GO
CREATE PROCEDURE [dbo].[spThemTheLoai]
@MaTheLoai varchar(10),
@TenTheLoai nvarchar(MAX)
AS
BEGIN
	Insert into TheLoai values(@MaTheLoai,@TenTheLoai)
END


--CẬP NHẬT THỂ LOẠI
GO
CREATE PROCEDURE [dbo].[spCapNhatTheLoai]
@MaTheLoai varchar(10),
@TenTheLoai nvarchar(MAX)
AS
BEGIN
	Update TheLoai set TenTheLoai = @TenTheLoai
  where MaTheLoai = @MaTheLoai
END

--XÓA THỂ LOẠI
GO
CREATE PROCEDURE [dbo].[spXoaTheLoai]
	@MaTheLoai varchar(10)
AS
BEGIN
	Delete From TheLoai where MaTheLoai = @MaTheLoai
END
/*============================================================================*/
----------PHIM
--THÊM PHIM
GO
CREATE PROCEDURE [dbo].[spThemPhim]
@MaPhim varchar(10),
@TenPhim nvarchar(max),
@DaoDien nvarchar(max),
@MaTheLoai varchar(10),
@DienVien nvarchar(max),
@NoiDung nvarchar(max),
@Hinh image,
@Trailer nvarchar(max),
@NamSanXuat int,
@QuocGia nvarchar(max),
@ThoiLuong nvarchar(max)
AS
BEGIN
	Insert into Phim values(@MaPhim,@TenPhim,@DaoDien,@MaTheLoai,@DienVien,@NoiDung,@Hinh,@Trailer,@NamSanXuat,@QuocGia,@ThoiLuong)
END


--CẬP NHẬT PHIM
GO
CREATE PROCEDURE [dbo].[spCapNhatPhim]
@MaPhim varchar(10),
@TenPhim nvarchar(max),
@DaoDien nvarchar(max),
@MaTheLoai varchar(10),
@DienVien nvarchar(max),
@NoiDung nvarchar(max),
@Hinh image,
@Trailer nvarchar(max),
@NamSanXuat int,
@QuocGia nvarchar(max),
@ThoiLuong nvarchar(max)

AS
BEGIN
	Update Phim set MaPhim=@MaPhim,TenPhim=@TenPhim, 
	DaoDien = @DaoDien, MaTheLoai = @MaTheLoai, DienVien = @DienVien, NoiDung= @NoiDung,Hinh =@Hinh,Trailer =@Trailer
	,NamSanXuat=@NamSanXuat,QuocGia=@QuocGia,ThoiLuong=@ThoiLuong
  where MaPhim = @MaPhim
END

--XÓA PHIM
GO
CREATE PROCEDURE [dbo].[spXoaPhim]
	@MaPhim varchar(10)
AS
BEGIN
	Delete From Phim where MaPhim=@MaPhim
END
/*=========================================================================================*/
----------PHÒNG CHIẾU
--THÊM PHÒNG CHIẾU
GO
CREATE PROCEDURE [dbo].[spThemPhongChieu]
@MaPhongChieu varchar(10),
@SoCho int,
@SoDay int,
@MayChieu varchar(10),
@AmThanh nvarchar(max),
@DienTich nvarchar(max),
@TinhTrang bit,
@ThietBiKhac nvarchar(max)
AS
BEGIN
	Insert into PhongChieu values(@MaPhongChieu,@SoCho,@SoDay,@MayChieu,@AmThanh,@DienTich,
	@TinhTrang,@ThietBiKhac)
END


--CẬP NHẬT PHÒNG CHIẾU
GO
CREATE PROCEDURE [dbo].[spCapNhatPhongChieu]
@MaPhongChieu varchar(10),
@SoCho int,
@SoDay int,
@MayChieu varchar(10),
@AmThanh nvarchar(max),
@DienTich nvarchar(max),
@TinhTrang bit,
@ThietBiKhac nvarchar(max)
AS
BEGIN
	Update PhongChieu set MaPhongChieu=@MaPhongChieu,SoCho=@SoCho, 
	SoDay = @SoDay, MayChieu = @MayChieu, AmThanh = @AmThanh, DienTich= @DienTich,TinhTrang =@TinhTrang,ThietBiKhac =@ThietBiKhac
  where MaPhongChieu = @MaPhongChieu
END

--XÓA PHÒNG CHIẾU
GO
CREATE PROCEDURE [dbo].[spXoaPhongChieu]
	@MaPhongChieu varchar(10)
AS
BEGIN
	Delete From PhongChieu where MaPhongChieu=@MaPhongChieu
END


/*===============================================================================================*/
----------TÀI KHOẢN
--THÊM TÀI KHOẢN
GO
CREATE PROCEDURE [dbo].[spThemTaiKhoan]
@TaiKhoan varchar(10),
@MatKhau varchar(10),
@Quyen varchar(10)
AS
BEGIN
	Insert into TaiKhoan values(@TaiKhoan,@MatKhau,@Quyen)
END


--CẬP NHẬT TÀI KHOẢN
GO
CREATE PROCEDURE [dbo].[spCapNhatTaiKhoan]
@TaiKhoan varchar(10),
@PassWord varchar(10),
@Quyen varchar(10)
AS
BEGIN
	Update TaiKhoan set TaiKhoan=@TaiKhoan, MatKhau = @PassWord, 
	Quyen = @Quyen
  where TaiKhoan = @TaiKhoan
END

--XÓA TÀI KHOẢN
GO
CREATE PROCEDURE [dbo].[spXoaTaiKhoan]
	@TaiKhoan varchar(10)
AS
BEGIN
	Delete From TaiKhoan where TaiKhoan=@TaiKhoan
END

/*==================================================================================*/
----------VÉ BÁN
--THÊM VÉ BÁN
GO
CREATE PROCEDURE [dbo].[spThemVeBan]

@MaVe varchar(10),
@MaLichChieu varchar(10),
@MaLoaiVe varchar(10),
@SoLuong int,
@Ghe varchar(10),
@MaNhanVien varchar(10),
@Gia float
AS
BEGIN
	Insert into VeBan values(@MaVe,@MaLichChieu,@MaLoaiVe,@SoLuong,@Ghe,@MaNhanVien,@Gia)
END


--CẬP NHẬT VÉ BÁN
GO
CREATE PROCEDURE [dbo].[spCapNhatVeBan]
@MaVe varchar(10),
@MaLichChieu varchar(10),
@MaLoaiVe varchar(10),
@SoLuong int,
@Ghe varchar(10),
@MaNhanVien varchar(10),
@Gia float
AS
BEGIN
	Update VeBan set MaVe=@MaVe, MaLichChieu = @MaLichChieu,MaLoaiVe= @MaLoaiVe,
	SoLuong =@SoLuong,Ghe= @Ghe,MaNhanVien=@MaNhanVien,Gia=@Gia
  where MaVe = @MaVe
END

--XÓA VÉ BÁN
GO
CREATE PROCEDURE [dbo].[spXoaVeBan]
	@MaVe nchar(10)
AS
BEGIN
	Delete From VeBan where MaVe=@MaVe
END

/*==================================================================================*/
----------DỊCH VỤ
--THÊM DỊCH VỤ
GO
CREATE PROCEDURE [dbo].[spThemDichVu]
@MaDichVu varchar(10),
@TenDichVu nvarchar (MAX),
@GiaDV float

AS
BEGIN
	Insert into DichVu values(@MaDichVu,@TenDichVu,@GiaDV)
END

--CẬP NHẬT DỊCH VỤ
GO
CREATE PROCEDURE [dbo].[spCapNhatDichVu]
@MaDichVu varchar(10),
@TenDichVu nvarchar (MAX),
@GiaDV float
AS
BEGIN
	Update DichVu set TenDichVu = @TenDichVu, GiaDV = @GiaDV
  where MaDichVu = @MaDichVu
END

--XÓA DỊCH VỤ
GO
CREATE PROCEDURE [dbo].[spXoaDichVu]
	@MaDichVu varchar(10)
AS
BEGIN
	Delete From DichVu where MaDichVu=@MaDichVu
END


/*==================================================================================*/
----HÓA ĐƠN DỊCH VỤ
--THÊM HDDV
GO
CREATE PROCEDURE [dbo].[spThemHoaDonDichVu]
@MaHoaDonDichVu varchar (10),
@MaNhanVien varchar (10), 
@MaDichVu varchar (10), 							
@SoLuong int, 
@DonGia float

AS
BEGIN
	Insert into HoaDonDichVu values(@MaHoaDonDichVu,@MaNhanVien,@MaDichVu,@SoLuong,@DonGia)
END

--CẬP NHẬT HDDV
GO
CREATE PROCEDURE [dbo].[spCapNhatHoaDonDichVu]
@MaHoaDonDichVu varchar (10),
@MaNhanVien varchar (10), 
@MaDichVu varchar (10), 							
@SoLuong int, 
@DonGia float
AS
BEGIN
	Update HoaDonDichVu set SoLuong = @SoLuong, DonGia = @DonGia, MaNhanVien = @MaNhanVien, MaDichVu = @MaDichVu
	where MaHoaDonDichVu = @MaHoaDonDichVu
END

--XÓA HDDV
GO
CREATE PROCEDURE [dbo].[spXoaHoaDonDichVu]
	@MaHoaDonDichVu varchar (10)
AS
BEGIN
	Delete From HoaDonDichVu where MaHoaDonDichVu=@MaHoaDonDichVu
END