namespace MDSolution
{
    partial class frm_DatNgayMia
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
            this.dt_NgayMia = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cmd_TaoMoi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dt_NgayMia
            // 
            this.dt_NgayMia.CustomFormat = "dd/MM/yyyy";
            this.dt_NgayMia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_NgayMia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_NgayMia.Location = new System.Drawing.Point(158, 22);
            this.dt_NgayMia.Name = "dt_NgayMia";
            this.dt_NgayMia.Size = new System.Drawing.Size(126, 27);
            this.dt_NgayMia.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ngày nhập mía";
            // 
            // cmd_TaoMoi
            // 
            this.cmd_TaoMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_TaoMoi.Location = new System.Drawing.Point(29, 71);
            this.cmd_TaoMoi.Name = "cmd_TaoMoi";
            this.cmd_TaoMoi.Size = new System.Drawing.Size(90, 31);
            this.cmd_TaoMoi.TabIndex = 6;
            this.cmd_TaoMoi.Text = "Thiết lập";
            this.cmd_TaoMoi.UseVisualStyleBackColor = true;
            this.cmd_TaoMoi.Click += new System.EventHandler(this.cmd_TaoMoi_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(259, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 31);
            this.button1.TabIndex = 7;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(135, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 31);
            this.button2.TabIndex = 8;
            this.button2.Text = "Xem ngày cân";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frm_DatNgayMia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 117);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmd_TaoMoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dt_NgayMia);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DatNgayMia";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết lập ngày nhập mía";
            this.Load += new System.EventHandler(this.frm_DatNgayMia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dt_NgayMia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmd_TaoMoi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}