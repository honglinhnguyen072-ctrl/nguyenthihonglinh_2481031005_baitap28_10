namespace BaiTap5_1_LoginForm
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

            Application.Run(new FrmLogin());
        }
    }
}
