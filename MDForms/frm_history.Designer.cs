namespace LD.MD2008.MDForms
{
    partial class frm_history
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.phụcHồiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToànBộToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.GVHistory = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GVPast = new System.Windows.Forms.DataGridView();
            this.lbPast = new System.Windows.Forms.Label();
            this.GVCurent = new System.Windows.Forms.DataGridView();
            this.lbcurent = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.btDeleteAll = new System.Windows.Forms.Button();
            this.btdelete = new System.Windows.Forms.Button();
            this.btShowAll = new System.Windows.Forms.Button();
            this.btShow = new System.Windows.Forms.Button();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.DTTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVHistory)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVPast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVCurent)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel23.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phụcHồiToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.xóaToànBộToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // phụcHồiToolStripMenuItem
            // 
            this.phụcHồiToolStripMenuItem.Name = "phụcHồiToolStripMenuItem";
            this.phụcHồiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.phụcHồiToolStripMenuItem.Text = "Phục hồi";
            this.phụcHồiToolStripMenuItem.Click += new System.EventHandler(this.phụcHồiToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            // 
            // xóaToànBộToolStripMenuItem
            // 
            this.xóaToànBộToolStripMenuItem.Name = "xóaToànBộToolStripMenuItem";
            this.xóaToànBộToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.xóaToànBộToolStripMenuItem.Text = "Xóa toàn bộ";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.GVHistory);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(860, 515);
            this.splitContainer2.SplitterDistance = 320;
            this.splitContainer2.TabIndex = 4;
            // 
            // GVHistory
            // 
            this.GVHistory.AllowUserToAddRows = false;
            this.GVHistory.AllowUserToDeleteRows = false;
            this.GVHistory.AllowUserToOrderColumns = true;
            this.GVHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GVHistory.BackgroundColor = System.Drawing.Color.LightGray;
            this.GVHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVHistory.GridColor = System.Drawing.Color.Silver;
            this.GVHistory.Location = new System.Drawing.Point(0, 0);
            this.GVHistory.MultiSelect = false;
            this.GVHistory.Name = "GVHistory";
            this.GVHistory.ReadOnly = true;
            this.GVHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GVHistory.Size = new System.Drawing.Size(860, 320);
            this.GVHistory.TabIndex = 0;
            this.GVHistory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GVHistory_DataBindingComplete);
            this.GVHistory.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVHistory_CellEnter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GVPast);
            this.splitContainer1.Panel1.Controls.Add(this.lbPast);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GVCurent);
            this.splitContainer1.Panel2.Controls.Add(this.lbcurent);
            this.splitContainer1.Size = new System.Drawing.Size(860, 191);
            this.splitContainer1.SplitterDistance = 352;
            this.splitContainer1.TabIndex = 3;
            // 
            // GVPast
            // 
            this.GVPast.AllowUserToAddRows = false;
            this.GVPast.AllowUserToDeleteRows = false;
            this.GVPast.AllowUserToOrderColumns = true;
            this.GVPast.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GVPast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVPast.ContextMenuStrip = this.contextMenuStrip1;
            this.GVPast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVPast.Location = new System.Drawing.Point(0, 45);
            this.GVPast.MultiSelect = false;
            this.GVPast.Name = "GVPast";
            this.GVPast.ReadOnly = true;
            this.GVPast.Size = new System.Drawing.Size(352, 146);
            this.GVPast.TabIndex = 3;
            this.GVPast.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVPast_CellClick);
            this.GVPast.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVPast_CellEnter);
            // 
            // lbPast
            // 
            this.lbPast.BackColor = System.Drawing.Color.Silver;
            this.lbPast.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPast.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbPast.Location = new System.Drawing.Point(0, 0);
            this.lbPast.Name = "lbPast";
            this.lbPast.Size = new System.Drawing.Size(352, 45);
            this.lbPast.TabIndex = 2;
            this.lbPast.Text = "DỮ LIỆU THAY ĐỔI";
            this.lbPast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GVCurent
            // 
            this.GVCurent.AllowUserToAddRows = false;
            this.GVCurent.AllowUserToDeleteRows = false;
            this.GVCurent.AllowUserToOrderColumns = true;
            this.GVCurent.BackgroundColor = System.Drawing.Color.Teal;
            this.GVCurent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVCurent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVCurent.Location = new System.Drawing.Point(0, 45);
            this.GVCurent.MultiSelect = false;
            this.GVCurent.Name = "GVCurent";
            this.GVCurent.ReadOnly = true;
            this.GVCurent.Size = new System.Drawing.Size(504, 146);
            this.GVCurent.TabIndex = 4;
            this.GVCurent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVCurent_CellClick);
            this.GVCurent.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GVCurent_DataBindingComplete);
            // 
            // lbcurent
            // 
            this.lbcurent.BackColor = System.Drawing.Color.Silver;
            this.lbcurent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbcurent.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbcurent.Location = new System.Drawing.Point(0, 0);
            this.lbcurent.Name = "lbcurent";
            this.lbcurent.Size = new System.Drawing.Size(504, 45);
            this.lbcurent.TabIndex = 3;
            this.lbcurent.Text = "DỮ LIỆU HIỆN TẠI";
            this.lbcurent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 515);
            this.panel1.TabIndex = 5;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.btDeleteAll);
            this.panel23.Controls.Add(this.btdelete);
            this.panel23.Controls.Add(this.btShowAll);
            this.panel23.Controls.Add(this.btShow);
            this.panel23.Controls.Add(this.dtDenNgay);
            this.panel23.Controls.Add(this.DTTuNgay);
            this.panel23.Controls.Add(this.label4);
            this.panel23.Controls.Add(this.label3);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(0, 0);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(860, 44);
            this.panel23.TabIndex = 6;
            // 
            // btDeleteAll
            // 
            this.btDeleteAll.Location = new System.Drawing.Point(663, 8);
            this.btDeleteAll.Name = "btDeleteAll";
            this.btDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btDeleteAll.TabIndex = 6;
            this.btDeleteAll.Text = "Xóa hết";
            this.toolTip1.SetToolTip(this.btDeleteAll, "Xóa hết dữ liệu trong bảng tạm");
            this.btDeleteAll.UseVisualStyleBackColor = true;
            this.btDeleteAll.Click += new System.EventHandler(this.btDeleteAll_Click);
            // 
            // btdelete
            // 
            this.btdelete.Location = new System.Drawing.Point(582, 8);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(75, 23);
            this.btdelete.TabIndex = 5;
            this.btdelete.Text = "Xóa";
            this.toolTip1.SetToolTip(this.btdelete, "Xóa dữ liệu trong bảng tạm");
            this.btdelete.UseVisualStyleBackColor = true;
            this.btdelete.Click += new System.EventHandler(this.btdelete_Click);
            // 
            // btShowAll
            // 
            this.btShowAll.Location = new System.Drawing.Point(501, 8);
            this.btShowAll.Name = "btShowAll";
            this.btShowAll.Size = new System.Drawing.Size(75, 23);
            this.btShowAll.TabIndex = 4;
            this.btShowAll.Text = "Hiển thị hết";
            this.toolTip1.SetToolTip(this.btShowAll, "Hiển thị hết tất cả những dữ lliệu đã thay đổi");
            this.btShowAll.UseVisualStyleBackColor = true;
            this.btShowAll.Click += new System.EventHandler(this.btShowAll_Click);
            // 
            // btShow
            // 
            this.btShow.Location = new System.Drawing.Point(420, 9);
            this.btShow.Name = "btShow";
            this.btShow.Size = new System.Drawing.Size(75, 23);
            this.btShow.TabIndex = 3;
            this.btShow.Text = "Hiển thị";
            this.toolTip1.SetToolTip(this.btShow, "Hiển thị theo ngày chọn");
            this.btShow.UseVisualStyleBackColor = true;
            this.btShow.Click += new System.EventHandler(this.btShow_Click);
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(296, 9);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(101, 20);
            this.dtDenNgay.TabIndex = 2;
            // 
            // DTTuNgay
            // 
            this.DTTuNgay.CustomFormat = "dd/MM/yyyy";
            this.DTTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTTuNgay.Location = new System.Drawing.Point(134, 9);
            this.DTTuNgay.Name = "DTTuNgay";
            this.DTTuNgay.Size = new System.Drawing.Size(95, 20);
            this.DTTuNgay.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label4.Location = new System.Drawing.Point(237, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đến ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label3.Location = new System.Drawing.Point(64, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Từ ngày";
            // 
            // frm_history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 559);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel23);
            this.Name = "frm_history";
            this.Text = "history";
            this.Load += new System.EventHandler(this.frm_history_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVHistory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVPast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVCurent)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem phụcHồiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToànBộToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView GVPast;
        private System.Windows.Forms.Label lbPast;
        private System.Windows.Forms.DataGridView GVCurent;
        private System.Windows.Forms.Label lbcurent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btShowAll;
        private System.Windows.Forms.Button btShow;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.DateTimePicker DTTuNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btDeleteAll;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btdelete;
        private System.Windows.Forms.DataGridView GVHistory;
    }
}