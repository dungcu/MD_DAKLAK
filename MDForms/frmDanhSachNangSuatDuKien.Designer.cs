namespace MDSolution.MDForms
{
    partial class frmDanhSachNangSuatDuKien
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
            Janus.Windows.GridEX.GridEXLayout grdNangSuat_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSachNangSuatDuKien));
            this.grdNangSuat = new Janus.Windows.GridEX.GridEX();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPhiapdung = new System.Windows.Forms.Label();
            this.lblNgayapdung = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btInPhieu = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdNangSuat)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdNangSuat
            // 
            this.grdNangSuat.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdNangSuat.AlternatingColors = true;
            this.grdNangSuat.AutomaticSort = false;
            this.grdNangSuat.ColumnAutoResize = true;
            this.grdNangSuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNangSuat.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grdNangSuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grdNangSuat.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.grdNangSuat.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdNangSuat.GroupByBoxVisible = false;
            this.grdNangSuat.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            grdNangSuat_Layout_0.IsCurrentLayout = true;
            grdNangSuat_Layout_0.Key = "tbl_DauTu";
            grdNangSuat_Layout_0.LayoutString = resources.GetString("grdNangSuat_Layout_0.LayoutString");
            this.grdNangSuat.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grdNangSuat_Layout_0});
            this.grdNangSuat.Location = new System.Drawing.Point(3, 46);
            this.grdNangSuat.Name = "grdNangSuat";
            this.grdNangSuat.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdNangSuat.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.grdNangSuat.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grdNangSuat.ScrollBarWidth = 17;
            this.grdNangSuat.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grdNangSuat.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdNangSuat.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.grdNangSuat.ShowErrors = false;
            this.grdNangSuat.Size = new System.Drawing.Size(851, 443);
            this.grdNangSuat.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(538, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 31);
            this.label4.TabIndex = 29;
            this.label4.Text = "(kg /m2)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhiapdung
            // 
            this.lblPhiapdung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhiapdung.AutoSize = true;
            this.lblPhiapdung.BackColor = System.Drawing.Color.Transparent;
            this.lblPhiapdung.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhiapdung.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPhiapdung.Location = new System.Drawing.Point(443, 0);
            this.lblPhiapdung.Name = "lblPhiapdung";
            this.lblPhiapdung.Size = new System.Drawing.Size(89, 31);
            this.lblPhiapdung.TabIndex = 28;
            this.lblPhiapdung.Text = "lblPhiapdung";
            this.lblPhiapdung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNgayapdung
            // 
            this.lblNgayapdung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNgayapdung.AutoSize = true;
            this.lblNgayapdung.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayapdung.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayapdung.Location = new System.Drawing.Point(119, 0);
            this.lblNgayapdung.Name = "lblNgayapdung";
            this.lblNgayapdung.Size = new System.Drawing.Size(102, 31);
            this.lblNgayapdung.TabIndex = 27;
            this.lblNgayapdung.Text = "lblNgayapdung";
            this.lblNgayapdung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 31);
            this.label3.TabIndex = 26;
            this.label3.Text = "Năng suất dự kiến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 31);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ngày áp dụng :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btInPhieu
            // 
            this.btInPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInPhieu.Location = new System.Drawing.Point(753, 3);
            this.btInPhieu.Name = "btInPhieu";
            this.btInPhieu.Size = new System.Drawing.Size(95, 31);
            this.btInPhieu.TabIndex = 30;
            this.btInPhieu.Text = "In Phiếu";
            this.btInPhieu.UseVisualStyleBackColor = true;
            this.btInPhieu.Click += new System.EventHandler(this.btInPhieu_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.89636F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.10364F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNgayapdung, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPhiapdung, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(720, 31);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.grdNangSuat, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.943089F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.05691F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(857, 492);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.41114F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.58886F));
            this.tableLayoutPanel3.Controls.Add(this.btInPhieu, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(851, 37);
            this.tableLayoutPanel3.TabIndex = 33;
            // 
            // frmDanhSachNangSuatDuKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(857, 492);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDanhSachNangSuatDuKien";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách năng suất dự kiến";
            ((System.ComponentModel.ISupportInitialize)(this.grdNangSuat)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX grdNangSuat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPhiapdung;
        private System.Windows.Forms.Label lblNgayapdung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btInPhieu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}