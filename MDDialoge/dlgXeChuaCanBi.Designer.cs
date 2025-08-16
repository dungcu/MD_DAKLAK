namespace DACASUCO.MDDialoge
{
    partial class dlgXeChuaCanBi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgXeChuaCanBi));
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
            this.gdVHopDongVanChuyen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdVHopDongVanChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gdVHopDongVanChuyen.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVHopDongVanChuyen.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVHopDongVanChuyen.GroupByBoxVisible = false;
            this.gdVHopDongVanChuyen.Location = new System.Drawing.Point(0, 0);
            this.gdVHopDongVanChuyen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gdVHopDongVanChuyen.Name = "gdVHopDongVanChuyen";
            this.gdVHopDongVanChuyen.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdVHopDongVanChuyen.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVHopDongVanChuyen.ScrollBarWidth = 17;
            this.gdVHopDongVanChuyen.SelectedFormatStyle.BackColor = System.Drawing.Color.Red;
            this.gdVHopDongVanChuyen.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVHopDongVanChuyen.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.Red;
            this.gdVHopDongVanChuyen.Size = new System.Drawing.Size(790, 437);
            this.gdVHopDongVanChuyen.TabIndex = 10;
            this.gdVHopDongVanChuyen.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gdVHopDongVanChuyen_RowDoubleClick);
            this.gdVHopDongVanChuyen.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdVHopDongVanChuyen_FormattingRow);
            // 
            // dlgXeChuaCanBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 437);
            this.Controls.Add(this.gdVHopDongVanChuyen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgXeChuaCanBi";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách xe chưa cân bì";
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDongVanChuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVHopDongVanChuyen;
    }
}