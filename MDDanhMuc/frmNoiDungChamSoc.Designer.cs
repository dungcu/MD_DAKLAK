namespace DACASUCO.MDDanhMuc
{
    partial class frmNoiDungChamSoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNoiDungChamSoc));
            this.gdVDMTD = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).BeginInit();
            this.SuspendLayout();
            // 
            // gdVDMTD
            // 
            this.gdVDMTD.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdVDMTD.AlternatingColors = true;
            this.gdVDMTD.AutoEdit = true;
            this.gdVDMTD.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
                "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdVDMTD.ColumnAutoResize = true;
            gdVDMTD_DesignTimeLayout.LayoutString = resources.GetString("gdVDMTD_DesignTimeLayout.LayoutString");
            this.gdVDMTD.DesignTimeLayout = gdVDMTD_DesignTimeLayout;
            this.gdVDMTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVDMTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdVDMTD.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVDMTD.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVDMTD.GroupByBoxVisible = false;
            this.gdVDMTD.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVDMTD.Location = new System.Drawing.Point(0, 0);
            this.gdVDMTD.Name = "gdVDMTD";
            this.gdVDMTD.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVDMTD.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVDMTD.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.ScrollBarWidth = 17;
            this.gdVDMTD.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVDMTD.Size = new System.Drawing.Size(462, 273);
            this.gdVDMTD.TabIndex = 9;
            this.gdVDMTD.UpdateOnLeave = false;
            this.gdVDMTD.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVDMTD_DeletingRecord);
            this.gdVDMTD.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD_UpdatingRecord);
            this.gdVDMTD.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD_AddingRecord);
            this.gdVDMTD.SelectionChanged += new System.EventHandler(this.gdVDMTD_SelectionChanged);
            this.gdVDMTD.RecordsDeleted += new System.EventHandler(this.gdVDMTD_RecordsDeleted);
            this.gdVDMTD.RecordAdded += new System.EventHandler(this.gdVDMTD_RecordAdded);
            this.gdVDMTD.RecordUpdated += new System.EventHandler(this.gdVDMTD_RecordUpdated);
            // 
            // frmNoiDungChamSoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 273);
            this.Controls.Add(this.gdVDMTD);
            this.Name = "frmNoiDungChamSoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nội dung chăm sóc";
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVDMTD;
    }
}