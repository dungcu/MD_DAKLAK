namespace MDSolution
{
    partial class frmQuanLyNguoiDung_XacNhanPass
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
            this.btok = new System.Windows.Forms.Button();
            this.txtPasConfig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btok
            // 
            this.btok.Location = new System.Drawing.Point(120, 46);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(75, 23);
            this.btok.TabIndex = 0;
            this.btok.Text = "OK";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // txtPasConfig
            // 
            this.txtPasConfig.Location = new System.Drawing.Point(137, 20);
            this.txtPasConfig.Name = "txtPasConfig";
            this.txtPasConfig.PasswordChar = '*';
            this.txtPasConfig.Size = new System.Drawing.Size(129, 20);
            this.txtPasConfig.TabIndex = 1;
            this.txtPasConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPasConfig_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Xác nhận mật khẩu:";
            // 
            // frmQuanLyNguoiDung_XacNhanPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(324, 96);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPasConfig);
            this.Controls.Add(this.btok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyNguoiDung_XacNhanPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xác nhận lại mật khẩu";
            this.Load += new System.EventHandler(this.frmQuanLyNguoiDung_XacNhanPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.TextBox txtPasConfig;
        private System.Windows.Forms.Label label1;
    }
}