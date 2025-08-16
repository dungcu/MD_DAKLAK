namespace MDSolution
{
    partial class frmBangKeThuMua
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txt_sophieu = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblVT = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbDV = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.cmdIn = new System.Windows.Forms.Button();
            this.dgvNhapMia = new System.Windows.Forms.DataGridView();
            this.SoPhieuNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayVanChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoCMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrongLuongMiaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaMia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienMia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDGBQ = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbThanhTien = new System.Windows.Forms.Label();
            this.lbTLMiaSach = new System.Windows.Forms.Label();
            this.lbl_tongxe = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapMia)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // txt_sophieu
            // 
            this.txt_sophieu.Location = new System.Drawing.Point(135, 46);
            this.txt_sophieu.Name = "txt_sophieu";
            this.txt_sophieu.Size = new System.Drawing.Size(153, 20);
            this.txt_sophieu.TabIndex = 5;
            this.txt_sophieu.Text = "Nguyễn Bá Thành";
            this.toolTip.SetToolTip(this.txt_sophieu, "Nhập tiếng Việt có dấu. Ví dụ: Thừa tướng Đoàn Ngọc Sơn");
            this.txt_sophieu.Click += new System.EventHandler(this.txt_sophieu_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblVT);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.lbDV);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txt_sophieu);
            this.panel3.Controls.Add(this.dtDenNgay);
            this.panel3.Controls.Add(this.dtTuNgay);
            this.panel3.Controls.Add(this.cmdIn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1103, 76);
            this.panel3.TabIndex = 10;
            // 
            // lblVT
            // 
            this.lblVT.AutoSize = true;
            this.lblVT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblVT.Location = new System.Drawing.Point(82, 13);
            this.lblVT.Name = "lblVT";
            this.lblVT.Size = new System.Drawing.Size(30, 19);
            this.lblVT.TabIndex = 32;
            this.lblVT.Text = "VT";
            this.lblVT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(14, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "Niên vụ:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(10, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 17);
            this.label13.TabIndex = 30;
            this.label13.Text = "Tên người thu mua";
            // 
            // lbDV
            // 
            this.lbDV.AutoSize = true;
            this.lbDV.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDV.ForeColor = System.Drawing.Color.Blue;
            this.lbDV.Location = new System.Drawing.Point(346, 7);
            this.lbDV.Name = "lbDV";
            this.lbDV.Size = new System.Drawing.Size(513, 31);
            this.lbDV.TabIndex = 22;
            this.lbDV.Text = "BẢNG KÊ THU MUA THEO THỜI GIAN";
            this.lbDV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(581, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Đến ngày";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(432, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Từ ngày";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(638, 45);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(87, 20);
            this.dtDenNgay.TabIndex = 23;
            this.dtDenNgay.ValueChanged += new System.EventHandler(this.dtDenNgay_ValueChanged);
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(482, 46);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(86, 20);
            this.dtTuNgay.TabIndex = 21;
            this.dtTuNgay.ValueChanged += new System.EventHandler(this.dtTuNgay_ValueChanged);
            // 
            // cmdIn
            // 
            this.cmdIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIn.Location = new System.Drawing.Point(895, 42);
            this.cmdIn.Name = "cmdIn";
            this.cmdIn.Size = new System.Drawing.Size(95, 24);
            this.cmdIn.TabIndex = 3;
            this.cmdIn.Text = "In Bảng kê";
            this.cmdIn.UseVisualStyleBackColor = true;
            this.cmdIn.Click += new System.EventHandler(this.cmdIn_Click);
            // 
            // dgvNhapMia
            // 
            this.dgvNhapMia.AllowUserToAddRows = false;
            this.dgvNhapMia.AllowUserToDeleteRows = false;
            this.dgvNhapMia.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvNhapMia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNhapMia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSalmon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhapMia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhapMia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhapMia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoPhieuNhap,
            this.NgayVanChuyen,
            this.HoTen,
            this.DiaChi,
            this.SoCMT,
            this.TrongLuongMiaSach,
            this.DonGiaMia,
            this.TienMia});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhapMia.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvNhapMia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhapMia.GridColor = System.Drawing.Color.Black;
            this.dgvNhapMia.Location = new System.Drawing.Point(0, 0);
            this.dgvNhapMia.MultiSelect = false;
            this.dgvNhapMia.Name = "dgvNhapMia";
            this.dgvNhapMia.ReadOnly = true;
            this.dgvNhapMia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhapMia.Size = new System.Drawing.Size(1099, 368);
            this.dgvNhapMia.TabIndex = 2;
            // 
            // SoPhieuNhap
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Format = "#####";
            dataGridViewCellStyle2.NullValue = null;
            this.SoPhieuNhap.DefaultCellStyle = dataGridViewCellStyle2;
            this.SoPhieuNhap.HeaderText = "Số phiếu";
            this.SoPhieuNhap.Name = "SoPhieuNhap";
            this.SoPhieuNhap.ReadOnly = true;
            this.SoPhieuNhap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SoPhieuNhap.Width = 70;
            // 
            // NgayVanChuyen
            // 
            this.NgayVanChuyen.DataPropertyName = "NgayVanChuyen";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.NgayVanChuyen.DefaultCellStyle = dataGridViewCellStyle3;
            this.NgayVanChuyen.HeaderText = "Ngày thu mua";
            this.NgayVanChuyen.Name = "NgayVanChuyen";
            this.NgayVanChuyen.ReadOnly = true;
            this.NgayVanChuyen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NgayVanChuyen.Width = 115;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HoTen.DefaultCellStyle = dataGridViewCellStyle4;
            this.HoTen.HeaderText = "Người bán";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HoTen.Width = 230;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 300;
            // 
            // SoCMT
            // 
            this.SoCMT.DataPropertyName = "SoCMT";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SoCMT.DefaultCellStyle = dataGridViewCellStyle5;
            this.SoCMT.HeaderText = "Số CMND";
            this.SoCMT.Name = "SoCMT";
            this.SoCMT.ReadOnly = true;
            this.SoCMT.Width = 120;
            // 
            // TrongLuongMiaSach
            // 
            this.TrongLuongMiaSach.DataPropertyName = "TrongLuongMiaSach";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.Format = "###,###,###";
            dataGridViewCellStyle6.NullValue = null;
            this.TrongLuongMiaSach.DefaultCellStyle = dataGridViewCellStyle6;
            this.TrongLuongMiaSach.HeaderText = "TLMS";
            this.TrongLuongMiaSach.Name = "TrongLuongMiaSach";
            this.TrongLuongMiaSach.ReadOnly = true;
            this.TrongLuongMiaSach.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DonGiaMia
            // 
            this.DonGiaMia.DataPropertyName = "DonGiaMia";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.DonGiaMia.DefaultCellStyle = dataGridViewCellStyle7;
            this.DonGiaMia.HeaderText = "Giá 10CCS";
            this.DonGiaMia.Name = "DonGiaMia";
            this.DonGiaMia.ReadOnly = true;
            // 
            // TienMia
            // 
            this.TienMia.DataPropertyName = "TienMia";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.Format = "###,###,###";
            dataGridViewCellStyle8.NullValue = null;
            this.TienMia.DefaultCellStyle = dataGridViewCellStyle8;
            this.TienMia.HeaderText = "Thành tiền";
            this.TienMia.Name = "TienMia";
            this.TienMia.ReadOnly = true;
            this.TienMia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TienMia.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tổng phiếu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblDGBQ);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbThanhTien);
            this.panel1.Controls.Add(this.lbTLMiaSach);
            this.panel1.Controls.Add(this.lbl_tongxe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 448);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 49);
            this.panel1.TabIndex = 9;
            // 
            // lblDGBQ
            // 
            this.lblDGBQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDGBQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDGBQ.ForeColor = System.Drawing.Color.Red;
            this.lblDGBQ.Location = new System.Drawing.Point(248, 21);
            this.lblDGBQ.Name = "lblDGBQ";
            this.lblDGBQ.Size = new System.Drawing.Size(65, 22);
            this.lblDGBQ.TabIndex = 11;
            this.lblDGBQ.Text = "500000";
            this.lblDGBQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(262, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "ĐG BQ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(368, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tổng tiền mía";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(147, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tổng TL MS";
            // 
            // lbThanhTien
            // 
            this.lbThanhTien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThanhTien.ForeColor = System.Drawing.Color.DarkRed;
            this.lbThanhTien.Location = new System.Drawing.Point(339, 20);
            this.lbThanhTien.Name = "lbThanhTien";
            this.lbThanhTien.Size = new System.Drawing.Size(123, 22);
            this.lbThanhTien.TabIndex = 1;
            this.lbThanhTien.Text = "500000";
            this.lbThanhTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTLMiaSach
            // 
            this.lbTLMiaSach.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTLMiaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTLMiaSach.ForeColor = System.Drawing.Color.Green;
            this.lbTLMiaSach.Location = new System.Drawing.Point(117, 21);
            this.lbTLMiaSach.Name = "lbTLMiaSach";
            this.lbTLMiaSach.Size = new System.Drawing.Size(104, 22);
            this.lbTLMiaSach.TabIndex = 1;
            this.lbTLMiaSach.Text = "500000";
            this.lbTLMiaSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_tongxe
            // 
            this.lbl_tongxe.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_tongxe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_tongxe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tongxe.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbl_tongxe.Location = new System.Drawing.Point(7, 21);
            this.lbl_tongxe.Name = "lbl_tongxe";
            this.lbl_tongxe.Size = new System.Drawing.Size(81, 22);
            this.lbl_tongxe.TabIndex = 1;
            this.lbl_tongxe.Text = "500000";
            this.lbl_tongxe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvNhapMia);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1103, 372);
            this.panel2.TabIndex = 11;
            // 
            // frmBangKeThuMua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmBangKeThuMua";
            this.Text = "Bảng kê thu mua theo thời gian";
            this.Load += new System.EventHandler(this.frmBangKeThuMua_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapMia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbDV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.TextBox txt_sophieu;
        private System.Windows.Forms.Button cmdIn;
        private System.Windows.Forms.DataGridView dgvNhapMia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDGBQ;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbThanhTien;
        private System.Windows.Forms.Label lbTLMiaSach;
        private System.Windows.Forms.Label lbl_tongxe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayVanChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoCMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrongLuongMiaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaMia;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienMia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVT;
    }
}