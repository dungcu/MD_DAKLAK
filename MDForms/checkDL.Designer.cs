namespace MDSolution.MDForms
{
    partial class checkDL
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
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem1 = new Janus.Windows.EditControls.UIComboBoxItem();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiComboBox1 = new Janus.Windows.EditControls.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.calendarComboDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calendarComboTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.SuspendLayout();
            // 
            // uiButton1
            // 
            this.uiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton1.Location = new System.Drawing.Point(80, 159);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(75, 23);
            this.uiButton1.TabIndex = 2;
            this.uiButton1.Text = "OK";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiComboBox1
            // 
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.IsSeparator = false;
            uiComboBoxItem1.Text = "Diện Tích";
            uiComboBoxItem1.Value = "DienTich\\\\TongHopDienTichTheoNgay.rpt";
            this.uiComboBox1.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1});
            this.uiComboBox1.Location = new System.Drawing.Point(123, 116);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Size = new System.Drawing.Size(145, 20);
            this.uiComboBox1.TabIndex = 3;
            this.uiComboBox1.Text = "Chọn danh mục kiểm tra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đến ngày :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày :";
            // 
            // calendarComboDenNgay
            // 
            // 
            // 
            // 
            this.calendarComboDenNgay.DropDownCalendar.Name = "";
            this.calendarComboDenNgay.Location = new System.Drawing.Point(123, 86);
            this.calendarComboDenNgay.Name = "calendarComboDenNgay";
            this.calendarComboDenNgay.Size = new System.Drawing.Size(145, 20);
            this.calendarComboDenNgay.TabIndex = 8;
            // 
            // calendarComboTuNgay
            // 
            // 
            // 
            // 
            this.calendarComboTuNgay.DropDownCalendar.Name = "";
            this.calendarComboTuNgay.Location = new System.Drawing.Point(123, 56);
            this.calendarComboTuNgay.Name = "calendarComboTuNgay";
            this.calendarComboTuNgay.Size = new System.Drawing.Size(145, 20);
            this.calendarComboTuNgay.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Danh mục :";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 26);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Kiểm tra dữ liệu theo ngày";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uiButton2
            // 
            this.uiButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton2.Location = new System.Drawing.Point(177, 159);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(75, 23);
            this.uiButton2.TabIndex = 11;
            this.uiButton2.Text = "Hủy";
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // checkDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(338, 245);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calendarComboDenNgay);
            this.Controls.Add(this.calendarComboTuNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiComboBox1);
            this.Controls.Add(this.uiButton1);
            this.Name = "checkDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm tra dữ liệu theo ngày";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIComboBox uiComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarComboDenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarComboTuNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private Janus.Windows.EditControls.UIButton uiButton2;
    }
}