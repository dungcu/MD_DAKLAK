namespace DACASUCO.MDForms
{
    partial class frmChonDK_ChoRP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonDK_ChoRP));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDonVi = new System.Windows.Forms.TreeView();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnThang = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdToanVu = new System.Windows.Forms.RadioButton();
            this.rdThang = new System.Windows.Forms.RadioButton();
            this.rdNgay = new System.Windows.Forms.RadioButton();
            this.pnTuNgayDenNgay = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.cmdHuy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBCTongHop = new System.Windows.Forms.RadioButton();
            this.rdBCChiTiet = new System.Windows.Forms.RadioButton();
            this.cmdChon = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnThang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.pnTuNgayDenNgay.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 313);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 27);
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
            this.splitContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.cmdHuy);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.cmdChon);
            this.splitContainer1.Size = new System.Drawing.Size(560, 313);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.TabIndex = 2;
            // 
            // tvDonVi
            // 
            this.tvDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDonVi.HideSelection = false;
            this.tvDonVi.ImageIndex = 0;
            this.tvDonVi.ImageList = this.images;
            this.tvDonVi.Location = new System.Drawing.Point(0, 29);
            this.tvDonVi.Name = "tvDonVi";
            this.tvDonVi.SelectedImageIndex = 0;
            this.tvDonVi.Size = new System.Drawing.Size(187, 284);
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
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 29);
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(59, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnThang);
            this.groupBox2.Controls.Add(this.rdToanVu);
            this.groupBox2.Controls.Add(this.rdThang);
            this.groupBox2.Controls.Add(this.rdNgay);
            this.groupBox2.Controls.Add(this.pnTuNgayDenNgay);
            this.groupBox2.Location = new System.Drawing.Point(16, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 109);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thiết lập thời gian cho báo cáo";
            // 
            // pnThang
            // 
            this.pnThang.Controls.Add(this.numericUpDown1);
            this.pnThang.Controls.Add(this.comboBox2);
            this.pnThang.Controls.Add(this.label3);
            this.pnThang.Enabled = false;
            this.pnThang.Location = new System.Drawing.Point(79, 49);
            this.pnThang.Name = "pnThang";
            this.pnThang.Size = new System.Drawing.Size(248, 28);
            this.pnThang.TabIndex = 15;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(169, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2008,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(65, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            2008,
            0,
            0,
            0});
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Một",
            "Hai",
            "Ba",
            "Bốn",
            "Năm",
            "Sáu",
            "Bẩy",
            "Tám",
            "Chín",
            "Mười",
            "Mười một",
            "Mười hai"});
            this.comboBox2.Location = new System.Drawing.Point(3, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(101, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Năm:";
            // 
            // rdToanVu
            // 
            this.rdToanVu.AutoSize = true;
            this.rdToanVu.Checked = true;
            this.rdToanVu.Location = new System.Drawing.Point(13, 82);
            this.rdToanVu.Name = "rdToanVu";
            this.rdToanVu.Size = new System.Drawing.Size(65, 17);
            this.rdToanVu.TabIndex = 14;
            this.rdToanVu.TabStop = true;
            this.rdToanVu.Text = "Toàn vụ";
            this.rdToanVu.UseVisualStyleBackColor = true;
            // 
            // rdThang
            // 
            this.rdThang.AutoSize = true;
            this.rdThang.Location = new System.Drawing.Point(13, 52);
            this.rdThang.Name = "rdThang";
            this.rdThang.Size = new System.Drawing.Size(59, 17);
            this.rdThang.TabIndex = 14;
            this.rdThang.Text = "Tháng:";
            this.rdThang.UseVisualStyleBackColor = true;
            this.rdThang.CheckedChanged += new System.EventHandler(this.rdThang_CheckedChanged);
            // 
            // rdNgay
            // 
            this.rdNgay.AutoSize = true;
            this.rdNgay.Location = new System.Drawing.Point(13, 21);
            this.rdNgay.Name = "rdNgay";
            this.rdNgay.Size = new System.Drawing.Size(53, 17);
            this.rdNgay.TabIndex = 14;
            this.rdNgay.Text = "Ngày:";
            this.rdNgay.UseVisualStyleBackColor = true;
            this.rdNgay.CheckedChanged += new System.EventHandler(this.rdNgay_CheckedChanged);
            // 
            // pnTuNgayDenNgay
            // 
            this.pnTuNgayDenNgay.Controls.Add(this.label7);
            this.pnTuNgayDenNgay.Controls.Add(this.dtDenNgay);
            this.pnTuNgayDenNgay.Controls.Add(this.dtTuNgay);
            this.pnTuNgayDenNgay.Enabled = false;
            this.pnTuNgayDenNgay.Location = new System.Drawing.Point(80, 18);
            this.pnTuNgayDenNgay.Name = "pnTuNgayDenNgay";
            this.pnTuNgayDenNgay.Size = new System.Drawing.Size(248, 26);
            this.pnTuNgayDenNgay.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(92, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Đến ngày:";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(157, 3);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(83, 20);
            this.dtDenNgay.TabIndex = 11;
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(4, 3);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(84, 20);
            this.dtTuNgay.TabIndex = 0;
            this.dtTuNgay.ValueChanged += new System.EventHandler(this.dtTuNgay_ValueChanged);
            // 
            // cmdHuy
            // 
            this.cmdHuy.Location = new System.Drawing.Point(208, 171);
            this.cmdHuy.Name = "cmdHuy";
            this.cmdHuy.Size = new System.Drawing.Size(62, 23);
            this.cmdHuy.TabIndex = 16;
            this.cmdHuy.Text = "Hủy";
            this.cmdHuy.UseVisualStyleBackColor = true;
            this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBCTongHop);
            this.groupBox1.Controls.Add(this.rdBCChiTiet);
            this.groupBox1.Location = new System.Drawing.Point(16, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 64);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn báo cáo";
            // 
            // rdBCTongHop
            // 
            this.rdBCTongHop.AutoSize = true;
            this.rdBCTongHop.Location = new System.Drawing.Point(15, 42);
            this.rdBCTongHop.Name = "rdBCTongHop";
            this.rdBCTongHop.Size = new System.Drawing.Size(110, 17);
            this.rdBCTongHop.TabIndex = 1;
            this.rdBCTongHop.Text = "Báo cáo tổng hợp";
            this.rdBCTongHop.UseVisualStyleBackColor = true;
            // 
            // rdBCChiTiet
            // 
            this.rdBCChiTiet.AutoSize = true;
            this.rdBCChiTiet.Checked = true;
            this.rdBCChiTiet.Location = new System.Drawing.Point(16, 19);
            this.rdBCChiTiet.Name = "rdBCChiTiet";
            this.rdBCChiTiet.Size = new System.Drawing.Size(99, 17);
            this.rdBCChiTiet.TabIndex = 0;
            this.rdBCChiTiet.TabStop = true;
            this.rdBCChiTiet.Text = "Báo cáo chi tiết";
            this.rdBCChiTiet.UseVisualStyleBackColor = true;
            // 
            // cmdChon
            // 
            this.cmdChon.Location = new System.Drawing.Point(208, 137);
            this.cmdChon.Name = "cmdChon";
            this.cmdChon.Size = new System.Drawing.Size(62, 23);
            this.cmdChon.TabIndex = 14;
            this.cmdChon.Text = "Nhận";
            this.cmdChon.UseVisualStyleBackColor = true;
            this.cmdChon.Click += new System.EventHandler(this.cmdChon_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btbackground.bmp");
            this.imageList1.Images.SetKeyName(1, "btbackgroundOver.bmp");
            // 
            // frmChonDK_ChoRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 340);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmChonDK_ChoRP";
            this.ShowInTaskbar = false;
            this.Text = "Chọn điều kiện cho báo cáo";
            this.Load += new System.EventHandler(this.frmShowRP2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnThang.ResumeLayout(false);
            this.pnThang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.pnTuNgayDenNgay.ResumeLayout(false);
            this.pnTuNgayDenNgay.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tvDonVi;
        private System.Windows.Forms.Panel pnTuNgayDenNgay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.ImageList images;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdChon;
        private System.Windows.Forms.RadioButton rdBCTongHop;
        private System.Windows.Forms.RadioButton rdBCChiTiet;
        private System.Windows.Forms.Button cmdHuy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdToanVu;
        private System.Windows.Forms.RadioButton rdThang;
        private System.Windows.Forms.RadioButton rdNgay;
        private System.Windows.Forms.Panel pnThang;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
    }
}