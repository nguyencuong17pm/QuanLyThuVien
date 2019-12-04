namespace GUI
{
    partial class frmBCMuonTra
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBCMuonTra));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDieuKien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDanhSach = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnXem = new System.Windows.Forms.Button();
            this.CTMuonTra_DTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CTMuonTra_DTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDieuKien);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboDanhSach);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(43, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 139);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm ";
            // 
            // cboDieuKien
            // 
            this.cboDieuKien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDieuKien.FormattingEnabled = true;
            this.cboDieuKien.Items.AddRange(new object[] {
            "Mã mượn trả",
            "Tình trạng"});
            this.cboDieuKien.Location = new System.Drawing.Point(155, 23);
            this.cboDieuKien.Name = "cboDieuKien";
            this.cboDieuKien.Size = new System.Drawing.Size(154, 32);
            this.cboDieuKien.TabIndex = 4;
            this.cboDieuKien.SelectedIndexChanged += new System.EventHandler(this.cboDieuKien_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn";
            // 
            // cboDanhSach
            // 
            this.cboDanhSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhSach.FormattingEnabled = true;
            this.cboDanhSach.Location = new System.Drawing.Point(414, 23);
            this.cboDanhSach.Name = "cboDanhSach";
            this.cboDanhSach.Size = new System.Drawing.Size(188, 32);
            this.cboDanhSach.TabIndex = 1;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CTMuonTra_DTOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.rpChiTiet.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(10, 146);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(767, 277);
            this.reportViewer1.TabIndex = 6;
            // 
            // btnXem
            // 
            this.btnXem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Image = global::GUI.Properties.Resources.iconfinder_edit_find_replace_118921;
            this.btnXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXem.Location = new System.Drawing.Point(312, 72);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(103, 61);
            this.btnXem.TabIndex = 2;
            this.btnXem.Text = "Xem";
            this.btnXem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // CTMuonTra_DTOBindingSource
            // 
            this.CTMuonTra_DTOBindingSource.DataSource = typeof(DTO.CTMuonTra_DTO);
            // 
            // frmBCMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBCMuonTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo chi tiết mượn trả";
            this.Load += new System.EventHandler(this.frmBCMuonTra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CTMuonTra_DTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDieuKien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDanhSach;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.BindingSource CTMuonTra_DTOBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}