# Bài tập 5.1 – Login Form lưu trữ CSDL (nâng cấp Bài 4.1)

**Sinh viên:** Nguyễn Thị Hồng Linh – MSSV 24810310005 – Lớp D19QTANM1 – Lập trình .NET

## Nội dung nâng cấp
Bài 4.1 chỉ kiểm tra ô trống rồi báo "Đăng nhập thành công". Bài 5.1 lưu tài khoản trong **MySQL** và kiểm tra đăng nhập thật:

- Giữ nguyên yêu cầu 4.1: `txtUsername`, `txtPassword`, `chkShowPassword`, `btnLogin`, `btnExit`, `errorProvider`; Enter = Đăng nhập (`AcceptButton`), Esc = Thoát (`CancelButton`); không để trống bằng `ErrorProvider`.
- **CSDL `ql_dangnhap`**
  - `TaiKhoan`: tên đăng nhập, mật khẩu đã băm **SHA-256** (không lưu mật khẩu gốc), họ tên, ngày tạo.
  - `LichSuDangNhap`: ghi lại mọi lần đăng nhập thành công / thất bại.
- Truy vấn dùng **tham số** (`@u`, `@p`) để chống SQL Injection.
- Nút **Tạo tài khoản** thêm tài khoản mới vào CSDL (mật khẩu ≥ 6 ký tự, báo lỗi nếu trùng tên).
- Sai mật khẩu 3 lần thì chương trình tự đóng.
- Chương trình **tự tạo CSDL + bảng + tài khoản mẫu** khi chạy lần đầu.

Tài khoản mẫu: **admin / 123456**

## Hình ảnh minh họa

**1. Giao diện bình thường** – nhập tài khoản, tick "Hiện mật khẩu" để xem mật khẩu.
<img width="308" height="234" alt="Screenshot 2026-10-28 182948" src="https://github.com/user-attachments/assets/6ffa5da0-53ea-43e9-81ca-aa098771794d" />


**2. Nhập lỗi** – để trống tên đăng nhập rồi bấm Đăng nhập, `ErrorProvider` báo lỗi cạnh ô nhập.


<img width="344" height="181" alt="Screenshot 2026-10-28 182611" src="https://github.com/user-attachments/assets/971db531-6723-4f98-857b-ab45640ed3ff" />

**3. Thêm tài khoản thành công** – bấm "Tạo tài khoản", tài khoản mới được lưu vào bảng `TaiKhoan` trong MySQL.

<img width="327" height="232" alt="Screenshot 2026-10-28 183131" src="https://github.com/user-attachments/assets/31c27e7e-5d74-4e1c-88f3-2629e5a59c5f" />

**4. Đăng nhập thành công** – mật khẩu được kiểm tra với dữ liệu trong CSDL.

<img width="244" height="185" alt="Screenshot 2026-10-28 182642" src="https://github.com/user-attachments/assets/7a7fe340-1607-4787-acc7-fc51d58b0484" />


## Cách chạy
1. Cài XAMPP, mở **XAMPP Control Panel** → **Start MySQL** (mặc định user `root`, không mật khẩu, cổng 3306).
2. Mở `BaiTap5_1_LoginForm.csproj` bằng Visual Studio 2022+ (.NET 10). NuGet tự tải gói `MySqlConnector`.
3. Nhấn **F5**. (Tùy chọn: chạy `database.sql` trong phpMyAdmin để tạo CSDL thủ công.)

Nếu MySQL có mật khẩu, sửa chuỗi kết nối trong `Database.cs`.
# Bài tập 5.2 – Form đăng ký học viên lưu trữ CSDL (nâng cấp Bài 4.2)


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
<img width="325" height="132" alt="Screenshot 2026-10-28 183429" src="https://github.com/user-attachments/assets/253ea29b-8b45-4ddd-ba23-8e4fafb67680" />



**2. Nhập lỗi** – họ tên có ký tự đặc biệt, số điện thoại chưa đủ, `ErrorProvider` báo lỗi cạnh từng ô.

<img width="519" height="205" alt="Screenshot 2026-10-28 183158" src="https://github.com/user-attachments/assets/cd347cfb-1101-4e8a-a2fd-7fe1335f037f" />


**3. Thêm học viên thành công** – bấm "Đăng ký", thông tin được tổng hợp lên MessageBox và lưu vào bảng `HocVien`.


<img width="371" height="141" alt="Screenshot 2026-10-28 183518" src="https://github.com/user-attachments/assets/d9ee67ce-1056-4160-9750-cecbc80257b8" />

## Cách chạy
1. Cài XAMPP, mở **XAMPP Control Panel** → **Start MySQL** (mặc định user `root`, không mật khẩu, cổng 3306).
2. Mở `BaiTap5_2_DangKyHocVien.csproj` bằng Visual Studio 2022+ (.NET 10). NuGet tự tải gói `MySqlConnector`.
3. Nhấn **F5**. (Tùy chọn: chạy `database.sql` trong phpMyAdmin để tạo CSDL thủ công.)

Nếu MySQL có mật khẩu, sửa chuỗi kết nối trong `Database.cs`.
