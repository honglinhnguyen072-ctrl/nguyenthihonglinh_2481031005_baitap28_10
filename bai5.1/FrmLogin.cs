namespace BaiTap5_1_LoginForm
{
    public partial class FrmLogin : Form
    {
        private int soLanSai = 0;
        private const int SoLanSaiToiDa = 3;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private bool KiemTraNhapLieu()
        {
            errorProvider.Clear();

            if (txtUsername.Text.Trim() == "")
            {
                errorProvider.SetError(txtUsername, "Vui lòng nhập tên đăng nhập");
                txtUsername.Focus();
                return false;
            }

            if (txtPassword.Text == "")
            {
                errorProvider.SetError(txtPassword, "Vui lòng nhập mật khẩu");
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhapLieu()) return;

            string tenDangNhap = txtUsername.Text.Trim();

            try
            {
                string hoTen = Database.KiemTraDangNhap(tenDangNhap, txtPassword.Text);
                Database.GhiLichSu(tenDangNhap, hoTen != null);

                if (hoTen != null)
                {
                    soLanSai = 0;
                    MessageBox.Show("Đăng nhập thành công!\nXin chào " + hoTen + ".",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                soLanSai++;
                if (soLanSai >= SoLanSaiToiDa)
                {
                    MessageBox.Show("Bạn đã nhập sai " + SoLanSaiToiDa + " lần. Chương trình sẽ đóng.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                errorProvider.SetError(txtPassword,
                    "Sai tên đăng nhập hoặc mật khẩu (còn " + (SoLanSaiToiDa - soLanSai) + " lần thử)");
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhapLieu()) return;

            if (txtPassword.Text.Length < 6)
            {
                errorProvider.SetError(txtPassword, "Mật khẩu phải có ít nhất 6 ký tự");
                return;
            }

            try
            {
                string tenDangNhap = txtUsername.Text.Trim();
                if (Database.TaoTaiKhoan(tenDangNhap, txtPassword.Text, tenDangNhap))
                {
                    MessageBox.Show("Tạo tài khoản \"" + tenDangNhap + "\" thành công. Bây giờ bạn có thể đăng nhập.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    errorProvider.SetError(txtUsername, "Tên đăng nhập đã tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
