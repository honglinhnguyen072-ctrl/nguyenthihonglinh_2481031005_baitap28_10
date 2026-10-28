namespace BaiTap5_1_LoginForm
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox();
            btnLogin = new Button();
            btnRegister = new Button();
            btnExit = new Button();
            lblHint = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(30, 33);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(30, 73);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            //
            // txtUsername
            //
            txtUsername.Location = new Point(130, 30);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(210, 23);
            txtUsername.TabIndex = 2;
            //
            // txtPassword
            //
            txtPassword.Location = new Point(130, 70);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(210, 23);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            //
            // chkShowPassword
            //
            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new Point(130, 105);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(104, 19);
            chkShowPassword.TabIndex = 4;
            chkShowPassword.Text = "Hiện mật khẩu";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            //
            // btnLogin
            //
            btnLogin.Location = new Point(30, 140);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(95, 30);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            //
            // btnRegister
            //
            btnRegister.Location = new Point(138, 140);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(95, 30);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Tạo tài khoản";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            //
            // btnExit
            //
            btnExit.Location = new Point(245, 140);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(95, 30);
            btnExit.TabIndex = 7;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            //
            // lblHint
            //
            lblHint.AutoSize = true;
            lblHint.ForeColor = Color.Gray;
            lblHint.Location = new Point(30, 185);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(250, 15);
            lblHint.TabIndex = 8;
            lblHint.Text = "Tài khoản mẫu: admin / 123456 (lưu trong MySQL)";
            //
            // errorProvider
            //
            errorProvider.ContainerControl = this;
            //
            // FrmLogin
            //
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(375, 215);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(chkShowPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(btnExit);
            Controls.Add(lblHint);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Button btnExit;
        private Label lblHint;
        private ErrorProvider errorProvider;
    }
}
