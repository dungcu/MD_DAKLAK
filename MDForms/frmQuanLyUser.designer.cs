namespace MDSolution
{
    partial class frmQuanLyUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyUser));
            Janus.Windows.GridEX.GridEXLayout gdVUser_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gridTram_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gdVDMTD01_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.btGhiNhan = new Janus.Windows.EditControls.UIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gdVUser = new Janus.Windows.GridEX.GridEX();
            this.uiButtonControl = new Janus.Windows.EditControls.UIButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridTram = new Janus.Windows.GridEX.GridEX();
            this.gdVDMTD01 = new Janus.Windows.GridEX.GridEX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdVUser)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD01)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.ForeColor = System.Drawing.Color.Maroon;
            this.lblUser.Name = "lblUser";
            // 
            // lblHoTen
            // 
            resources.ApplyResources(this.lblHoTen, "lblHoTen");
            this.lblHoTen.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblHoTen.Name = "lblHoTen";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // uiButton1
            // 
            this.uiButton1.Icon = ((System.Drawing.Icon)(resources.GetObject("uiButton1.Icon")));
            resources.ApplyResources(this.uiButton1, "uiButton1");
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // btGhiNhan
            // 
            this.btGhiNhan.Icon = ((System.Drawing.Icon)(resources.GetObject("btGhiNhan.Icon")));
            this.btGhiNhan.Image = global::DACASUCO.Properties.Resources.end;
            resources.ApplyResources(this.btGhiNhan, "btGhiNhan");
            this.btGhiNhan.Name = "btGhiNhan";
            this.btGhiNhan.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btGhiNhan.Click += new System.EventHandler(this.btGhiNhan_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Name = "label3";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gdVUser);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // gdVUser
            // 
            this.gdVUser.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVUser.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVUser.AlternatingColors = true;
            this.gdVUser.AutoEdit = true;
            resources.ApplyResources(this.gdVUser, "gdVUser");
            resources.ApplyResources(gdVUser_DesignTimeLayout, "gdVUser_DesignTimeLayout");
            this.gdVUser.DesignTimeLayout = gdVUser_DesignTimeLayout;
            this.gdVUser.DynamicFiltering = true;
            this.gdVUser.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVUser.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdVUser.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdVUser.GridLineColor = System.Drawing.SystemColors.ControlLightLight;
            this.gdVUser.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVUser.GroupByBoxVisible = false;
            this.gdVUser.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdVUser.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVUser.Name = "gdVUser";
            this.gdVUser.NewRowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Flat;
            this.gdVUser.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdVUser.NewRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Solid;
            this.gdVUser.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVUser.NewRowFormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.gdVUser.NewRowFormatStyle.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Center;
            this.gdVUser.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVUser.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVUser.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVUser.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVUser.ScrollBarWidth = 17;
            this.gdVUser.SelectedFormatStyle.BackColor = System.Drawing.Color.PaleGreen;
            this.gdVUser.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVUser.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gdVUser.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVUser_DeletingRecord);
            this.gdVUser.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVUser_UpdatingRecord);
            this.gdVUser.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVUser_AddingRecord);
            this.gdVUser.SelectionChanged += new System.EventHandler(this.gdVUser_SelectionChanged);
            // 
            // uiButtonControl
            // 
            resources.ApplyResources(this.uiButtonControl, "uiButtonControl");
            this.uiButtonControl.Icon = ((System.Drawing.Icon)(resources.GetObject("uiButtonControl.Icon")));
            this.uiButtonControl.Name = "uiButtonControl";
            this.uiButtonControl.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButtonControl.Click += new System.EventHandler(this.uiButtonControl_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.gridTram, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gdVDMTD01, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // gridTram
            // 
            this.gridTram.AlternatingColors = true;
            this.gridTram.AutoEdit = true;
            resources.ApplyResources(this.gridTram, "gridTram");
            this.gridTram.ColumnAutoResize = true;
            resources.ApplyResources(gridTram_DesignTimeLayout, "gridTram_DesignTimeLayout");
            this.gridTram.DesignTimeLayout = gridTram_DesignTimeLayout;
            this.gridTram.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gridTram.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gridTram.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridTram.GroupByBoxVisible = false;
            this.gridTram.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gridTram.Name = "gridTram";
            this.gridTram.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridTram.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gridTram.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridTram.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gridTram.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gridTram.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridTram.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gridTram.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridTram.ScrollBarWidth = 17;
            this.gridTram.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridTram.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridTram.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gridTram.UpdateOnLeave = false;
            // 
            // gdVDMTD01
            // 
            this.gdVDMTD01.AlternatingColors = true;
            this.gdVDMTD01.AutoEdit = true;
            resources.ApplyResources(this.gdVDMTD01, "gdVDMTD01");
            this.gdVDMTD01.ColumnAutoResize = true;
            resources.ApplyResources(gdVDMTD01_DesignTimeLayout, "gdVDMTD01_DesignTimeLayout");
            this.gdVDMTD01.DesignTimeLayout = gdVDMTD01_DesignTimeLayout;
            this.gdVDMTD01.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVDMTD01.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVDMTD01.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVDMTD01.GroupByBoxVisible = false;
            this.gdVDMTD01.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVDMTD01.Name = "gdVDMTD01";
            this.gdVDMTD01.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdVDMTD01.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD01.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD01.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD01.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVDMTD01.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVDMTD01.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVDMTD01.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD01.ScrollBarWidth = 17;
            this.gdVDMTD01.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVDMTD01.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD01.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVDMTD01.UpdateOnLeave = false;
            // 
            // frmQuanLyUser
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.uiButtonControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btGhiNhan);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmQuanLyUser_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdVUser)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton btGhiNhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Panel panel1;
        internal Janus.Windows.GridEX.GridEX gdVUser;
        private Janus.Windows.EditControls.UIButton uiButtonControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal Janus.Windows.GridEX.GridEX gridTram;
        internal Janus.Windows.GridEX.GridEX gdVDMTD01;
        //private CrystalReport1 CrystalReport11;
        //private CrystalReport1 CrystalReport12;
        //private CrystalReport1 CrystalReport13;
        //private CrystalReport1 CrystalReport14;
        //private CrystalReport1 CrystalReport15;
    }
}