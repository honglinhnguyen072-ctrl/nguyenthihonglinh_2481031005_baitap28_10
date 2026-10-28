using System.Text.RegularExpressions;

namespace BaiTap5_2_DangKyHocVien
{
    public partial class FrmDangKy : Form
    {
        public FrmDangKy()
        {
            InitializeComponent();
        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            try
            {
                // Danh sách khóa học lấy từ bảng KhoaHoc trong CSDL
                cboCourse.DataSource = Database.LayDanhSachKhoaHoc();
                cboCourse.DisplayMember = "TenKH";
                cboCourse.ValueMember = "MaKH";

                dtpBirthDate.MaxDate = DateTime.Today;
                dtpBirthDate.Value = DateTime.Today.AddYears(-18);

                TaiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDanhSach()
        {
            dgvHocVien.DataSource = Database.LayDanhSachHocVien();
            if (dgvHocVien.Columns.Contains("Ngày sinh"))
                dgvHocVien.Columns["Ngày sinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvHocVien.Columns.Contains("Ngày đăng ký"))
                dgvHocVien.Columns["Ngày đăng ký"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            lblTong.Text = "Tổng số học viên: " + dgvHocVien.Rows.Count;
        }

        private bool KiemTraNhapLieu()
        {
            errorProvider.Clear();
            bool hopLe = true;

            string hoTen = txtHoTen.Text.Trim();
            if (hoTen == "" || !Regex.IsMatch(hoTen, @"^[\p{L}\s]+$"))
            {
                errorProvider.SetError(txtHoTen, "Họ tên không được trống và chỉ gồm chữ cái");
                hopLe = false;
            }

            if (!mtxtPhone.MaskCompleted)
            {
                errorProvider.SetError(mtxtPhone, "Vui lòng nhập đủ 10 chữ số");
                hopLe = false;
            }

            if (cboCourse.SelectedValue == null)
            {
                errorProvider.SetError(cboCourse, "Vui lòng chọn khóa học");
                hopLe = false;
            }

            return hopLe;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhapLieu()) return;

            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string online = chkOnline.Checked ? "Có" : "Không";

            try
            {
                // Lưu thông tin đăng ký vào bảng HocVien
                Database.ThemHocVien(
                    txtHoTen.Text.Trim(),
                    gioiTinh,
                    dtpBirthDate.Value,
                    mtxtPhone.Text,
                    cboCourse.SelectedValue.ToString(),
                    chkOnline.Checked);

                // Tổng hợp và in thông tin đăng ký lên MessageBox (giữ yêu cầu bài 4.2)
                string thongTin = "Họ tên: " + txtHoTen.Text.Trim() + "\n"
                    + "Giới tính: " + gioiTinh + "\n"
                    + "Ngày sinh: " + dtpBirthDate.Value.ToString("dd/MM/yyyy") + "\n"
                    + "SĐT: " + mtxtPhone.Text + "\n"
                    + "Khóa học: " + cboCourse.Text + " (" + cboCourse.SelectedValue + ")" + "\n"
                    + "Học online: " + online + "\n\n"
                    + "Đã lưu vào CSDL ql_hocvien.";

                MessageBox.Show(thongTin, "Thông tin đăng ký",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LamMoiForm();
                TaiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHocVien.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn một học viên trong danh sách.", "Thông báo");
                return;
            }

            int id = Convert.ToInt32(dgvHocVien.CurrentRow.Cells["Mã"].Value);
            string ten = dgvHocVien.CurrentRow.Cells["Họ tên"].Value.ToString();

            if (MessageBox.Show("Xóa học viên \"" + ten + "\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                Database.XoaHocVien(id);
                TaiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            TaiDanhSach();
        }

        private void LamMoiForm()
        {
            errorProvider.Clear();
            txtHoTen.Clear();
            radNam.Checked = true;
            dtpBirthDate.Value = DateTime.Today.AddYears(-18);
            mtxtPhone.Clear();
            if (cboCourse.Items.Count > 0) cboCourse.SelectedIndex = 0;
            chkOnline.Checked = false;
            txtHoTen.Focus();
        }
    }
}
