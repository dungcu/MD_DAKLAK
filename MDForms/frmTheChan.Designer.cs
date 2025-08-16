namespace DACASUCO.MDForms
{
    partial class frmTheChan
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
            this.cmdExit = new System.Windows.Forms.Button();
            this.cbNoiNhan = new System.Windows.Forms.ComboBox();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSCT = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.cldNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label11 = new System.Windows.Forms.Label();
            this.rtbGhiChu = new System.Windows.Forms.RichTextBox();
            this.cmdLuu = new System.Windows.Forms.Button();
            this.lblDV = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkListXe = new System.Windows.Forms.CheckedListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(514, 398);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(105, 35);
            this.cmdExit.TabIndex = 0;
            this.cmdExit.Text = "Thoát";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cbNoiNhan
            // 
            this.cbNoiNhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNoiNhan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNoiNhan.FormattingEnabled = true;
            this.cbNoiNhan.Location = new System.Drawing.Point(143, 167);
            this.cbNoiNhan.Name = "cbNoiNhan";
            this.cbNoiNhan.Size = new System.Drawing.Size(163, 26);
            this.cbNoiNhan.TabIndex = 1;
            // 
            // cbLoai
            // 
            this.cbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoai.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(143, 126);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(164, 26);
            this.cbLoai.TabIndex = 2;
            this.cbLoai.SelectedValueChanged += new System.EventHandler(this.cbLoai_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nơi nhận";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chủng loại";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(58, 23);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(586, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "CẬP NHẬT TIỀN THẾ CHÂN VÀ CÁP CỦA HĐ VẬN CHUYỂN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSCT
            // 
            this.txtSCT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSCT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSCT.ForeColor = System.Drawing.Color.Red;
            this.txtSCT.Location = new System.Drawing.Point(144, 90);
            this.txtSCT.Name = "txtSCT";
            this.txtSCT.ReadOnly = true;
            this.txtSCT.Size = new System.Drawing.Size(132, 26);
            this.txtSCT.TabIndex = 6;
            this.txtSCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSL
            // 
            this.txtSL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtSL.Location = new System.Drawing.Point(142, 249);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(115, 26);
            this.txtSL.TabIndex = 7;
            this.txtSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSL.TextChanged += new System.EventHandler(this.txtSL_TextChanged);
            // 
            // txtSoTien
            // 
            this.txtSoTien.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSoTien.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTien.Location = new System.Drawing.Point(142, 288);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.ReadOnly = true;
            this.txtSoTien.Size = new System.Drawing.Size(116, 26);
            this.txtSoTien.TabIndex = 8;
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số CT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số lượng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Số tiền";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ghi chú";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(342, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Chủ HĐVC";
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtHoTen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(452, 125);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(170, 26);
            this.txtHoTen.TabIndex = 14;
            this.txtHoTen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(53, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Đơn giá";
            // 
            // txtGia
            // 
            this.txtGia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGia.Location = new System.Drawing.Point(143, 208);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(116, 26);
            this.txtGia.TabIndex = 16;
            this.txtGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            // 
            // cldNgay
            // 
            this.cldNgay.CustomFormat = "dd/MM/yyyy";
            this.cldNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.cldNgay.DropDownCalendar.Name = "";
            this.cldNgay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cldNgay.IsNullDate = true;
            this.cldNgay.Location = new System.Drawing.Point(489, 86);
            this.cldNgay.Name = "cldNgay";
            this.cldNgay.Size = new System.Drawing.Size(133, 26);
            this.cldNgay.TabIndex = 145;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(341, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 17);
            this.label11.TabIndex = 146;
            this.label11.Text = "Ngày làm CT";
            // 
            // rtbGhiChu
            // 
            this.rtbGhiChu.Location = new System.Drawing.Point(143, 330);
            this.rtbGhiChu.Name = "rtbGhiChu";
            this.rtbGhiChu.Size = new System.Drawing.Size(476, 42);
            this.rtbGhiChu.TabIndex = 147;
            this.rtbGhiChu.Text = "";
            // 
            // cmdLuu
            // 
            this.cmdLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLuu.Location = new System.Drawing.Point(142, 398);
            this.cmdLuu.Name = "cmdLuu";
            this.cmdLuu.Size = new System.Drawing.Size(105, 35);
            this.cmdLuu.TabIndex = 148;
            this.cmdLuu.Text = "Lưu";
            this.cmdLuu.UseVisualStyleBackColor = true;
            this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
            // 
            // lblDV
            // 
            this.lblDV.AutoSize = true;
            this.lblDV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDV.Location = new System.Drawing.Point(260, 254);
            this.lblDV.Name = "lblDV";
            this.lblDV.Size = new System.Drawing.Size(0, 18);
            this.lblDV.TabIndex = 149;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(261, 216);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 18);
            this.label12.TabIndex = 150;
            this.label12.Text = "(đồng)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(260, 289);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 18);
            this.label13.TabIndex = 151;
            this.label13.Text = "(đồng)";
            // 
            // chkListXe
            // 
            this.chkListXe.CheckOnClick = true;
            this.chkListXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListXe.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkListXe.FormattingEnabled = true;
            this.chkListXe.Location = new System.Drawing.Point(489, 191);
            this.chkListXe.Name = "chkListXe";
            this.chkListXe.ScrollAlwaysVisible = true;
            this.chkListXe.Size = new System.Drawing.Size(133, 118);
            this.chkListXe.Sorted = true;
            this.chkListXe.TabIndex = 154;
            this.chkListXe.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListXe_ItemCheck);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(342, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(181, 17);
            this.label14.TabIndex = 155;
            this.label14.Text = "Các Xe VC của chủ HĐVC";
            // 
            // frmTheChan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 450);
            this.ControlBox = false;
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkListXe);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblDV);
            this.Controls.Add(this.cmdLuu);
            this.Controls.Add(this.rtbGhiChu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cldNgay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.txtSCT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLoai);
            this.Controls.Add(this.cbNoiNhan);
            this.Controls.Add(this.cmdExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmTheChan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cap nhat tien the chan va cap cua HDVC";
            this.Load += new System.EventHandler(this.frmTheChan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.ComboBox cbNoiNhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGia;
        private Janus.Windows.CalendarCombo.CalendarCombo cldNgay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox rtbGhiChu;
        private System.Windows.Forms.Button cmdLuu;
        private System.Windows.Forms.Label lblDV;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.CheckedListBox chkListXe;
        public System.Windows.Forms.ComboBox cbLoai;
        public System.Windows.Forms.TextBox txtSCT;
    }
}