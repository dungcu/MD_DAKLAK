namespace DACASUCO.MDForms.ThanhToan
{
    partial class frmThanhToan2013_NhapTienTraNo
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
            Janus.Windows.GridEX.GridEXLayout grvNoDauTu_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThanhToan2013_NhapTienTraNo));
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.grvNoDauTu = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvNoDauTu)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.grvNoDauTu);
            this.uiGroupBox1.Controls.Add(this.btnCancel);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(816, 358);
            this.uiGroupBox1.TabIndex = 63;
            this.uiGroupBox1.Text = "Nhập tiền trả nợ";
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(364, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 21);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grvNoDauTu
            // 
            this.grvNoDauTu.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grvNoDauTu.AlternatingColors = true;
            this.grvNoDauTu.AutomaticSort = false;
            this.grvNoDauTu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grvNoDauTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grvNoDauTu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grvNoDauTu.FrozenColumns = 4;
            this.grvNoDauTu.GridLineColor = System.Drawing.Color.Black;
            this.grvNoDauTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grvNoDauTu.GroupByBoxVisible = false;
            grvNoDauTu_Layout_0.IsCurrentLayout = true;
            grvNoDauTu_Layout_0.Key = "tbl_DauTu";
            grvNoDauTu_Layout_0.LayoutString = resources.GetString("grvNoDauTu_Layout_0.LayoutString");
            this.grvNoDauTu.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grvNoDauTu_Layout_0});
            this.grvNoDauTu.Location = new System.Drawing.Point(3, 17);
            this.grvNoDauTu.Name = "grvNoDauTu";
            this.grvNoDauTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grvNoDauTu.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grvNoDauTu.ScrollBarWidth = 17;
            this.grvNoDauTu.SelectedFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.grvNoDauTu.Size = new System.Drawing.Size(810, 260);
            this.grvNoDauTu.TabIndex = 66;
            this.grvNoDauTu.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grvNoDauTu.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grvNoDauTu.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grvNoDauTu.CellEdited += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grvNoDauTu_CellEdited);
            // 
            // frmThanhToan2013_NhapTienTraNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(816, 358);
            this.Controls.Add(this.uiGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmThanhToan2013_NhapTienTraNo";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvNoDauTu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btnCancel;
        public Janus.Windows.GridEX.GridEX grvNoDauTu;
    }
}