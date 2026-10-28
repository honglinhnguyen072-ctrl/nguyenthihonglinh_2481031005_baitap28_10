namespace BaiTap5_2_DangKyHocVien
{
    partial class FrmDangKy
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtHoTen = new TextBox();
            radNam = new RadioButton();
            radNu = new RadioButton();
            dtpBirthDate = new DateTimePicker();
            mtxtPhone = new MaskedTextBox();
            cboCourse = new ComboBox();
            chkOnline = new CheckBox();
            btnDangKy = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            dgvHocVien = new DataGridView();
            lblTong = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvHocVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Họ tên";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(30, 65);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Giới tính";
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(30, 100);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Ngày sinh";
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(30, 135);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 3;
            label4.Text = "Số điện thoại";
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(30, 170);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 4;
            label5.Text = "Khóa học";
            //
            // txtHoTen
            //
            txtHoTen.Location = new Point(130, 27);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 23);
            txtHoTen.TabIndex = 5;
            //
            // radNam
            //
            radNam.AutoSize = true;
            radNam.Checked = true;
            radNam.Location = new Point(130, 63);
            radNam.Name = "radNam";
            radNam.Size = new Size(51, 19);
            radNam.TabIndex = 6;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            //
            // radNu
            //
            radNu.AutoSize = true;
            radNu.Location = new Point(200, 63);
            radNu.Name = "radNu";
            radNu.Size = new Size(41, 19);
            radNu.TabIndex = 7;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            //
            // dtpBirthDate
            //
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(130, 97);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(200, 23);
            dtpBirthDate.TabIndex = 8;
            //
            // mtxtPhone
            //
            mtxtPhone.Location = new Point(130, 132);
            mtxtPhone.Mask = "(000) 000-0000";
            mtxtPhone.Name = "mtxtPhone";
            mtxtPhone.Size = new Size(200, 23);
            mtxtPhone.TabIndex = 9;
            //
            // cboCourse
            //
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FormattingEnabled = true;
            cboCourse.Location = new Point(130, 167);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(200, 23);
            cboCourse.TabIndex = 10;
            //
            // chkOnline
            //
            chkOnline.AutoSize = true;
            chkOnline.Location = new Point(130, 202);
            chkOnline.Name = "chkOnline";
            chkOnline.Size = new Size(85, 19);
            chkOnline.TabIndex = 11;
            chkOnline.Text = "Học online";
            chkOnline.UseVisualStyleBackColor = true;
            //
            // btnDangKy
            //
            btnDangKy.Location = new Point(30, 240);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(95, 30);
            btnDangKy.TabIndex = 12;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(133, 240);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(95, 30);
            btnLamMoi.TabIndex = 13;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(236, 240);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(95, 30);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            //
            // dgvHocVien
            //
            dgvHocVien.AllowUserToAddRows = false;
            dgvHocVien.AllowUserToDeleteRows = false;
            dgvHocVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHocVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHocVien.Location = new Point(360, 27);
            dgvHocVien.MultiSelect = false;
            dgvHocVien.Name = "dgvHocVien";
            dgvHocVien.ReadOnly = true;
            dgvHocVien.RowHeadersVisible = false;
            dgvHocVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHocVien.Size = new Size(600, 243);
            dgvHocVien.TabIndex = 15;
            //
            // lblTong
            //
            lblTong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTong.AutoSize = true;
            lblTong.Location = new Point(360, 280);
            lblTong.Name = "lblTong";
            lblTong.Size = new Size(110, 15);
            lblTong.TabIndex = 16;
            lblTong.Text = "Tổng số học viên: 0";
            //
            // errorProvider
            //
            errorProvider.ContainerControl = this;
            //
            // FrmDangKy
            //
            AcceptButton = btnDangKy;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 310);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(txtHoTen);
            Controls.Add(radNam);
            Controls.Add(radNu);
            Controls.Add(dtpBirthDate);
            Controls.Add(mtxtPhone);
            Controls.Add(cboCourse);
            Controls.Add(chkOnline);
            Controls.Add(btnDangKy);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(dgvHocVien);
            Controls.Add(lblTong);
            MinimumSize = new Size(900, 349);
            Name = "FrmDangKy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký học viên (lưu MySQL)";
            Load += FrmDangKy_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHocVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtHoTen;
        private RadioButton radNam;
        private RadioButton radNu;
        private DateTimePicker dtpBirthDate;
        private MaskedTextBox mtxtPhone;
        private ComboBox cboCourse;
        private CheckBox chkOnline;
        private Button btnDangKy;
        private Button btnLamMoi;
        private Button btnXoa;
        private DataGridView dgvHocVien;
        private Label lblTong;
        private ErrorProvider errorProvider;
    }
}
