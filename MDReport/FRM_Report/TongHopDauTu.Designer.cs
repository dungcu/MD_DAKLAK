namespace DACASUCO.MDReport.FRM_Report
{
    partial class TongHopDauTu
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
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem1 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem2 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem3 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem4 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem5 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem6 = new Janus.Windows.EditControls.UIComboBoxItem();
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.labelLoi = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btCancel = new Janus.Windows.EditControls.UIButton();
            this.btXem = new Janus.Windows.EditControls.UIButton();
            this.uiComboBoxChonBC = new Janus.Windows.EditControls.UIComboBox();
            this.ComboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.uiGroupBox1.Controls.Add(this.labelLoi);
            this.uiGroupBox1.Controls.Add(this.lbTitle);
            this.uiGroupBox1.Controls.Add(this.btCancel);
            this.uiGroupBox1.Controls.Add(this.btXem);
            this.uiGroupBox1.Controls.Add(this.uiComboBoxChonBC);
            this.uiGroupBox1.Controls.Add(this.ComboVuTrong);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(459, 204);
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // labelLoi
            // 
            this.labelLoi.AutoSize = true;
            this.labelLoi.BackColor = System.Drawing.Color.Transparent;
            this.labelLoi.ForeColor = System.Drawing.Color.Red;
            this.labelLoi.Location = new System.Drawing.Point(154, 110);
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
            this.lbTitle.Size = new System.Drawing.Size(459, 25);
            this.lbTitle.TabIndex = 56;
            this.lbTitle.Text = "Báo cáo đầu tư - công nợ";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(301, 151);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(91, 29);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Hủy";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btXem
            // 
            this.btXem.Location = new System.Drawing.Point(133, 149);
            this.btXem.Name = "btXem";
            this.btXem.Size = new System.Drawing.Size(99, 29);
            this.btXem.TabIndex = 4;
            this.btXem.Text = "Xem";
            this.btXem.Click += new System.EventHandler(this.btXem_Click);
            // 
            // uiComboBoxChonBC
            // 
            this.uiComboBoxChonBC.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.uiComboBoxChonBC.DropListFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiComboBoxChonBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.IsSeparator = false;
            uiComboBoxItem1.Text = "Biểu tổng hợp công nợ đầu tư theo trạm";
            uiComboBoxItem1.Value = "DauTu\\\\BieuTongHopCongNoDauTuTheoTram.rpt";
            uiComboBoxItem2.FormatStyle.Alpha = 0;
            uiComboBoxItem2.IsSeparator = false;
            uiComboBoxItem2.Text = "Biểu tổng hợp công nợ đầu tư theo CBĐB";
            uiComboBoxItem2.Value = "DauTu\\\\BieuTongHopCongNoDauTuTheoCBDB.rpt";
            uiComboBoxItem3.FormatStyle.Alpha = 0;
            uiComboBoxItem3.IsSeparator = false;
            uiComboBoxItem3.Text = "Biểu tổng hợp công nợ đầu tư theo xã";
            uiComboBoxItem3.Value = "DauTu\\\\BieuTongHopCongNoDauTuTheoXa.rpt";
            uiComboBoxItem4.FormatStyle.Alpha = 0;
            uiComboBoxItem4.IsSeparator = false;
            uiComboBoxItem4.Text = "Biểu tổng hợp công nợ đầu tư theo huyện";
            uiComboBoxItem4.Value = "DauTu\\\\BieuTongHopCongNoDauTuTheoHuyen.rpt";
            uiComboBoxItem5.FormatStyle.Alpha = 0;
            uiComboBoxItem5.IsSeparator = false;
            uiComboBoxItem5.Text = "Biểu tổng hợp công nợ đầu tư theo chủ mía";
            uiComboBoxItem5.Value = "DauTu\\\\BieuTongHopCongNoDauTuTheoChuMia.rpt";
            uiComboBoxItem6.FormatStyle.Alpha = 0;
            uiComboBoxItem6.IsSeparator = false;
            uiComboBoxItem6.Text = "Biểu tổng hợp công nợ đầu tư toàn bộ các trạm";
            uiComboBoxItem6.Value = "DauTu\\\\BieuTongHopCongNoDauTuChiTietToanBoCacTram.rpt";
            this.uiComboBoxChonBC.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1,
            uiComboBoxItem2,
            uiComboBoxItem3,
            uiComboBoxItem4,
            uiComboBoxItem5,
            uiComboBoxItem6});
            this.uiComboBoxChonBC.Location = new System.Drawing.Point(145, 52);
            this.uiComboBoxChonBC.Name = "uiComboBoxChonBC";
            this.uiComboBoxChonBC.Size = new System.Drawing.Size(246, 22);
            this.uiComboBoxChonBC.TabIndex = 3;
            this.uiComboBoxChonBC.Text = "Chọn báo cáo đầu tư";
            // 
            // ComboVuTrong
            // 
            this.ComboVuTrong.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.ComboVuTrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboVuTrong.Location = new System.Drawing.Point(145, 95);
            this.ComboVuTrong.Name = "ComboVuTrong";
            this.ComboVuTrong.Size = new System.Drawing.Size(246, 22);
            this.ComboVuTrong.TabIndex = 3;
            this.ComboVuTrong.Text = "Chọn vụ trồng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(60, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn báo cáo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(86, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vụ trồng:";
            // 
            // TongHopDauTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 204);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TongHopDauTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Các báo cáo đầu tư";
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
        private Janus.Windows.EditControls.UIComboBox uiComboBoxChonBC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLoi;
    }
}