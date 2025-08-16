namespace DACASUCO.MDForms
{
    partial class frmSuaTTVC
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
            Janus.Windows.GridEX.GridEXLayout gdvChitietvanchuyen_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuaTTVC));
            this.label1 = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.txtKHHD = new System.Windows.Forms.TextBox();
            this.txtSoHD = new System.Windows.Forms.TextBox();
            this.cbLoaiHD = new System.Windows.Forms.ComboBox();
            this.cbHTTT = new System.Windows.Forms.ComboBox();
            this.txtDV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMST = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDC = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoXe = new System.Windows.Forms.TextBox();
            this.txtHDVC = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gdvChitietvanchuyen = new Janus.Windows.GridEX.GridEX();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTienVC = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.txtTC = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTT = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTienVAT = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lblSP = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvChitietvanchuyen)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại hóa đơn";
            // 
            // dtNgay
            // 
            this.dtNgay.CustomFormat = "dd/MM/yyyy";
            this.dtNgay.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgay.Location = new System.Drawing.Point(431, 269);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(108, 22);
            this.dtNgay.TabIndex = 1;
            // 
            // txtKHHD
            // 
            this.txtKHHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKHHD.Location = new System.Drawing.Point(123, 42);
            this.txtKHHD.Name = "txtKHHD";
            this.txtKHHD.Size = new System.Drawing.Size(121, 22);
            this.txtKHHD.TabIndex = 2;
            // 
            // txtSoHD
            // 
            this.txtSoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHD.Location = new System.Drawing.Point(431, 236);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.Size = new System.Drawing.Size(108, 22);
            this.txtSoHD.TabIndex = 3;
            // 
            // cbLoaiHD
            // 
            this.cbLoaiHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiHD.FormattingEnabled = true;
            this.cbLoaiHD.Items.AddRange(new object[] {
            "Có VAT",
            "Không VAT"});
            this.cbLoaiHD.Location = new System.Drawing.Point(124, 75);
            this.cbLoaiHD.Name = "cbLoaiHD";
            this.cbLoaiHD.Size = new System.Drawing.Size(121, 24);
            this.cbLoaiHD.TabIndex = 4;
            // 
            // cbHTTT
            // 
            this.cbHTTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHTTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHTTT.FormattingEnabled = true;
            this.cbHTTT.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản"});
            this.cbHTTT.Location = new System.Drawing.Point(431, 306);
            this.cbHTTT.Name = "cbHTTT";
            this.cbHTTT.Size = new System.Drawing.Size(108, 24);
            this.cbHTTT.TabIndex = 7;
            // 
            // txtDV
            // 
            this.txtDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDV.Location = new System.Drawing.Point(136, 349);
            this.txtDV.Name = "txtDV";
            this.txtDV.Size = new System.Drawing.Size(403, 22);
            this.txtDV.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hình thức thanh toán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(93, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(691, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "CẬP NHẬT THÔNG TIN PHIẾU THANH TOÁN VẬN CHUYỂN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(374, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ký hiệu hóa đơn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mã số thuế";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(346, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Số hóa đơn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Đơn vị cung cấp";
            // 
            // txtMST
            // 
            this.txtMST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMST.Location = new System.Drawing.Point(123, 112);
            this.txtMST.Name = "txtMST";
            this.txtMST.Size = new System.Drawing.Size(121, 22);
            this.txtMST.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(64, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Địa chỉ";
            // 
            // txtDC
            // 
            this.txtDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDC.Location = new System.Drawing.Point(136, 386);
            this.txtDC.Name = "txtDC";
            this.txtDC.Size = new System.Drawing.Size(403, 22);
            this.txtDC.TabIndex = 15;
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(123, 19);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 25);
            this.cmdOK.TabIndex = 17;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(690, 470);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 25);
            this.cmdCancel.TabIndex = 18;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtMST);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbLoaiHD);
            this.groupBox1.Controls.Add(this.txtKHHD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(12, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 234);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn VAT";
            // 
            // txtSoXe
            // 
            this.txtSoXe.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSoXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoXe.Location = new System.Drawing.Point(75, 32);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.ReadOnly = true;
            this.txtSoXe.Size = new System.Drawing.Size(96, 22);
            this.txtSoXe.TabIndex = 20;
            this.txtSoXe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHDVC
            // 
            this.txtHDVC.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtHDVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHDVC.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtHDVC.Location = new System.Drawing.Point(272, 33);
            this.txtHDVC.Name = "txtHDVC";
            this.txtHDVC.ReadOnly = true;
            this.txtHDVC.Size = new System.Drawing.Size(268, 22);
            this.txtHDVC.TabIndex = 21;
            this.txtHDVC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Số xe";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtHDVC);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtSoXe);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(12, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 84);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin HĐVC";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(190, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "Chủ HĐVC";
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhieu.ForeColor = System.Drawing.Color.Teal;
            this.lblSoPhieu.Location = new System.Drawing.Point(305, 55);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(125, 16);
            this.lblSoPhieu.TabIndex = 24;
            this.lblSoPhieu.Text = "Số phiếu thanh toán";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gdvChitietvanchuyen);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(575, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 176);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết vận chuyển";
            // 
            // gdvChitietvanchuyen
            // 
            this.gdvChitietvanchuyen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdvChitietvanchuyen.AutoEdit = true;
            this.gdvChitietvanchuyen.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdvChitietvanchuyen.ColumnAutoResize = true;
            this.gdvChitietvanchuyen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader;
            this.gdvChitietvanchuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvChitietvanchuyen.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdvChitietvanchuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdvChitietvanchuyen.FrozenColumns = 2;
            this.gdvChitietvanchuyen.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdvChitietvanchuyen.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdvChitietvanchuyen.GroupByBoxVisible = false;
            this.gdvChitietvanchuyen.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gdvChitietvanchuyen_Layout_0.IsCurrentLayout = true;
            gdvChitietvanchuyen_Layout_0.Key = "tbl_NhapMia";
            gdvChitietvanchuyen_Layout_0.LayoutString = resources.GetString("gdvChitietvanchuyen_Layout_0.LayoutString");
            this.gdvChitietvanchuyen.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdvChitietvanchuyen_Layout_0});
            this.gdvChitietvanchuyen.Location = new System.Drawing.Point(3, 16);
            this.gdvChitietvanchuyen.Name = "gdvChitietvanchuyen";
            this.gdvChitietvanchuyen.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdvChitietvanchuyen.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdvChitietvanchuyen.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical;
            this.gdvChitietvanchuyen.ScrollBarWidth = 17;
            this.gdvChitietvanchuyen.SelectedFormatStyle.BackColor = System.Drawing.Color.DarkKhaki;
            this.gdvChitietvanchuyen.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdvChitietvanchuyen.Size = new System.Drawing.Size(257, 157);
            this.gdvChitietvanchuyen.TabIndex = 6;
            this.gdvChitietvanchuyen.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdvChitietvanchuyen.TotalRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdvChitietvanchuyen.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdvChitietvanchuyen.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.gdvChitietvanchuyen.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdvChitietvanchuyen.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(590, 302);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "Tổng tiền VC";
            // 
            // txtTienVC
            // 
            this.txtTienVC.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTienVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienVC.Location = new System.Drawing.Point(686, 296);
            this.txtTienVC.Name = "txtTienVC";
            this.txtTienVC.ReadOnly = true;
            this.txtTienVC.Size = new System.Drawing.Size(109, 22);
            this.txtTienVC.TabIndex = 27;
            this.txtTienVC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(639, 328);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 16);
            this.label13.TabIndex = 28;
            this.label13.Text = "VAT";
            // 
            // txtVAT
            // 
            this.txtVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVAT.ForeColor = System.Drawing.Color.Red;
            this.txtVAT.Location = new System.Drawing.Point(686, 325);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(72, 22);
            this.txtVAT.TabIndex = 29;
            this.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVAT.TextChanged += new System.EventHandler(this.txtVAT_TextChanged);
            // 
            // txtTC
            // 
            this.txtTC.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTC.Location = new System.Drawing.Point(687, 383);
            this.txtTC.Name = "txtTC";
            this.txtTC.ReadOnly = true;
            this.txtTC.Size = new System.Drawing.Size(108, 22);
            this.txtTC.TabIndex = 31;
            this.txtTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(594, 385);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 16);
            this.label14.TabIndex = 30;
            this.label14.Text = "Thu thế chân";
            // 
            // txtTT
            // 
            this.txtTT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTT.Location = new System.Drawing.Point(687, 412);
            this.txtTT.Name = "txtTT";
            this.txtTT.ReadOnly = true;
            this.txtTT.Size = new System.Drawing.Size(108, 22);
            this.txtTT.TabIndex = 33;
            this.txtTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(579, 414);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 16);
            this.label15.TabIndex = 32;
            this.label15.Text = "Tiền thanh toán";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(801, 299);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 16);
            this.label16.TabIndex = 34;
            this.label16.Text = "đ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(764, 328);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 16);
            this.label17.TabIndex = 35;
            this.label17.Text = "%";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(801, 388);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 16);
            this.label18.TabIndex = 36;
            this.label18.Text = "đ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(801, 415);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(16, 16);
            this.label19.TabIndex = 37;
            this.label19.Text = "đ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(612, 356);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 16);
            this.label20.TabIndex = 38;
            this.label20.Text = "Tiền VAT";
            // 
            // txtTienVAT
            // 
            this.txtTienVAT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTienVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienVAT.Location = new System.Drawing.Point(687, 353);
            this.txtTienVAT.Name = "txtTienVAT";
            this.txtTienVAT.ReadOnly = true;
            this.txtTienVAT.Size = new System.Drawing.Size(108, 22);
            this.txtTienVAT.TabIndex = 39;
            this.txtTienVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(801, 352);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 16);
            this.label21.TabIndex = 40;
            this.label21.Text = "đ";
            // 
            // lblSP
            // 
            this.lblSP.AutoSize = true;
            this.lblSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSP.ForeColor = System.Drawing.Color.Maroon;
            this.lblSP.Location = new System.Drawing.Point(436, 49);
            this.lblSP.Name = "lblSP";
            this.lblSP.Size = new System.Drawing.Size(94, 24);
            this.lblSP.TabIndex = 41;
            this.lblSP.Text = "Số phiếu";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmdOK);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(12, 455);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(823, 51);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thao tác cập nhật";
            // 
            // frmSuaTTVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 512);
            this.Controls.Add(this.lblSP);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtTienVAT);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtTT);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTC);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTienVC);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblSoPhieu);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.txtDC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbHTTT);
            this.Controls.Add(this.txtDV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoHD);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuaTTVC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sua phieu thanh toan van chuyen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvChitietvanchuyen)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.DateTimePicker dtNgay;
        public System.Windows.Forms.TextBox txtKHHD;
        public System.Windows.Forms.TextBox txtSoHD;
        public System.Windows.Forms.ComboBox cbLoaiHD;
        public System.Windows.Forms.ComboBox cbHTTT;
        public System.Windows.Forms.TextBox txtDV;
        public System.Windows.Forms.TextBox txtMST;
        public System.Windows.Forms.TextBox txtDC;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtSoXe;
        public System.Windows.Forms.TextBox txtHDVC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.GroupBox groupBox3;
        internal Janus.Windows.GridEX.GridEX gdvChitietvanchuyen;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtTienVC;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtVAT;
        public System.Windows.Forms.TextBox txtTC;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtTT;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox txtTienVAT;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblSP;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}