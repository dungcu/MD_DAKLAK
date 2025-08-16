namespace MDSolution.MDDialoge
{
    partial class dlgChonDonViCungUng
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
            Janus.Windows.GridEX.GridEXLayout grdDVCU_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChonDonViCungUng));
            this.grdDVCU = new Janus.Windows.GridEX.GridEX();
            this.uiButtonOk = new Janus.Windows.EditControls.UIButton();
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDVCU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDVCU
            // 
            this.grdDVCU.AlternatingColors = true;
            grdDVCU_DesignTimeLayout.LayoutString = resources.GetString("grdDVCU_DesignTimeLayout.LayoutString");
            this.grdDVCU.DesignTimeLayout = grdDVCU_DesignTimeLayout;
            this.grdDVCU.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDVCU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDVCU.GroupByBoxVisible = false;
            this.grdDVCU.Location = new System.Drawing.Point(0, 0);
            this.grdDVCU.Name = "grdDVCU";
            this.grdDVCU.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grdDVCU.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdDVCU.Size = new System.Drawing.Size(345, 193);
            this.grdDVCU.TabIndex = 0;
            // 
            // uiButtonOk
            // 
            this.uiButtonOk.Location = new System.Drawing.Point(68, 219);
            this.uiButtonOk.Name = "uiButtonOk";
            this.uiButtonOk.Size = new System.Drawing.Size(75, 23);
            this.uiButtonOk.TabIndex = 1;
            this.uiButtonOk.Text = "&Nhập";
            this.uiButtonOk.Click += new System.EventHandler(this.uiButtonOk_Click);
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            this.officeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty;
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(189, 219);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(75, 23);
            this.uiButton1.TabIndex = 2;
            this.uiButton1.Text = "&Thoát";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // dlgChonDonViCungUng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 261);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiButtonOk);
            this.Controls.Add(this.grdDVCU);
            this.Name = "dlgChonDonViCungUng";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đơn vị cung ứng";
            this.Load += new System.EventHandler(this.dlgChonDonViCungUng_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDVCU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdDVCU;
        private Janus.Windows.EditControls.UIButton uiButtonOk;
        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.EditControls.UIButton uiButton1;
    }
}