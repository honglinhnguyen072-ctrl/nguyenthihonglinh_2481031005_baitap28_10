-- CSDL cho Bài 5.2 (nâng cấp Bài 4.2 - Form đăng ký học viên)
-- Chương trình tự tạo CSDL khi chạy lần đầu; file này để tham khảo / tạo thủ công.
CREATE DATABASE IF NOT EXISTS ql_hocvien CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE ql_hocvien;

CREATE TABLE IF NOT EXISTS KhoaHoc (
    MaKH VARCHAR(10) PRIMARY KEY,
    TenKH VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS HocVien (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    HoTen VARCHAR(100) NOT NULL,
    GioiTinh VARCHAR(5) NOT NULL,
    NgaySinh DATE NOT NULL,
    SoDienThoai VARCHAR(20) NOT NULL,
    MaKH VARCHAR(10) NOT NULL,
    HocOnline TINYINT(1) NOT NULL DEFAULT 0,
    NgayDangKy DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (MaKH) REFERENCES KhoaHoc(MaKH)
);

INSERT IGNORE INTO KhoaHoc (MaKH, TenKH) VALUES
    ('KH01', 'Lập trình C#'),
    ('KH02', 'Lập trình WinForms'),
    ('KH03', 'Lập trình Web');
