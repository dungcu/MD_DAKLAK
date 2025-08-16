namespace DACASUCO.MDForms.ThanhToan
{
    partial class frmThanhToan_DuToanThu
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
            Janus.Windows.GridEX.GridEXLayout grvDuToanThuList_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThanhToan_DuToanThu));
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_vutrong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grvDuToanThuList = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_In = new Janus.Windows.EditControls.UIButton();
            this.btn_thoat = new Janus.Windows.EditControls.UIButton();
            this.btn_excel = new Janus.Windows.EditControls.UIButton();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.cmd_TinhDuToanDT = new Janus.Windows.EditControls.UIButton();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDuToanThuList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.panel2);
            this.uiGroupBox1.Controls.Add(this.panel1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(1093, 569);
            this.uiGroupBox1.TabIndex = 65;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1087, 521);
            this.panel2.TabIndex = 66;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbl_vutrong);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grvDuToanThuList);
            this.splitContainer1.Size = new System.Drawing.Size(1087, 521);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 66;
            // 
            // lbl_vutrong
            // 
            this.lbl_vutrong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_vutrong.AutoSize = true;
            this.lbl_vutrong.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vutrong.Location = new System.Drawing.Point(607, 5);
            this.lbl_vutrong.Name = "lbl_vutrong";
            this.lbl_vutrong.Size = new System.Drawing.Size(30, 19);
            this.lbl_vutrong.TabIndex = 1;
            this.lbl_vutrong.Text = "Vụ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "DỰ TOÁN THU NỢ ĐẦU TƯ NIÊN VỤ:";
            // 
            // grvDuToanThuList
            // 
            this.grvDuToanThuList.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grvDuToanThuList.AlternatingColors = true;
            this.grvDuToanThuList.AutomaticSort = false;
            this.grvDuToanThuList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvDuToanThuList.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.grvDuToanThuList.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grvDuToanThuList.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grvDuToanThuList.Font = new System.Drawing.Font("Arial", 9.75F);
            this.grvDuToanThuList.FrozenColumns = 6;
            this.grvDuToanThuList.GridLineColor = System.Drawing.Color.Black;
            this.grvDuToanThuList.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grvDuToanThuList.GroupByBoxVisible = false;
            grvDuToanThuList_Layout_0.IsCurrentLayout = true;
            grvDuToanThuList_Layout_0.Key = "tbl_DauTu";
            grvDuToanThuList_Layout_0.LayoutString = resources.GetString("grvDuToanThuList_Layout_0.LayoutString");
            this.grvDuToanThuList.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grvDuToanThuList_Layout_0});
            this.grvDuToanThuList.Location = new System.Drawing.Point(0, 0);
            this.grvDuToanThuList.Name = "grvDuToanThuList";
            this.grvDuToanThuList.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grvDuToanThuList.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grvDuToanThuList.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grvDuToanThuList.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grvDuToanThuList.ScrollBarWidth = 17;
            this.grvDuToanThuList.SelectedFormatStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.grvDuToanThuList.Size = new System.Drawing.Size(1087, 484);
            this.grvDuToanThuList.TabIndex = 65;
            this.grvDuToanThuList.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grvDuToanThuList.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grvDuToanThuList.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grvDuToanThuList.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grvDuToanThuList_CellUpdated);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btn_In);
            this.panel1.Controls.Add(this.btn_thoat);
            this.panel1.Controls.Add(this.btn_excel);
            this.panel1.Controls.Add(this.picLoading);
            this.panel1.Controls.Add(this.cmd_TinhDuToanDT);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 529);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 37);
            this.panel1.TabIndex = 66;
            // 
            // btn_In
            // 
            this.btn_In.Location = new System.Drawing.Point(747, 8);
            this.btn_In.Name = "btn_In";
            this.btn_In.Size = new System.Drawing.Size(101, 21);
            this.btn_In.TabIndex = 13;
            this.btn_In.Text = "In";
            this.btn_In.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btn_In.Click += new System.EventHandler(this.btn_In_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(979, 8);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(101, 21);
            this.btn_thoat.TabIndex = 12;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.Location = new System.Drawing.Point(863, 8);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(101, 21);
            this.btn_excel.TabIndex = 11;
            this.btn_excel.Text = "Xuất Excel";
            this.btn_excel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // picLoading
            // 
            this.picLoading.Image = global::DACASUCO.Properties.Resources.database_32;
            this.picLoading.Location = new System.Drawing.Point(415, 3);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(32, 32);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLoading.TabIndex = 10;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // cmd_TinhDuToanDT
            // 
            this.cmd_TinhDuToanDT.Image = global::DACASUCO.Properties.Resources._1367891550_credit_card_payment;
            this.cmd_TinhDuToanDT.Location = new System.Drawing.Point(297, 7);
            this.cmd_TinhDuToanDT.Name = "cmd_TinhDuToanDT";
            this.cmd_TinhDuToanDT.Size = new System.Drawing.Size(112, 21);
            this.cmd_TinhDuToanDT.TabIndex = 7;
            this.cmd_TinhDuToanDT.Text = "Tính tự động";
            this.cmd_TinhDuToanDT.Visible = false;
            this.cmd_TinhDuToanDT.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.cmd_TinhDuToanDT.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Location = new System.Drawing.Point(658, 17);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 16);
            this.lbStatus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tìm kiếm";
            // 
            // txtKey
            // 
            this.txtKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey.Location = new System.Drawing.Point(77, 8);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(214, 21);
            this.txtKey.TabIndex = 6;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = " Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // frmThanhToan_DuToanThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 569);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "frmThanhToan_DuToanThu";
            this.Text = "Dự toán thu thu nợ đầu tư";
            this.Load += new System.EventHandler(this.frmThanhToan_DuToanThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDuToanThuList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public Janus.Windows.GridEX.GridEX grvDuToanThuList;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtKey;
        private Janus.Windows.EditControls.UIButton cmd_TinhDuToanDT;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Label lbStatus;
        private Janus.Windows.EditControls.UIButton btn_thoat;
        private Janus.Windows.EditControls.UIButton btn_excel;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_vutrong;
        private Janus.Windows.EditControls.UIButton btn_In;
    }
}