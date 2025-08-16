namespace MDSolution
{
    partial class frmQuanLyNguoiDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyNguoiDung));
            Janus.Windows.GridEX.GridEXLayout gdVUser_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.gdVUser = new Janus.Windows.GridEX.GridEX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_NhanVienNhapMia = new System.Windows.Forms.CheckBox();
            this.chk_TruongCaNhapMia = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_QuanTriHeThong = new System.Windows.Forms.CheckBox();
            this.chk_QuanLyVanChuyen = new System.Windows.Forms.CheckBox();
            this.chk_ThanhToan = new System.Windows.Forms.CheckBox();
            this.chk_TheoDoiNhapMia = new System.Windows.Forms.CheckBox();
            this.chk_QuanLyDauTu = new System.Windows.Forms.CheckBox();
            this.chk_QuanLyDienTich = new System.Windows.Forms.CheckBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.btGhiNhan = new Janus.Windows.EditControls.UIButton();
            this.uiButtonControl = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdVUser)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdVUser
            // 
            this.gdVUser.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVUser.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVUser.AlternatingColors = true;
            this.gdVUser.AutoEdit = true;
            resources.ApplyResources(this.gdVUser, "gdVUser");
            resources.ApplyResources(gdVUser_DesignTimeLayout, "gdVUser_DesignTimeLayout");
            this.gdVUser.DesignTimeLayout = gdVUser_DesignTimeLayout;
            this.gdVUser.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVUser.GridLineColor = System.Drawing.SystemColors.ControlLightLight;
            this.gdVUser.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVUser.GroupByBoxVisible = false;
            this.gdVUser.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVUser.Name = "gdVUser";
            this.gdVUser.NewRowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Flat;
            this.gdVUser.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdVUser.NewRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Solid;
            this.gdVUser.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVUser.NewRowFormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.gdVUser.NewRowFormatStyle.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Center;
            this.gdVUser.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVUser.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVUser.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVUser.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVUser.ScrollBarWidth = 17;
            this.gdVUser.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVUser.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVUser_DeletingRecord);
            this.gdVUser.RecordsDeleted += new System.EventHandler(this.gdVUser_RecordsDeleted);
            this.gdVUser.RecordUpdated += new System.EventHandler(this.gdVUser_RecordUpdated);
            this.gdVUser.RecordAdded += new System.EventHandler(this.gdVUser_RecordAdded);
            this.gdVUser.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVUser_UpdatingRecord);
            this.gdVUser.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVUser_AddingRecord);
            this.gdVUser.SelectionChanged += new System.EventHandler(this.gdVUser_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_NhanVienNhapMia);
            this.groupBox1.Controls.Add(this.chk_TruongCaNhapMia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chk_QuanTriHeThong);
            this.groupBox1.Controls.Add(this.chk_QuanLyVanChuyen);
            this.groupBox1.Controls.Add(this.chk_ThanhToan);
            this.groupBox1.Controls.Add(this.chk_TheoDoiNhapMia);
            this.groupBox1.Controls.Add(this.chk_QuanLyDauTu);
            this.groupBox1.Controls.Add(this.chk_QuanLyDienTich);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chk_NhanVienNhapMia
            // 
            resources.ApplyResources(this.chk_NhanVienNhapMia, "chk_NhanVienNhapMia");
            this.chk_NhanVienNhapMia.Name = "chk_NhanVienNhapMia";
            this.chk_NhanVienNhapMia.UseVisualStyleBackColor = true;
            // 
            // chk_TruongCaNhapMia
            // 
            resources.ApplyResources(this.chk_TruongCaNhapMia, "chk_TruongCaNhapMia");
            this.chk_TruongCaNhapMia.Name = "chk_TruongCaNhapMia";
            this.chk_TruongCaNhapMia.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chk_QuanTriHeThong
            // 
            resources.ApplyResources(this.chk_QuanTriHeThong, "chk_QuanTriHeThong");
            this.chk_QuanTriHeThong.Name = "chk_QuanTriHeThong";
            this.chk_QuanTriHeThong.UseVisualStyleBackColor = true;
            // 
            // chk_QuanLyVanChuyen
            // 
            resources.ApplyResources(this.chk_QuanLyVanChuyen, "chk_QuanLyVanChuyen");
            this.chk_QuanLyVanChuyen.Name = "chk_QuanLyVanChuyen";
            this.chk_QuanLyVanChuyen.UseVisualStyleBackColor = true;
            // 
            // chk_ThanhToan
            // 
            resources.ApplyResources(this.chk_ThanhToan, "chk_ThanhToan");
            this.chk_ThanhToan.Name = "chk_ThanhToan";
            this.chk_ThanhToan.UseVisualStyleBackColor = true;
            // 
            // chk_TheoDoiNhapMia
            // 
            resources.ApplyResources(this.chk_TheoDoiNhapMia, "chk_TheoDoiNhapMia");
            this.chk_TheoDoiNhapMia.Name = "chk_TheoDoiNhapMia";
            this.chk_TheoDoiNhapMia.UseVisualStyleBackColor = true;
            // 
            // chk_QuanLyDauTu
            // 
            resources.ApplyResources(this.chk_QuanLyDauTu, "chk_QuanLyDauTu");
            this.chk_QuanLyDauTu.Name = "chk_QuanLyDauTu";
            this.chk_QuanLyDauTu.UseVisualStyleBackColor = true;
            // 
            // chk_QuanLyDienTich
            // 
            resources.ApplyResources(this.chk_QuanLyDienTich, "chk_QuanLyDienTich");
            this.chk_QuanLyDienTich.Name = "chk_QuanLyDienTich";
            this.chk_QuanLyDienTich.UseVisualStyleBackColor = true;
            // 
            // uiButton1
            // 
            this.uiButton1.Icon = ((System.Drawing.Icon)(resources.GetObject("uiButton1.Icon")));
            resources.ApplyResources(this.uiButton1, "uiButton1");
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Icon = ((System.Drawing.Icon)(resources.GetObject("uiButton2.Icon")));
            this.uiButton2.Image = global::DACASUCO.Properties.Resources.end;
            resources.ApplyResources(this.uiButton2, "uiButton2");
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // btGhiNhan
            // 
            this.btGhiNhan.Icon = ((System.Drawing.Icon)(resources.GetObject("btGhiNhan.Icon")));
            this.btGhiNhan.Image = global::DACASUCO.Properties.Resources.end;
            resources.ApplyResources(this.btGhiNhan, "btGhiNhan");
            this.btGhiNhan.Name = "btGhiNhan";
            this.btGhiNhan.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btGhiNhan.Click += new System.EventHandler(this.btGhiNhan_Click);
            // 
            // uiButtonControl
            // 
            this.uiButtonControl.Icon = ((System.Drawing.Icon)(resources.GetObject("uiButtonControl.Icon")));
            this.uiButtonControl.Image = global::DACASUCO.Properties.Resources.end;
            resources.ApplyResources(this.uiButtonControl, "uiButtonControl");
            this.uiButtonControl.Name = "uiButtonControl";
            this.uiButtonControl.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            //this.uiButtonControl.Click += new System.EventHandler(this.uiButtonControl_Click);
            // 
            // frmQuanLyNguoiDung
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButtonControl);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.btGhiNhan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gdVUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyNguoiDung";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmQuanLyNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdVUser)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_QuanLyDienTich;
        private System.Windows.Forms.CheckBox chk_TheoDoiNhapMia;
        private System.Windows.Forms.CheckBox chk_QuanLyDauTu;
        private System.Windows.Forms.CheckBox chk_QuanLyVanChuyen;
        private System.Windows.Forms.CheckBox chk_ThanhToan;
        private System.Windows.Forms.CheckBox chk_QuanTriHeThong;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton btGhiNhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_TruongCaNhapMia;
        private System.Windows.Forms.CheckBox chk_NhanVienNhapMia;
        private Janus.Windows.EditControls.UIButton uiButtonControl;
        private Janus.Windows.EditControls.UIButton uiButton2;
        //private CrystalReport1 CrystalReport11;
        //private CrystalReport1 CrystalReport12;
        //private CrystalReport1 CrystalReport13;
        //private CrystalReport1 CrystalReport14;
        //private CrystalReport1 CrystalReport15;
    }
}