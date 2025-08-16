namespace MDSolution
{
    partial class frm_GiaVanChuyen
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
            Janus.Windows.GridEX.GridEXLayout gdThongBaoGia_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GiaVanChuyen));
            this.grTB = new System.Windows.Forms.GroupBox();
            this.gdThongBaoGia = new Janus.Windows.GridEX.GridEX();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnMedium = new System.Windows.Forms.Panel();
            this.tabThietLapGiaMia = new Janus.Windows.UI.Tab.UITab();
            this.tabGiaMiaTaiRuong = new Janus.Windows.UI.Tab.UITabPage();
            this.pnMother = new System.Windows.Forms.Panel();
            this.grTittle = new Janus.Windows.EditControls.UIGroupBox();
            this.pnGiaMia = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdExit = new Janus.Windows.EditControls.UIButton();
            this.cbTinh = new Janus.Windows.EditControls.UIComboBox();
            this.cmdThem = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.grTB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdThongBaoGia)).BeginInit();
            this.pnTop.SuspendLayout();
            this.pnMedium.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabThietLapGiaMia)).BeginInit();
            this.tabThietLapGiaMia.SuspendLayout();
            this.tabGiaMiaTaiRuong.SuspendLayout();
            this.pnMother.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grTittle)).BeginInit();
            this.grTittle.SuspendLayout();
            this.pnGiaMia.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // grTB
            // 
            this.grTB.Controls.Add(this.gdThongBaoGia);
            this.grTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grTB.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTB.ForeColor = System.Drawing.Color.Green;
            this.grTB.Location = new System.Drawing.Point(0, 0);
            this.grTB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grTB.Name = "grTB";
            this.grTB.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grTB.Size = new System.Drawing.Size(1161, 348);
            this.grTB.TabIndex = 12;
            this.grTB.TabStop = false;
            this.grTB.Text = "Thông báo giá";
            // 
            // gdThongBaoGia
            // 
            this.gdThongBaoGia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdThongBaoGia.AutoEdit = true;
            this.gdThongBaoGia.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdThongBaoGia.ColumnAutoResize = true;
            this.gdThongBaoGia.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader;
            this.gdThongBaoGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdThongBaoGia.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdThongBaoGia.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdThongBaoGia.Font = new System.Drawing.Font("Arial", 9F);
            this.gdThongBaoGia.FrozenColumns = 2;
            this.gdThongBaoGia.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdThongBaoGia.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdThongBaoGia.GroupByBoxVisible = false;
            this.gdThongBaoGia.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gdThongBaoGia_Layout_0.IsCurrentLayout = true;
            gdThongBaoGia_Layout_0.Key = "tbl_NhapMia";
            gdThongBaoGia_Layout_0.LayoutString = resources.GetString("gdThongBaoGia_Layout_0.LayoutString");
            this.gdThongBaoGia.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdThongBaoGia_Layout_0});
            this.gdThongBaoGia.Location = new System.Drawing.Point(2, 21);
            this.gdThongBaoGia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gdThongBaoGia.Name = "gdThongBaoGia";
            this.gdThongBaoGia.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdThongBaoGia.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdThongBaoGia.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdThongBaoGia.ScrollBarWidth = 17;
            this.gdThongBaoGia.SelectedFormatStyle.BackColor = System.Drawing.Color.MediumAquamarine;
            this.gdThongBaoGia.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdThongBaoGia.Size = new System.Drawing.Size(1157, 324);
            this.gdThongBaoGia.TabIndex = 7;
            this.gdThongBaoGia.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdThongBaoGia.TotalRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdThongBaoGia.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdThongBaoGia.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.gdThongBaoGia.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdThongBaoGia.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005;
            this.gdThongBaoGia.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdMainGrid_ColumnButtonClick);
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1181, 41);
            this.pnTop.TabIndex = 21;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1181, 41);
            this.lblTitle.TabIndex = 148;
            this.lblTitle.Text = "THIẾT LẬP GIÁ VẬN CHUYỂN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnMedium
            // 
            this.pnMedium.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMedium.Controls.Add(this.tabThietLapGiaMia);
            this.pnMedium.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMedium.Location = new System.Drawing.Point(0, 41);
            this.pnMedium.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnMedium.Name = "pnMedium";
            this.pnMedium.Size = new System.Drawing.Size(1181, 462);
            this.pnMedium.TabIndex = 23;
            // 
            // tabThietLapGiaMia
            // 
            this.tabThietLapGiaMia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabThietLapGiaMia.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabThietLapGiaMia.ForeColor = System.Drawing.Color.Black;
            this.tabThietLapGiaMia.Location = new System.Drawing.Point(0, 0);
            this.tabThietLapGiaMia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabThietLapGiaMia.Name = "tabThietLapGiaMia";
            this.tabThietLapGiaMia.Size = new System.Drawing.Size(1177, 458);
            this.tabThietLapGiaMia.TabIndex = 61;
            this.tabThietLapGiaMia.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabGiaMiaTaiRuong});
            this.tabThietLapGiaMia.TabsStateStyles.SelectedFormatStyle.BackColor = System.Drawing.Color.CadetBlue;
            this.tabThietLapGiaMia.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.tabThietLapGiaMia.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.VS2005;
            // 
            // tabGiaMiaTaiRuong
            // 
            this.tabGiaMiaTaiRuong.Controls.Add(this.pnMother);
            this.tabGiaMiaTaiRuong.Location = new System.Drawing.Point(1, 26);
            this.tabGiaMiaTaiRuong.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabGiaMiaTaiRuong.Name = "tabGiaMiaTaiRuong";
            this.tabGiaMiaTaiRuong.Size = new System.Drawing.Size(1175, 431);
            this.tabGiaMiaTaiRuong.TabStop = true;
            this.tabGiaMiaTaiRuong.Text = "GIÁ VẬN CHUYỂN";
            // 
            // pnMother
            // 
            this.pnMother.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMother.Controls.Add(this.grTittle);
            this.pnMother.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMother.Location = new System.Drawing.Point(0, 0);
            this.pnMother.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnMother.Name = "pnMother";
            this.pnMother.Size = new System.Drawing.Size(1175, 431);
            this.pnMother.TabIndex = 4;
            // 
            // grTittle
            // 
            this.grTittle.Controls.Add(this.pnGiaMia);
            this.grTittle.Controls.Add(this.pnBottom);
            this.grTittle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grTittle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTittle.ForeColor = System.Drawing.Color.Maroon;
            this.grTittle.FormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.grTittle.Location = new System.Drawing.Point(0, 0);
            this.grTittle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grTittle.Name = "grTittle";
            this.grTittle.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Blue;
            this.grTittle.Size = new System.Drawing.Size(1171, 427);
            this.grTittle.TabIndex = 60;
            this.grTittle.Text = "GIÁ VẬN CHUYỂN THEO THÔNG BÁO";
            this.grTittle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.grTittle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // pnGiaMia
            // 
            this.pnGiaMia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnGiaMia.Controls.Add(this.grTB);
            this.pnGiaMia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGiaMia.Location = new System.Drawing.Point(3, 21);
            this.pnGiaMia.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnGiaMia.Name = "pnGiaMia";
            this.pnGiaMia.Size = new System.Drawing.Size(1165, 352);
            this.pnGiaMia.TabIndex = 153;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdExit);
            this.pnBottom.Controls.Add(this.cbTinh);
            this.pnBottom.Controls.Add(this.cmdThem);
            this.pnBottom.Controls.Add(this.label2);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(3, 373);
            this.pnBottom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1165, 51);
            this.pnBottom.TabIndex = 13;
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.Location = new System.Drawing.Point(1009, 9);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(138, 32);
            this.cmdExit.TabIndex = 27;
            this.cmdExit.Text = "Đóng";
            this.cmdExit.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdExit.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cbTinh
            // 
            this.cbTinh.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cbTinh.DisplayMember = "Ten";
            this.cbTinh.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTinh.ForeColor = System.Drawing.Color.Black;
            this.cbTinh.Location = new System.Drawing.Point(72, 13);
            this.cbTinh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbTinh.MaxDropDownItems = 100;
            this.cbTinh.Name = "cbTinh";
            this.cbTinh.ReadOnly = true;
            this.cbTinh.Size = new System.Drawing.Size(185, 25);
            this.cbTinh.TabIndex = 26;
            this.cbTinh.ValueMember = "ID";
            this.cbTinh.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cbTinh.SelectedIndexChanged += new System.EventHandler(this.cbTinh_SelectedIndexChanged);
            // 
            // cmdThem
            // 
            this.cmdThem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdThem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThem.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdThem.Icon")));
            this.cmdThem.Location = new System.Drawing.Point(284, 9);
            this.cmdThem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(138, 32);
            this.cmdThem.TabIndex = 24;
            this.cmdThem.Text = "Thêm TB giá";
            this.cmdThem.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(29, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tỉnh:";
            // 
            // frm_GiaVanChuyen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1181, 503);
            this.Controls.Add(this.pnMedium);
            this.Controls.Add(this.pnTop);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_GiaVanChuyen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thiết lập giá nhập mía";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_GiaVanChuyen_Load);
            this.grTB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdThongBaoGia)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnMedium.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabThietLapGiaMia)).EndInit();
            this.tabThietLapGiaMia.ResumeLayout(false);
            this.tabGiaMiaTaiRuong.ResumeLayout(false);
            this.pnMother.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grTittle)).EndInit();
            this.grTittle.ResumeLayout(false);
            this.pnGiaMia.ResumeLayout(false);
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grTB;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnMedium;
        private System.Windows.Forms.Panel pnBottom;
        internal Janus.Windows.GridEX.GridEX gdThongBaoGia;
        private System.Windows.Forms.Label lblTitle;
        private Janus.Windows.UI.Tab.UITab tabThietLapGiaMia;
        private Janus.Windows.UI.Tab.UITabPage tabGiaMiaTaiRuong;
        private System.Windows.Forms.Panel pnMother;
        private Janus.Windows.EditControls.UIGroupBox grTittle;
        private System.Windows.Forms.Panel pnGiaMia;
        private Janus.Windows.EditControls.UIButton cmdThem;
        private Janus.Windows.EditControls.UIComboBox cbTinh;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton cmdExit;
    }
}