namespace DACASUCO.MDDialoge
{
    partial class dlgHopDongVanChuyen
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
            Janus.Windows.GridEX.GridEXLayout gdVHopDongVanChuyen_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgHopDongVanChuyen));
            this.gdVHopDongVanChuyen = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDongVanChuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // gdVHopDongVanChuyen
            // 
            this.gdVHopDongVanChuyen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdVHopDongVanChuyen.AlternatingColors = true;
            this.gdVHopDongVanChuyen.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
                "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdVHopDongVanChuyen.ColumnAutoResize = true;
            gdVHopDongVanChuyen_DesignTimeLayout.LayoutString = resources.GetString("gdVHopDongVanChuyen_DesignTimeLayout.LayoutString");
            this.gdVHopDongVanChuyen.DesignTimeLayout = gdVHopDongVanChuyen_DesignTimeLayout;
            this.gdVHopDongVanChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVHopDongVanChuyen.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVHopDongVanChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdVHopDongVanChuyen.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVHopDongVanChuyen.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVHopDongVanChuyen.GroupByBoxVisible = false;
            this.gdVHopDongVanChuyen.Location = new System.Drawing.Point(0, 0);
            this.gdVHopDongVanChuyen.Name = "gdVHopDongVanChuyen";
            this.gdVHopDongVanChuyen.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdVHopDongVanChuyen.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVHopDongVanChuyen.ScrollBarWidth = 17;
            this.gdVHopDongVanChuyen.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVHopDongVanChuyen.SelectedFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdVHopDongVanChuyen.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVHopDongVanChuyen.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVHopDongVanChuyen.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.Red;
            this.gdVHopDongVanChuyen.Size = new System.Drawing.Size(343, 486);
            this.gdVHopDongVanChuyen.TabIndex = 10;
            this.gdVHopDongVanChuyen.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gdVHopDongVanChuyen_RowDoubleClick);
            this.gdVHopDongVanChuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdVHopDongVanChuyen_KeyDown);
            this.gdVHopDongVanChuyen.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdVHopDongVanChuyen_FormattingRow);
            // 
            // dlgHopDongVanChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 486);
            this.Controls.Add(this.gdVHopDongVanChuyen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgHopDongVanChuyen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn hợp đồng vận chuyển";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dlgHopDongVanChuyen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDongVanChuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVHopDongVanChuyen;
    }
}