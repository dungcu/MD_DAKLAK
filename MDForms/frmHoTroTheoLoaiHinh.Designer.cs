namespace MDSolution.MDForms
{
    partial class frmHoTroTheoLoaiHinh
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
            Janus.Windows.GridEX.GridEXLayout gdVHopDong_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoTroTheoLoaiHinh));
            Janus.Windows.GridEX.GridEXLayout gdVLoaiHinh_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.gdVHopDong = new Janus.Windows.GridEX.GridEX();
            this.dtpNgayLam = new System.Windows.Forms.DateTimePicker();
            this.cbnNhap = new System.Windows.Forms.Button();
            this.cbXa = new System.Windows.Forms.ComboBox();
            this.cbThon = new System.Windows.Forms.ComboBox();
            this.cbbHoTro = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.chkTimkiemchinhxac = new System.Windows.Forms.CheckBox();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.gdVLoaiHinh = new Janus.Windows.GridEX.GridEX();
            this.lblLoaiHinhHoTro = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdVLoaiHinh)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonViTinh.Location = new System.Drawing.Point(570, 10);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(59, 16);
            this.lblDonViTinh.TabIndex = 22;
            this.lblDonViTinh.Text = "đồng/m2";
            this.lblDonViTinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTien.Location = new System.Drawing.Point(448, 7);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(116, 22);
            this.txtSoTien.TabIndex = 21;
            this.txtSoTien.TextChanged += new System.EventHandler(this.txtSoTien_TextChanged);
            this.txtSoTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTien_KeyPress);
            // 
            // gdVHopDong
            // 
            this.gdVHopDong.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdVHopDong.AlternatingColors = true;
            this.gdVHopDong.AutomaticSort = false;
            this.gdVHopDong.ColumnAutoResize = true;
            this.gdVHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVHopDong.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVHopDong.Font = new System.Drawing.Font("Arial", 9F);
            this.gdVHopDong.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVHopDong.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVHopDong.GroupByBoxVisible = false;
            this.gdVHopDong.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdVHopDong_Layout_0.IsCurrentLayout = true;
            gdVHopDong_Layout_0.Key = "tbl_DauTu";
            gdVHopDong_Layout_0.LayoutString = resources.GetString("gdVHopDong_Layout_0.LayoutString");
            this.gdVHopDong.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdVHopDong_Layout_0});
            this.gdVHopDong.Location = new System.Drawing.Point(0, 0);
            this.gdVHopDong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdVHopDong.Name = "gdVHopDong";
            this.gdVHopDong.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdVHopDong.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVHopDong.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVHopDong.ScrollBarWidth = 17;
            this.gdVHopDong.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVHopDong.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVHopDong.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVHopDong.ShowErrors = false;
            this.gdVHopDong.Size = new System.Drawing.Size(932, 162);
            this.gdVHopDong.TabIndex = 20;
            this.gdVHopDong.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVHopDong.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // dtpNgayLam
            // 
            this.dtpNgayLam.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLam.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLam.Location = new System.Drawing.Point(340, 7);
            this.dtpNgayLam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayLam.Name = "dtpNgayLam";
            this.dtpNgayLam.Size = new System.Drawing.Size(102, 22);
            this.dtpNgayLam.TabIndex = 24;
            this.dtpNgayLam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpNgayLam_KeyPress);
            // 
            // cbnNhap
            // 
            this.cbnNhap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbnNhap.Location = new System.Drawing.Point(647, 5);
            this.cbnNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbnNhap.Name = "cbnNhap";
            this.cbnNhap.Size = new System.Drawing.Size(100, 25);
            this.cbnNhap.TabIndex = 23;
            this.cbnNhap.Text = "Áp dụng";
            this.cbnNhap.UseVisualStyleBackColor = true;
            this.cbnNhap.Click += new System.EventHandler(this.cbnNhap_Click);
            // 
            // cbXa
            // 
            this.cbXa.DisplayMember = "Ten";
            this.cbXa.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbXa.FormattingEnabled = true;
            this.cbXa.Location = new System.Drawing.Point(120, 6);
            this.cbXa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbXa.Name = "cbXa";
            this.cbXa.Size = new System.Drawing.Size(78, 24);
            this.cbXa.TabIndex = 17;
            this.cbXa.ValueMember = "ID";
            this.cbXa.SelectedIndexChanged += new System.EventHandler(this.cbXa_SelectedIndexChanged);
            this.cbXa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbXa_KeyPress);
            // 
            // cbThon
            // 
            this.cbThon.DisplayMember = "Ten";
            this.cbThon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThon.FormattingEnabled = true;
            this.cbThon.Location = new System.Drawing.Point(204, 6);
            this.cbThon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbThon.Name = "cbThon";
            this.cbThon.Size = new System.Drawing.Size(130, 24);
            this.cbThon.TabIndex = 19;
            this.cbThon.ValueMember = "ID";
            this.cbThon.SelectedIndexChanged += new System.EventHandler(this.cbThon_SelectedIndexChanged);
            this.cbThon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbThon_KeyPress);
            // 
            // cbbHoTro
            // 
            this.cbbHoTro.DisplayMember = "Ten";
            this.cbbHoTro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbHoTro.FormattingEnabled = true;
            this.cbbHoTro.Location = new System.Drawing.Point(10, 6);
            this.cbbHoTro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbHoTro.Name = "cbbHoTro";
            this.cbbHoTro.Size = new System.Drawing.Size(93, 24);
            this.cbbHoTro.TabIndex = 18;
            this.cbbHoTro.ValueMember = "ID";
            this.cbbHoTro.SelectedIndexChanged += new System.EventHandler(this.cbbHoTro_SelectedIndexChanged);
            this.cbbHoTro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbHoTro_KeyPress);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(9, 4);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(143, 22);
            this.txtTimKiem.TabIndex = 21;
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // chkTimkiemchinhxac
            // 
            this.chkTimkiemchinhxac.AutoSize = true;
            this.chkTimkiemchinhxac.Checked = true;
            this.chkTimkiemchinhxac.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTimkiemchinhxac.Location = new System.Drawing.Point(158, 6);
            this.chkTimkiemchinhxac.Name = "chkTimkiemchinhxac";
            this.chkTimkiemchinhxac.Size = new System.Drawing.Size(137, 20);
            this.chkTimkiemchinhxac.TabIndex = 24;
            this.chkTimkiemchinhxac.Text = "Tìm kiếm chính xác";
            this.chkTimkiemchinhxac.UseVisualStyleBackColor = true;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.Location = new System.Drawing.Point(301, 4);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(117, 25);
            this.btnTimkiem.TabIndex = 23;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // gdVLoaiHinh
            // 
            this.gdVLoaiHinh.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVLoaiHinh.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdVLoaiHinh.AlternatingColors = true;
            this.gdVLoaiHinh.AutoEdit = true;
            this.gdVLoaiHinh.AutomaticSort = false;
            this.gdVLoaiHinh.ColumnAutoResize = true;
            this.gdVLoaiHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVLoaiHinh.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVLoaiHinh.Font = new System.Drawing.Font("Arial", 9F);
            this.gdVLoaiHinh.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVLoaiHinh.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVLoaiHinh.GroupByBoxVisible = false;
            this.gdVLoaiHinh.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdVLoaiHinh_Layout_0.IsCurrentLayout = true;
            gdVLoaiHinh_Layout_0.Key = "tbl_DauTu";
            gdVLoaiHinh_Layout_0.LayoutString = resources.GetString("gdVLoaiHinh_Layout_0.LayoutString");
            this.gdVLoaiHinh.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdVLoaiHinh_Layout_0});
            this.gdVLoaiHinh.Location = new System.Drawing.Point(0, 0);
            this.gdVLoaiHinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdVLoaiHinh.Name = "gdVLoaiHinh";
            this.gdVLoaiHinh.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVLoaiHinh.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVLoaiHinh.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVLoaiHinh.ScrollBarWidth = 17;
            this.gdVLoaiHinh.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVLoaiHinh.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVLoaiHinh.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVLoaiHinh.Size = new System.Drawing.Size(932, 162);
            this.gdVLoaiHinh.TabIndex = 25;
            this.gdVLoaiHinh.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVLoaiHinh_DeletingRecord);
            this.gdVLoaiHinh.RecordsDeleted += new System.EventHandler(this.gdVLoaiHinh_RecordsDeleted);
            this.gdVLoaiHinh.RecordUpdated += new System.EventHandler(this.gdVLoaiHinh_RecordUpdated);
            this.gdVLoaiHinh.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVLoaiHinh_UpdatingRecord);
            this.gdVLoaiHinh.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdVLoaiHinh_ColumnButtonClick);
            // 
            // lblLoaiHinhHoTro
            // 
            this.lblLoaiHinhHoTro.AutoSize = true;
            this.lblLoaiHinhHoTro.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblLoaiHinhHoTro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLoaiHinhHoTro.Location = new System.Drawing.Point(12, 9);
            this.lblLoaiHinhHoTro.Name = "lblLoaiHinhHoTro";
            this.lblLoaiHinhHoTro.Size = new System.Drawing.Size(91, 16);
            this.lblLoaiHinhHoTro.TabIndex = 27;
            this.lblLoaiHinhHoTro.Text = "LOẠI HỖ TRỢ";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.panel5, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.panel6, 0, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(938, 496);
            this.tableLayoutPanel4.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 34);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSoTien);
            this.panel2.Controls.Add(this.dtpNgayLam);
            this.panel2.Controls.Add(this.cbnNhap);
            this.panel2.Controls.Add(this.cbbHoTro);
            this.panel2.Controls.Add(this.lblDonViTinh);
            this.panel2.Controls.Add(this.cbXa);
            this.panel2.Controls.Add(this.cbThon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(932, 34);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gdVHopDong);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(932, 162);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnTimkiem);
            this.panel4.Controls.Add(this.chkTimkiemchinhxac);
            this.panel4.Controls.Add(this.txtTimKiem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 251);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(932, 34);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.lblLoaiHinhHoTro);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 291);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(932, 34);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.gdVLoaiHinh);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 331);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(932, 162);
            this.panel6.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "HỖ TRỢ THEO LOẠI HÌNH";
            // 
            // frmHoTroTheoLoaiHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(938, 496);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmHoTroTheoLoaiHinh";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hỗ trợ theo loại hình ";
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdVLoaiHinh)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.TextBox txtSoTien;
        internal Janus.Windows.GridEX.GridEX gdVHopDong;
        private System.Windows.Forms.DateTimePicker dtpNgayLam;
        private System.Windows.Forms.Button cbnNhap;
        private System.Windows.Forms.ComboBox cbXa;
        private System.Windows.Forms.ComboBox cbThon;
        private System.Windows.Forms.ComboBox cbbHoTro;
        private System.Windows.Forms.Label lblLoaiHinhHoTro;
        private Janus.Windows.GridEX.GridEX gdVLoaiHinh;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.CheckBox chkTimkiemchinhxac;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
    }
}