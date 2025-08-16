namespace DACASUCO.MDReport.FRM_Report
{
    partial class ChamSoc
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
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem15 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem16 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem17 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem18 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem19 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem20 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem21 = new Janus.Windows.EditControls.UIComboBoxItem();
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.labelLoi = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btCancel = new Janus.Windows.EditControls.UIButton();
            this.btXem = new Janus.Windows.EditControls.UIButton();
            this.uiComboBoxChonBC = new Janus.Windows.EditControls.UIComboBox();
            this.ComboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            this.officeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.labelLoi);
            this.uiGroupBox1.Controls.Add(this.lbTitle);
            this.uiGroupBox1.Controls.Add(this.btCancel);
            this.uiGroupBox1.Controls.Add(this.btXem);
            this.uiGroupBox1.Controls.Add(this.uiComboBoxChonBC);
            this.uiGroupBox1.Controls.Add(this.ComboVuTrong);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(455, 200);
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // labelLoi
            // 
            this.labelLoi.AutoSize = true;
            this.labelLoi.BackColor = System.Drawing.Color.Transparent;
            this.labelLoi.ForeColor = System.Drawing.Color.Red;
            this.labelLoi.Location = new System.Drawing.Point(154, 106);
            this.labelLoi.Name = "labelLoi";
            this.labelLoi.Size = new System.Drawing.Size(0, 13);
            this.labelLoi.TabIndex = 57;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.SystemColors.Info;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(455, 25);
            this.lbTitle.TabIndex = 56;
            this.lbTitle.Text = "Biểu tổng hợp theo dõi chăm sóc";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(267, 135);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(91, 21);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Thoát";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btXem
            // 
            this.btXem.Location = new System.Drawing.Point(145, 135);
            this.btXem.Name = "btXem";
            this.btXem.Size = new System.Drawing.Size(87, 21);
            this.btXem.TabIndex = 4;
            this.btXem.Text = "Xem";
            this.btXem.Click += new System.EventHandler(this.btXem_Click);
            // 
            // uiComboBoxChonBC
            // 
            uiComboBoxItem15.FormatStyle.Alpha = 0;
            uiComboBoxItem15.IsSeparator = false;
            uiComboBoxItem15.Text = "Theo trạm";
            uiComboBoxItem15.Value = "ChamSoc\\\\BieuTongHopTheoDoiChamSocTheoTram.rpt";
            uiComboBoxItem16.FormatStyle.Alpha = 0;
            uiComboBoxItem16.IsSeparator = false;
            uiComboBoxItem16.Text = "Theo cán bộ địa bàn";
            uiComboBoxItem16.Value = "ChamSoc\\\\BieuTongHopTheoDoiChamSocTheoCBDB.rpt";
            uiComboBoxItem17.FormatStyle.Alpha = 0;
            uiComboBoxItem17.IsSeparator = false;
            uiComboBoxItem17.Text = "Theo bến mía";
            uiComboBoxItem17.Value = "ChamSoc\\\\BieuTongHopTheoDoiChamSocTheoBenMia.rpt";
            uiComboBoxItem18.FormatStyle.Alpha = 0;
            uiComboBoxItem18.IsSeparator = false;
            uiComboBoxItem18.Text = "Theo xã";
            uiComboBoxItem18.Value = "ChamSoc\\\\BieuTongHopTheoDoiChamSocTheoXa.rpt";
            uiComboBoxItem19.FormatStyle.Alpha = 0;
            uiComboBoxItem19.IsSeparator = false;
            uiComboBoxItem19.Text = "Theo huyện";
            uiComboBoxItem19.Value = "ChamSoc\\\\BieuTongHopTheoDoiChamSocTheoHuyen.rpt";
            uiComboBoxItem20.FormatStyle.Alpha = 0;
            uiComboBoxItem20.IsSeparator = false;
            uiComboBoxItem20.Text = "Theo tỉnh";
            uiComboBoxItem20.Value = "ChamSoc\\\\BieuTongHopTheoDoiChamSocTheoTinh.rpt";
            uiComboBoxItem21.FormatStyle.Alpha = 0;
            uiComboBoxItem21.IsSeparator = false;
            uiComboBoxItem21.Text = "Theo chủ mía";
            uiComboBoxItem21.Value = "ChamSoc\\\\BieuTongHopTheoDoiChamSocTheoChuMia.rpt";
            this.uiComboBoxChonBC.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem15,
            uiComboBoxItem16,
            uiComboBoxItem17,
            uiComboBoxItem18,
            uiComboBoxItem19,
            uiComboBoxItem20,
            uiComboBoxItem21});
            this.uiComboBoxChonBC.Location = new System.Drawing.Point(145, 44);
            this.uiComboBoxChonBC.Name = "uiComboBoxChonBC";
            this.uiComboBoxChonBC.Size = new System.Drawing.Size(213, 20);
            this.uiComboBoxChonBC.TabIndex = 3;
            this.uiComboBoxChonBC.Text = "Chọn biểu chăm sóc ";
            // 
            // ComboVuTrong
            // 
            this.ComboVuTrong.Location = new System.Drawing.Point(145, 70);
            this.ComboVuTrong.Name = "ComboVuTrong";
            this.ComboVuTrong.Size = new System.Drawing.Size(213, 20);
            this.ComboVuTrong.TabIndex = 3;
            this.ComboVuTrong.Text = "Chọn vụ trồng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(42, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn báo cáo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(42, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vụ trồng:";
            // 
            // ChamSoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 200);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "ChamSoc";
            this.Text = "Biểu tổng hợp chăm sóc";
            this.Load += new System.EventHandler(this.TongHopDienTichHuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btCancel;
        private Janus.Windows.EditControls.UIButton btXem;
        private Janus.Windows.EditControls.UIComboBox ComboVuTrong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTitle;
        private Janus.Windows.EditControls.UIComboBox uiComboBoxChonBC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLoi;
    }
}