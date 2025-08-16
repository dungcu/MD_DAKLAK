namespace MDSolution
{
    partial class frm_NhapTB_GiaVC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NhapTB_GiaVC));
            Janus.Windows.GridEX.GridEXLayout gdvHoTroVanChuyen_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmdOK = new Janus.Windows.EditControls.UIButton();
            this.cmdExit = new Janus.Windows.EditControls.UIButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtTenThongBao = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtHetNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nTapChat = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nGia = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.dtNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gdvHoTroVanChuyen = new Janus.Windows.GridEX.GridEX();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTapChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvHoTroVanChuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmdOK);
            this.panel3.Controls.Add(this.cmdExit);
            this.panel3.Location = new System.Drawing.Point(23, 312);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(516, 53);
            this.panel3.TabIndex = 30;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdOK.Icon")));
            this.cmdOK.Location = new System.Drawing.Point(38, 11);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(95, 32);
            this.cmdOK.TabIndex = 15;
            this.cmdOK.Text = "Lưu";
            this.cmdOK.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.Location = new System.Drawing.Point(392, 11);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(95, 32);
            this.cmdExit.TabIndex = 16;
            this.cmdExit.Text = "Thoát";
            this.cmdExit.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdExit.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtTenThongBao);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(0, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(551, 379);
            this.panel4.TabIndex = 2;
            // 
            // txtTenThongBao
            // 
            this.txtTenThongBao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTenThongBao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenThongBao.ForeColor = System.Drawing.Color.Black;
            this.txtTenThongBao.Location = new System.Drawing.Point(82, 14);
            this.txtTenThongBao.Name = "txtTenThongBao";
            this.txtTenThongBao.Size = new System.Drawing.Size(457, 25);
            this.txtTenThongBao.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtHetNgay);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nTapChat);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nGia);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dtNgay);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(23, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 243);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thời gian áp dụng và đơn giá";
            // 
            // dtHetNgay
            // 
            this.dtHetNgay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtHetNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtHetNgay.DropDownCalendar.Name = "";
            this.dtHetNgay.DropDownCalendar.Visible = false;
            this.dtHetNgay.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtHetNgay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHetNgay.ForeColor = System.Drawing.Color.Black;
            this.dtHetNgay.Location = new System.Drawing.Point(215, 92);
            this.dtHetNgay.Name = "dtHetNgay";
            this.dtHetNgay.Size = new System.Drawing.Size(261, 26);
            this.dtHetNgay.TabIndex = 26;
            this.dtHetNgay.Value = new System.DateTime(2021, 11, 22, 23, 59, 0, 0);
            this.dtHetNgay.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(17, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ngày kết thúc áp dụng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(330, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "(%) tạp chất bắt đầu tính";
            // 
            // nTapChat
            // 
            this.nTapChat.DecimalPlaces = 1;
            this.nTapChat.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nTapChat.Location = new System.Drawing.Point(215, 145);
            this.nTapChat.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nTapChat.Name = "nTapChat";
            this.nTapChat.Size = new System.Drawing.Size(107, 29);
            this.nTapChat.TabIndex = 22;
            this.nTapChat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nTapChat.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(543, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "(%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Bắt đầu từ tạp chất";
            // 
            // nGia
            // 
            this.nGia.DecimalPlaces = 1;
            this.nGia.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nGia.Location = new System.Drawing.Point(215, 193);
            this.nGia.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nGia.Name = "nGia";
            this.nGia.Size = new System.Drawing.Size(107, 29);
            this.nGia.TabIndex = 8;
            this.nGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nGia.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(330, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "(%)";
            // 
            // dtNgay
            // 
            this.dtNgay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgay.DropDownCalendar.Name = "";
            this.dtNgay.DropDownCalendar.Visible = false;
            this.dtNgay.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgay.ForeColor = System.Drawing.Color.Black;
            this.dtNgay.Location = new System.Drawing.Point(215, 38);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(261, 26);
            this.dtNgay.TabIndex = 7;
            this.dtNgay.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(17, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "% hỗ trợ (số dương)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(17, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Áp dụng từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(10, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên TB:";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.AliceBlue;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(551, 28);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "THIẾT LẬP THÔNG BÁO TRỪ GIÁ VẬN CHUYỂN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblTitle);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gdvHoTroVanChuyen);
            this.splitContainer1.Size = new System.Drawing.Size(1403, 412);
            this.splitContainer1.SplitterDistance = 551;
            this.splitContainer1.TabIndex = 31;
            // 
            // gdvHoTroVanChuyen
            // 
            this.gdvHoTroVanChuyen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdvHoTroVanChuyen.AutoEdit = true;
            this.gdvHoTroVanChuyen.AutomaticSort = false;
            this.gdvHoTroVanChuyen.CardCaptionFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdvHoTroVanChuyen.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdvHoTroVanChuyen.ColumnAutoResize = true;
            this.gdvHoTroVanChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvHoTroVanChuyen.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdvHoTroVanChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gdvHoTroVanChuyen.FrozenColumns = 2;
            this.gdvHoTroVanChuyen.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdvHoTroVanChuyen.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdvHoTroVanChuyen.GroupByBoxVisible = false;
            this.gdvHoTroVanChuyen.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gdvHoTroVanChuyen_Layout_0.IsCurrentLayout = true;
            gdvHoTroVanChuyen_Layout_0.Key = "tbl_DauTu";
            gdvHoTroVanChuyen_Layout_0.LayoutString = resources.GetString("gdvHoTroVanChuyen_Layout_0.LayoutString");
            this.gdvHoTroVanChuyen.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdvHoTroVanChuyen_Layout_0});
            this.gdvHoTroVanChuyen.Location = new System.Drawing.Point(0, 0);
            this.gdvHoTroVanChuyen.Name = "gdvHoTroVanChuyen";
            this.gdvHoTroVanChuyen.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdvHoTroVanChuyen.RowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdvHoTroVanChuyen.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdvHoTroVanChuyen.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdvHoTroVanChuyen.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdvHoTroVanChuyen.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical;
            this.gdvHoTroVanChuyen.ScrollBarWidth = 17;
            this.gdvHoTroVanChuyen.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gdvHoTroVanChuyen.Size = new System.Drawing.Size(848, 412);
            this.gdvHoTroVanChuyen.TabIndex = 5;
            this.gdvHoTroVanChuyen.TotalRowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Flat;
            this.gdvHoTroVanChuyen.TotalRowFormatStyle.BackColor = System.Drawing.Color.LightPink;
            this.gdvHoTroVanChuyen.TotalRowFormatStyle.BackgroundImageDrawMode = Janus.Windows.GridEX.BackgroundImageDrawMode.None;
            this.gdvHoTroVanChuyen.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdvHoTroVanChuyen.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.gdvHoTroVanChuyen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.gdvHoTroVanChuyen.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdvHoTroVanChuyen_ColumnButtonClick);
            this.gdvHoTroVanChuyen.LayoutLoad += new System.EventHandler(this.gdvHoTroVanChuyen_LayoutLoad);
            // 
            // frm_NhapTB_GiaVC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1403, 412);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frm_NhapTB_GiaVC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông báo giá giá vận chuyển trừ tạp chất";
            this.Load += new System.EventHandler(this.frm_NhapTB_GiaVC_Load);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTapChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGia)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvHoTroVanChuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private Janus.Windows.EditControls.UIButton cmdExit;
        private Janus.Windows.EditControls.UIButton cmdOK;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtTenThongBao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nGia;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal Janus.Windows.GridEX.GridEX gdvHoTroVanChuyen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nTapChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.CalendarCombo.CalendarCombo dtHetNgay;
        private System.Windows.Forms.Label label5;
    }
}