namespace MDSolution
{
    partial class frmChuyenXe
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
            Janus.Windows.GridEX.GridEXLayout gdvChiTietVC_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuyenXe));
            this.cbChuHDVC_Di = new System.Windows.Forms.ComboBox();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdCa2 = new System.Windows.Forms.RadioButton();
            this.rdMoi = new System.Windows.Forms.RadioButton();
            this.rdCu = new System.Windows.Forms.RadioButton();
            this.cmd_OK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdTim = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXeVC = new System.Windows.Forms.TextBox();
            this.cbHDVC_Den = new System.Windows.Forms.ComboBox();
            this.chk_MTBC = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSoXe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gdvChiTietVC = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvChiTietVC)).BeginInit();
            this.SuspendLayout();
            // 
            // cbChuHDVC_Di
            // 
            this.cbChuHDVC_Di.DisplayMember = "Ten";
            this.cbChuHDVC_Di.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChuHDVC_Di.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChuHDVC_Di.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cbChuHDVC_Di.FormattingEnabled = true;
            this.cbChuHDVC_Di.Location = new System.Drawing.Point(92, 60);
            this.cbChuHDVC_Di.Name = "cbChuHDVC_Di";
            this.cbChuHDVC_Di.Size = new System.Drawing.Size(410, 26);
            this.cbChuHDVC_Di.TabIndex = 25;
            this.cbChuHDVC_Di.ValueMember = "ID";
            this.cbChuHDVC_Di.SelectedIndexChanged += new System.EventHandler(this.cbChuHDVC_Di_SelectedIndexChanged);
            // 
            // uiTab1
            // 
            this.uiTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTab1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTab1.Location = new System.Drawing.Point(0, 0);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(1119, 527);
            this.uiTab1.TabIndex = 25;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1});
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007;
            this.uiTab1.VisualStyleManager = this.visualStyleManager1;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.button1);
            this.uiTabPage1.Controls.Add(this.groupBox2);
            this.uiTabPage1.Controls.Add(this.cmd_OK);
            this.uiTabPage1.Controls.Add(this.groupBox3);
            this.uiTabPage1.Controls.Add(this.panel2);
            this.uiTabPage1.Controls.Add(this.panel1);
            this.uiTabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTabPage1.Location = new System.Drawing.Point(1, 24);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(1117, 502);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "Chuyển xe - Phiếu cân";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(914, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 38);
            this.button1.TabIndex = 46;
            this.button1.TabStop = false;
            this.button1.Text = "&CLOSE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdCa2);
            this.groupBox2.Controls.Add(this.rdMoi);
            this.groupBox2.Controls.Add(this.rdCu);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Location = new System.Drawing.Point(837, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 179);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tuỳ chọn";
            // 
            // rdCa2
            // 
            this.rdCa2.AutoSize = true;
            this.rdCa2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCa2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdCa2.Location = new System.Drawing.Point(16, 140);
            this.rdCa2.Name = "rdCa2";
            this.rdCa2.Size = new System.Drawing.Size(155, 18);
            this.rdCa2.TabIndex = 2;
            this.rdCa2.Text = "Xe sẽ chạy ở cả hai HĐVC";
            this.rdCa2.UseVisualStyleBackColor = true;
            this.rdCa2.CheckedChanged += new System.EventHandler(this.rdCa2_CheckedChanged);
            // 
            // rdMoi
            // 
            this.rdMoi.AutoSize = true;
            this.rdMoi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdMoi.Location = new System.Drawing.Point(16, 87);
            this.rdMoi.Name = "rdMoi";
            this.rdMoi.Size = new System.Drawing.Size(222, 18);
            this.rdMoi.TabIndex = 1;
            this.rdMoi.Text = "Xe sẽ chạy ở HĐVC mới từ ngày chuyển";
            this.rdMoi.UseVisualStyleBackColor = true;
            this.rdMoi.CheckedChanged += new System.EventHandler(this.rdMoi_CheckedChanged);
            // 
            // rdCu
            // 
            this.rdCu.AutoSize = true;
            this.rdCu.Checked = true;
            this.rdCu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdCu.Location = new System.Drawing.Point(16, 33);
            this.rdCu.Name = "rdCu";
            this.rdCu.Size = new System.Drawing.Size(144, 18);
            this.rdCu.TabIndex = 0;
            this.rdCu.TabStop = true;
            this.rdCu.Text = "Xe vẫn chạy ở HĐVC cũ";
            this.rdCu.UseVisualStyleBackColor = true;
            this.rdCu.CheckedChanged += new System.EventHandler(this.rdCu_CheckedChanged);
            // 
            // cmd_OK
            // 
            this.cmd_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_OK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_OK.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cmd_OK.Location = new System.Drawing.Point(914, 362);
            this.cmd_OK.Name = "cmd_OK";
            this.cmd_OK.Size = new System.Drawing.Size(142, 38);
            this.cmd_OK.TabIndex = 31;
            this.cmd_OK.TabStop = false;
            this.cmd_OK.Text = "&CHUYỂN";
            this.cmd_OK.UseVisualStyleBackColor = true;
            this.cmd_OK.Click += new System.EventHandler(this.cmd_OK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.cmdTim);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtXeVC);
            this.groupBox3.Controls.Add(this.cbHDVC_Den);
            this.groupBox3.Controls.Add(this.chk_MTBC);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbSoXe);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbChuHDVC_Di);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(11, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1095, 129);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tuỳ chọn Xe - Phiếu cân";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::DACASUCO.Properties.Resources.end;
            this.pictureBox1.Location = new System.Drawing.Point(566, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // cmdTim
            // 
            this.cmdTim.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTim.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdTim.Location = new System.Drawing.Point(283, 24);
            this.cmdTim.Name = "cmdTim";
            this.cmdTim.Size = new System.Drawing.Size(97, 26);
            this.cmdTim.TabIndex = 39;
            this.cmdTim.Text = "Tìm kiếm";
            this.cmdTim.UseVisualStyleBackColor = true;
            this.cmdTim.Click += new System.EventHandler(this.cmdTim_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(43, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "Số xe:";
            // 
            // txtXeVC
            // 
            this.txtXeVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXeVC.Location = new System.Drawing.Point(92, 24);
            this.txtXeVC.Name = "txtXeVC";
            this.txtXeVC.Size = new System.Drawing.Size(174, 26);
            this.txtXeVC.TabIndex = 37;
            this.txtXeVC.Click += new System.EventHandler(this.txtXeVC_Click);
            this.txtXeVC.TextChanged += new System.EventHandler(this.txtXeVC_TextChanged);
            this.txtXeVC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXeVC_KeyPress);
            // 
            // cbHDVC_Den
            // 
            this.cbHDVC_Den.DisplayMember = "Ten";
            this.cbHDVC_Den.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHDVC_Den.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHDVC_Den.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cbHDVC_Den.FormattingEnabled = true;
            this.cbHDVC_Den.Location = new System.Drawing.Point(665, 62);
            this.cbHDVC_Den.Name = "cbHDVC_Den";
            this.cbHDVC_Den.Size = new System.Drawing.Size(410, 26);
            this.cbHDVC_Den.TabIndex = 36;
            this.cbHDVC_Den.ValueMember = "ID";
            // 
            // chk_MTBC
            // 
            this.chk_MTBC.AutoSize = true;
            this.chk_MTBC.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_MTBC.ForeColor = System.Drawing.Color.Maroon;
            this.chk_MTBC.Location = new System.Drawing.Point(284, 98);
            this.chk_MTBC.Name = "chk_MTBC";
            this.chk_MTBC.Size = new System.Drawing.Size(216, 21);
            this.chk_MTBC.TabIndex = 33;
            this.chk_MTBC.Text = "Bao gồm phiếu mua tại BC";
            this.chk_MTBC.UseVisualStyleBackColor = true;
            this.chk_MTBC.CheckedChanged += new System.EventHandler(this.chk_MTBC_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(768, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 18);
            this.label3.TabIndex = 35;
            this.label3.Text = "Chọn HĐVC mà Xe sẽ chuyển đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(44, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "Số xe:";
            // 
            // cbSoXe
            // 
            this.cbSoXe.DisplayMember = "Ten";
            this.cbSoXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSoXe.FormattingEnabled = true;
            this.cbSoXe.Location = new System.Drawing.Point(92, 96);
            this.cbSoXe.Name = "cbSoXe";
            this.cbSoXe.Size = new System.Drawing.Size(174, 24);
            this.cbSoXe.TabIndex = 35;
            this.cbSoXe.ValueMember = "ID";
            this.cbSoXe.SelectedIndexChanged += new System.EventHandler(this.cbSoXe_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Chọn HĐVC:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.gdvChiTietVC);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 361);
            this.panel2.TabIndex = 44;
            // 
            // gdvChiTietVC
            // 
            this.gdvChiTietVC.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdvChiTietVC.AutoEdit = true;
            this.gdvChiTietVC.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdvChiTietVC.ColumnAutoResize = true;
            this.gdvChiTietVC.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader;
            this.gdvChiTietVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvChiTietVC.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdvChiTietVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gdvChiTietVC.FrozenColumns = 2;
            this.gdvChiTietVC.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdvChiTietVC.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdvChiTietVC.GroupByBoxVisible = false;
            this.gdvChiTietVC.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gdvChiTietVC_Layout_0.IsCurrentLayout = true;
            gdvChiTietVC_Layout_0.Key = "tbl_NhapMia";
            gdvChiTietVC_Layout_0.LayoutString = resources.GetString("gdvChiTietVC_Layout_0.LayoutString");
            this.gdvChiTietVC.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdvChiTietVC_Layout_0});
            this.gdvChiTietVC.Location = new System.Drawing.Point(0, 0);
            this.gdvChiTietVC.Name = "gdvChiTietVC";
            this.gdvChiTietVC.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdvChiTietVC.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdvChiTietVC.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdvChiTietVC.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdvChiTietVC.ScrollBarWidth = 17;
            this.gdvChiTietVC.SelectedFormatStyle.BackColor = System.Drawing.Color.DarkKhaki;
            this.gdvChiTietVC.Size = new System.Drawing.Size(827, 357);
            this.gdvChiTietVC.TabIndex = 6;
            this.gdvChiTietVC.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdvChiTietVC.TotalRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdvChiTietVC.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdvChiTietVC.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.gdvChiTietVC.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdvChiTietVC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.gdvChiTietVC.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.gdvChiTietVC_RowCheckStateChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1117, 141);
            this.panel1.TabIndex = 43;
            // 
            // frmChuyenXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 527);
            this.Controls.Add(this.uiTab1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChuyenXe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển xe của HĐVC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChuyenXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvChiTietVC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private System.Windows.Forms.ComboBox cbChuHDVC_Di;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmd_OK;
        private System.Windows.Forms.ComboBox cbHDVC_Den;
        private System.Windows.Forms.CheckBox chk_MTBC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSoXe;
        internal Janus.Windows.GridEX.GridEX gdvChiTietVC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdCa2;
        private System.Windows.Forms.RadioButton rdMoi;
        private System.Windows.Forms.RadioButton rdCu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdTim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtXeVC;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}