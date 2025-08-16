namespace MDSolution.MDReport.NoDauTu
{
    partial class rp_TongNoTruocKhiTru_frm2
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
            this.calenTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calenDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btCancel = new Janus.Windows.EditControls.UIButton();
            this.btXem = new Janus.Windows.EditControls.UIButton();
            this.ComboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            // calenTuNgay
            // 
            this.calenTuNgay.CustomFormat = "dd/MM/yyyy";
            this.calenTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calenTuNgay.DropDownCalendar.Name = "";
            this.calenTuNgay.Location = new System.Drawing.Point(115, 12);
            this.calenTuNgay.Name = "calenTuNgay";
            this.calenTuNgay.Size = new System.Drawing.Size(101, 20);
            this.calenTuNgay.TabIndex = 0;
            // 
            // calenDenNgay
            // 
            this.calenDenNgay.CustomFormat = "dd/MM/yyyy";
            this.calenDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calenDenNgay.DropDownCalendar.Name = "";
            this.calenDenNgay.Location = new System.Drawing.Point(115, 49);
            this.calenDenNgay.Name = "calenDenNgay";
            this.calenDenNgay.Size = new System.Drawing.Size(101, 20);
            this.calenDenNgay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(42, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ ngày:";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.textBox2);
            this.uiGroupBox1.Controls.Add(this.textBox1);
            this.uiGroupBox1.Controls.Add(this.btCancel);
            this.uiGroupBox1.Controls.Add(this.btXem);
            this.uiGroupBox1.Controls.Add(this.ComboVuTrong);
            this.uiGroupBox1.Controls.Add(this.calenDenNgay);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.calenTuNgay);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(313, 283);
            this.uiGroupBox1.TabIndex = 3;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(115, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 189);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(150, 136);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(91, 21);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Hủy";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btXem
            // 
            this.btXem.Location = new System.Drawing.Point(40, 136);
            this.btXem.Name = "btXem";
            this.btXem.Size = new System.Drawing.Size(87, 21);
            this.btXem.TabIndex = 4;
            this.btXem.Text = "Xem";
            this.btXem.Click += new System.EventHandler(this.btXem_Click);
            // 
            // ComboVuTrong
            // 
            this.ComboVuTrong.Location = new System.Drawing.Point(115, 87);
            this.ComboVuTrong.Name = "ComboVuTrong";
            this.ComboVuTrong.Size = new System.Drawing.Size(103, 20);
            this.ComboVuTrong.TabIndex = 3;
            this.ComboVuTrong.Text = "uiComboBox1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(42, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vụ trồng:";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(42, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // rp_TongNoTruocKhiTru_frm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 283);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rp_TongNoTruocKhiTru_frm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tông nợ trước khi trừ";
            this.Load += new System.EventHandler(this.rp_TongNoTruocKhiTru_frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.CalendarCombo.CalendarCombo calenDenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo calenTuNgay;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIComboBox ComboVuTrong;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton btXem;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIButton btCancel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}