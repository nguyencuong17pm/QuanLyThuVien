CREATE DATABASE QLyThuVien 
GO
Use QLyThuVien

CREATE TABLE BANDOC
(
    MaSV		 CHAR(5) PRIMARY KEY,
	HoVaDem		 NVARCHAR(100) NOT NULL,
	Ten			 NVARCHAR(100) NOT NULL,
	HoVaTen		 NVARCHAR(200) NOT NULL,
	Lop			 NVARCHAR(20) NOT NULL,
	GioiTinh	 NVARCHAR(3) NOT NULL,
	NgaySinh     DATETIME NOT NULL,
	DiaChiSV	 NVARCHAR(200) NOT NULL,
	Anh          Image,
	
)
CREATE TABLE THETHUVIEN
(
	MaThe  	     CHAR(5) NOT NULL PRIMARY KEY,
	MaSV		 CHAR(5) FOREIGN KEY(MaSV) REFERENCES BANDOC(MaSV),
	NgayCap    	 DATETIME NOT NULL,
	NgayHieuLuc  DATETIME NOT NULL,
	NgayHetHan   DATETIME NOT NULL,
)
CREATE TABLE THELOAI
(
	MaLoai		CHAR(5)  PRIMARY KEY,
	TenLoai		NVARCHAR(50) NOT NULL,
)
CREATE TABLE NHAXUATBAN
(
	MaNXB	CHAR(5)  PRIMARY KEY,
	TenNXB	NVARCHAR(100) NOT NULL,
)
CREATE TABLE NHANVIEN
(
	MaNV		CHAR(5) PRIMARY KEY,
	TenNV		NVARCHAR(100) NOT NULL,
	NgaySinh    smalldatetime NOT NULL,
	NgayVaoLam  smalldatetime NOT NULL,
	Gioitinh	NVARCHAR(3) NOT NULL,
	DiaChiNV	NVARCHAR(200) NOT NULL,
	DienThoai	NVARCHAR(20),

)
CREATE TABLE SACH
(
	MaSach		CHAR(5) PRIMARY KEY,
	TenSach		NVARCHAR(200) NOT NULL,
    MaLoai		CHAR(5) FOREIGN KEY(MaLoai) REFERENCES THELOAI(MaLoai),
	TinhTrang	NVARCHAR(20),
	SoLuong		INT NOT NULL,
	MaNXB	    CHAR(5) FOREIGN KEY(MaNXB) REFERENCES NHAXUATBAN(MaNXB),
	NamXB		NVARCHAR(20) NOT NULL,
	TacGia	    NVARCHAR(200) NOT NULL,
)
CREATE TABLE MUONTRA
(
    MaMuonTra 	CHAR(5) PRIMARY KEY,
	MaThe  	    CHAR(5) FOREIGN KEY(MaThe) REFERENCES THETHUVIEN(MaThe),
	MaSach      CHAR(5) FOREIGN KEY(MaSach) REFERENCES SACH(MaSach),
	MaNV		CHAR(5) FOREIGN KEY(MaNV) REFERENCES NHANVIEN(MaNV),
	NgayMuon   	DATETIME NOT NULL,
	KyHanTra	DATETIME NOT NULL,
	SoLuongMuon INT NOT NULL,
	SoTien      INT NOT NULL,
)
CREATE TABLE CTMuonTra
(   
    ID          INT IDENTITY(1,1) PRIMARY KEY,  
	MaMuonTra	CHAR(5) FOREIGN KEY(MaMuonTra) REFERENCES MUONTRA(MaMuonTra),
	MaSach      CHAR(5) FOREIGN KEY(MaSach) REFERENCES SACH(MaSach),
	DaTra		INT NOT NULL, 
	NgayTra   	DATETIME NOT NULL,
	GhiChu      NVARCHAR(200) NOT NULL,
)
CREATE TABLE TAIKHOAN
(
   ID           INT IDENTITY(1,1) PRIMARY KEY,
   MaNV			CHAR(5) FOREIGN KEY(MaNV) REFERENCES NHANVIEN(MaNV),
   MaSV			CHAR(5) FOREIGN KEY(MaSV) REFERENCES BANDOC(MaSV),
   TenHienThi   NVARCHAR(200),
   MatKhau   	NVARCHAR(20),
   QuyenHan 	NVARCHAR(20),
)

--Giảm số lượng sách khi thêm 1 hoặc nhiều cuốn sách bên bảng mượn trả
CREATE TRIGGER trg_SL ON MUONTRA AFTER INSERT AS
BEGIN
UPDATE SACH
SET SoLuong = SoLuong - (SELECT SoLuongMuon 
FROM inserted
WHERE MaSach = SACH.MaSach
)
from SACH
JOIN inserted on SACH.MaSach = inserted.MaSach
end
--
CREATE TRIGGER trg_CapNhatSL ON MUONTRA AFTER UPDATE AS
BEGIN
--Cập nhật lại số lượng sách khi thay đổi số lượng sách bên bảng mượn trả
UPDATE SACH SET SoLuong = SoLuong - 
(SELECT SoLuongMuon FROM inserted WHERE MaSach = SACH.MaSach) +
(SELECT SoLuongMuon FROM deleted WHERE MaSach = SACH.MaSach)
from SACH
JOIN DELETED ON SACH.MaSach = deleted.MaSach
END

--Tăng số lượng sách khi xóa sách bên bảng mượn trả
CREATE TRIGGER trg_Xoa ON MUONTRA FOR DELETE AS
BEGIN
  UPDATE SACH
  SET SoLuong = SoLuong + (SELECT SoLuongMuon FROM deleted WHERE MaSach = SACH.MaSach)
  FROM SACH
  JOIN DELETED ON SACH.MaSach = deleted.MaSach
  END

--Them sach
CREATE PROCEDURE InsertSach 
	@MaSach CHAR(5),
	@TenSach NVARCHAR(200),
	@MaLoai CHAR(5),
        @SoLuong INT,
        @TinhTrang NVARCHAR(20),
        @MaNXB CHAR(5),
	@NamXB	INT,
	@TacGia	NVARCHAR(100)
AS
BEGIN 
   INSERT INTO SACH(MaSach,TenSach, MaLoai,SoLuong,TinhTrang,MaNXB,NamXB, TacGia)
   VALUES(@MaSach,@TenSach,@MaLoai,@SoLuong,@TinhTrang,@MaNXB,@NamXB,@TacGia) 
   SELECT * FROM SACH
 END 
 --Sua sach
 CREATE PROCEDURE UpdateSach
@MaSach CHAR(5),
	@TenSach NVARCHAR(200),
	@MaLoai CHAR(5),
        @SoLuong INT,
        @TinhTrang NVARCHAR(20),
        @MaNXB CHAR(5),
	@NamXB	INT,
	@TacGia	NVARCHAR(100) 
AS 
BEGIN 
UPDATE SACH 
SET TenSach =  @TenSach, MaLoai = @MaLoai,  SoLuong = @SoLuong, TinhTrang = @TinhTrang, 
MaNXB = @MaNXB,  NamXB = @NamXB, TacGia = @TacGia
WHERE MaSach = @MaSach 
END 


--Xoa sach
CREATE PROCEDURE DeleteSach
@MaSach CHAR(5) 
AS 
BEGIN 
DELETE FROM SACH
WHERE MaSach = @MaSach 
END 

