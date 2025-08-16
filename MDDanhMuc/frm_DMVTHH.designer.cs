namespace MDSolution
{
    partial class frm_DMVTHH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DMVTHH));
            this.gdVDMTD = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdVDMTD
            // 
            this.gdVDMTD.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.AlternatingColors = true;
            this.gdVDMTD.AutoEdit = true;
            this.gdVDMTD.ColumnAutoResize = true;
            gdVDMTD_DesignTimeLayout.LayoutString = resources.GetString("gdVDMTD_DesignTimeLayout.LayoutString");
            this.gdVDMTD.DesignTimeLayout = gdVDMTD_DesignTimeLayout;
            this.gdVDMTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVDMTD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdVDMTD.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVDMTD.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVDMTD.GroupByBoxVisible = false;
            this.gdVDMTD.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdVDMTD.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVDMTD.Location = new System.Drawing.Point(0, 0);
            this.gdVDMTD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdVDMTD.Name = "gdVDMTD";
            this.gdVDMTD.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVDMTD.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdVDMTD.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVDMTD.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.ScrollBarWidth = 17;
            this.gdVDMTD.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.Size = new System.Drawing.Size(560, 242);
            this.gdVDMTD.TabIndex = 9;
            this.gdVDMTD.UpdateOnLeave = false;
            this.gdVDMTD.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.gdVDMTD.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVDMTD_DeletingRecord);
            this.gdVDMTD.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD_UpdatingRecord);
            this.gdVDMTD.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD_AddingRecord);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gdVDMTD);
            this.panel1.Location = new System.Drawing.Point(7, 79);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 242);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "THIẾT LẬP DANH MỤC HÀNG HÓA QUA CÂN";
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmdThoat.Image = global::DACASUCO.Properties.Resources.action_stop;
            this.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThoat.Location = new System.Drawing.Point(440, 356);
            this.cmdThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(117, 43);
            this.cmdThoat.TabIndex = 12;
            this.cmdThoat.Text = "Close (Esc)";
            this.cmdThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdThoat.UseVisualStyleBackColor = true;
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // frm_DMVTHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdThoat;
            this.ClientSize = new System.Drawing.Size(570, 414);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DMVTHH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục hàng hóa";
            this.Load += new System.EventHandler(this.Frm_NoiUngVatTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVDMTD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdThoat;
    }
}