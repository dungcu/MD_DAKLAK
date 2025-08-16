namespace DACASUCO.MDReport.FRM_Report
{
    partial class TongHopDauTuTheoNgayThang
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
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem1 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem2 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem3 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem4 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem5 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem6 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem7 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem8 = new Janus.Windows.EditControls.UIComboBoxItem();
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
            this.label2 = new System.Windows.Forms.Label();
            this.calendarTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.calendarDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
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
            this.uiGroupBox1.Controls.Add(this.calendarDenNgay);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.calendarTuNgay);
            this.uiGroupBox1.Controls.Add(this.label2);
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
            this.labelLoi.Location = new System.Drawing.Point(137, 106);
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
            this.lbTitle.Text = "Tổng hợp đầu tư theo ngày tháng";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(238, 167);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(91, 21);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Hủy";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btXem
            // 
            this.btXem.Location = new System.Drawing.Point(128, 167);
            this.btXem.Name = "btXem";
            this.btXem.Size = new System.Drawing.Size(87, 21);
            this.btXem.TabIndex = 4;
            this.btXem.Text = "Xem";
            this.btXem.Click += new System.EventHandler(this.btXem_Click);
            // 
            // uiComboBoxChonBC
            // 
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.IsSeparator = false;
            uiComboBoxItem1.Text = "Tổng hợp nợ đầu tư";
            uiComboBoxItem1.Value = "DauTu\\\\TongHopNoDauTu.rpt";
            uiComboBoxItem2.FormatStyle.Alpha = 0;
            uiComboBoxItem2.IsSeparator = false;
            uiComboBoxItem2.Text = "Tổng hợp đầu tư phân bón";
            uiComboBoxItem2.Value = "DauTu\\\\TongHopDauTuPhanBon.rpt";
            uiComboBoxItem3.FormatStyle.Alpha = 0;
            uiComboBoxItem3.IsSeparator = false;
            uiComboBoxItem3.Text = "Tổng hợp đầu tư mía giống";
            uiComboBoxItem3.Value = "DauTu\\\\TongHopDauTuMiaGiong.rpt";
            uiComboBoxItem4.FormatStyle.Alpha = 0;
            uiComboBoxItem4.IsSeparator = false;
            uiComboBoxItem4.Text = "Tổng hợp đầu tư tiền mặt";
            uiComboBoxItem4.Value = "DauTu\\\\TongHopDauTuTienMat.rpt";
            uiComboBoxItem5.FormatStyle.Alpha = 0;
            uiComboBoxItem5.IsSeparator = false;
            uiComboBoxItem5.Text = "Tổng hợp đầu tư theo trạm";
            uiComboBoxItem5.Value = "DauTu\\\\TongHopDauTuTheoTram.rpt";
            uiComboBoxItem6.FormatStyle.Alpha = 0;
            uiComboBoxItem6.IsSeparator = false;
            uiComboBoxItem6.Text = "Tổng hợp đầu tư theo CBĐB";
            uiComboBoxItem6.Value = "DauTu\\\\TongHopDauTuTheoCBDB.rpt";
            uiComboBoxItem7.FormatStyle.Alpha = 0;
            uiComboBoxItem7.IsSeparator = false;
            uiComboBoxItem7.Text = "Tổng hợp đầu tư theo vùng mía";
            uiComboBoxItem7.Value = "DauTu\\\\TongHopDauTuTheoVungMia.rpt";
            uiComboBoxItem8.FormatStyle.Alpha = 0;
            uiComboBoxItem8.IsSeparator = false;
            uiComboBoxItem8.Text = "Tổng hợp đầu tư theo xã";
            uiComboBoxItem8.Value = "DauTu\\\\TongHopDauTuTheoXa.rpt";
            this.uiComboBoxChonBC.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1,
            uiComboBoxItem2,
            uiComboBoxItem3,
            uiComboBoxItem4,
            uiComboBoxItem5,
            uiComboBoxItem6,
            uiComboBoxItem7,
            uiComboBoxItem8});
            this.uiComboBoxChonBC.Location = new System.Drawing.Point(128, 44);
            this.uiComboBoxChonBC.Name = "uiComboBoxChonBC";
            this.uiComboBoxChonBC.Size = new System.Drawing.Size(246, 20);
            this.uiComboBoxChonBC.TabIndex = 3;
            this.uiComboBoxChonBC.Text = "Chọn báo đầu tư";
            // 
            // ComboVuTrong
            // 
            this.ComboVuTrong.Location = new System.Drawing.Point(128, 70);
            this.ComboVuTrong.Name = "ComboVuTrong";
            this.ComboVuTrong.Size = new System.Drawing.Size(246, 20);
            this.ComboVuTrong.TabIndex = 3;
            this.ComboVuTrong.Text = "Chọn vụ trồng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(43, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn báo cáo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(55, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vụ trồng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(55, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ ngày:";
            // 
            // calendarTuNgay
            // 
            this.calendarTuNgay.CustomFormat = "dd/MM/yyyy";
            this.calendarTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calendarTuNgay.DropDownCalendar.Name = "";
            this.calendarTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.calendarTuNgay.Location = new System.Drawing.Point(128, 96);
            this.calendarTuNgay.Name = "calendarTuNgay";
            this.calendarTuNgay.Size = new System.Drawing.Size(125, 22);
            this.calendarTuNgay.TabIndex = 58;
            this.calendarTuNgay.Value = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(51, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Đến ngày:";
            // 
            // calendarDenNgay
            // 
            this.calendarDenNgay.CustomFormat = "dd/MM/yyyy";
            this.calendarDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calendarDenNgay.DropDownCalendar.Name = "";
            this.calendarDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.calendarDenNgay.Location = new System.Drawing.Point(128, 124);
            this.calendarDenNgay.Name = "calendarDenNgay";
            this.calendarDenNgay.Size = new System.Drawing.Size(125, 22);
            this.calendarDenNgay.TabIndex = 60;
            this.calendarDenNgay.Value = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            // 
            // TongHopDauTuTheoNgayThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 200);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "TongHopDauTuTheoNgayThang";
            this.Text = "TongHopDauTuTheoNgayThang";
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
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarDenNgay;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarTuNgay;
    }
}