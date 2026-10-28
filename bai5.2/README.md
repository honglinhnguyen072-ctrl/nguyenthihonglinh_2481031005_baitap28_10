# Bài tập 5.2 – Form đăng ký học viên lưu trữ CSDL (nâng cấp Bài 4.2)

**Sinh viên:** Trần Nhật Đông – MSSV 24810320177 – Lớp D19QTANM1 – Lập trình .NET

## Nội dung nâng cấp
Bài 4.2 chỉ in thông tin đăng ký ra MessageBox, danh sách khóa học viết cứng trong code. Bài 5.2 lưu toàn bộ vào **MySQL**:

- Giữ nguyên yêu cầu 4.2: `mtxtPhone` mask `(000) 000-0000`, `dtpBirthDate` Format Short, `cboCourse` binding `DisplayMember`/`ValueMember`, RadioButton giới tính, CheckBox học online, nút **Đăng ký** tổng hợp thông tin lên MessageBox.
- **CSDL `ql_hocvien`**
  - `KhoaHoc` (MaKH, TenKH): `cboCourse` nạp danh sách từ bảng này.
  - `HocVien` (họ tên, giới tính, ngày sinh, SĐT, mã khóa học – khóa ngoại tới `KhoaHoc`, học online, ngày đăng ký).
- Nút **Đăng ký** → `INSERT` học viên vào CSDL (truy vấn có tham số), rồi cập nhật lưới.
- **DataGridView** hiển thị danh sách học viên đã đăng ký (JOIN với `KhoaHoc`), có nút **Xóa** (xác nhận Yes/No) và **Làm mới**.
- Kiểm tra dữ liệu bằng `ErrorProvider`: họ tên không trống, chỉ chữ cái; SĐT phải nhập đủ.
- Chương trình **tự tạo CSDL + bảng + 3 khóa học mẫu** khi chạy lần đầu.

## Hình ảnh minh họa

**1. Giao diện bình thường** – danh sách học viên đọc từ CSDL hiển thị trên DataGridView.

![Giao diện chính](docs/bai5_2_main.jpg)

**2. Nhập lỗi** – họ tên có ký tự đặc biệt, số điện thoại chưa đủ, `ErrorProvider` báo lỗi cạnh từng ô.

![Bắt lỗi nhập liệu](docs/bai5_2_error.jpg)

**3. Thêm học viên thành công** – bấm "Đăng ký", thông tin được tổng hợp lên MessageBox và lưu vào bảng `HocVien`.

![Đăng ký thành công](docs/bai5_2_add.jpg)

## Cách chạy
1. Cài XAMPP, mở **XAMPP Control Panel** → **Start MySQL** (mặc định user `root`, không mật khẩu, cổng 3306).
2. Mở `BaiTap5_2_DangKyHocVien.csproj` bằng Visual Studio 2022+ (.NET 10). NuGet tự tải gói `MySqlConnector`.
3. Nhấn **F5**. (Tùy chọn: chạy `database.sql` trong phpMyAdmin để tạo CSDL thủ công.)

Nếu MySQL có mật khẩu, sửa chuỗi kết nối trong `Database.cs`.
