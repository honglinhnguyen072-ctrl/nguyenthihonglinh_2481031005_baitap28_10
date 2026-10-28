-- CSDL cho Bài 5.1 (nâng cấp Bài 4.1 - Login Form)
-- Chương trình tự tạo CSDL khi chạy lần đầu; file này để tham khảo / tạo thủ công.
CREATE DATABASE IF NOT EXISTS ql_dangnhap CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE ql_dangnhap;

CREATE TABLE IF NOT EXISTS TaiKhoan (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhauHash CHAR(64) NOT NULL,          -- SHA-256 của mật khẩu
    HoTen VARCHAR(100),
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS LichSuDangNhap (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL,
    ThoiGian DATETIME DEFAULT CURRENT_TIMESTAMP,
    ThanhCong TINYINT(1) NOT NULL
);

-- Tài khoản mẫu: admin / 123456
INSERT IGNORE INTO TaiKhoan (TenDangNhap, MatKhauHash, HoTen)
VALUES ('admin', SHA2('123456', 256), 'Quản trị viên');
