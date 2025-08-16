namespace DACASUCO.MDForms
{
    partial class frmXoMia
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.trackXoMia = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackHS = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trackHSPL = new System.Windows.Forms.TrackBar();
            this.txtHS = new System.Windows.Forms.TextBox();
            this.txtHSPL = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblThongbao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackXoMia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHSPL)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(36, 311);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "&OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(449, 311);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackXoMia
            // 
            this.trackXoMia.LargeChange = 10;
            this.trackXoMia.Location = new System.Drawing.Point(162, 34);
            this.trackXoMia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackXoMia.Maximum = 10000;
            this.trackXoMia.Minimum = 1;
            this.trackXoMia.Name = "trackXoMia";
            this.trackXoMia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackXoMia.RightToLeftLayout = true;
            this.trackXoMia.Size = new System.Drawing.Size(264, 45);
            this.trackXoMia.TabIndex = 2;
            this.trackXoMia.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackXoMia.Value = 1;
            this.trackXoMia.Scroll += new System.EventHandler(this.trackXoMia_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Xơ mía:";
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtResult.Location = new System.Drawing.Point(433, 34);
            this.txtResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(80, 26);
            this.txtResult.TabIndex = 5;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(526, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "HS Máy ép:";
            // 
            // trackHS
            // 
            this.trackHS.LargeChange = 10;
            this.trackHS.Location = new System.Drawing.Point(162, 90);
            this.trackHS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackHS.Maximum = 100;
            this.trackHS.Minimum = 1;
            this.trackHS.Name = "trackHS";
            this.trackHS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackHS.RightToLeftLayout = true;
            this.trackHS.Size = new System.Drawing.Size(264, 45);
            this.trackHS.TabIndex = 7;
            this.trackHS.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackHS.Value = 1;
            this.trackHS.Scroll += new System.EventHandler(this.trackHS_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "HS pha loãng:";
            // 
            // trackHSPL
            // 
            this.trackHSPL.LargeChange = 10;
            this.trackHSPL.Location = new System.Drawing.Point(176, 218);
            this.trackHSPL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackHSPL.Maximum = 200;
            this.trackHSPL.Minimum = 100;
            this.trackHSPL.Name = "trackHSPL";
            this.trackHSPL.RightToLeftLayout = true;
            this.trackHSPL.Size = new System.Drawing.Size(264, 45);
            this.trackHSPL.TabIndex = 9;
            this.trackHSPL.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackHSPL.Value = 100;
            this.trackHSPL.Scroll += new System.EventHandler(this.trackHSPL_Scroll);
            // 
            // txtHS
            // 
            this.txtHS.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtHS.Location = new System.Drawing.Point(433, 85);
            this.txtHS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHS.Name = "txtHS";
            this.txtHS.ReadOnly = true;
            this.txtHS.Size = new System.Drawing.Size(80, 26);
            this.txtHS.TabIndex = 11;
            this.txtHS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHSPL
            // 
            this.txtHSPL.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtHSPL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSPL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtHSPL.Location = new System.Drawing.Point(433, 144);
            this.txtHSPL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHSPL.Name = "txtHSPL";
            this.txtHSPL.ReadOnly = true;
            this.txtHSPL.Size = new System.Drawing.Size(80, 26);
            this.txtHSPL.TabIndex = 13;
            this.txtHSPL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHSPL);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHS);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.trackHS);
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackXoMia);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(14, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(569, 215);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều chỉnh";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MediumBlue;
            this.label7.Location = new System.Drawing.Point(173, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(290, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "THAM SỐ ĐO CHỮ ĐƯỜNG CCS";
            // 
            // lblThongbao
            // 
            this.lblThongbao.AutoSize = true;
            this.lblThongbao.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongbao.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblThongbao.Location = new System.Drawing.Point(209, 322);
            this.lblThongbao.Name = "lblThongbao";
            this.lblThongbao.Size = new System.Drawing.Size(160, 15);
            this.lblThongbao.TabIndex = 17;
            this.lblThongbao.Text = "Click Cancel khi không thay đổi";
            // 
            // frmXoMia
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(601, 366);
            this.ControlBox = false;
            this.Controls.Add(this.lblThongbao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trackHSPL);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmXoMia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tham số tính CCS";
            this.Load += new System.EventHandler(this.frmXoMia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackXoMia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHSPL)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackXoMia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackHS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackHSPL;
        private System.Windows.Forms.TextBox txtHS;
        private System.Windows.Forms.TextBox txtHSPL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblThongbao;
    }
}