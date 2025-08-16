namespace DACASUCO.MDReport.FRM_Report
{
    partial class frmTongHopVanChuyen
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
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem13 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem14 = new Janus.Windows.EditControls.UIComboBoxItem();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiComboBox1 = new Janus.Windows.EditControls.UIComboBox();
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            this.SuspendLayout();
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.calendarCombo1.DateFormat = Janus.Windows.CalendarCombo.DateFormat.DateTime;
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.Name = "";
            this.calendarCombo1.Location = new System.Drawing.Point(108, 88);
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.Size = new System.Drawing.Size(205, 20);
            this.calendarCombo1.TabIndex = 8;
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(57, 155);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(75, 23);
            this.uiButton1.TabIndex = 9;
            this.uiButton1.Text = "Xem";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn ngày :";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 26);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Tổng hợp vận chuyển";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn báo cáo :";
            // 
            // uiButton2
            // 
            this.uiButton2.Location = new System.Drawing.Point(156, 155);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(75, 23);
            this.uiButton2.TabIndex = 10;
            this.uiButton2.Text = "Hủy";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiComboBox1
            // 
            uiComboBoxItem13.FormatStyle.Alpha = 0;
            uiComboBoxItem13.IsSeparator = false;
            uiComboBoxItem13.Text = "Tổng hợp vận chuyển theo ngày";
            uiComboBoxItem13.Value = "VanChuyen\\\\rp_TongHopVanChuyenDonViTheoNgay.rpt";
            uiComboBoxItem14.FormatStyle.Alpha = 0;
            uiComboBoxItem14.IsSeparator = false;
            uiComboBoxItem14.Text = "Biểu tổng hợp vận chuyển đến ngày";
            uiComboBoxItem14.Value = "VanChuyen\\\\rp_BieuTongHopNhapMiaDenGioNgay.rpt";
            this.uiComboBox1.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem13,
            uiComboBoxItem14});
            this.uiComboBox1.Location = new System.Drawing.Point(126, 62);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Size = new System.Drawing.Size(187, 20);
            this.uiComboBox1.TabIndex = 7;
            this.uiComboBox1.Text = "Chọn báo cáo xem";
            this.uiComboBox1.Leave += new System.EventHandler(this.uiComboBox1_Leave);
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            this.officeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty;
            // 
            // frmTongHopVanChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(325, 220);
            this.Controls.Add(this.uiComboBox1);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.calendarCombo1);
            this.Name = "frmTongHopVanChuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TongHopVanChuyen";
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.EditControls.UIComboBox uiComboBox1;
        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
    }
}