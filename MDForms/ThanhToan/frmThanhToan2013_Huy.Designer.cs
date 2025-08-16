namespace DACASUCO.MDForms.ThanhToan
{
    partial class frmThanhToan2013_Huy
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
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.txtLyDoHuy = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.btnOK);
            this.uiGroupBox1.Controls.Add(this.btnCancel);
            this.uiGroupBox1.Controls.Add(this.txtLyDoHuy);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(455, 151);
            this.uiGroupBox1.TabIndex = 63;
            this.uiGroupBox1.Text = "Lý do hủy phiếu thanh toán";
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(225, 93);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 21);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(130, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 21);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtLyDoHuy
            // 
            this.txtLyDoHuy.BackColor = System.Drawing.Color.White;
            this.txtLyDoHuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLyDoHuy.Location = new System.Drawing.Point(12, 20);
            this.txtLyDoHuy.Multiline = true;
            this.txtLyDoHuy.Name = "txtLyDoHuy";
            this.txtLyDoHuy.Size = new System.Drawing.Size(418, 58);
            this.txtLyDoHuy.TabIndex = 0;
            // 
            // frmThanhToan2013_Huy
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(455, 151);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmThanhToan2013_Huy";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btnOK;
        private Janus.Windows.EditControls.UIButton btnCancel;
        public System.Windows.Forms.TextBox txtLyDoHuy;
    }
}