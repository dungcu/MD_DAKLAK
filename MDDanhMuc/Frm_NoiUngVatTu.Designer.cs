namespace MDSolution
{
    partial class Frm_NoiUngVatTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NoiUngVatTu));
            this.gdVDMTD = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).BeginInit();
            this.SuspendLayout();
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
            this.gdVDMTD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdVDMTD.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVDMTD.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVDMTD.GroupByBoxVisible = false;
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
            this.gdVDMTD.Size = new System.Drawing.Size(762, 336);
            this.gdVDMTD.TabIndex = 9;
            this.gdVDMTD.UpdateOnLeave = false;
            this.gdVDMTD.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.gdVDMTD.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVDMTD_DeletingRecord);
            this.gdVDMTD.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD_UpdatingRecord);
            this.gdVDMTD.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD_AddingRecord);
            // 
            // Frm_NoiUngVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 336);
            this.Controls.Add(this.gdVDMTD);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_NoiUngVatTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nơi tạm ứng vật tư";
            this.Load += new System.EventHandler(this.Frm_NoiUngVatTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVDMTD;
    }
}