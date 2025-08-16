namespace MDSolution.MDForms
{
    partial class Export_DLTheoNgay
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
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.calendarComboTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calendarComboDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.uiButtonOk = new Janus.Windows.EditControls.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            this.SuspendLayout();
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            this.officeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty;
            // 
            // calendarComboTuNgay
            // 
            this.calendarComboTuNgay.CustomFormat = "MM-dd-yyyy";
            this.calendarComboTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calendarComboTuNgay.DropDownCalendar.Name = "";
            this.calendarComboTuNgay.Location = new System.Drawing.Point(130, 52);
            this.calendarComboTuNgay.Name = "calendarComboTuNgay";
            this.calendarComboTuNgay.Size = new System.Drawing.Size(96, 20);
            this.calendarComboTuNgay.TabIndex = 0;
            // 
            // calendarComboDenNgay
            // 
            this.calendarComboDenNgay.CustomFormat = "MM-dd-yyyy";
            this.calendarComboDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calendarComboDenNgay.DropDownCalendar.Name = "";
            this.calendarComboDenNgay.Location = new System.Drawing.Point(130, 93);
            this.calendarComboDenNgay.Name = "calendarComboDenNgay";
            this.calendarComboDenNgay.Size = new System.Drawing.Size(96, 20);
            this.calendarComboDenNgay.TabIndex = 1;
            // 
            // uiButtonOk
            // 
            this.uiButtonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButtonOk.Location = new System.Drawing.Point(82, 133);
            this.uiButtonOk.Name = "uiButtonOk";
            this.uiButtonOk.Size = new System.Drawing.Size(75, 23);
            this.uiButtonOk.TabIndex = 2;
            this.uiButtonOk.Text = "Submit";
            this.uiButtonOk.Click += new System.EventHandler(this.uiButtonOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ ngày :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến ngày :";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 26);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Export dữ liệu theo ngày";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Export_DLTheoNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(278, 189);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiButtonOk);
            this.Controls.Add(this.calendarComboDenNgay);
            this.Controls.Add(this.calendarComboTuNgay);
            this.Name = "Export_DLTheoNgay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export_DLTheoNgay";
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarComboTuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton uiButtonOk;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarComboDenNgay;
        private System.Windows.Forms.TextBox textBox1;
    }
}