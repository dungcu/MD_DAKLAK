namespace MDSolution
{
    partial class frmDanhMucTuDien
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tỉnh");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Huyện");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Trạm Nông Vụ");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Xã");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Giống Mía");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Hiện trạng giao thông");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Loại Đất");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Mục Đích Trồng");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Nội Dung Chăm Sóc");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Phế Canh");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Rải vụ");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Vật Tư Ứng Vận Chuyển");
            Janus.Windows.GridEX.GridEXLayout gdVDMTD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucTuDien));
            this.panelManager = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanel4 = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.uiPanel1 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel1Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.gdVDMTD = new Janus.Windows.GridEX.GridEX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTimXa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel4)).BeginInit();
            this.uiPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).BeginInit();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelManager
            // 
            this.panelManager.AllowPanelDrag = false;
            this.panelManager.AllowPanelDrop = false;
            this.panelManager.ContainerControl = this;
            this.panelManager.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.panelManager.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.panelManager.DefaultPanelSettings.CaptionFormatStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panelManager.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.panelManager.DefaultPanelSettings.CloseButtonVisible = false;
            this.panelManager.DefaultPanelSettings.DarkCaptionFormatStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.panelManager.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.panelManager.DefaultPanelSettings.TabStateStyles.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.panelManager.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Standard;
            this.uiPanel4.Id = new System.Guid("877309af-b1ff-40c1-bcd3-125b1eb2f217");
            this.uiPanel4.StaticGroup = true;
            this.uiPanel0.Id = new System.Guid("36dc197c-fe17-4a81-a1f2-9f8f1b9483df");
            this.uiPanel4.Panels.Add(this.uiPanel0);
            this.panelManager.Panels.Add(this.uiPanel4);
            // 
            // Design Time Panel Info:
            // 
            this.panelManager.BeginPanelInfo();
            this.panelManager.AddDockPanelInfo(new System.Guid("877309af-b1ff-40c1-bcd3-125b1eb2f217"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Left, true, new System.Drawing.Size(200, 420), true);
            this.panelManager.AddDockPanelInfo(new System.Guid("36dc197c-fe17-4a81-a1f2-9f8f1b9483df"), new System.Guid("877309af-b1ff-40c1-bcd3-125b1eb2f217"), 393, true);
            this.panelManager.AddFloatingPanelInfo(new System.Guid("214c86ac-d105-4ce7-b1e4-c6381e34d797"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(291, 384), new System.Drawing.Size(200, 200), false);
            this.panelManager.AddFloatingPanelInfo(new System.Guid("dfbec675-d611-4480-8fb4-e0fe090b8c91"), new System.Guid("214c86ac-d105-4ce7-b1e4-c6381e34d797"), 271, false);
            this.panelManager.AddFloatingPanelInfo(new System.Guid("9783a795-57bc-49f5-a9dc-7a815ba82796"), new System.Guid("214c86ac-d105-4ce7-b1e4-c6381e34d797"), 271, false);
            this.panelManager.AddFloatingPanelInfo(new System.Guid("c2a6b25c-d6c4-4ae0-b8f4-d869aca3b53f"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(561, 343), new System.Drawing.Size(200, 200), false);
            this.panelManager.AddFloatingPanelInfo(new System.Guid("74be1f47-723c-41e2-b702-222eef942145"), new System.Guid("c2a6b25c-d6c4-4ae0-b8f4-d869aca3b53f"), 436, false);
            this.panelManager.AddFloatingPanelInfo(new System.Guid("877309af-b1ff-40c1-bcd3-125b1eb2f217"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(78, 78), new System.Drawing.Size(200, 200), false);
            this.panelManager.AddFloatingPanelInfo(new System.Guid("36dc197c-fe17-4a81-a1f2-9f8f1b9483df"), new System.Guid("877309af-b1ff-40c1-bcd3-125b1eb2f217"), 393, false);
            this.panelManager.AddFloatingPanelInfo(new System.Guid("808e765a-28c1-4bf4-b512-36763d5fcb50"), new System.Drawing.Point(464, 456), new System.Drawing.Size(200, 200), false);
            this.panelManager.EndPanelInfo();
            // 
            // uiPanel4
            // 
            this.uiPanel4.AllowPanelDrag = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel4.AllowPanelDrop = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel4.FloatingLocation = new System.Drawing.Point(78, 78);
            this.uiPanel4.Location = new System.Drawing.Point(3, 3);
            this.uiPanel4.Name = "uiPanel4";
            this.uiPanel4.Size = new System.Drawing.Size(200, 420);
            this.uiPanel4.TabIndex = 4;
            this.uiPanel4.Text = "Từ điển danh mục";
            // 
            // uiPanel0
            // 
            this.uiPanel0.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            this.uiPanel0.Location = new System.Drawing.Point(0, 24);
            this.uiPanel0.Name = "uiPanel0";
            this.uiPanel0.Size = new System.Drawing.Size(196, 396);
            this.uiPanel0.TabIndex = 4;
            this.uiPanel0.Text = "Panel 0";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Controls.Add(this.treeView1);
            this.uiPanel0Container.Location = new System.Drawing.Point(1, 1);
            this.uiPanel0Container.Name = "uiPanel0Container";
            this.uiPanel0Container.Size = new System.Drawing.Size(194, 394);
            this.uiPanel0Container.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.images;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Tinh";
            treeNode1.Text = "Tỉnh";
            treeNode2.Name = "Huyen";
            treeNode2.Text = "Huyện";
            treeNode3.Name = "TramNongVu";
            treeNode3.Text = "Trạm Nông Vụ";
            treeNode4.Name = "Xa";
            treeNode4.Text = "Xã";
            treeNode5.Name = "GiongMia";
            treeNode5.NodeFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode5.Text = "Giống Mía";
            treeNode6.Name = "HienTrangGiaoThong";
            treeNode6.Text = "Hiện trạng giao thông";
            treeNode7.Name = "LoaiDat";
            treeNode7.Text = "Loại Đất";
            treeNode8.Name = "MucDichTrong";
            treeNode8.Text = "Mục Đích Trồng";
            treeNode9.Name = "NoiDungChamSoc";
            treeNode9.Text = "Nội Dung Chăm Sóc";
            treeNode10.Name = "PheCanh";
            treeNode10.Text = "Phế Canh";
            treeNode11.Name = "RaiVu";
            treeNode11.Text = "Rải vụ";
            treeNode12.Name = "VatTuVanChuyen";
            treeNode12.Text = "Vật Tư Ứng Vận Chuyển";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.Size = new System.Drawing.Size(194, 394);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "Doc.ico");
            this.images.Images.SetKeyName(1, "Folder.ico");
            this.images.Images.SetKeyName(2, "Home.ico");
            this.images.Images.SetKeyName(3, "Buddy-Blue.ico");
            this.images.Images.SetKeyName(4, "Doc.ico");
            this.images.Images.SetKeyName(5, "Folder.ico");
            this.images.Images.SetKeyName(6, "Buddy-Green.ico");
            // 
            // uiPanel1
            // 
            this.uiPanel1.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel1.InnerContainer = this.uiPanel1Container;
            this.uiPanel1.Location = new System.Drawing.Point(0, 25);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(586, 523);
            this.uiPanel1.TabIndex = 4;
            this.uiPanel1.Text = "Từ Điển Danh Mục";
            // 
            // uiPanel1Container
            // 
            this.uiPanel1Container.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1Container.Name = "uiPanel1Container";
            this.uiPanel1Container.Size = new System.Drawing.Size(586, 523);
            this.uiPanel1Container.TabIndex = 0;
            // 
            // gdVDMTD
            // 
            this.gdVDMTD.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.AlternatingColors = true;
            this.gdVDMTD.AutoEdit = true;
            this.gdVDMTD.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdVDMTD.ColumnAutoResize = true;
            gdVDMTD_DesignTimeLayout.LayoutString = resources.GetString("gdVDMTD_DesignTimeLayout.LayoutString");
            this.gdVDMTD.DesignTimeLayout = gdVDMTD_DesignTimeLayout;
            this.gdVDMTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVDMTD.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVDMTD.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdVDMTD.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdVDMTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gdVDMTD.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVDMTD.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVDMTD.GroupByBoxVisible = false;
            this.gdVDMTD.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVDMTD.Location = new System.Drawing.Point(3, 38);
            this.gdVDMTD.Name = "gdVDMTD";
            this.gdVDMTD.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdVDMTD.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVDMTD.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVDMTD.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVDMTD.RowHeaderFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD.RowHeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.ScrollBarWidth = 17;
            this.gdVDMTD.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVDMTD.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.Size = new System.Drawing.Size(714, 379);
            this.gdVDMTD.TabIndex = 9;
            this.gdVDMTD.UpdateOnLeave = false;
            this.gdVDMTD.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.gdVDMTD.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVDMTD_DeletingRecord);
            this.gdVDMTD.RecordsDeleted += new System.EventHandler(this.gdVDMTD_RecordsDeleted);
            this.gdVDMTD.RecordUpdated += new System.EventHandler(this.gdVDMTD_RecordUpdated);
            this.gdVDMTD.RecordAdded += new System.EventHandler(this.gdVDMTD_RecordAdded);
            this.gdVDMTD.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD_UpdatingRecord);
            this.gdVDMTD.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD_AddingRecord);
            this.gdVDMTD.SelectionChanged += new System.EventHandler(this.gdVDMTD_SelectionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTen, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gdVDMTD, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(203, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(720, 420);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTen.Location = new System.Drawing.Point(3, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(90, 19);
            this.lblTen.TabIndex = 10;
            this.lblTen.Text = "Danh Mục ";
            this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTimXa
            // 
            this.txtTimXa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimXa.Location = new System.Drawing.Point(461, 12);
            this.txtTimXa.Name = "txtTimXa";
            this.txtTimXa.Size = new System.Drawing.Size(153, 22);
            this.txtTimXa.TabIndex = 11;
            this.txtTimXa.TextChanged += new System.EventHandler(this.txtTimXa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tìm xã:";
            // 
            // frmDanhMucTuDien
            // 
            this.ClientSize = new System.Drawing.Size(926, 426);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimXa);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.uiPanel4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDanhMucTuDien";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Từ điển danh mục";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDanhMucTuDien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel4)).EndInit();
            this.uiPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager panelManager;
        private Janus.Windows.UI.Dock.UIPanel uiPanel1;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel1Container;
        private Janus.Windows.UI.Dock.UIPanelGroup uiPanelGroup1;
        private Janus.Windows.UI.Dock.UIPanelGroup uiPanel4;
        private Janus.Windows.UI.Dock.UIPanel uiPanel0;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        private System.Windows.Forms.TreeView treeView1;
        internal Janus.Windows.GridEX.GridEX gdVDMTD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTen;
        internal System.Windows.Forms.ImageList images;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimXa;
    }
}