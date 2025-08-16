namespace DACASUCO.MDForms
{
    partial class frmShowRP2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowRP2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CheckDieuKien = new System.Windows.Forms.CheckBox();
            this.pnDotThanhToan = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.nudDotThanhToan = new System.Windows.Forms.NumericUpDown();
            this.pnNgayThang = new System.Windows.Forms.Panel();
            this.dtNgayLoc = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.pnDienTichToiThieu = new System.Windows.Forms.Panel();
            this.txtDienTichToiThieu = new System.Windows.Forms.TextBox();
            this.lbDienTichToiThieu = new System.Windows.Forms.Label();
            this.btHienThi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnTuNgayDenNgay = new System.Windows.Forms.Panel();
            this.lbDenNgay = new System.Windows.Forms.Label();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lbTuNgay = new System.Windows.Forms.Label();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.pnTuyChon = new System.Windows.Forms.Panel();
            this.btcancel = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            this.dgvChanTrang = new System.Windows.Forms.DataGridView();
            this.Vitri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.btTuyChonChanTrang = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnDotThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDotThanhToan)).BeginInit();
            this.pnNgayThang.SuspendLayout();
            this.pnDienTichToiThieu.SuspendLayout();
            this.pnTuNgayDenNgay.SuspendLayout();
            this.pnTuyChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 620);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 29);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "status";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(360, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(91, 22);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.CheckDieuKien);
            this.panel2.Controls.Add(this.pnDotThanhToan);
            this.panel2.Controls.Add(this.pnNgayThang);
            this.panel2.Controls.Add(this.pnDienTichToiThieu);
            this.panel2.Controls.Add(this.btHienThi);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 27);
            this.panel2.TabIndex = 3;
            // 
            // CheckDieuKien
            // 
            this.CheckDieuKien.AutoSize = true;
            this.CheckDieuKien.Location = new System.Drawing.Point(526, 6);
            this.CheckDieuKien.Name = "CheckDieuKien";
            this.CheckDieuKien.Size = new System.Drawing.Size(15, 14);
            this.CheckDieuKien.TabIndex = 8;
            this.CheckDieuKien.UseVisualStyleBackColor = true;
            this.CheckDieuKien.Visible = false;
            this.CheckDieuKien.CheckedChanged += new System.EventHandler(this.CheckDieuKien_CheckedChanged);
            // 
            // pnDotThanhToan
            // 
            this.pnDotThanhToan.Controls.Add(this.label5);
            this.pnDotThanhToan.Controls.Add(this.nudDotThanhToan);
            this.pnDotThanhToan.Location = new System.Drawing.Point(5, 0);
            this.pnDotThanhToan.Name = "pnDotThanhToan";
            this.pnDotThanhToan.Size = new System.Drawing.Size(301, 27);
            this.pnDotThanhToan.TabIndex = 7;
            this.pnDotThanhToan.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đợt thanh toán:";
            // 
            // nudDotThanhToan
            // 
            this.nudDotThanhToan.Location = new System.Drawing.Point(193, 4);
            this.nudDotThanhToan.Name = "nudDotThanhToan";
            this.nudDotThanhToan.Size = new System.Drawing.Size(45, 20);
            this.nudDotThanhToan.TabIndex = 0;
            // 
            // pnNgayThang
            // 
            this.pnNgayThang.Controls.Add(this.dtNgayLoc);
            this.pnNgayThang.Controls.Add(this.label4);
            this.pnNgayThang.Location = new System.Drawing.Point(1, 0);
            this.pnNgayThang.Name = "pnNgayThang";
            this.pnNgayThang.Size = new System.Drawing.Size(298, 27);
            this.pnNgayThang.TabIndex = 6;
            // 
            // dtNgayLoc
            // 
            this.dtNgayLoc.CustomFormat = "dd/MM/yyyy";
            this.dtNgayLoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayLoc.Location = new System.Drawing.Point(171, 4);
            this.dtNgayLoc.Name = "dtNgayLoc";
            this.dtNgayLoc.Size = new System.Drawing.Size(114, 20);
            this.dtNgayLoc.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày";
            // 
            // pnDienTichToiThieu
            // 
            this.pnDienTichToiThieu.Controls.Add(this.txtDienTichToiThieu);
            this.pnDienTichToiThieu.Controls.Add(this.lbDienTichToiThieu);
            this.pnDienTichToiThieu.Location = new System.Drawing.Point(12, 2);
            this.pnDienTichToiThieu.Name = "pnDienTichToiThieu";
            this.pnDienTichToiThieu.Size = new System.Drawing.Size(296, 24);
            this.pnDienTichToiThieu.TabIndex = 5;
            // 
            // txtDienTichToiThieu
            // 
            this.txtDienTichToiThieu.Location = new System.Drawing.Point(187, 2);
            this.txtDienTichToiThieu.Name = "txtDienTichToiThieu";
            this.txtDienTichToiThieu.Size = new System.Drawing.Size(101, 20);
            this.txtDienTichToiThieu.TabIndex = 7;
            this.txtDienTichToiThieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDienTichToiThieu_KeyPress);
            // 
            // lbDienTichToiThieu
            // 
            this.lbDienTichToiThieu.AutoSize = true;
            this.lbDienTichToiThieu.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDienTichToiThieu.Location = new System.Drawing.Point(3, 3);
            this.lbDienTichToiThieu.Name = "lbDienTichToiThieu";
            this.lbDienTichToiThieu.Size = new System.Drawing.Size(183, 14);
            this.lbDienTichToiThieu.TabIndex = 6;
            this.lbDienTichToiThieu.Text = "Diện tích đất trồng mía tối thiểu(m2):";
            this.lbDienTichToiThieu.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btHienThi
            // 
            this.btHienThi.Location = new System.Drawing.Point(459, 1);
            this.btHienThi.Name = "btHienThi";
            this.btHienThi.Size = new System.Drawing.Size(58, 25);
            this.btHienThi.TabIndex = 4;
            this.btHienThi.Text = "Hiển thị";
            this.btHienThi.UseVisualStyleBackColor = true;
            this.btHienThi.Click += new System.EventHandler(this.btHienThi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vụ Trồng:";
            // 
            // pnTuNgayDenNgay
            // 
            this.pnTuNgayDenNgay.Controls.Add(this.lbDenNgay);
            this.pnTuNgayDenNgay.Controls.Add(this.dtDenNgay);
            this.pnTuNgayDenNgay.Controls.Add(this.lbTuNgay);
            this.pnTuNgayDenNgay.Controls.Add(this.dtTuNgay);
            this.pnTuNgayDenNgay.Location = new System.Drawing.Point(523, 29);
            this.pnTuNgayDenNgay.Name = "pnTuNgayDenNgay";
            this.pnTuNgayDenNgay.Size = new System.Drawing.Size(278, 25);
            this.pnTuNgayDenNgay.TabIndex = 9;
            this.pnTuNgayDenNgay.Visible = false;
            // 
            // lbDenNgay
            // 
            this.lbDenNgay.AutoSize = true;
            this.lbDenNgay.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDenNgay.Location = new System.Drawing.Point(133, 4);
            this.lbDenNgay.Name = "lbDenNgay";
            this.lbDenNgay.Size = new System.Drawing.Size(54, 14);
            this.lbDenNgay.TabIndex = 12;
            this.lbDenNgay.Text = "Đến ngày:";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(192, 3);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(78, 20);
            this.dtDenNgay.TabIndex = 11;
            // 
            // lbTuNgay
            // 
            this.lbTuNgay.AutoSize = true;
            this.lbTuNgay.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTuNgay.Location = new System.Drawing.Point(3, 5);
            this.lbTuNgay.Name = "lbTuNgay";
            this.lbTuNgay.Size = new System.Drawing.Size(49, 14);
            this.lbTuNgay.TabIndex = 10;
            this.lbTuNgay.Text = "Từ ngày:";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(52, 4);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(78, 20);
            this.dtTuNgay.TabIndex = 0;
            this.dtTuNgay.ValueChanged += new System.EventHandler(this.dtTuNgay_ValueChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.EnableDrillDown = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 27);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(955, 593);
            this.crystalReportViewer1.TabIndex = 4;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // pnTuyChon
            // 
            this.pnTuyChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTuyChon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTuyChon.Controls.Add(this.btcancel);
            this.pnTuyChon.Controls.Add(this.btok);
            this.pnTuyChon.Controls.Add(this.dgvChanTrang);
            this.pnTuyChon.Location = new System.Drawing.Point(211, 57);
            this.pnTuyChon.Name = "pnTuyChon";
            this.pnTuyChon.Size = new System.Drawing.Size(245, 201);
            this.pnTuyChon.TabIndex = 9;
            this.pnTuyChon.Visible = false;
            this.pnTuyChon.MouseLeave += new System.EventHandler(this.pnTuyChon_MouseLeave);
            // 
            // btcancel
            // 
            this.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcancel.ForeColor = System.Drawing.Color.Red;
            this.btcancel.Location = new System.Drawing.Point(208, 1);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(32, 23);
            this.btcancel.TabIndex = 2;
            this.btcancel.Text = "X";
            this.btcancel.UseVisualStyleBackColor = true;
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // btok
            // 
            this.btok.Location = new System.Drawing.Point(87, 3);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(75, 23);
            this.btok.TabIndex = 1;
            this.btok.Text = "Đồng ý";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // dgvChanTrang
            // 
            this.dgvChanTrang.AllowUserToAddRows = false;
            this.dgvChanTrang.AllowUserToDeleteRows = false;
            this.dgvChanTrang.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvChanTrang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChanTrang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vitri,
            this.Ten});
            this.dgvChanTrang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvChanTrang.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvChanTrang.Location = new System.Drawing.Point(0, 30);
            this.dgvChanTrang.Name = "dgvChanTrang";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvChanTrang.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChanTrang.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChanTrang.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvChanTrang.Size = new System.Drawing.Size(243, 169);
            this.dgvChanTrang.TabIndex = 0;
            this.dgvChanTrang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChanTrang_CellContentClick);
            this.dgvChanTrang.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChanTrang_RowEnter);
            // 
            // Vitri
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vitri.DefaultCellStyle = dataGridViewCellStyle1;
            this.Vitri.HeaderText = "Vị trí";
            this.Vitri.Name = "Vitri";
            this.Vitri.ReadOnly = true;
            this.Vitri.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Ten
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ten.DefaultCellStyle = dataGridViewCellStyle2;
            this.Ten.HeaderText = "Tên";
            this.Ten.Name = "Ten";
            this.Ten.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ten.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // picLoading
            // 
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(478, 107);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(51, 48);
            this.picLoading.TabIndex = 5;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // btTuyChonChanTrang
            // 
            this.btTuyChonChanTrang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btTuyChonChanTrang.FlatAppearance.BorderSize = 0;
            this.btTuyChonChanTrang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btTuyChonChanTrang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btTuyChonChanTrang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTuyChonChanTrang.Image = global::DACASUCO.Properties.Resources.config1;
            this.btTuyChonChanTrang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTuyChonChanTrang.Location = new System.Drawing.Point(290, 29);
            this.btTuyChonChanTrang.Name = "btTuyChonChanTrang";
            this.btTuyChonChanTrang.Size = new System.Drawing.Size(112, 26);
            this.btTuyChonChanTrang.TabIndex = 11;
            this.btTuyChonChanTrang.Text = "Tùy chọn...";
            this.toolTip1.SetToolTip(this.btTuyChonChanTrang, "Thiết lập chân trang cho báo cáo");
            this.btTuyChonChanTrang.UseVisualStyleBackColor = false;
            this.btTuyChonChanTrang.Click += new System.EventHandler(this.btTuyChonChanTrang_Click);
            this.btTuyChonChanTrang.MouseEnter += new System.EventHandler(this.btTuyChonChanTrang_MouseEnter);
            this.btTuyChonChanTrang.MouseLeave += new System.EventHandler(this.btTuyChonChanTrang_MouseLeave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // frmShowRP2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 649);
            this.Controls.Add(this.pnTuNgayDenNgay);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btTuyChonChanTrang);
            this.Controls.Add(this.pnTuyChon);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmShowRP2";
            this.Text = "k";
            this.Load += new System.EventHandler(this.frmShowRP2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnDotThanhToan.ResumeLayout(false);
            this.pnDotThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDotThanhToan)).EndInit();
            this.pnNgayThang.ResumeLayout(false);
            this.pnNgayThang.PerformLayout();
            this.pnDienTichToiThieu.ResumeLayout(false);
            this.pnDienTichToiThieu.PerformLayout();
            this.pnTuNgayDenNgay.ResumeLayout(false);
            this.pnTuNgayDenNgay.PerformLayout();
            this.pnTuyChon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btHienThi;
        private System.Windows.Forms.Panel pnDienTichToiThieu;
        private System.Windows.Forms.TextBox txtDienTichToiThieu;
        private System.Windows.Forms.Label lbDienTichToiThieu;
        private System.Windows.Forms.Panel pnNgayThang;
        private System.Windows.Forms.DateTimePicker dtNgayLoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Panel pnDotThanhToan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudDotThanhToan;
        private System.Windows.Forms.Panel pnTuyChon;
        private System.Windows.Forms.DataGridView dgvChanTrang;
        private System.Windows.Forms.Button btcancel;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vitri;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.CheckBox CheckDieuKien;
        private System.Windows.Forms.Panel pnTuNgayDenNgay;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.Label lbDenNgay;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.Label lbTuNgay;
        private System.Windows.Forms.Button btTuyChonChanTrang;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}