namespace DACASUCO.MDForms
{
    partial class frmShowRP_TheoDonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowRP_TheoDonVi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDonVi = new System.Windows.Forms.TreeView();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnTuNgayDenNgay = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnTuyChon = new System.Windows.Forms.Panel();
            this.btcancel = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            this.dgvChanTrang = new System.Windows.Forms.DataGridView();
            this.Vitri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btTuyChonChanTrang = new System.Windows.Forms.Button();
            this.CheckDieuKien = new System.Windows.Forms.CheckBox();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnTuNgayDenNgay.SuspendLayout();
            this.pnTuyChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 551);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 27);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "status";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDonVi);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.pnTuyChon);
            this.splitContainer1.Panel2.Controls.Add(this.btTuyChonChanTrang);
            this.splitContainer1.Panel2.Controls.Add(this.CheckDieuKien);
            this.splitContainer1.Panel2.Controls.Add(this.picLoading);
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 551);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 2;
            // 
            // tvDonVi
            // 
            this.tvDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDonVi.HideSelection = false;
            this.tvDonVi.ImageIndex = 0;
            this.tvDonVi.ImageList = this.images;
            this.tvDonVi.Location = new System.Drawing.Point(0, 45);
            this.tvDonVi.Name = "tvDonVi";
            this.tvDonVi.SelectedImageIndex = 0;
            this.tvDonVi.Size = new System.Drawing.Size(204, 506);
            this.tvDonVi.TabIndex = 7;
            this.tvDonVi.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDonVi_NodeMouseDoubleClick);
            this.tvDonVi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tvDonVi_KeyPress);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "Home.ico");
            this.images.Images.SetKeyName(1, "Doc.ico");
            this.images.Images.SetKeyName(2, "Folder.ico");
            this.images.Images.SetKeyName(3, "Buddy-Blue.ico");
            this.images.Images.SetKeyName(4, "Doc.ico");
            this.images.Images.SetKeyName(5, "Folder.ico");
            this.images.Images.SetKeyName(6, "Buddy-Green.ico");
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pnTuNgayDenNgay);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 45);
            this.panel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vụ trồng:";
            // 
            // pnTuNgayDenNgay
            // 
            this.pnTuNgayDenNgay.Controls.Add(this.label7);
            this.pnTuNgayDenNgay.Controls.Add(this.dtDenNgay);
            this.pnTuNgayDenNgay.Controls.Add(this.label6);
            this.pnTuNgayDenNgay.Controls.Add(this.dtTuNgay);
            this.pnTuNgayDenNgay.Location = new System.Drawing.Point(0, 51);
            this.pnTuNgayDenNgay.Name = "pnTuNgayDenNgay";
            this.pnTuNgayDenNgay.Size = new System.Drawing.Size(154, 56);
            this.pnTuNgayDenNgay.TabIndex = 13;
            this.pnTuNgayDenNgay.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Đến ngày:";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(63, 27);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(83, 20);
            this.dtDenNgay.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Từ ngày:";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(63, 3);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(84, 20);
            this.dtTuNgay.TabIndex = 0;
            this.dtTuNgay.ValueChanged += new System.EventHandler(this.dtTuNgay_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(59, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // pnTuyChon
            // 
            this.pnTuyChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTuyChon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTuyChon.Controls.Add(this.btcancel);
            this.pnTuyChon.Controls.Add(this.btok);
            this.pnTuyChon.Controls.Add(this.dgvChanTrang);
            this.pnTuyChon.Location = new System.Drawing.Point(195, 32);
            this.pnTuyChon.Name = "pnTuyChon";
            this.pnTuyChon.Size = new System.Drawing.Size(249, 201);
            this.pnTuyChon.TabIndex = 11;
            this.pnTuyChon.Visible = false;
            // 
            // btcancel
            // 
            this.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcancel.ForeColor = System.Drawing.Color.Red;
            this.btcancel.Location = new System.Drawing.Point(217, 1);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(30, 23);
            this.btcancel.TabIndex = 2;
            this.btcancel.Text = "X";
            this.btcancel.UseVisualStyleBackColor = true;
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // btok
            // 
            this.btok.Location = new System.Drawing.Point(88, 3);
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
            this.dgvChanTrang.Size = new System.Drawing.Size(247, 169);
            this.dgvChanTrang.TabIndex = 0;
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
            // btTuyChonChanTrang
            // 
            this.btTuyChonChanTrang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btTuyChonChanTrang.FlatAppearance.BorderSize = 0;
            this.btTuyChonChanTrang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btTuyChonChanTrang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btTuyChonChanTrang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTuyChonChanTrang.Image = global::DACASUCO.Properties.Resources.config2;
            this.btTuyChonChanTrang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTuyChonChanTrang.Location = new System.Drawing.Point(268, 3);
            this.btTuyChonChanTrang.Name = "btTuyChonChanTrang";
            this.btTuyChonChanTrang.Size = new System.Drawing.Size(112, 26);
            this.btTuyChonChanTrang.TabIndex = 10;
            this.btTuyChonChanTrang.Text = "Tùy chọn...";
            this.toolTip1.SetToolTip(this.btTuyChonChanTrang, "Thiết lập chân trang cho báo cáo");
            this.btTuyChonChanTrang.UseVisualStyleBackColor = false;
            this.btTuyChonChanTrang.Click += new System.EventHandler(this.btTuyChonChanTrang_Click);
            this.btTuyChonChanTrang.MouseEnter += new System.EventHandler(this.btTuyChonChanTrang_MouseEnter);
            this.btTuyChonChanTrang.MouseLeave += new System.EventHandler(this.btTuyChonChanTrang_MouseLeave);
            // 
            // CheckDieuKien
            // 
            this.CheckDieuKien.AutoSize = true;
            this.CheckDieuKien.Location = new System.Drawing.Point(452, 9);
            this.CheckDieuKien.Name = "CheckDieuKien";
            this.CheckDieuKien.Size = new System.Drawing.Size(124, 17);
            this.CheckDieuKien.TabIndex = 12;
            this.CheckDieuKien.Text = "Lọc theo ngày tháng";
            this.CheckDieuKien.UseVisualStyleBackColor = true;
            this.CheckDieuKien.CheckedChanged += new System.EventHandler(this.CheckDieuKien_CheckedChanged);
            // 
            // picLoading
            // 
            this.picLoading.BackColor = System.Drawing.Color.Transparent;
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(25, 67);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(50, 48);
            this.picLoading.TabIndex = 1;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.EnableDrillDown = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(812, 551);
            this.crystalReportViewer1.TabIndex = 15;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btbackground.bmp");
            this.imageList1.Images.SetKeyName(1, "btbackgroundOver.bmp");
            // 
            // frmShowRP_TheoDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 578);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmShowRP_TheoDonVi";
            this.Text = "Title được set trong code";
            this.Load += new System.EventHandler(this.frmShowRP2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tvDonVi;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Button btTuyChonChanTrang;
        private System.Windows.Forms.Panel pnTuyChon;
        private System.Windows.Forms.Button btcancel;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.DataGridView dgvChanTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vitri;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.Panel pnTuNgayDenNgay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.CheckBox CheckDieuKien;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.ImageList images;
    }
}