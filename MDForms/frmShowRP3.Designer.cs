namespace DACASUCO.MDForms
{
    partial class frmShowRP3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowRP3));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnNgayThang = new System.Windows.Forms.Panel();
            this.dtNgayLoc = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.pnDienTichToiThieu = new System.Windows.Forms.Panel();
            this.txtDienTichToiThieu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btHienThi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.btTuyChonChanTrang = new System.Windows.Forms.Button();
            this.pnTuyChon = new System.Windows.Forms.Panel();
            this.btcancel = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            this.dgvChanTrang = new System.Windows.Forms.DataGridView();
            this.Vitri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnNgayThang.SuspendLayout();
            this.pnDienTichToiThieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.pnTuyChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanTrang)).BeginInit();
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
            this.comboBox1.Location = new System.Drawing.Point(521, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(91, 22);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.pnNgayThang);
            this.panel2.Controls.Add(this.pnDienTichToiThieu);
            this.panel2.Controls.Add(this.btHienThi);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(955, 30);
            this.panel2.TabIndex = 3;
            // 
            // pnNgayThang
            // 
            this.pnNgayThang.Controls.Add(this.dtNgayLoc);
            this.pnNgayThang.Controls.Add(this.label4);
            this.pnNgayThang.Location = new System.Drawing.Point(3, 0);
            this.pnNgayThang.Name = "pnNgayThang";
            this.pnNgayThang.Size = new System.Drawing.Size(305, 27);
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
            this.pnDienTichToiThieu.Controls.Add(this.label3);
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Diện tích đất trồng mía tối thiểu(m2):";
            // 
            // btHienThi
            // 
            this.btHienThi.Location = new System.Drawing.Point(614, 0);
            this.btHienThi.Name = "btHienThi";
            this.btHienThi.Size = new System.Drawing.Size(75, 25);
            this.btHienThi.TabIndex = 4;
            this.btHienThi.Text = "Hiển thị";
            this.btHienThi.UseVisualStyleBackColor = true;
            this.btHienThi.Click += new System.EventHandler(this.btHienThi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(463, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vụ Trồng:";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.EnableDrillDown = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 30);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            //this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(955, 590);
            this.crystalReportViewer1.TabIndex = 4;
            //this.crystalReportViewer1.ViewTimeSelectionFormula = "";
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
            this.btTuyChonChanTrang.BackgroundImage = global::DACASUCO.Properties.Resources.btbackground;
            this.btTuyChonChanTrang.FlatAppearance.BorderSize = 0;
            this.btTuyChonChanTrang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btTuyChonChanTrang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btTuyChonChanTrang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTuyChonChanTrang.Image = global::DACASUCO.Properties.Resources.config1;
            this.btTuyChonChanTrang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTuyChonChanTrang.Location = new System.Drawing.Point(296, 32);
            this.btTuyChonChanTrang.Name = "btTuyChonChanTrang";
            this.btTuyChonChanTrang.Size = new System.Drawing.Size(112, 26);
            this.btTuyChonChanTrang.TabIndex = 13;
            this.btTuyChonChanTrang.Text = "Tùy chọn...";
            this.btTuyChonChanTrang.UseVisualStyleBackColor = false;
            this.btTuyChonChanTrang.MouseLeave += new System.EventHandler(this.btTuyChonChanTrang_MouseLeave);
            this.btTuyChonChanTrang.Click += new System.EventHandler(this.btTuyChonChanTrang_Click);
            this.btTuyChonChanTrang.MouseEnter += new System.EventHandler(this.btTuyChonChanTrang_MouseEnter);
            // 
            // pnTuyChon
            // 
            this.pnTuyChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTuyChon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTuyChon.Controls.Add(this.btcancel);
            this.pnTuyChon.Controls.Add(this.btok);
            this.pnTuyChon.Controls.Add(this.dgvChanTrang);
            this.pnTuyChon.Location = new System.Drawing.Point(217, 61);
            this.pnTuyChon.Name = "pnTuyChon";
            this.pnTuyChon.Size = new System.Drawing.Size(245, 201);
            this.pnTuyChon.TabIndex = 12;
            this.pnTuyChon.Visible = false;
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
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvChanTrang.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvChanTrang.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChanTrang.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvChanTrang.Size = new System.Drawing.Size(243, 169);
            this.dgvChanTrang.TabIndex = 0;
            // 
            // Vitri
            // 
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vitri.DefaultCellStyle = dataGridViewCellStyle19;
            this.Vitri.HeaderText = "Vị trí";
            this.Vitri.Name = "Vitri";
            this.Vitri.ReadOnly = true;
            this.Vitri.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Ten
            // 
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ten.DefaultCellStyle = dataGridViewCellStyle20;
            this.Ten.HeaderText = "Tên";
            this.Ten.Name = "Ten";
            this.Ten.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ten.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DACASUCO.Properties.Resources.btbackgroundOver;
            this.button1.Location = new System.Drawing.Point(603, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // frmShowRP3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 649);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btTuyChonChanTrang);
            this.Controls.Add(this.pnTuyChon);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmShowRP3";
            this.Text = "k";
            this.Load += new System.EventHandler(this.frmShowRP2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnNgayThang.ResumeLayout(false);
            this.pnNgayThang.PerformLayout();
            this.pnDienTichToiThieu.ResumeLayout(false);
            this.pnDienTichToiThieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.pnTuyChon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanTrang)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnNgayThang;
        private System.Windows.Forms.DateTimePicker dtNgayLoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Button btTuyChonChanTrang;
        private System.Windows.Forms.Panel pnTuyChon;
        private System.Windows.Forms.Button btcancel;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.DataGridView dgvChanTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vitri;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.Button button1;
    }
}