namespace GUI
{
    partial class frmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMatKhau));
            this.btndong = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.ckbhienthimk = new System.Windows.Forms.CheckBox();
            this.txtmkmoi1 = new System.Windows.Forms.TextBox();
            this.txtmkmoi2 = new System.Windows.Forms.TextBox();
            this.txtmkcu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.TenHT = new System.Windows.Forms.TextBox();
            this.QuyenHan = new System.Windows.Forms.TextBox();
            this.TK = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.dgvtk = new System.Windows.Forms.DataGridView();
            this.lbltieude = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtk)).BeginInit();
            this.SuspendLayout();
            // 
            // btndong
            // 
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndong.Image = global::GUI.Properties.Resources.iconfinder_exit_3226;
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(304, 236);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(86, 39);
            this.btndong.TabIndex = 15;
            this.btndong.Text = "Đóng  ";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnluu
            // 
            this.btnluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnluu.Image = global::GUI.Properties.Resources.iconfinder_Save_1493294;
            this.btnluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnluu.Location = new System.Drawing.Point(102, 236);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(82, 39);
            this.btnluu.TabIndex = 14;
            this.btnluu.Text = "Lưu    ";
            this.btnluu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // ckbhienthimk
            // 
            this.ckbhienthimk.AutoSize = true;
            this.ckbhienthimk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbhienthimk.Location = new System.Drawing.Point(216, 195);
            this.ckbhienthimk.Name = "ckbhienthimk";
            this.ckbhienthimk.Size = new System.Drawing.Size(128, 20);
            this.ckbhienthimk.TabIndex = 13;
            this.ckbhienthimk.Text = "Hiển thị mật khẩu";
            this.ckbhienthimk.UseVisualStyleBackColor = true;
            this.ckbhienthimk.CheckedChanged += new System.EventHandler(this.ckbhienthimk_CheckedChanged);
            // 
            // txtmkmoi1
            // 
            this.txtmkmoi1.Location = new System.Drawing.Point(216, 116);
            this.txtmkmoi1.Name = "txtmkmoi1";
            this.txtmkmoi1.PasswordChar = '●';
            this.txtmkmoi1.Size = new System.Drawing.Size(162, 20);
            this.txtmkmoi1.TabIndex = 1;
            this.txtmkmoi1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmkmoi1_KeyPress);
            // 
            // txtmkmoi2
            // 
            this.txtmkmoi2.Location = new System.Drawing.Point(216, 157);
            this.txtmkmoi2.Name = "txtmkmoi2";
            this.txtmkmoi2.PasswordChar = '●';
            this.txtmkmoi2.Size = new System.Drawing.Size(162, 20);
            this.txtmkmoi2.TabIndex = 12;
            this.txtmkmoi2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmkmoi2_KeyPress);
            // 
            // txtmkcu
            // 
            this.txtmkcu.Enabled = false;
            this.txtmkcu.Location = new System.Drawing.Point(216, 77);
            this.txtmkcu.Name = "txtmkcu";
            this.txtmkcu.PasswordChar = '●';
            this.txtmkcu.Size = new System.Drawing.Size(162, 20);
            this.txtmkcu.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Xác nhận mật khẩu mới";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(4, 319);
            this.ID.Name = "ID";
            this.ID.PasswordChar = '●';
            this.ID.Size = new System.Drawing.Size(62, 20);
            this.ID.TabIndex = 16;
            // 
            // TenHT
            // 
            this.TenHT.Location = new System.Drawing.Point(94, 319);
            this.TenHT.Name = "TenHT";
            this.TenHT.PasswordChar = '●';
            this.TenHT.Size = new System.Drawing.Size(62, 20);
            this.TenHT.TabIndex = 17;
            // 
            // QuyenHan
            // 
            this.QuyenHan.Location = new System.Drawing.Point(180, 319);
            this.QuyenHan.Name = "QuyenHan";
            this.QuyenHan.PasswordChar = '●';
            this.QuyenHan.Size = new System.Drawing.Size(62, 20);
            this.QuyenHan.TabIndex = 18;
            // 
            // TK
            // 
            this.TK.Location = new System.Drawing.Point(272, 319);
            this.TK.Name = "TK";
            this.TK.PasswordChar = '●';
            this.TK.Size = new System.Drawing.Size(62, 20);
            this.TK.TabIndex = 19;
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = global::GUI.Properties.Resources.iconfinder_edit_undo_118755;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(204, 236);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(77, 39);
            this.btnHuy.TabIndex = 96;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // dgvtk
            // 
            this.dgvtk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtk.Location = new System.Drawing.Point(359, 285);
            this.dgvtk.Name = "dgvtk";
            this.dgvtk.Size = new System.Drawing.Size(101, 54);
            this.dgvtk.TabIndex = 97;
            this.dgvtk.Click += new System.EventHandler(this.dgvtk_Click);
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.BackColor = System.Drawing.Color.Transparent;
            this.lbltieude.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.ForeColor = System.Drawing.Color.Black;
            this.lbltieude.Location = new System.Drawing.Point(142, 21);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(202, 36);
            this.lbltieude.TabIndex = 24;
            this.lbltieude.Text = "Đổi mật khẩu";
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 351);
            this.Controls.Add(this.lbltieude);
            this.Controls.Add(this.dgvtk);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.TK);
            this.Controls.Add(this.QuyenHan);
            this.Controls.Add(this.TenHT);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.ckbhienthimk);
            this.Controls.Add(this.txtmkmoi1);
            this.Controls.Add(this.txtmkmoi2);
            this.Controls.Add(this.txtmkcu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.CheckBox ckbhienthimk;
        private System.Windows.Forms.TextBox txtmkmoi1;
        private System.Windows.Forms.TextBox txtmkmoi2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtmkcu;
        public System.Windows.Forms.TextBox ID;
        public System.Windows.Forms.TextBox TenHT;
        public System.Windows.Forms.TextBox QuyenHan;
        public System.Windows.Forms.TextBox TK;
        public System.Windows.Forms.Button btnHuy;
        public System.Windows.Forms.DataGridView dgvtk;
        private System.Windows.Forms.Label lbltieude;
    }
}