namespace MDSolution
{
    partial class frmDiabanVC
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
            Janus.Windows.GridEX.GridEXLayout dgAvailable_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiabanVC));
            Janus.Windows.GridEX.GridEXLayout dgAssigned_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.cbChuHDVC = new System.Windows.Forms.ComboBox();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgAvailable = new Janus.Windows.GridEX.GridEX();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.dgAssigned = new Janus.Windows.GridEX.GridEX();
            this.cmdChuyen = new System.Windows.Forms.Button();
            this.cmdBo1 = new System.Windows.Forms.Button();
            this.cmd_OK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTram = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_All = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoXe = new System.Windows.Forms.TextBox();
            this.rdDaPB = new System.Windows.Forms.RadioButton();
            this.rdChuaPB = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAssigned)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbChuHDVC
            // 
            this.cbChuHDVC.DisplayMember = "Ten";
            this.cbChuHDVC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChuHDVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChuHDVC.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cbChuHDVC.FormattingEnabled = true;
            this.cbChuHDVC.Location = new System.Drawing.Point(92, 21);
            this.cbChuHDVC.Name = "cbChuHDVC";
            this.cbChuHDVC.Size = new System.Drawing.Size(323, 26);
            this.cbChuHDVC.TabIndex = 25;
            this.cbChuHDVC.ValueMember = "ID";
            this.cbChuHDVC.SelectedIndexChanged += new System.EventHandler(this.cbChuHDVC_SelectedIndexChanged);
            // 
            // uiTab1
            // 
            this.uiTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTab1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTab1.Location = new System.Drawing.Point(0, 0);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(1185, 610);
            this.uiTab1.TabIndex = 25;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1});
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007;
            this.uiTab1.VisualStyleManager = this.visualStyleManager1;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.tableLayoutPanel1);
            this.uiTabPage1.Controls.Add(this.groupBox1);
            this.uiTabPage1.Controls.Add(this.groupBox3);
            this.uiTabPage1.Controls.Add(this.panel1);
            this.uiTabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTabPage1.Location = new System.Drawing.Point(1, 24);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(1183, 585);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "Điều hành xe vận chuyển";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgAvailable, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgAssigned, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 105);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1183, 480);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // dgAvailable
            // 
            this.dgAvailable.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.dgAvailable.BorderStyle = Janus.Windows.GridEX.BorderStyle.Raised;
            this.dgAvailable.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><EmptyGridInfo>Chưa có" +
    " dữ liệu xe có sẵn</EmptyGridInfo></LocalizableData>";
            dgAvailable_DesignTimeLayout.LayoutString = resources.GetString("dgAvailable_DesignTimeLayout.LayoutString");
            this.dgAvailable.DesignTimeLayout = dgAvailable_DesignTimeLayout;
            this.dgAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAvailable.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.dgAvailable.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.dgAvailable.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAvailable.FrozenColumns = 3;
            this.dgAvailable.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.dgAvailable.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.dgAvailable.GroupByBoxVisible = false;
            this.dgAvailable.HeaderFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.dgAvailable.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.dgAvailable.HeaderFormatStyle.ForeColor = System.Drawing.Color.Indigo;
            this.dgAvailable.Location = new System.Drawing.Point(3, 3);
            this.dgAvailable.Name = "dgAvailable";
            this.dgAvailable.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.dgAvailable.Size = new System.Drawing.Size(545, 474);
            this.dgAvailable.TabIndex = 5;
            this.dgAvailable.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgAvailable.TotalRowFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.dgAvailable.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.dgAvailable.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.dgAvailable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.dgAvailable.VisualStyleManager = this.visualStyleManager1;
            this.dgAvailable.WatermarkImage.Alpha = 150;
            this.dgAvailable.WatermarkImage.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dgAvailable.WatermarkImage.MaskColor = System.Drawing.Color.Silver;
            this.dgAvailable.WatermarkImage.WashColor = System.Drawing.Color.Lavender;
            this.dgAvailable.WatermarkImage.WashMode = Janus.Windows.GridEX.WashMode.UseWashColor;
            // 
            // dgAssigned
            // 
            this.dgAssigned.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.dgAssigned.AlternatingRowFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dgAssigned.BorderStyle = Janus.Windows.GridEX.BorderStyle.Raised;
            this.dgAssigned.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><EmptyGridInfo>Chưa có" +
    " dữ liệu xe được gán</EmptyGridInfo></LocalizableData>";
            this.dgAssigned.CardColumnHeaderFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dgAssigned_DesignTimeLayout.LayoutString = resources.GetString("dgAssigned_DesignTimeLayout.LayoutString");
            this.dgAssigned.DesignTimeLayout = dgAssigned_DesignTimeLayout;
            this.dgAssigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAssigned.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.dgAssigned.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.dgAssigned.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAssigned.FrozenColumns = 3;
            this.dgAssigned.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.dgAssigned.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.dgAssigned.GroupByBoxVisible = false;
            this.dgAssigned.HeaderFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.dgAssigned.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.dgAssigned.HeaderFormatStyle.ForeColor = System.Drawing.Color.Purple;
            this.dgAssigned.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.dgAssigned.Location = new System.Drawing.Point(634, 3);
            this.dgAssigned.Name = "dgAssigned";
            this.dgAssigned.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.dgAssigned.Size = new System.Drawing.Size(546, 474);
            this.dgAssigned.TabIndex = 34;
            this.dgAssigned.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgAssigned.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.dgAssigned.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.dgAssigned.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.dgAssigned.VisualStyleManager = this.visualStyleManager1;
            this.dgAssigned.WatermarkImage.Alpha = 90;
            this.dgAssigned.WatermarkImage.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dgAssigned.WatermarkImage.MaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgAssigned.WatermarkImage.WashColor = System.Drawing.Color.DodgerBlue;
            this.dgAssigned.WatermarkImage.WashMode = Janus.Windows.GridEX.WashMode.UseWashColor;
            // 
            // cmdChuyen
            // 
            this.cmdChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChuyen.ForeColor = System.Drawing.Color.Green;
            this.cmdChuyen.Location = new System.Drawing.Point(6, 111);
            this.cmdChuyen.Name = "cmdChuyen";
            this.cmdChuyen.Size = new System.Drawing.Size(63, 36);
            this.cmdChuyen.TabIndex = 40;
            this.cmdChuyen.TabStop = false;
            this.cmdChuyen.Text = ">>";
            this.cmdChuyen.UseVisualStyleBackColor = true;
            this.cmdChuyen.Click += new System.EventHandler(this.cmdChuyen_Click);
            // 
            // cmdBo1
            // 
            this.cmdBo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBo1.ForeColor = System.Drawing.Color.Red;
            this.cmdBo1.Location = new System.Drawing.Point(6, 170);
            this.cmdBo1.Name = "cmdBo1";
            this.cmdBo1.Size = new System.Drawing.Size(63, 36);
            this.cmdBo1.TabIndex = 39;
            this.cmdBo1.TabStop = false;
            this.cmdBo1.Text = "<<";
            this.cmdBo1.UseVisualStyleBackColor = true;
            this.cmdBo1.Click += new System.EventHandler(this.cmdBo1_Click);
            // 
            // cmd_OK
            // 
            this.cmd_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_OK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_OK.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cmd_OK.Location = new System.Drawing.Point(6, 229);
            this.cmd_OK.Name = "cmd_OK";
            this.cmd_OK.Size = new System.Drawing.Size(63, 36);
            this.cmd_OK.TabIndex = 31;
            this.cmd_OK.TabStop = false;
            this.cmd_OK.Text = "&OK";
            this.cmd_OK.UseVisualStyleBackColor = true;
            this.cmd_OK.Click += new System.EventHandler(this.cmd_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbTram);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(842, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 82);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gán xe cho Trạm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(73, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Tên Trạm:";
            // 
            // cbTram
            // 
            this.cbTram.DisplayMember = "Ten";
            this.cbTram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTram.FormattingEnabled = true;
            this.cbTram.Location = new System.Drawing.Point(155, 33);
            this.cbTram.Name = "cbTram";
            this.cbTram.Size = new System.Drawing.Size(139, 24);
            this.cbTram.TabIndex = 31;
            this.cbTram.ValueMember = "ID";
            this.cbTram.SelectedIndexChanged += new System.EventHandler(this.cbTram_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.chk_All);
            this.groupBox3.Controls.Add(this.cbChuHDVC);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(11, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(456, 82);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chọn xe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Chủ HĐVC:";
            // 
            // chk_All
            // 
            this.chk_All.AutoSize = true;
            this.chk_All.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_All.ForeColor = System.Drawing.Color.DarkRed;
            this.chk_All.Location = new System.Drawing.Point(92, 56);
            this.chk_All.Name = "chk_All";
            this.chk_All.Size = new System.Drawing.Size(218, 22);
            this.chk_All.TabIndex = 33;
            this.chk_All.Text = "Chọn tất cả xe chưa được gán";
            this.chk_All.UseVisualStyleBackColor = true;
            this.chk_All.CheckedChanged += new System.EventHandler(this.chk_All_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1183, 105);
            this.panel1.TabIndex = 43;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtSoXe);
            this.groupBox2.Controls.Add(this.rdDaPB);
            this.groupBox2.Controls.Add(this.rdChuaPB);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox2.Location = new System.Drawing.Point(471, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 82);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(33, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nhập số xe:";
            // 
            // txtSoXe
            // 
            this.txtSoXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoXe.Location = new System.Drawing.Point(117, 50);
            this.txtSoXe.Name = "txtSoXe";
            this.txtSoXe.Size = new System.Drawing.Size(212, 24);
            this.txtSoXe.TabIndex = 2;
            this.txtSoXe.Click += new System.EventHandler(this.txtSoXe_Click);
            this.txtSoXe.TextChanged += new System.EventHandler(this.txtSoXe_TextChanged);
            // 
            // rdDaPB
            // 
            this.rdDaPB.AutoSize = true;
            this.rdDaPB.Checked = true;
            this.rdDaPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDaPB.ForeColor = System.Drawing.SystemColors.InfoText;
            this.rdDaPB.Location = new System.Drawing.Point(183, 24);
            this.rdDaPB.Name = "rdDaPB";
            this.rdDaPB.Size = new System.Drawing.Size(172, 17);
            this.rdDaPB.TabIndex = 1;
            this.rdDaPB.TabStop = true;
            this.rdDaPB.Text = "Xe đã được phân bổ vào Trạm";
            this.rdDaPB.UseVisualStyleBackColor = true;
            // 
            // rdChuaPB
            // 
            this.rdChuaPB.AutoSize = true;
            this.rdChuaPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdChuaPB.ForeColor = System.Drawing.SystemColors.InfoText;
            this.rdChuaPB.Location = new System.Drawing.Point(23, 24);
            this.rdChuaPB.Name = "rdChuaPB";
            this.rdChuaPB.Size = new System.Drawing.Size(135, 17);
            this.rdChuaPB.TabIndex = 0;
            this.rdChuaPB.Text = "Xe chưa được phân bổ";
            this.rdChuaPB.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmdChuyen);
            this.groupBox4.Controls.Add(this.cmd_OK);
            this.groupBox4.Controls.Add(this.cmdBo1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(554, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(74, 474);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            // 
            // frmDiabanVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 610);
            this.Controls.Add(this.uiTab1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmDiabanVC";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gán địa bàn cho xe vận chuyển";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDiabanVC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAssigned)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.GridEX.GridEX dgAvailable;
        private System.Windows.Forms.ComboBox cbChuHDVC;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chk_All;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmd_OK;
        private System.Windows.Forms.Button cmdChuyen;
        private System.Windows.Forms.Button cmdBo1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdDaPB;
        private System.Windows.Forms.RadioButton rdChuaPB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoXe;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Janus.Windows.GridEX.GridEX dgAssigned;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}