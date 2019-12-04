namespace GUI
{
    partial class frmCTMuonTra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCTMuonTra));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtpNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.CK1 = new System.Windows.Forms.CheckBox();
            this.CK0 = new System.Windows.Forms.CheckBox();
            this.ID = new System.Windows.Forms.ComboBox();
            this.dgvCTMuonTra = new System.Windows.Forms.DataGridView();
            this.cboMaSach = new System.Windows.Forms.ComboBox();
            this.cboMaMuonTra = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnInChiTiet = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.BtnLuu = new System.Windows.Forms.Button();
            this.lbltieude = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTMuonTra)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(518, 339);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 141;
            this.textBox1.Visible = false;
            // 
            // dtpNgayMuon
            // 
            this.dtpNgayMuon.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayMuon.Location = new System.Drawing.Point(117, 172);
            this.dtpNgayMuon.Name = "dtpNgayMuon";
            this.dtpNgayMuon.Size = new System.Drawing.Size(94, 26);
            this.dtpNgayMuon.TabIndex = 136;
            this.dtpNgayMuon.Value = new System.DateTime(2019, 10, 25, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(41, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 135;
            this.label5.Text = "Ngày trả";
            // 
            // CK1
            // 
            this.CK1.AutoSize = true;
            this.CK1.Location = new System.Drawing.Point(175, 147);
            this.CK1.Name = "CK1";
            this.CK1.Size = new System.Drawing.Size(36, 23);
            this.CK1.TabIndex = 134;
            this.CK1.Text = "1";
            this.CK1.UseVisualStyleBackColor = true;
            this.CK1.CheckedChanged += new System.EventHandler(this.CK1_CheckedChanged);
            // 
            // CK0
            // 
            this.CK0.AutoSize = true;
            this.CK0.Location = new System.Drawing.Point(116, 147);
            this.CK0.Name = "CK0";
            this.CK0.Size = new System.Drawing.Size(36, 23);
            this.CK0.TabIndex = 133;
            this.CK0.Text = "0";
            this.CK0.UseVisualStyleBackColor = true;
            this.CK0.CheckedChanged += new System.EventHandler(this.CK0_CheckedChanged);
            // 
            // ID
            // 
            this.ID.FormattingEnabled = true;
            this.ID.Location = new System.Drawing.Point(17, 244);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(172, 27);
            this.ID.TabIndex = 132;
            // 
            // dgvCTMuonTra
            // 
            this.dgvCTMuonTra.AllowUserToAddRows = false;
            this.dgvCTMuonTra.AllowUserToDeleteRows = false;
            this.dgvCTMuonTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvCTMuonTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTMuonTra.GridColor = System.Drawing.Color.Blue;
            this.dgvCTMuonTra.Location = new System.Drawing.Point(321, 21);
            this.dgvCTMuonTra.Name = "dgvCTMuonTra";
            this.dgvCTMuonTra.ReadOnly = true;
            this.dgvCTMuonTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCTMuonTra.Size = new System.Drawing.Size(717, 177);
            this.dgvCTMuonTra.TabIndex = 130;
            this.dgvCTMuonTra.Click += new System.EventHandler(this.dgvCTMuonTra_Click);
            // 
            // cboMaSach
            // 
            this.cboMaSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaSach.FormattingEnabled = true;
            this.cboMaSach.Location = new System.Drawing.Point(117, 104);
            this.cboMaSach.Name = "cboMaSach";
            this.cboMaSach.Size = new System.Drawing.Size(198, 27);
            this.cboMaSach.TabIndex = 130;
            // 
            // cboMaMuonTra
            // 
            this.cboMaMuonTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaMuonTra.FormattingEnabled = true;
            this.cboMaMuonTra.Location = new System.Drawing.Point(117, 60);
            this.cboMaMuonTra.Name = "cboMaMuonTra";
            this.cboMaMuonTra.Size = new System.Drawing.Size(198, 27);
            this.cboMaMuonTra.TabIndex = 129;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(55, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 102;
            this.label6.Text = "Đã trả";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(116, 204);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(922, 26);
            this.txtGhiChu.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(41, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 98;
            this.label4.Text = "Ghi chú";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(41, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(31, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã mượn ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpNgayMuon);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CK1);
            this.groupBox1.Controls.Add(this.CK0);
            this.groupBox1.Controls.Add(this.ID);
            this.groupBox1.Controls.Add(this.dgvCTMuonTra);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnInChiTiet);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.cboMaSach);
            this.groupBox1.Controls.Add(this.cboMaMuonTra);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Controls.Add(this.BtnLuu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(15, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1044, 282);
            this.groupBox1.TabIndex = 139;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin ";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::GUI.Properties.Resources.dddd1;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(217, 21);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(85, 36);
            this.btnXoa.TabIndex = 100;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnInChiTiet
            // 
            this.btnInChiTiet.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInChiTiet.Image = global::GUI.Properties.Resources.iconfinder_Print_27870;
            this.btnInChiTiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInChiTiet.Location = new System.Drawing.Point(503, 235);
            this.btnInChiTiet.Name = "btnInChiTiet";
            this.btnInChiTiet.Size = new System.Drawing.Size(119, 36);
            this.btnInChiTiet.TabIndex = 131;
            this.btnInChiTiet.Text = "In chi tiết";
            this.btnInChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInChiTiet.UseVisualStyleBackColor = true;
            this.btnInChiTiet.Click += new System.EventHandler(this.btnInChiTiet_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::GUI.Properties.Resources.iconfinder_Edit_18910261;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(117, 21);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(76, 36);
            this.btnSua.TabIndex = 98;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::GUI.Properties.Resources.iconfinder_1_416882;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(9, 21);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 36);
            this.btnThem.TabIndex = 99;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = global::GUI.Properties.Resources.iconfinder_edit_undo_118755;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(287, 235);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(77, 36);
            this.btnHuy.TabIndex = 97;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // BtnLuu
            // 
            this.BtnLuu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLuu.Image = global::GUI.Properties.Resources.iconfinder_Save_1493294;
            this.BtnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLuu.Location = new System.Drawing.Point(398, 235);
            this.BtnLuu.Name = "BtnLuu";
            this.BtnLuu.Size = new System.Drawing.Size(76, 36);
            this.BtnLuu.TabIndex = 67;
            this.BtnLuu.Text = "Lưu";
            this.BtnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLuu.UseVisualStyleBackColor = true;
            this.BtnLuu.Click += new System.EventHandler(this.BtnLuu_Click);
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.BackColor = System.Drawing.Color.Transparent;
            this.lbltieude.Font = new System.Drawing.Font("Colonna MT", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.Location = new System.Drawing.Point(371, 9);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(348, 39);
            this.lbltieude.TabIndex = 138;
            this.lbltieude.Text = "CHI TIẾT MƯỢN TRẢ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::GUI.Properties.Resources.QuiDinh;
            this.pictureBox1.Location = new System.Drawing.Point(32, 339);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(475, 67);
            this.pictureBox1.TabIndex = 140;
            this.pictureBox1.TabStop = false;
            // 
            // frmCTMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 423);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbltieude);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCTMuonTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết mượn trả";
            this.Load += new System.EventHandler(this.frmCTMuonTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTMuonTra)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtpNgayMuon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CK1;
        private System.Windows.Forms.CheckBox CK0;
        private System.Windows.Forms.ComboBox ID;
        private System.Windows.Forms.DataGridView dgvCTMuonTra;
        public System.Windows.Forms.Button btnXoa;
        public System.Windows.Forms.Button btnInChiTiet;
        public System.Windows.Forms.Button btnSua;
        public System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cboMaSach;
        private System.Windows.Forms.ComboBox cboMaMuonTra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnHuy;
        public System.Windows.Forms.Button BtnLuu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbltieude;
    }
}