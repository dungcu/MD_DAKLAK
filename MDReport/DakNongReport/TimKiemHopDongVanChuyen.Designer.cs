namespace DACASUCO.MDReport.DakNongReport
{
    partial class TimKiemHopDongVanChuyen
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
            Janus.Windows.GridEX.GridEXLayout grvCongNoVanChuyenMia_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimKiemHopDongVanChuyen));
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenChuMia = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.grvCongNoVanChuyenMia = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.grvCongNoVanChuyenMia)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaHD
            // 
            this.txtMaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaHD.Location = new System.Drawing.Point(-128, -11);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(111, 20);
            this.txtMaHD.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(-190, -6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Chủ mía:";
            // 
            // txtTenChuMia
            // 
            this.txtTenChuMia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtTenChuMia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTenChuMia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenChuMia.Location = new System.Drawing.Point(204, 6);
            this.txtTenChuMia.Name = "txtTenChuMia";
            this.txtTenChuMia.Size = new System.Drawing.Size(494, 20);
            this.txtTenChuMia.TabIndex = 74;
            this.txtTenChuMia.Click += new System.EventHandler(this.txtTenChuMia_TextChanged);
            this.txtTenChuMia.TextChanged += new System.EventHandler(this.txtTenChuMia_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(83, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 20);
            this.textBox1.TabIndex = 72;
            this.textBox1.Click += new System.EventHandler(this.txtMaHD_TextChanged);
            this.textBox1.TextChanged += new System.EventHandler(this.txtMaHD_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Chủ mía:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(383, 267);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 21);
            this.btnOK.TabIndex = 71;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(288, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 21);
            this.btnCancel.TabIndex = 70;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grvCongNoVanChuyenMia
            // 
            this.grvCongNoVanChuyenMia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grvCongNoVanChuyenMia.AlternatingColors = true;
            this.grvCongNoVanChuyenMia.AutomaticSort = false;
            this.grvCongNoVanChuyenMia.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.grvCongNoVanChuyenMia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grvCongNoVanChuyenMia.FrozenColumns = 4;
            this.grvCongNoVanChuyenMia.GridLineColor = System.Drawing.Color.Black;
            this.grvCongNoVanChuyenMia.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grvCongNoVanChuyenMia.GroupByBoxVisible = false;
            grvCongNoVanChuyenMia_Layout_0.IsCurrentLayout = true;
            grvCongNoVanChuyenMia_Layout_0.Key = "tbl_DauTu";
            grvCongNoVanChuyenMia_Layout_0.LayoutString = resources.GetString("grvCongNoVanChuyenMia_Layout_0.LayoutString");
            this.grvCongNoVanChuyenMia.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grvCongNoVanChuyenMia_Layout_0});
            this.grvCongNoVanChuyenMia.Location = new System.Drawing.Point(17, 44);
            this.grvCongNoVanChuyenMia.Name = "grvCongNoVanChuyenMia";
            this.grvCongNoVanChuyenMia.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grvCongNoVanChuyenMia.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grvCongNoVanChuyenMia.ScrollBarWidth = 17;
            this.grvCongNoVanChuyenMia.SelectedFormatStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.grvCongNoVanChuyenMia.Size = new System.Drawing.Size(690, 208);
            this.grvCongNoVanChuyenMia.TabIndex = 75;
            this.grvCongNoVanChuyenMia.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grvCongNoVanChuyenMia.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grvCongNoVanChuyenMia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grvCongNoVanChuyenMia.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grvCongNoVanChuyenMia_RowDoubleClick);
            // 
            // TimKiemHopDongVanChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 296);
            this.Controls.Add(this.grvCongNoVanChuyenMia);
            this.Controls.Add(this.txtTenChuMia);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.label3);
            this.Name = "TimKiemHopDongVanChuyen";
            this.Text = "Tìm kiếm hợp đồng vận chuyển";
            ((System.ComponentModel.ISupportInitialize)(this.grvCongNoVanChuyenMia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtTenChuMia;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnOK;
        private Janus.Windows.EditControls.UIButton btnCancel;
        public Janus.Windows.GridEX.GridEX grvCongNoVanChuyenMia;
    }
}