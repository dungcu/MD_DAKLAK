namespace MDSolution.MDDataSetForms
{
    partial class frmNganHang
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
            Janus.Windows.Common.JanusColorScheme janusColorScheme1 = new Janus.Windows.Common.JanusColorScheme();
            Janus.Windows.Common.JanusColorScheme janusColorScheme2 = new Janus.Windows.Common.JanusColorScheme();
            Janus.Windows.Common.JanusColorScheme janusColorScheme3 = new Janus.Windows.Common.JanusColorScheme();
            Janus.Windows.GridEX.GridEXLayout tbl_NganHangGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNganHang));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.VisualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.tbl_NganHangGridEX = new Janus.Windows.GridEX.GridEX();
            this.tbl_NganHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nganHangDataSet = new MDSolution.MDDataSet.NganHangDataSet();
            this.tbl_NganHangTableAdapter = new MDSolution.MDDataSet.NganHangDataSetTableAdapters.tbl_NganHangTableAdapter();
            this.tbl_NganHangBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tbl_NganHangBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_NganHangGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_NganHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nganHangDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_NganHangBindingNavigator)).BeginInit();
            this.tbl_NganHangBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.VisualStyleManager = this.VisualStyleManager1;
            this.uiPanel0.Id = new System.Guid("5c80ff1c-28f2-4279-9e8f-848c01ae6d39");
            this.uiPanelManager1.Panels.Add(this.uiPanel0);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("5c80ff1c-28f2-4279-9e8f-848c01ae6d39"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(809, 505), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("3a6968ba-1c2e-4bb0-9530-4d8b15257ff7"), new System.Drawing.Point(392, 172), new System.Drawing.Size(200, 200), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5c80ff1c-28f2-4279-9e8f-848c01ae6d39"), new System.Drawing.Point(600, 391), new System.Drawing.Size(200, 200), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // VisualStyleManager1
            // 
            janusColorScheme1.HighlightColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Office";
            janusColorScheme1.Office2007CustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.UseThemes = false;
            janusColorScheme2.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme2.Name = "OfficeThemes";
            janusColorScheme2.Office2007CustomColor = System.Drawing.Color.Empty;
            janusColorScheme3.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme3.Name = "Scheme0";
            janusColorScheme3.Office2007CustomColor = System.Drawing.Color.Empty;
            janusColorScheme3.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.VisualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            this.VisualStyleManager1.ColorSchemes.Add(janusColorScheme2);
            this.VisualStyleManager1.ColorSchemes.Add(janusColorScheme3);
            this.VisualStyleManager1.DefaultColorScheme = "OfficeThemes";
            // 
            // uiPanel0
            // 
            this.uiPanel0.CaptionFormatStyle.BackColorAlphaMode = Janus.Windows.UI.AlphaMode.Transparent;
            this.uiPanel0.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.FloatingLocation = new System.Drawing.Point(600, 391);
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            this.uiPanel0.Location = new System.Drawing.Point(3, 3);
            this.uiPanel0.Name = "uiPanel0";
            this.uiPanel0.Size = new System.Drawing.Size(809, 505);
            this.uiPanel0.TabIndex = 4;
            this.uiPanel0.Text = "Panel 0";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Controls.Add(this.tbl_NganHangGridEX);
            this.uiPanel0Container.Location = new System.Drawing.Point(1, 1);
            this.uiPanel0Container.Name = "uiPanel0Container";
            this.uiPanel0Container.Size = new System.Drawing.Size(807, 503);
            this.uiPanel0Container.TabIndex = 0;
            // 
            // tbl_NganHangGridEX
            // 
            this.tbl_NganHangGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.tbl_NganHangGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.tbl_NganHangGridEX.AlternatingColors = true;
            this.tbl_NganHangGridEX.AutoEdit = true;
            this.tbl_NganHangGridEX.DataSource = this.tbl_NganHangBindingSource;
            tbl_NganHangGridEX_DesignTimeLayout.LayoutString = resources.GetString("tbl_NganHangGridEX_DesignTimeLayout.LayoutString");
            this.tbl_NganHangGridEX.DesignTimeLayout = tbl_NganHangGridEX_DesignTimeLayout;
            this.tbl_NganHangGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_NganHangGridEX.Font = new System.Drawing.Font("Arial", 9F);
            this.tbl_NganHangGridEX.GroupByBoxVisible = false;
            this.tbl_NganHangGridEX.Location = new System.Drawing.Point(0, 0);
            this.tbl_NganHangGridEX.Name = "tbl_NganHangGridEX";
            this.tbl_NganHangGridEX.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.tbl_NganHangGridEX.Size = new System.Drawing.Size(807, 503);
            this.tbl_NganHangGridEX.TabIndex = 0;
            this.tbl_NganHangGridEX.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.tbl_NganHangGridEX_DeletingRecord);
            this.tbl_NganHangGridEX.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.tbl_NganHangGridEX_UpdatingRecord);
            this.tbl_NganHangGridEX.AddingRecord += new System.ComponentModel.CancelEventHandler(this.tbl_NganHangGridEX_AddingRecord);
            this.tbl_NganHangGridEX.SelectionChanged += new System.EventHandler(this.tbl_NganHangGridEX_SelectionChanged);
            this.tbl_NganHangGridEX.RecordsDeleted += new System.EventHandler(this.tbl_NganHangGridEX_RecordsDeleted);
            this.tbl_NganHangGridEX.RecordAdded += new System.EventHandler(this.tbl_NganHangGridEX_RecordAdded);
            this.tbl_NganHangGridEX.RecordUpdated += new System.EventHandler(this.tbl_NganHangGridEX_RecordUpdated);
            // 
            // tbl_NganHangBindingSource
            // 
            this.tbl_NganHangBindingSource.DataMember = "tbl_NganHang";
            this.tbl_NganHangBindingSource.DataSource = this.nganHangDataSet;
            // 
            // nganHangDataSet
            // 
            this.nganHangDataSet.DataSetName = "NganHangDataSet";
            this.nganHangDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_NganHangTableAdapter
            // 
            this.tbl_NganHangTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_NganHangBindingNavigator
            // 
            this.tbl_NganHangBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tbl_NganHangBindingNavigator.BindingSource = this.tbl_NganHangBindingSource;
            this.tbl_NganHangBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tbl_NganHangBindingNavigator.DeleteItem = this.bindingNavigatorMoveFirstItem;
            this.tbl_NganHangBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tbl_NganHangBindingNavigatorSaveItem});
            this.tbl_NganHangBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tbl_NganHangBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tbl_NganHangBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tbl_NganHangBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tbl_NganHangBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tbl_NganHangBindingNavigator.Name = "tbl_NganHangBindingNavigator";
            this.tbl_NganHangBindingNavigator.PositionItem = this.bindingNavigatorSeparator2;
            this.tbl_NganHangBindingNavigator.Size = new System.Drawing.Size(815, 25);
            this.tbl_NganHangBindingNavigator.TabIndex = 5;
            this.tbl_NganHangBindingNavigator.Text = "bindingNavigator1";
            this.tbl_NganHangBindingNavigator.Visible = false;
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // tbl_NganHangBindingNavigatorSaveItem
            // 
            this.tbl_NganHangBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbl_NganHangBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tbl_NganHangBindingNavigatorSaveItem.Image")));
            this.tbl_NganHangBindingNavigatorSaveItem.Name = "tbl_NganHangBindingNavigatorSaveItem";
            this.tbl_NganHangBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.tbl_NganHangBindingNavigatorSaveItem.Text = "Save Data";
            this.tbl_NganHangBindingNavigatorSaveItem.Click += new System.EventHandler(this.tbl_NganHangBindingNavigatorSaveItem_Click_1);
            // 
            // frmNganHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 511);
            this.Controls.Add(this.uiPanel0);
            this.Controls.Add(this.tbl_NganHangBindingNavigator);
            this.Name = "frmNganHang";
            this.Text = "frmNganHang";
            this.Load += new System.EventHandler(this.frmNganHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_NganHangGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_NganHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nganHangDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_NganHangBindingNavigator)).EndInit();
            this.tbl_NganHangBindingNavigator.ResumeLayout(false);
            this.tbl_NganHangBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel0;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        private Janus.Windows.Common.VisualStyleManager VisualStyleManager1;
        private System.Windows.Forms.BindingNavigator tbl_NganHangBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.BindingSource tbl_NganHangBindingSource;
        private MDSolution.MDDataSet.NganHangDataSet nganHangDataSet;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tbl_NganHangBindingNavigatorSaveItem;
        private MDSolution.MDDataSet.NganHangDataSetTableAdapters.tbl_NganHangTableAdapter tbl_NganHangTableAdapter;
        private Janus.Windows.GridEX.GridEX tbl_NganHangGridEX;
    }
}