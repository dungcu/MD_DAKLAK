namespace DACASUCO.MDReport.FRM_Report
{
    partial class frmTongHopNhapMia
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
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem3 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem4 = new Janus.Windows.EditControls.UIComboBoxItem();
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.uiComboBox1 = new Janus.Windows.EditControls.UIComboBox();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.uiGroupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.textBox1);
            this.uiGroupBox1.Controls.Add(this.uiComboBox1);
            this.uiGroupBox1.Controls.Add(this.uiButton2);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.uiButton1);
            this.uiGroupBox1.Controls.Add(this.calendarCombo1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(438, 220);
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // uiComboBox1
            // 
            uiComboBoxItem3.FormatStyle.Alpha = 0;
            uiComboBoxItem3.IsSeparator = false;
            uiComboBoxItem3.Text = "Tổng hợp vận chuyển của đơn vị theo ngày";
            uiComboBoxItem3.Value = "VanChuyen\\\\rp_TongHopVanChuyenDonViTheoNgay.rpt";
            uiComboBoxItem4.FormatStyle.Alpha = 0;
            uiComboBoxItem4.IsSeparator = false;
            uiComboBoxItem4.Text = "Biểu tổng hợp nhập mía đến giờ - ngày";
            uiComboBoxItem4.Value = "VanChuyen\\\\rp_BieuTongHopNhapMiaDenGioNgay.rpt";
            this.uiComboBox1.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem3,
            uiComboBoxItem4});
            this.uiComboBox1.Location = new System.Drawing.Point(177, 47);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Size = new System.Drawing.Size(205, 20);
            this.uiComboBox1.TabIndex = 13;
            this.uiComboBox1.Text = "Chọn báo cáo để xem";
            // 
            // uiButton2
            // 
            this.uiButton2.Location = new System.Drawing.Point(259, 145);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(78, 29);
            this.uiButton2.TabIndex = 16;
            this.uiButton2.Text = "Hủy";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Chọn báo cáo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Chọn Ngày - Giờ  :";
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(125, 145);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(78, 29);
            this.uiButton1.TabIndex = 15;
            this.uiButton1.Text = "Xem";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.calendarCombo1.DateFormat = Janus.Windows.CalendarCombo.DateFormat.DateTime;
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.Name = "";
            this.calendarCombo1.Location = new System.Drawing.Point(177, 86);
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.Size = new System.Drawing.Size(205, 20);
            this.calendarCombo1.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(438, 26);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Tổng hợp nhập mía - vận chuyển";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmTongHopNhapMia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(438, 220);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "frmTongHopNhapMia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TongHopVanChuyen";
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIComboBox uiComboBox1;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private System.Windows.Forms.TextBox textBox1;
    }
}