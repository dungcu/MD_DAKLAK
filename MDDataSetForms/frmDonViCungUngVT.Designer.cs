namespace DACASUCO.MDDataSetForms
{
    partial class frmDonViCungUngVT
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
            Janus.Windows.GridEX.GridEXLayout gridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonViCungUngVT));
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.tblDonViCungUngVatTuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dVCungUngDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dVCungUngDataSet = new MDSolution.MDDataSet.DVCungUngDataSet();
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.tbl_DonViCungUngVatTuTableAdapter = new MDSolution.MDDataSet.DVCungUngDataSetTableAdapters.tbl_DonViCungUngVatTuTableAdapter();
            this.buttThietLapDanhMucDT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDonViCungUngVatTuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVCungUngDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVCungUngDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridEX1
            // 
            this.gridEX1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.AlternatingColors = true;
            this.gridEX1.AutoEdit = true;
            this.gridEX1.DataSource = this.tblDonViCungUngVatTuBindingSource;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridEX1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gridEX1.Font = new System.Drawing.Font("Arial", 9F);
            this.gridEX1.FrozenColumns = 4;
            this.gridEX1.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gridEX1.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gridEX1.Location = new System.Drawing.Point(0, 0);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridEX1.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gridEX1.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridEX1.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gridEX1.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gridEX1.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridEX1.RowHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridEX1.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gridEX1.Size = new System.Drawing.Size(755, 322);
            this.gridEX1.TabIndex = 0;
            this.gridEX1.UpdateOnLeave = false;
            this.gridEX1.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gridEX1_UpdatingRecord);
            this.gridEX1.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gridEX1_AddingRecord);
            this.gridEX1.DeletingRecords += new System.ComponentModel.CancelEventHandler(this.gridEX1_DeletingRecords);
            this.gridEX1.RecordAdded += new System.EventHandler(this.gridEX1_RecordAdded);
            this.gridEX1.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridEX1_FormattingRow);
            // 
            // tblDonViCungUngVatTuBindingSource
            // 
            this.tblDonViCungUngVatTuBindingSource.DataMember = "tbl_DonViCungUngVatTu";
            this.tblDonViCungUngVatTuBindingSource.DataSource = this.dVCungUngDataSetBindingSource;
            // 
            // dVCungUngDataSetBindingSource
            // 
            this.dVCungUngDataSetBindingSource.DataSource = this.dVCungUngDataSet;
            this.dVCungUngDataSetBindingSource.Position = 0;
            // 
            // dVCungUngDataSet
            // 
            this.dVCungUngDataSet.DataSetName = "DVCungUngDataSet";
            this.dVCungUngDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            this.officeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty;
            // 
            // tbl_DonViCungUngVatTuTableAdapter
            // 
            this.tbl_DonViCungUngVatTuTableAdapter.ClearBeforeFill = true;
            // 
            // buttThietLapDanhMucDT
            // 
            this.buttThietLapDanhMucDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttThietLapDanhMucDT.Location = new System.Drawing.Point(439, 326);
            this.buttThietLapDanhMucDT.Name = "buttThietLapDanhMucDT";
            this.buttThietLapDanhMucDT.Size = new System.Drawing.Size(291, 43);
            this.buttThietLapDanhMucDT.TabIndex = 1;
            this.buttThietLapDanhMucDT.Text = "Thiết lập danh mục đầu tư cho đơn vị cung ứng";
            this.buttThietLapDanhMucDT.UseVisualStyleBackColor = true;
            this.buttThietLapDanhMucDT.Click += new System.EventHandler(this.buttThietLapDanhMucDT_Click);
            // 
            // frmDonViCungUngVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 375);
            this.Controls.Add(this.buttThietLapDanhMucDT);
            this.Controls.Add(this.gridEX1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDonViCungUngVT";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn vị cung ứng vật tư";
            this.Load += new System.EventHandler(this.frmDonViCungUngVT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDonViCungUngVatTuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVCungUngDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dVCungUngDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.BindingSource dVCungUngDataSetBindingSource;
        
        private DACASUCO.MDDataSet.DVCungUngDataSet dVCungUngDataSet;
        private System.Windows.Forms.BindingSource tblDonViCungUngVatTuBindingSource;
        private DACASUCO.MDDataSet.DVCungUngDataSetTableAdapters.tbl_DonViCungUngVatTuTableAdapter tbl_DonViCungUngVatTuTableAdapter;
        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private System.Windows.Forms.Button buttThietLapDanhMucDT;
    }
}