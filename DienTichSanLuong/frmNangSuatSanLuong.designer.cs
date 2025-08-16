namespace MDSolution
{
    partial class frmNangSuatSanLuong
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
            Janus.Windows.GridEX.GridEXLayout dgvNhapMia_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNangSuatSanLuong));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblVT = new System.Windows.Forms.Label();
            this.cmd2Exel = new System.Windows.Forms.Button();
            this.cmdIn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvNhapMia = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapMia)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.lblVT);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1800, 36);
            this.panel3.TabIndex = 8;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(545, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 16);
            this.label19.TabIndex = 31;
            this.label19.Text = "Niên vụ:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Blue;
            this.label18.Location = new System.Drawing.Point(10, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(512, 22);
            this.label18.TabIndex = 30;
            this.label18.Text = "THEO DÕI NĂNG SUẤT SẢN LƯỢNG MÍA NGUYÊN LIỆU";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVT
            // 
            this.lblVT.AutoSize = true;
            this.lblVT.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblVT.Location = new System.Drawing.Point(612, 7);
            this.lblVT.Name = "lblVT";
            this.lblVT.Size = new System.Drawing.Size(27, 18);
            this.lblVT.TabIndex = 29;
            this.lblVT.Text = "VT";
            this.lblVT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmd2Exel
            // 
            this.cmd2Exel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmd2Exel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd2Exel.Location = new System.Drawing.Point(13, 2);
            this.cmd2Exel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmd2Exel.Name = "cmd2Exel";
            this.cmd2Exel.Size = new System.Drawing.Size(91, 32);
            this.cmd2Exel.TabIndex = 20;
            this.cmd2Exel.Text = "2Excel";
            this.cmd2Exel.UseVisualStyleBackColor = true;
            this.cmd2Exel.Click += new System.EventHandler(this.cmd2Exel_Click);
            // 
            // cmdIn
            // 
            this.cmdIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIn.Location = new System.Drawing.Point(127, 2);
            this.cmdIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdIn.Name = "cmdIn";
            this.cmdIn.Size = new System.Drawing.Size(84, 32);
            this.cmdIn.TabIndex = 3;
            this.cmdIn.Text = "In chi tiết";
            this.cmdIn.UseVisualStyleBackColor = true;
            this.cmdIn.Click += new System.EventHandler(this.cmdIn_Click);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = " Excel files (*.xls)|*.xls|All files (*.*)|*.*";
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
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1800, 631);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvNhapMia, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1800, 591);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dgvNhapMia
            // 
            this.dgvNhapMia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            dgvNhapMia_DesignTimeLayout.LayoutString = resources.GetString("dgvNhapMia_DesignTimeLayout.LayoutString");
            this.dgvNhapMia.DesignTimeLayout = dgvNhapMia_DesignTimeLayout;
            this.dgvNhapMia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhapMia.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.dgvNhapMia.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.dgvNhapMia.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dgvNhapMia.FrozenColumns = 4;
            this.dgvNhapMia.GroupByBoxVisible = false;
            this.dgvNhapMia.Location = new System.Drawing.Point(3, 4);
            this.dgvNhapMia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvNhapMia.Name = "dgvNhapMia";
            this.dgvNhapMia.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.dgvNhapMia.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgvNhapMia.Size = new System.Drawing.Size(1794, 543);
            this.dgvNhapMia.TabIndex = 3;
            this.dgvNhapMia.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgvNhapMia.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.dgvNhapMia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmd2Exel);
            this.panel1.Controls.Add(this.cmdIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 554);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1794, 34);
            this.panel1.TabIndex = 4;
            // 
            // frmNangSuatSanLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 631);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "frmNangSuatSanLuong";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Theo dõi năng suất sản lượng mía nguyên liệu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNangSuatSanLuong_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapMia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdIn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button cmd2Exel;
        private System.Windows.Forms.Label lblVT;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Janus.Windows.GridEX.GridEX dgvNhapMia;
        private System.Windows.Forms.Panel panel1;
    }
}