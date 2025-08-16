namespace DACASUCO.MDDanhMuc
{
    partial class frm_Gia_Mia_Theo_Tram_Nong_Vu
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
            Janus.Windows.GridEX.GridEXLayout gdMainGrid_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Gia_Mia_Theo_Tram_Nong_Vu));
            Janus.Windows.GridEX.GridEXLayout grdGiaCaBiet_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.gdMainGrid = new Janus.Windows.GridEX.GridEX();
            this.grpGia = new System.Windows.Forms.GroupBox();
            this.grdGiaCaBiet = new Janus.Windows.GridEX.GridEX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSua = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkTram = new System.Windows.Forms.CheckBox();
            this.cboTram = new System.Windows.Forms.ComboBox();
            this.rdPhodung = new System.Windows.Forms.RadioButton();
            this.rdCabiet = new System.Windows.Forms.RadioButton();
            this.cmdTimKiem = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdXoa = new System.Windows.Forms.Button();
            this.lblVT = new System.Windows.Forms.Label();
            this.VT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gdMainGrid)).BeginInit();
            this.grpGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGiaCaBiet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdMainGrid
            // 
            this.gdMainGrid.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdMainGrid.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdMainGrid.AllowDrop = true;
            this.gdMainGrid.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdMainGrid.AlternatingColors = true;
            this.gdMainGrid.AutoEdit = true;
            this.gdMainGrid.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdMainGrid.ColumnAutoResize = true;
            gdMainGrid_DesignTimeLayout.LayoutString = resources.GetString("gdMainGrid_DesignTimeLayout.LayoutString");
            this.gdMainGrid.DesignTimeLayout = gdMainGrid_DesignTimeLayout;
            this.gdMainGrid.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdMainGrid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdMainGrid.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdMainGrid.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdMainGrid.GroupByBoxVisible = false;
            this.gdMainGrid.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdMainGrid.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdMainGrid.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdMainGrid.Location = new System.Drawing.Point(8, 23);
            this.gdMainGrid.Name = "gdMainGrid";
            this.gdMainGrid.NewRowEnterKeyBehavior = Janus.Windows.GridEX.NewRowEnterKeyBehavior.None;
            this.gdMainGrid.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdMainGrid.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdMainGrid.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdMainGrid.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdMainGrid.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdMainGrid.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdMainGrid.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdMainGrid.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdMainGrid.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdMainGrid.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical;
            this.gdMainGrid.ScrollBarWidth = 17;
            this.gdMainGrid.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdMainGrid.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdMainGrid.Size = new System.Drawing.Size(534, 212);
            this.gdMainGrid.TabIndex = 9;
            this.gdMainGrid.UpdateOnLeave = false;
            this.gdMainGrid.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.gdMainGrid.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdMainGrid_DeletingRecord);
            this.gdMainGrid.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdMainGrid_UpdatingRecord);
            this.gdMainGrid.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdMainGrid_AddingRecord);
            // 
            // grpGia
            // 
            this.grpGia.Controls.Add(this.grdGiaCaBiet);
            this.grpGia.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGia.ForeColor = System.Drawing.Color.Crimson;
            this.grpGia.Location = new System.Drawing.Point(12, 334);
            this.grpGia.Name = "grpGia";
            this.grpGia.Size = new System.Drawing.Size(798, 420);
            this.grpGia.TabIndex = 11;
            this.grpGia.TabStop = false;
            this.grpGia.Text = "Giá mía cá biệt theo HĐĐT";
            // 
            // grdGiaCaBiet
            // 
            this.grdGiaCaBiet.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdGiaCaBiet.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdGiaCaBiet.AlternatingColors = true;
            this.grdGiaCaBiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGiaCaBiet.AutoEdit = true;
            this.grdGiaCaBiet.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo><EmptyGridInfo>Không có dữ li" +
    "ệu!</EmptyGridInfo></LocalizableData>";
            this.grdGiaCaBiet.CardCaptionFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.grdGiaCaBiet.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            grdGiaCaBiet_DesignTimeLayout.LayoutString = resources.GetString("grdGiaCaBiet_DesignTimeLayout.LayoutString");
            this.grdGiaCaBiet.DesignTimeLayout = grdGiaCaBiet_DesignTimeLayout;
            this.grdGiaCaBiet.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grdGiaCaBiet.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdGiaCaBiet.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdGiaCaBiet.FlatBorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdGiaCaBiet.Font = new System.Drawing.Font("Arial", 9F);
            this.grdGiaCaBiet.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.grdGiaCaBiet.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdGiaCaBiet.GroupByBoxVisible = false;
            this.grdGiaCaBiet.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdGiaCaBiet.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.grdGiaCaBiet.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdGiaCaBiet.Location = new System.Drawing.Point(8, 21);
            this.grdGiaCaBiet.Name = "grdGiaCaBiet";
            this.grdGiaCaBiet.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdGiaCaBiet.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.grdGiaCaBiet.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdGiaCaBiet.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.grdGiaCaBiet.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.grdGiaCaBiet.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grdGiaCaBiet.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grdGiaCaBiet.RowHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.grdGiaCaBiet.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdGiaCaBiet.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
            this.grdGiaCaBiet.ScrollBarWidth = 17;
            this.grdGiaCaBiet.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grdGiaCaBiet.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdGiaCaBiet.Size = new System.Drawing.Size(784, 381);
            this.grdGiaCaBiet.TabIndex = 6;
            this.grdGiaCaBiet.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdGiaCaBiet.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdGiaCaBiet.UpdateOnLeave = false;
            this.grdGiaCaBiet.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gdMainGrid);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Green;
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 243);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giá mía phổ dụng theo Trạm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(322, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "THIẾT LẬP GIÁ NHẬP MÍA";
            // 
            // cmdSua
            // 
            this.cmdSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSua.Location = new System.Drawing.Point(854, 385);
            this.cmdSua.Name = "cmdSua";
            this.cmdSua.Size = new System.Drawing.Size(95, 35);
            this.cmdSua.TabIndex = 12;
            this.cmdSua.Text = "Sửa";
            this.cmdSua.UseVisualStyleBackColor = true;
            this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(35, 210);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(209, 26);
            this.txtTimKiem.TabIndex = 15;
            this.txtTimKiem.Click += new System.EventHandler(this.txtTimKiem_Click);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(28, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = " Tìm theo Mã HĐ ĐT/Tên Chủ mía";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkTram);
            this.groupBox3.Controls.Add(this.cboTram);
            this.groupBox3.Controls.Add(this.rdPhodung);
            this.groupBox3.Controls.Add(this.rdCabiet);
            this.groupBox3.Controls.Add(this.cmdTimKiem);
            this.groupBox3.Controls.Add(this.txtTimKiem);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(566, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 244);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Đặt lọc và Tìm kiếm";
            // 
            // chkTram
            // 
            this.chkTram.AutoSize = true;
            this.chkTram.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTram.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTram.Location = new System.Drawing.Point(34, 39);
            this.chkTram.Name = "chkTram";
            this.chkTram.Size = new System.Drawing.Size(180, 20);
            this.chkTram.TabIndex = 24;
            this.chkTram.Text = "Lọc theo Trạm nguyên liệu";
            this.chkTram.UseVisualStyleBackColor = true;
            this.chkTram.CheckedChanged += new System.EventHandler(this.chkTram_CheckedChanged);
            // 
            // cboTram
            // 
            this.cboTram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTram.Enabled = false;
            this.cboTram.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTram.FormattingEnabled = true;
            this.cboTram.Location = new System.Drawing.Point(242, 34);
            this.cboTram.Name = "cboTram";
            this.cboTram.Size = new System.Drawing.Size(121, 25);
            this.cboTram.TabIndex = 20;
            this.cboTram.SelectedValueChanged += new System.EventHandler(this.cboTram_SelectedValueChanged);
            // 
            // rdPhodung
            // 
            this.rdPhodung.AutoSize = true;
            this.rdPhodung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPhodung.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdPhodung.Location = new System.Drawing.Point(32, 87);
            this.rdPhodung.Name = "rdPhodung";
            this.rdPhodung.Size = new System.Drawing.Size(183, 20);
            this.rdPhodung.TabIndex = 19;
            this.rdPhodung.Text = "Lọc theo giá mía phổ dụng";
            this.rdPhodung.UseVisualStyleBackColor = true;
            this.rdPhodung.CheckedChanged += new System.EventHandler(this.rdPhodung_CheckedChanged);
            // 
            // rdCabiet
            // 
            this.rdCabiet.AutoSize = true;
            this.rdCabiet.Checked = true;
            this.rdCabiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCabiet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdCabiet.Location = new System.Drawing.Point(34, 133);
            this.rdCabiet.Name = "rdCabiet";
            this.rdCabiet.Size = new System.Drawing.Size(167, 20);
            this.rdCabiet.TabIndex = 18;
            this.rdCabiet.TabStop = true;
            this.rdCabiet.Text = "Lọc theo giá mía cá biệt";
            this.rdCabiet.UseVisualStyleBackColor = true;
            this.rdCabiet.CheckedChanged += new System.EventHandler(this.rdCabiet_CheckedChanged);
            // 
            // cmdTimKiem
            // 
            this.cmdTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTimKiem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdTimKiem.Location = new System.Drawing.Point(288, 206);
            this.cmdTimKiem.Name = "cmdTimKiem";
            this.cmdTimKiem.Size = new System.Drawing.Size(95, 30);
            this.cmdTimKiem.TabIndex = 17;
            this.cmdTimKiem.Text = "Tìm";
            this.cmdTimKiem.UseVisualStyleBackColor = true;
            this.cmdTimKiem.Click += new System.EventHandler(this.cmdTimKiem_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Image = global::DACASUCO.Properties.Resources.action_stop;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(855, 599);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close (Esc)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdXoa
            // 
            this.cmdXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdXoa.Location = new System.Drawing.Point(855, 492);
            this.cmdXoa.Name = "cmdXoa";
            this.cmdXoa.Size = new System.Drawing.Size(95, 35);
            this.cmdXoa.TabIndex = 18;
            this.cmdXoa.Text = "Xóa";
            this.cmdXoa.UseVisualStyleBackColor = true;
            this.cmdXoa.Click += new System.EventHandler(this.cmdXoa_Click);
            // 
            // lblVT
            // 
            this.lblVT.AutoSize = true;
            this.lblVT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVT.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblVT.Location = new System.Drawing.Point(392, 44);
            this.lblVT.Name = "lblVT";
            this.lblVT.Size = new System.Drawing.Size(81, 19);
            this.lblVT.TabIndex = 19;
            this.lblVT.Text = "Vụ trồng:";
            this.lblVT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // VT
            // 
            this.VT.AutoSize = true;
            this.VT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.VT.Location = new System.Drawing.Point(477, 45);
            this.VT.Name = "VT";
            this.VT.Size = new System.Drawing.Size(30, 19);
            this.VT.TabIndex = 20;
            this.VT.Text = "VT";
            this.VT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frm_Gia_Mia_Theo_Tram_Nong_Vu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 757);
            this.Controls.Add(this.VT);
            this.Controls.Add(this.lblVT);
            this.Controls.Add(this.cmdXoa);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdSua);
            this.Controls.Add(this.grpGia);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Gia_Mia_Theo_Tram_Nong_Vu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thiết lập giá mía cho trạm nông vụ";
            this.Load += new System.EventHandler(this.frm_Gia_Mia_Theo_Tram_Nong_Vu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdMainGrid)).EndInit();
            this.grpGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGiaCaBiet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdMainGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpGia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSua;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdTimKiem;
        private System.Windows.Forms.RadioButton rdPhodung;
        private System.Windows.Forms.RadioButton rdCabiet;
        internal Janus.Windows.GridEX.GridEX grdGiaCaBiet;
        private System.Windows.Forms.Button cmdXoa;
        private System.Windows.Forms.ComboBox cboTram;
        private System.Windows.Forms.CheckBox chkTram;
        private System.Windows.Forms.Label lblVT;
        private System.Windows.Forms.Label VT;
    }
}