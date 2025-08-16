namespace DACASUCO.MDReport.FRM_Report
{
    partial class TongHopDauTuTheoDMDT
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
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.labelLoi = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btCancel = new Janus.Windows.EditControls.UIButton();
            this.btXem = new Janus.Windows.EditControls.UIButton();
            this.ComboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.labelLoi);
            this.uiGroupBox1.Controls.Add(this.lbTitle);
            this.uiGroupBox1.Controls.Add(this.btCancel);
            this.uiGroupBox1.Controls.Add(this.btXem);
            this.uiGroupBox1.Controls.Add(this.ComboVuTrong);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(455, 200);
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // labelLoi
            // 
            this.labelLoi.AutoSize = true;
            this.labelLoi.BackColor = System.Drawing.Color.Transparent;
            this.labelLoi.ForeColor = System.Drawing.Color.Red;
            this.labelLoi.Location = new System.Drawing.Point(155, 90);
            this.labelLoi.Name = "labelLoi";
            this.labelLoi.Size = new System.Drawing.Size(0, 13);
            this.labelLoi.TabIndex = 57;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.SystemColors.Info;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(455, 25);
            this.lbTitle.TabIndex = 56;
            this.lbTitle.Text = "Tổng hợp đầu tư theo danh mục đầu tư";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(267, 135);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(91, 21);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Hủy";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btXem
            // 
            this.btXem.Location = new System.Drawing.Point(157, 135);
            this.btXem.Name = "btXem";
            this.btXem.Size = new System.Drawing.Size(87, 21);
            this.btXem.TabIndex = 4;
            this.btXem.Text = "Xem";
            this.btXem.Click += new System.EventHandler(this.btXem_Click);
            // 
            // ComboVuTrong
            // 
            this.ComboVuTrong.Location = new System.Drawing.Point(146, 68);
            this.ComboVuTrong.Name = "ComboVuTrong";
            this.ComboVuTrong.Size = new System.Drawing.Size(246, 20);
            this.ComboVuTrong.TabIndex = 3;
            this.ComboVuTrong.Text = "Chọn vụ trồng";
            this.ComboVuTrong.SelectedIndexChanged += new System.EventHandler(this.ComboVuTrong_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(73, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vụ trồng:";
            // 
            // TongHopDauTuTheoDMDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 200);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "TongHopDauTuTheoDMDT";
            this.Text = "Tổng hợp đầu tư theo danh mục đầu tư";
            this.Load += new System.EventHandler(this.TongHopDienTichHuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btCancel;
        private Janus.Windows.EditControls.UIButton btXem;
        private Janus.Windows.EditControls.UIComboBox ComboVuTrong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label labelLoi;
    }
}