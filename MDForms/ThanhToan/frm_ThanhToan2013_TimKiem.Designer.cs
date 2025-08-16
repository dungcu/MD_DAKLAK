namespace DACASUCO.MDForms.ThanhToan
{
    partial class frm_ThanhToan2013_TimKiem
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
            Janus.Windows.GridEX.GridEXLayout grvThanhToanTienMia_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ThanhToan2013_TimKiem));
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.grvThanhToanTienMia = new Janus.Windows.GridEX.GridEX();
            this.txtTenChuMia = new System.Windows.Forms.TextBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvThanhToanTienMia)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.grvThanhToanTienMia);
            this.uiGroupBox1.Controls.Add(this.txtTenChuMia);
            this.uiGroupBox1.Controls.Add(this.txtMaHD);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.btnOK);
            this.uiGroupBox1.Controls.Add(this.btnCancel);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(704, 306);
            this.uiGroupBox1.TabIndex = 64;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // grvThanhToanTienMia
            // 
            this.grvThanhToanTienMia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grvThanhToanTienMia.AlternatingColors = true;
            this.grvThanhToanTienMia.AutomaticSort = false;
            this.grvThanhToanTienMia.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.grvThanhToanTienMia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grvThanhToanTienMia.FrozenColumns = 4;
            this.grvThanhToanTienMia.GridLineColor = System.Drawing.Color.Black;
            this.grvThanhToanTienMia.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grvThanhToanTienMia.GroupByBoxVisible = false;
            grvThanhToanTienMia_Layout_0.IsCurrentLayout = true;
            grvThanhToanTienMia_Layout_0.Key = "tbl_DauTu";
            grvThanhToanTienMia_Layout_0.LayoutString = resources.GetString("grvThanhToanTienMia_Layout_0.LayoutString");
            this.grvThanhToanTienMia.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grvThanhToanTienMia_Layout_0});
            this.grvThanhToanTienMia.Location = new System.Drawing.Point(6, 39);
            this.grvThanhToanTienMia.Name = "grvThanhToanTienMia";
            this.grvThanhToanTienMia.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grvThanhToanTienMia.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grvThanhToanTienMia.ScrollBarWidth = 17;
            this.grvThanhToanTienMia.SelectedFormatStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.grvThanhToanTienMia.Size = new System.Drawing.Size(690, 208);
            this.grvThanhToanTienMia.TabIndex = 65;
            this.grvThanhToanTienMia.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grvThanhToanTienMia.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grvThanhToanTienMia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grvThanhToanTienMia.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grvThanhToanTienMia_RowDoubleClick);
            // 
            // txtTenChuMia
            // 
            this.txtTenChuMia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtTenChuMia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTenChuMia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenChuMia.Location = new System.Drawing.Point(202, 12);
            this.txtTenChuMia.Name = "txtTenChuMia";
            this.txtTenChuMia.Size = new System.Drawing.Size(494, 21);
            this.txtTenChuMia.TabIndex = 6;
            this.txtTenChuMia.TextChanged += new System.EventHandler(this.txtTenChuMia_TextChanged);
            this.txtTenChuMia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaHD_KeyPress);
            // 
            // txtMaHD
            // 
            this.txtMaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaHD.Location = new System.Drawing.Point(81, 12);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(111, 21);
            this.txtMaHD.TabIndex = 4;
            this.txtMaHD.TextChanged += new System.EventHandler(this.txtMaHD_TextChanged);
            this.txtMaHD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaHD_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(19, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chủ mía:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(381, 273);
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
            this.btnCancel.Location = new System.Drawing.Point(286, 273);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 21);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_ThanhToan2013_TimKiem
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(704, 306);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_ThanhToan2013_TimKiem";
            this.Text = "Tìm kiếm hợp đồng";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvThanhToanTienMia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIButton btnOK;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private System.Windows.Forms.Label label3;
        public Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        public System.Windows.Forms.TextBox txtTenChuMia;
        public System.Windows.Forms.TextBox txtMaHD;
        public Janus.Windows.GridEX.GridEX grvThanhToanTienMia;
    }
}