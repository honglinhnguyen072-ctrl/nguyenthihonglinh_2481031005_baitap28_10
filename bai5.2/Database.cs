using System.Data;
using MySqlConnector;

namespace BaiTap5_2_DangKyHocVien
{
    /// <summary>
    /// Lớp truy cập CSDL MySQL (XAMPP) cho bài Đăng ký học viên.
    /// CSDL: ql_hocvien - bảng KhoaHoc và HocVien.
    /// </summary>
    public static class Database
    {
        // Mặc định XAMPP: user root, không mật khẩu, cổng 3306
        private const string ServerConn = "Server=localhost;Port=3306;User ID=root;Password=;CharSet=utf8mb4;";
        private const string DbName = "ql_hocvien";
        public static string ConnStr => ServerConn + "Database=" + DbName + ";";

        /// <summary>Tạo CSDL, bảng và dữ liệu khóa học mẫu nếu chưa có.</summary>
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
    ('KH03', 'Lập trình Web');";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<KhoaHoc> LayDanhSachKhoaHoc()
        {
            var ds = new List<KhoaHoc>();
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();
            using var cmd = new MySqlCommand("SELECT MaKH, TenKH FROM KhoaHoc ORDER BY MaKH", conn);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ds.Add(new KhoaHoc { MaKH = rd.GetString(0), TenKH = rd.GetString(1) });
            }
            return ds;
        }

        public static void ThemHocVien(string hoTen, string gioiTinh, DateTime ngaySinh,
                                       string soDienThoai, string maKH, bool hocOnline)
        {
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();
            using var cmd = new MySqlCommand(@"
INSERT INTO HocVien (HoTen, GioiTinh, NgaySinh, SoDienThoai, MaKH, HocOnline)
VALUES (@HoTen, @GioiTinh, @NgaySinh, @SoDienThoai, @MaKH, @HocOnline)", conn);
            cmd.Parameters.AddWithValue("@HoTen", hoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
            cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh.Date);
            cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
            cmd.Parameters.AddWithValue("@MaKH", maKH);
            cmd.Parameters.AddWithValue("@HocOnline", hocOnline);
            cmd.ExecuteNonQuery();
        }

        public static DataTable LayDanhSachHocVien()
        {
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();
            using var da = new MySqlDataAdapter(@"
SELECT hv.Id AS `Mã`, hv.HoTen AS `Họ tên`, hv.GioiTinh AS `Giới tính`,
       hv.NgaySinh AS `Ngày sinh`, hv.SoDienThoai AS `SĐT`, kh.TenKH AS `Khóa học`,
       IF(hv.HocOnline = 1, 'Có', 'Không') AS `Online`, hv.NgayDangKy AS `Ngày đăng ký`
FROM HocVien hv JOIN KhoaHoc kh ON hv.MaKH = kh.MaKH
ORDER BY hv.Id DESC", conn);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void XoaHocVien(int id)
        {
            using var conn = new MySqlConnection(ConnStr);
            conn.Open();
            using var cmd = new MySqlCommand("DELETE FROM HocVien WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
