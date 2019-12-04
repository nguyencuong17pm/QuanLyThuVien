namespace GUI
{
    partial class frmTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaiKhoan));
            this.cboTenHT = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdSinhVien = new System.Windows.Forms.RadioButton();
            this.rdNhanVien = new System.Windows.Forms.RadioButton();
            this.cboTaiKhoan = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnLUU = new System.Windows.Forms.Button();
            this.hienmatkhau = new System.Windows.Forms.CheckBox();
            this.cboQuyenHan = new System.Windows.Forms.ComboBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.nmID = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.lbltieude = new System.Windows.Forms.Label();
            this.txttracuu = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtTenHT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmID)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTenHT
            // 
            this.cboTenHT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenHT.FormattingEnabled = true;
            this.cboTenHT.Location = new System.Drawing.Point(97, 78);
            this.cboTenHT.Name = "cboTenHT";
            this.cboTenHT.Size = new System.Drawing.Size(172, 21);
            this.cboTenHT.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Tên hiển thị";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(383, 40);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(140, 21);
            this.txtTaiKhoan.TabIndex = 1;
            this.txtTaiKhoan.TextChanged += new System.EventHandler(this.txtTaiKhoan_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "Tài khoản";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdSinhVien);
            this.groupBox3.Controls.Add(this.rdNhanVien);
            this.groupBox3.Controls.Add(this.cboTaiKhoan);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.cboTenHT);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(5, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 108);
            this.groupBox3.TabIndex = 89;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chọn loại tài khoản";
            // 
            // rdSinhVien
            // 
            this.rdSinhVien.AutoSize = true;
            this.rdSinhVien.Location = new System.Drawing.Point(14, 50);
            this.rdSinhVien.Name = "rdSinhVien";
            this.rdSinhVien.Size = new System.Drawing.Size(68, 17);
            this.rdSinhVien.TabIndex = 87;
            this.rdSinhVien.TabStop = true;
            this.rdSinhVien.Text = "Sinh viên";
            this.rdSinhVien.UseVisualStyleBackColor = true;
            this.rdSinhVien.CheckedChanged += new System.EventHandler(this.rdSinhVien_CheckedChanged);
            // 
            // rdNhanVien
            // 
            this.rdNhanVien.AutoSize = true;
            this.rdNhanVien.Location = new System.Drawing.Point(16, 20);
            this.rdNhanVien.Name = "rdNhanVien";
            this.rdNhanVien.Size = new System.Drawing.Size(73, 17);
            this.rdNhanVien.TabIndex = 86;
            this.rdNhanVien.TabStop = true;
            this.rdNhanVien.Text = "Nhân viên";
            this.rdNhanVien.UseVisualStyleBackColor = true;
            this.rdNhanVien.CheckedChanged += new System.EventHandler(this.rdNhanVien_CheckedChanged);
            // 
            // cboTaiKhoan
            // 
            this.cboTaiKhoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaiKhoan.FormattingEnabled = true;
            this.cboTaiKhoan.Location = new System.Drawing.Point(97, 19);
            this.cboTaiKhoan.Name = "cboTaiKhoan";
            this.cboTaiKhoan.Size = new System.Drawing.Size(121, 21);
            this.cboTaiKhoan.TabIndex = 69;
            this.cboTaiKhoan.SelectedIndexChanged += new System.EventHandler(this.cboTaiKhoan_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(97, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 88;
            // 
            // BtnLUU
            // 
            this.BtnLUU.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLUU.Image = ((System.Drawing.Image)(resources.GetObject("BtnLUU.Image")));
            this.BtnLUU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLUU.Location = new System.Drawing.Point(543, 147);
            this.BtnLUU.Name = "BtnLUU";
            this.BtnLUU.Size = new System.Drawing.Size(76, 36);
            this.BtnLUU.TabIndex = 68;
            this.BtnLUU.Text = "Lưu";
            this.BtnLUU.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLUU.UseVisualStyleBackColor = true;
            this.BtnLUU.Click += new System.EventHandler(this.BtnLUU_Click);
            // 
            // hienmatkhau
            // 
            this.hienmatkhau.AutoSize = true;
            this.hienmatkhau.Location = new System.Drawing.Point(383, 105);
            this.hienmatkhau.Name = "hienmatkhau";
            this.hienmatkhau.Size = new System.Drawing.Size(94, 17);
            this.hienmatkhau.TabIndex = 13;
            this.hienmatkhau.Text = "Hiện mật khẩu";
            this.hienmatkhau.UseVisualStyleBackColor = true;
            this.hienmatkhau.CheckedChanged += new System.EventHandler(this.hienmatkhau_CheckedChanged);
            // 
            // cboQuyenHan
            // 
            this.cboQuyenHan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuyenHan.FormattingEnabled = true;
            this.cboQuyenHan.Items.AddRange(new object[] {
            "Quản lý",
            "Nhân viên",
            "Sinh Viên"});
            this.cboQuyenHan.Location = new System.Drawing.Point(681, 79);
            this.cboQuyenHan.Name = "cboQuyenHan";
            this.cboQuyenHan.Size = new System.Drawing.Size(140, 21);
            this.cboQuyenHan.TabIndex = 4;
            this.cboQuyenHan.SelectedIndexChanged += new System.EventHandler(this.cboQuyenHan_SelectedIndexChanged);
            this.cboQuyenHan.TextChanged += new System.EventHandler(this.cboQuyenHan_TextChanged);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(383, 77);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(140, 21);
            this.txtMatKhau.TabIndex = 3;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // nmID
            // 
            this.nmID.Location = new System.Drawing.Point(102, 145);
            this.nmID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmID.Name = "nmID";
            this.nmID.ReadOnly = true;
            this.nmID.Size = new System.Drawing.Size(86, 21);
            this.nmID.TabIndex = 1;
            this.nmID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(585, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Quyền hạn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DgvTaiKhoan);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(189, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(899, 285);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bảng thông tin";
            // 
            // DgvTaiKhoan
            // 
            this.DgvTaiKhoan.AllowUserToAddRows = false;
            this.DgvTaiKhoan.AllowUserToDeleteRows = false;
            this.DgvTaiKhoan.BackgroundColor = System.Drawing.Color.Aqua;
            this.DgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTaiKhoan.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DgvTaiKhoan.Location = new System.Drawing.Point(6, 28);
            this.DgvTaiKhoan.Name = "DgvTaiKhoan";
            this.DgvTaiKhoan.ReadOnly = true;
            this.DgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTaiKhoan.Size = new System.Drawing.Size(877, 251);
            this.DgvTaiKhoan.TabIndex = 7;
            this.DgvTaiKhoan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvTaiKhoan_CellFormatting);
            this.DgvTaiKhoan.Click += new System.EventHandler(this.DgvTaiKhoan_Click);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnThem,
            this.btnSua,
            this.barButtonItem3,
            this.btnXoa,
            this.btnExit});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1250, 160);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 1;
            this.btnThem.ImageUri.Uri = "Add";
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 2;
            this.btnSua.ImageUri.Uri = "CustomizeGrid";
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Id = 4;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 5;
            this.btnXoa.ImageUri.Uri = "Cancel";
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 8;
            this.btnExit.ImageUri.Uri = "Forward";
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage1.Image")));
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnThem);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSua);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnXoa);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExit);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.BackColor = System.Drawing.Color.Transparent;
            this.lbltieude.Font = new System.Drawing.Font("Colonna MT", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.Location = new System.Drawing.Point(360, 9);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(521, 51);
            this.lbltieude.TabIndex = 36;
            this.lbltieude.Text = "DANH MỤC TÀI KHOẢN";
            // 
            // txttracuu
            // 
            this.txttracuu.Location = new System.Drawing.Point(5, 36);
            this.txttracuu.Name = "txttracuu";
            this.txttracuu.Size = new System.Drawing.Size(171, 21);
            this.txttracuu.TabIndex = 83;
            this.txttracuu.Text = "Nhập tài khoản cần tìm...";
            this.txttracuu.Click += new System.EventHandler(this.txttracuu_Click);
            this.txttracuu.TextChanged += new System.EventHandler(this.txttracuu_TextChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnHuy);
            this.groupControl1.Controls.Add(this.nmID);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtTenHT);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.txtTaiKhoan);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.groupBox3);
            this.groupControl1.Controls.Add(this.BtnLUU);
            this.groupControl1.Controls.Add(this.txtMatKhau);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.cboQuyenHan);
            this.groupControl1.Controls.Add(this.hienmatkhau);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Location = new System.Drawing.Point(184, 65);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1066, 187);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "THÔNG TIN TÀI KHOẢN";
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(446, 147);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(77, 36);
            this.btnHuy.TabIndex = 97;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click_1);
            // 
            // txtTenHT
            // 
            this.txtTenHT.Location = new System.Drawing.Point(682, 40);
            this.txtTenHT.Name = "txtTenHT";
            this.txtTenHT.Size = new System.Drawing.Size(140, 21);
            this.txtTenHT.TabIndex = 91;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(585, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "Tên hiển thị";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.button2);
            this.groupControl2.Controls.Add(this.txttracuu);
            this.groupControl2.Location = new System.Drawing.Point(2, 158);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(181, 94);
            this.groupControl2.TabIndex = 86;
            this.groupControl2.Text = "TÌM KIẾM";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(50, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 119;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 542);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.lbltieude);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài khoản";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmID)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button BtnLUU;
        private System.Windows.Forms.CheckBox hienmatkhau;
        public System.Windows.Forms.ComboBox cboQuyenHan;
        public System.Windows.Forms.TextBox txtMatKhau;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Label lbltieude;
        private System.Windows.Forms.ComboBox cboTaiKhoan;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton rdSinhVien;
        private System.Windows.Forms.RadioButton rdNhanVien;
        public System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown nmID;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox groupBox2;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox txttracuu;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView DgvTaiKhoan;
        public System.Windows.Forms.ComboBox cboTenHT;
        public System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public System.Windows.Forms.TextBox txtTenHT;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnHuy;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Button button2;
    }
}