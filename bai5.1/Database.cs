using System.Security.Cryptography;
using System.Text;
using MySqlConnector;

namespace BaiTap5_1_LoginForm
{
    /// <summary>
    /// Lớp truy cập CSDL MySQL (XAMPP) cho bài Login.
    /// CSDL: ql_dangnhap - bảng TaiKhoan và LichSuDangNhap.
    /// </summary>
    public static class Database
    {
        // Mặc định XAMPP: user root, không mật khẩu, cổng 3306
        private const string ServerConn = "Server=localhost;Port=3306;User ID=root;Password=;CharSet=utf8mb4;";
        private const string DbName = "ql_dangnhap";
        public static string ConnStr => ServerConn + "Database=" + DbName + ";";

        /// <summary>Tạo CSDL, bảng và tài khoản mẫu nếu chưa có.</summary>
        public static void KhoiTao()
        {
            using (var conn = new MySqlConnection(ServerConn))
            {
                conn.Open();
                using var cmd = new MySqlCommand(
                    "CREATE DATABASE IF NOT EXISTS " + DbName +
                    " CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;", conn);
                cmd.ExecuteNonQuery();
            }

            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                string sql = @"
CREATE TABLE IF NOT EXISTS TaiKhoan (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhauHash CHAR(64) NOT NULL,
    HoTen VARCHAR(100),
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE IF NOT EXISTS LichSuDangNhap (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL,
    ThoiGian DATETIME DEFAULT CURRENT_TIMESTAMP,
    ThanhCong TINYINT(1) NOT NULL
);";
                using (var cmd = new MySqlCommand(sql, conn)) cmd.ExecuteNonQuery();

                // Tài khoản mẫu: admin / 123456
                using var seed = new MySqlCommand(
                    "INSERT IGNORE INTO TaiKhoan (TenDangNhap, MatKhauHash, HoTen) VALUES (@u, @p, @h)", conn);
                seed.Parameters.AddWithValue("@u", "admin");
                seed.Parameters.AddWithValue("@p", BamMatKhau("123456"));
                seed.Parameters.AddWithValue("@h", "Quản trị viên");
                seed.ExecuteNonQuery();
            }
        }

        /// <summary>Băm mật khẩu SHA-256, không lưu mật khẩu gốc vào CSDL.</summary>
        public static string BamMatKhau(string matKhau)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(matKhau));
            return Convert.ToHexString(hash).ToLower();
        }

        /// <summary>Kiểm tra đăng nhập. Trả về họ tên nếu đúng, null nếu sai.</summary>
        public static string KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT HoTen FROM TaiKhoan WHERE TenDangNhap = @u AND MatKhauHash = @p", conn);
            cmd.Parameters.AddWithValue("@u", tenDangNhap);
            cmd.Parameters.AddWithValue("@p", BamMatKhau(matKhau));
            object kq = cmd.ExecuteScalar();
            return kq == null ? null : (kq == DBNull.Value ? tenDangNhap : kq.ToString());
        }

        /// <summary>Tạo tài khoản mới. Trả về false nếu tên đăng nhập đã tồn tại.</summary>
        public static bool TaoTaiKhoan(string tenDangNhap, string matKhau, string hoTen)
        {
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();
            using var cmd = new MySqlCommand(
                "INSERT IGNORE INTO TaiKhoan (TenDangNhap, MatKhauHash, HoTen) VALUES (@u, @p, @h)", conn);
            cmd.Parameters.AddWithValue("@u", tenDangNhap);
            cmd.Parameters.AddWithValue("@p", BamMatKhau(matKhau));
            cmd.Parameters.AddWithValue("@h", hoTen);
            return cmd.ExecuteNonQuery() == 1;
        }

        /// <summary>Ghi lại mỗi lần đăng nhập (thành công hoặc thất bại).</summary>
        public static void GhiLichSu(string tenDangNhap, bool thanhCong)
        {
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();
            using var cmd = new MySqlCommand(
                "INSERT INTO LichSuDangNhap (TenDangNhap, ThanhCong) VALUES (@u, @t)", conn);
            cmd.Parameters.AddWithValue("@u", tenDangNhap);
            cmd.Parameters.AddWithValue("@t", thanhCong);
            cmd.ExecuteNonQuery();
        }
    }
}
