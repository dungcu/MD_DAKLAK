namespace MDSolution
{
    partial class frmDanhMucHoTro
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
            Janus.Windows.GridEX.GridEXLayout gdVLVHoTro_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucHoTro));
            this.gdVLVHoTro = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.gdVLVHoTro)).BeginInit();
            this.SuspendLayout();
            // 
            // gdVLVHoTro
            // 
            this.gdVLVHoTro.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVLVHoTro.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVLVHoTro.AlternatingColors = true;
            this.gdVLVHoTro.AutoEdit = true;
            this.gdVLVHoTro.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdVLVHoTro.ColumnAutoResize = true;
            gdVLVHoTro_DesignTimeLayout.LayoutString = resources.GetString("gdVLVHoTro_DesignTimeLayout.LayoutString");
            this.gdVLVHoTro.DesignTimeLayout = gdVLVHoTro_DesignTimeLayout;
            this.gdVLVHoTro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVLVHoTro.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVLVHoTro.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdVLVHoTro.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdVLVHoTro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdVLVHoTro.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVLVHoTro.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVLVHoTro.GroupByBoxVisible = false;
            this.gdVLVHoTro.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVLVHoTro.Location = new System.Drawing.Point(0, 0);
            this.gdVLVHoTro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdVLVHoTro.Name = "gdVLVHoTro";
            this.gdVLVHoTro.NewRowFormatStyle.BackColor = System.Drawing.Color.PowderBlue;
            this.gdVLVHoTro.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVLVHoTro.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdVLVHoTro.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVLVHoTro.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVLVHoTro.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVLVHoTro.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVLVHoTro.ScrollBarWidth = 17;
            this.gdVLVHoTro.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVLVHoTro.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVLVHoTro.Size = new System.Drawing.Size(869, 533);
            this.gdVLVHoTro.TabIndex = 6;
            this.gdVLVHoTro.UpdateOnLeave = false;
            this.gdVLVHoTro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.gdVLVHoTro.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVLVHoTro_DeletingRecord);
            this.gdVLVHoTro.RecordsDeleted += new System.EventHandler(this.gdVLVHoTro_RecordsDeleted);
            this.gdVLVHoTro.RecordUpdated += new System.EventHandler(this.gdVLVHoTro_RecordUpdated);
            this.gdVLVHoTro.RecordAdded += new System.EventHandler(this.gdVLVHoTro_RecordAdded);
            this.gdVLVHoTro.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVLVHoTro_UpdatingRecord);
            this.gdVLVHoTro.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVLVHoTro_AddingRecord);
            this.gdVLVHoTro.SelectionChanged += new System.EventHandler(this.gdVLVHoTro_SelectionChanged);
            // 
            // frmDanhMucHoTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 533);
            this.Controls.Add(this.gdVLVHoTro);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDanhMucHoTro";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục hỗ trợ";
            this.Load += new System.EventHandler(this.frmDanhMucHoTro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdVLVHoTro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVLVHoTro;
    }
}