namespace MDSolution
{
    partial class frmDanhMucLinhVucDauTu
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
            Janus.Windows.GridEX.GridEXLayout gdVLVDauTu_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucLinhVucDauTu));
            this.gdVLVDauTu = new Janus.Windows.GridEX.GridEX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdVLVDauTu)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdVLVDauTu
            // 
            this.gdVLVDauTu.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVLVDauTu.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVLVDauTu.AlternatingColors = true;
            this.gdVLVDauTu.AutoEdit = true;
            this.gdVLVDauTu.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdVLVDauTu.ColumnAutoResize = true;
            gdVLVDauTu_DesignTimeLayout.LayoutString = resources.GetString("gdVLVDauTu_DesignTimeLayout.LayoutString");
            this.gdVLVDauTu.DesignTimeLayout = gdVLVDauTu_DesignTimeLayout;
            this.gdVLVDauTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVLVDauTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVLVDauTu.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdVLVDauTu.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdVLVDauTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gdVLVDauTu.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVLVDauTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVLVDauTu.GroupByBoxVisible = false;
            this.gdVLVDauTu.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVLVDauTu.Location = new System.Drawing.Point(3, 3);
            this.gdVLVDauTu.Name = "gdVLVDauTu";
            this.gdVLVDauTu.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdVLVDauTu.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVLVDauTu.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdVLVDauTu.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVLVDauTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVLVDauTu.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVLVDauTu.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVLVDauTu.ScrollBarWidth = 17;
            this.gdVLVDauTu.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVLVDauTu.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVLVDauTu.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVLVDauTu.Size = new System.Drawing.Size(901, 396);
            this.gdVLVDauTu.TabIndex = 6;
            this.gdVLVDauTu.UpdateOnLeave = false;
            this.gdVLVDauTu.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVLVDauTu_DeletingRecord);
            this.gdVLVDauTu.RecordsDeleted += new System.EventHandler(this.gdVLVDauTu_RecordsDeleted);
            this.gdVLVDauTu.RecordUpdated += new System.EventHandler(this.gdVLVDauTu_RecordUpdated);
            this.gdVLVDauTu.RecordAdded += new System.EventHandler(this.gdVLVDauTu_RecordAdded);
            this.gdVLVDauTu.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVLVDauTu_UpdatingRecord);
            this.gdVLVDauTu.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVLVDauTu_AddingRecord);
            this.gdVLVDauTu.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdVLVDauTu_ColumnButtonClick);
            this.gdVLVDauTu.SelectionChanged += new System.EventHandler(this.gdVLVDauTu_SelectionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gdVLVDauTu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.35874F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.641255F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(907, 446);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(598, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(306, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Thiết lập các lĩnh vực đầu tư được chọn cho vụ trồng này";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDanhMucLinhVucDauTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 446);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDanhMucLinhVucDauTu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục lĩnh vực đầu tư";
            ((System.ComponentModel.ISupportInitialize)(this.gdVLVDauTu)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVLVDauTu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;

    }
}