namespace DACASUCO.MDDataSetForms
{
    partial class DanhMucLoaiHopDong
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
            Janus.Windows.GridEX.GridEXLayout gdLoaiHopDong_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhMucLoaiHopDong));
            this.hopDongTrongMiaDataSet = new DACASUCO.MDDataSet.HopDongTrongMiaDataSet();
            this.loaiHopDongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loaiHopDongTableAdapter = new DACASUCO.MDDataSet.HopDongTrongMiaDataSetTableAdapters.LoaiHopDongTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gdLoaiHopDong = new Janus.Windows.GridEX.GridEX();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hopDongTrongMiaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHopDongBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdLoaiHopDong)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hopDongTrongMiaDataSet
            // 
            this.hopDongTrongMiaDataSet.DataSetName = "HopDongTrongMiaDataSet";
            this.hopDongTrongMiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // loaiHopDongBindingSource
            // 
            this.loaiHopDongBindingSource.DataMember = "LoaiHopDong";
            this.loaiHopDongBindingSource.DataSource = this.hopDongTrongMiaDataSet;
            // 
            // loaiHopDongTableAdapter
            // 
            this.loaiHopDongTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gdLoaiHopDong);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 53);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 310);
            this.panel2.TabIndex = 1;
            // 
            // gdLoaiHopDong
            // 
            this.gdLoaiHopDong.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdLoaiHopDong.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdLoaiHopDong.AlternatingColors = true;
            this.gdLoaiHopDong.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdLoaiHopDong.ColumnAutoResize = true;
            this.gdLoaiHopDong.DataSource = this.loaiHopDongBindingSource;
            gdLoaiHopDong_DesignTimeLayout.LayoutString = resources.GetString("gdLoaiHopDong_DesignTimeLayout.LayoutString");
            this.gdLoaiHopDong.DesignTimeLayout = gdLoaiHopDong_DesignTimeLayout;
            this.gdLoaiHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdLoaiHopDong.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdLoaiHopDong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdLoaiHopDong.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdLoaiHopDong.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdLoaiHopDong.GroupByBoxVisible = false;
            this.gdLoaiHopDong.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdLoaiHopDong.Hierarchical = true;
            this.gdLoaiHopDong.Location = new System.Drawing.Point(0, 0);
            this.gdLoaiHopDong.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gdLoaiHopDong.Name = "gdLoaiHopDong";
            this.gdLoaiHopDong.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdLoaiHopDong.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdLoaiHopDong.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdLoaiHopDong.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdLoaiHopDong.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdLoaiHopDong.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdLoaiHopDong.ScrollBarWidth = 17;
            this.gdLoaiHopDong.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdLoaiHopDong.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdLoaiHopDong.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdLoaiHopDong.Size = new System.Drawing.Size(710, 310);
            this.gdLoaiHopDong.TabIndex = 8;
            this.gdLoaiHopDong.UpdateOnLeave = false;
            this.gdLoaiHopDong.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Image = global::DACASUCO.Properties.Resources.action_stop;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(587, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close (Esc)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 371);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(710, 41);
            this.panel3.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.Image = global::DACASUCO.Properties.Resources.save16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(440, 1);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 37);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save (Ctrl+S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(716, 416);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 41);
            this.panel1.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblUser.Location = new System.Drawing.Point(10, 7);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(143, 19);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "LOẠI HỢP ĐỒNG";
            // 
            // DanhMucLoaiHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 416);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DanhMucLoaiHopDong";
            this.Text = "Danh mục loại hợp đồng";
            this.Load += new System.EventHandler(this.DanhMucLoaiHopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hopDongTrongMiaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHopDongBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdLoaiHopDong)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MDDataSet.HopDongTrongMiaDataSet hopDongTrongMiaDataSet;
        private System.Windows.Forms.BindingSource loaiHopDongBindingSource;
        private MDDataSet.HopDongTrongMiaDataSetTableAdapters.LoaiHopDongTableAdapter loaiHopDongTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUser;
        internal Janus.Windows.GridEX.GridEX gdLoaiHopDong;
    }
}