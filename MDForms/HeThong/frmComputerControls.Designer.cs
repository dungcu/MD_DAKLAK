namespace DACASUCO.MDForms.HeThong
{
    partial class frmComputerControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComputerControls));
            Janus.Windows.GridEX.GridEXLayout gdComputer_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.gdComputer = new Janus.Windows.GridEX.GridEX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gdComputer)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdComputer
            // 
            this.gdComputer.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdComputer.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdComputer.AlternatingColors = true;
            this.gdComputer.AutoEdit = true;
            resources.ApplyResources(this.gdComputer, "gdComputer");
            this.gdComputer.ColumnAutoResize = true;
            resources.ApplyResources(gdComputer_DesignTimeLayout, "gdComputer_DesignTimeLayout");
            this.gdComputer.DesignTimeLayout = gdComputer_DesignTimeLayout;
            this.gdComputer.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdComputer.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdComputer.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdComputer.GridLineColor = System.Drawing.SystemColors.ControlLightLight;
            this.gdComputer.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdComputer.GroupByBoxVisible = false;
            this.gdComputer.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdComputer.Name = "gdComputer";
            this.gdComputer.NewRowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Flat;
            this.gdComputer.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdComputer.NewRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Solid;
            this.gdComputer.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdComputer.NewRowFormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.gdComputer.NewRowFormatStyle.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Center;
            this.gdComputer.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdComputer.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdComputer.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdComputer.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdComputer.ScrollBarWidth = 17;
            this.gdComputer.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdComputer.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVUser_DeletingRecord);
            this.gdComputer.RecordsDeleted += new System.EventHandler(this.gdVUser_RecordsDeleted);
            this.gdComputer.RecordUpdated += new System.EventHandler(this.gdVUser_RecordUpdated);
            this.gdComputer.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVUser_UpdatingRecord);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.gdComputer, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // frmComputerControls
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComputerControls";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.gdComputer)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdComputer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
       // private LD.MD2008.MDReport.Cachedsub_BangTongHopThanhToanTienMiaNguyenLieu1 cachedsub_BangTongHopThanhToanTienMiaNguyenLieu11;
        //private CrystalReport1 CrystalReport11;
        //private CrystalReport1 CrystalReport12;
        //private CrystalReport1 CrystalReport13;
        //private CrystalReport1 CrystalReport14;
        //private CrystalReport1 CrystalReport15;
    }
}