namespace BaiTap5_2_DangKyHocVien
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                Database.KhoiTao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được MySQL.\nHãy bật MySQL trong XAMPP Control Panel rồi chạy lại.\n\nChi tiết: " + ex.Message,
                    "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmDangKy());
        }
    }
}
