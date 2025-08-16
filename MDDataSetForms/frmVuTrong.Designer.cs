namespace DACASUCO.MDDanhMuc
{
    partial class frmVuTrong
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
            Janus.Windows.GridEX.GridEXLayout gdVDMTD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVuTrong));
            this.gdVDMTD = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdVDMTD
            // 
            this.gdVDMTD.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.AlternatingColors = true;
            this.gdVDMTD.AutoEdit = true;
            this.gdVDMTD.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdVDMTD.ColumnAutoResize = true;
            gdVDMTD_DesignTimeLayout.LayoutString = resources.GetString("gdVDMTD_DesignTimeLayout.LayoutString");
            this.gdVDMTD.DesignTimeLayout = gdVDMTD_DesignTimeLayout;
            this.gdVDMTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVDMTD.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVDMTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdVDMTD.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVDMTD.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVDMTD.GroupByBoxVisible = false;
            this.gdVDMTD.HeaderFormatStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gdVDMTD.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdVDMTD.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVDMTD.Location = new System.Drawing.Point(0, 0);
            this.gdVDMTD.Name = "gdVDMTD";
            this.gdVDMTD.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdVDMTD.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVDMTD.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVDMTD.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVDMTD.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVDMTD.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.ScrollBarWidth = 17;
            this.gdVDMTD.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVDMTD.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.Size = new System.Drawing.Size(587, 246);
            this.gdVDMTD.TabIndex = 8;
            this.gdVDMTD.UpdateOnLeave = false;
            this.gdVDMTD.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.gdVDMTD.RecordUpdated += new System.EventHandler(this.gdVVuTrong_RecordUpdated);
            this.gdVDMTD.RecordAdded += new System.EventHandler(this.gdVDMTD_RecordAdded);
            this.gdVDMTD.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVVuTrong_UpdatingRecord);
            this.gdVDMTD.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD_AddingRecord);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gdVDMTD);
            this.panel1.Location = new System.Drawing.Point(15, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 250);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(188, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "THIẾT LẬP VỤ TRỒNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(509, 321);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(97, 33);
            this.cmdClose.TabIndex = 11;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(15, 305);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 61);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chú ý";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(36, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Chỉ định vụ trồng mặc định nếu thuộc tính Mặc định của vụ trồng ấy được check";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(35, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Trên form login của user sẽ xuất hiện nhiều vụ trồng nếu thuộc tính Hiển thị được" +
    " check";
            // 
            // frmVuTrong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(618, 368);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVuTrong";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết lập vụ trồng";
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVDMTD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}