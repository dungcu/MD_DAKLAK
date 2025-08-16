namespace DACASUCO.MDForms.ThanhToan
{
    partial class RPT_TongHopCongNo
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
            this.dtDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXemBC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2009, 9, 1, 0, 0, 0, 0);
            this.dtDenNgay.DropDownCalendar.Name = "";
            this.dtDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDenNgay.IsNullDate = true;
            this.dtDenNgay.Location = new System.Drawing.Point(122, 61);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Nullable = true;
            this.dtDenNgay.Size = new System.Drawing.Size(110, 21);
            this.dtDenNgay.TabIndex = 16;
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2009, 9, 1, 0, 0, 0, 0);
            this.dtTuNgay.DropDownCalendar.Name = "";
            this.dtTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTuNgay.IsNullDate = true;
            this.dtTuNgay.Location = new System.Drawing.Point(122, 34);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Nullable = true;
            this.dtTuNgay.Size = new System.Drawing.Size(110, 21);
            this.dtTuNgay.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Đến ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Từ ngày:";
            // 
            // btnXemBC
            // 
            this.btnXemBC.Location = new System.Drawing.Point(122, 100);
            this.btnXemBC.Name = "btnXemBC";
            this.btnXemBC.Size = new System.Drawing.Size(95, 23);
            this.btnXemBC.TabIndex = 12;
            this.btnXemBC.Text = "Xem báo cáo";
            this.btnXemBC.UseVisualStyleBackColor = true;
            this.btnXemBC.Click += new System.EventHandler(this.btnXemBC_Click);
            // 
            // RPT_TongHopCongNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 163);
            this.Controls.Add(this.dtDenNgay);
            this.Controls.Add(this.dtTuNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXemBC);
            this.Name = "RPT_TongHopCongNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tổng hợp công nợ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.CalendarCombo.CalendarCombo dtDenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo dtTuNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXemBC;
    }
}