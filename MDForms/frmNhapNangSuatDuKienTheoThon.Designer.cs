namespace MDSolution.MDForms
{
    partial class frmNhapNangSuatDuKienTheoThon
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
            Janus.Windows.GridEX.GridEXLayout gridDanhSachNangSuatDuKienDaApDung_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapNangSuatDuKienTheoThon));
            this.gridDanhSachNangSuatDuKienDaApDung = new Janus.Windows.GridEX.GridEX();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.txtNangSuat = new System.Windows.Forms.TextBox();
            this.dtpNgayLam = new System.Windows.Forms.DateTimePicker();
            this.cbnNhap = new System.Windows.Forms.Button();
            this.cbXa = new System.Windows.Forms.ComboBox();
            this.cbThon = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachNangSuatDuKienDaApDung)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridDanhSachNangSuatDuKienDaApDung
            // 
            this.gridDanhSachNangSuatDuKienDaApDung.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridDanhSachNangSuatDuKienDaApDung.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridDanhSachNangSuatDuKienDaApDung.AlternatingColors = true;
            this.gridDanhSachNangSuatDuKienDaApDung.AutoEdit = true;
            this.gridDanhSachNangSuatDuKienDaApDung.AutomaticSort = false;
            this.gridDanhSachNangSuatDuKienDaApDung.ColumnAutoResize = true;
            this.gridDanhSachNangSuatDuKienDaApDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDanhSachNangSuatDuKienDaApDung.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gridDanhSachNangSuatDuKienDaApDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gridDanhSachNangSuatDuKienDaApDung.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gridDanhSachNangSuatDuKienDaApDung.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridDanhSachNangSuatDuKienDaApDung.GroupByBoxVisible = false;
            this.gridDanhSachNangSuatDuKienDaApDung.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gridDanhSachNangSuatDuKienDaApDung_Layout_0.IsCurrentLayout = true;
            gridDanhSachNangSuatDuKienDaApDung_Layout_0.Key = "tbl_DauTu";
            gridDanhSachNangSuatDuKienDaApDung_Layout_0.LayoutString = resources.GetString("gridDanhSachNangSuatDuKienDaApDung_Layout_0.LayoutString");
            this.gridDanhSachNangSuatDuKienDaApDung.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridDanhSachNangSuatDuKienDaApDung_Layout_0});
            this.gridDanhSachNangSuatDuKienDaApDung.Location = new System.Drawing.Point(3, 42);
            this.gridDanhSachNangSuatDuKienDaApDung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridDanhSachNangSuatDuKienDaApDung.Name = "gridDanhSachNangSuatDuKienDaApDung";
            this.gridDanhSachNangSuatDuKienDaApDung.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gridDanhSachNangSuatDuKienDaApDung.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridDanhSachNangSuatDuKienDaApDung.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridDanhSachNangSuatDuKienDaApDung.ScrollBarWidth = 17;
            this.gridDanhSachNangSuatDuKienDaApDung.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridDanhSachNangSuatDuKienDaApDung.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridDanhSachNangSuatDuKienDaApDung.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gridDanhSachNangSuatDuKienDaApDung.Size = new System.Drawing.Size(630, 293);
            this.gridDanhSachNangSuatDuKienDaApDung.TabIndex = 25;
            this.gridDanhSachNangSuatDuKienDaApDung.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gridDanhSachNangSuatDuKienDaApDung_DeletingRecord);
            this.gridDanhSachNangSuatDuKienDaApDung.RecordsDeleted += new System.EventHandler(this.gridDanhSachNangSuatDuKienDaApDung_RecordsDeleted);
            this.gridDanhSachNangSuatDuKienDaApDung.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gridDanhSachNangSuatDuKienDaApDung_ColumnButtonClick);
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonViTinh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonViTinh.Location = new System.Drawing.Point(474, 0);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(56, 32);
            this.lblDonViTinh.TabIndex = 22;
            this.lblDonViTinh.Text = "kg/m2";
            this.lblDonViTinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNangSuat
            // 
            this.txtNangSuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNangSuat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNangSuat.Location = new System.Drawing.Point(368, 4);
            this.txtNangSuat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNangSuat.Name = "txtNangSuat";
            this.txtNangSuat.Size = new System.Drawing.Size(100, 22);
            this.txtNangSuat.TabIndex = 21;
            this.txtNangSuat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNangSuat_KeyPress);
            this.txtNangSuat.TextChanged += new System.EventHandler(this.txtNangSuat_TextChanged);
            // 
            // dtpNgayLam
            // 
            this.dtpNgayLam.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayLam.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLam.Location = new System.Drawing.Point(262, 4);
            this.dtpNgayLam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayLam.Name = "dtpNgayLam";
            this.dtpNgayLam.Size = new System.Drawing.Size(100, 22);
            this.dtpNgayLam.TabIndex = 22;
            this.dtpNgayLam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpNgayLam_KeyPress);
            // 
            // cbnNhap
            // 
            this.cbnNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbnNhap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbnNhap.Location = new System.Drawing.Point(536, 4);
            this.cbnNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbnNhap.Name = "cbnNhap";
            this.cbnNhap.Size = new System.Drawing.Size(91, 24);
            this.cbnNhap.TabIndex = 23;
            this.cbnNhap.Text = "Áp dụng";
            this.cbnNhap.UseVisualStyleBackColor = true;
            this.cbnNhap.Click += new System.EventHandler(this.cbnNhap_Click);
            // 
            // cbXa
            // 
            this.cbXa.DisplayMember = "Ten";
            this.cbXa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbXa.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbXa.FormattingEnabled = true;
            this.cbXa.Location = new System.Drawing.Point(3, 4);
            this.cbXa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbXa.Name = "cbXa";
            this.cbXa.Size = new System.Drawing.Size(123, 24);
            this.cbXa.TabIndex = 17;
            this.cbXa.ValueMember = "ID";
            this.cbXa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbXa_KeyPress);
            // 
            // cbThon
            // 
            this.cbThon.DisplayMember = "Ten";
            this.cbThon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbThon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThon.FormattingEnabled = true;
            this.cbThon.Location = new System.Drawing.Point(132, 4);
            this.cbThon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbThon.Name = "cbThon";
            this.cbThon.Size = new System.Drawing.Size(124, 24);
            this.cbThon.TabIndex = 19;
            this.cbThon.ValueMember = "ID";
            this.cbThon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbThon_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridDanhSachNangSuatDuKienDaApDung, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.20944F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.79056F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 339);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.83165F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.16835F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel2.Controls.Add(this.cbXa, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbnNhap, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbThon, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpNgayLam, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNangSuat, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDonViTinh, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(630, 32);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // frmNhapNangSuatDuKienTheoThon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(636, 339);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmNhapNangSuatDuKienTheoThon";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập năng suất dự kiến cho thôn";
            ((System.ComponentModel.ISupportInitialize)(this.gridDanhSachNangSuatDuKienDaApDung)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gridDanhSachNangSuatDuKienDaApDung;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.TextBox txtNangSuat;
        private System.Windows.Forms.DateTimePicker dtpNgayLam;
        private System.Windows.Forms.Button cbnNhap;
        private System.Windows.Forms.ComboBox cbXa;
        private System.Windows.Forms.ComboBox cbThon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}