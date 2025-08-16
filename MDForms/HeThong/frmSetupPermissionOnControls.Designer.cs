namespace DACASUCO.MDForms.HeThong
{
    partial class frmSetupPermissionOnControls
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
            Janus.Windows.GridEX.GridEXLayout gdVDMTD01_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupPermissionOnControls));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gdVDMTD01 = new Janus.Windows.GridEX.GridEX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD01)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(754, 430);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 34);
            this.panel1.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblUser.Location = new System.Drawing.Point(9, 6);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(295, 19);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Thiết lập  phân quyền trên controls";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gdVDMTD01);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 344);
            this.panel2.TabIndex = 1;
            // 
            // gdVDMTD01
            // 
            this.gdVDMTD01.AlternatingColors = true;
            this.gdVDMTD01.AutoEdit = true;
            this.gdVDMTD01.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdVDMTD01.ColumnAutoResize = true;
            gdVDMTD01_DesignTimeLayout.LayoutString = resources.GetString("gdVDMTD01_DesignTimeLayout.LayoutString");
            this.gdVDMTD01.DesignTimeLayout = gdVDMTD01_DesignTimeLayout;
            this.gdVDMTD01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVDMTD01.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVDMTD01.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdVDMTD01.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdVDMTD01.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdVDMTD01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.gdVDMTD01.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVDMTD01.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVDMTD01.GroupByBoxVisible = false;
            this.gdVDMTD01.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVDMTD01.Location = new System.Drawing.Point(0, 0);
            this.gdVDMTD01.Name = "gdVDMTD01";
            this.gdVDMTD01.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdVDMTD01.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD01.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD01.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD01.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVDMTD01.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVDMTD01.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVDMTD01.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVDMTD01.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD01.ScrollBarWidth = 17;
            this.gdVDMTD01.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVDMTD01.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD01.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVDMTD01.Size = new System.Drawing.Size(748, 344);
            this.gdVDMTD01.TabIndex = 9;
            this.gdVDMTD01.UpdateOnLeave = false;
            this.gdVDMTD01.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD01_UpdatingRecord);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uiButton2);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 393);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(748, 34);
            this.panel3.TabIndex = 2;
            // 
            // uiButton2
            // 
            this.uiButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton2.Icon = ((System.Drawing.Icon)(resources.GetObject("uiButton2.Icon")));
            this.uiButton2.Location = new System.Drawing.Point(462, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(175, 31);
            this.uiButton2.TabIndex = 12;
            this.uiButton2.Text = "Khởi tạo các controls";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(336, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save (Ctrl+S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(642, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close (Esc)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSetupPermissionOnControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 430);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSetupPermissionOnControls";
            this.Text = "Thiết lập quyền trên controls";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD01)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        internal Janus.Windows.GridEX.GridEX gdVDMTD01;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private Janus.Windows.EditControls.UIButton uiButton2;
    }
}