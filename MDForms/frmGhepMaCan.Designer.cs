namespace DACASUCO.MDForms
{
    partial class frmGhepMaCan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGhepMaCan));
            this.dgList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhoiLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSoHopDong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKhoiLuong = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdDel = new System.Windows.Forms.Button();
            this.cmdFindHDVC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MaKH,
            this.SoHD,
            this.HoTen,
            this.KhoiLuong});
            this.dgList.Location = new System.Drawing.Point(3, 156);
            this.dgList.Margin = new System.Windows.Forms.Padding(4);
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersVisible = false;
            this.dgList.RowTemplate.Height = 24;
            this.dgList.Size = new System.Drawing.Size(558, 231);
            this.dgList.TabIndex = 7;
            this.dgList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellClick);
            this.dgList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgList_RowStateChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "";
            this.MaKH.Name = "MaKH";
            this.MaKH.ReadOnly = true;
            this.MaKH.Visible = false;
            // 
            // SoHD
            // 
            this.SoHD.DataPropertyName = "SoHD";
            this.SoHD.HeaderText = "Số HĐ";
            this.SoHD.Name = "SoHD";
            this.SoHD.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 150;
            // 
            // KhoiLuong
            // 
            this.KhoiLuong.DataPropertyName = "KhoiLuong";
            this.KhoiLuong.HeaderText = "Khối lượng";
            this.KhoiLuong.Name = "KhoiLuong";
            this.KhoiLuong.ReadOnly = true;
            this.KhoiLuong.Width = 150;
            // 
            // txtSoHopDong
            // 
            this.txtSoHopDong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSoHopDong.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHopDong.Location = new System.Drawing.Point(7, 29);
            this.txtSoHopDong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoHopDong.Name = "txtSoHopDong";
            this.txtSoHopDong.Size = new System.Drawing.Size(181, 39);
            this.txtSoHopDong.TabIndex = 1;
            this.txtSoHopDong.TextChanged += new System.EventHandler(this.txtSoHopDong_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Số hợp đồng";
            // 
            // txtKhoiLuong
            // 
            this.txtKhoiLuong.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhoiLuong.Location = new System.Drawing.Point(7, 93);
            this.txtKhoiLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtKhoiLuong.Name = "txtKhoiLuong";
            this.txtKhoiLuong.Size = new System.Drawing.Size(346, 39);
            this.txtKhoiLuong.TabIndex = 2;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(201, 27);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(269, 39);
            this.txtHoTen.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Họ và tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Khối lượng mía";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKH.Location = new System.Drawing.Point(283, 4);
            this.lblMaKH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(51, 17);
            this.lblMaKH.TabIndex = 9;
            this.lblMaKH.Text = "MAKH";
            this.lblMaKH.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMaKH.Visible = false;
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.White;
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            //this.cmdAdd.Image = global::MDSolution.Properties.Resources.ICO_Good_05_24x24x32bit;
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(361, 93);
            this.cmdAdd.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(109, 39);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "Cập nhật";
            this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAdd.UseVisualStyleBackColor = false;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdDel
            // 
            this.cmdDel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.cmdDel.Image = global::MDSolution.Properties.Resources.ICO_Symbol_Delete_05_24x24x32bit;
            this.cmdDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDel.Location = new System.Drawing.Point(478, 93);
            this.cmdDel.Name = "cmdDel";
            this.cmdDel.Size = new System.Drawing.Size(75, 39);
            this.cmdDel.TabIndex = 11;
            this.cmdDel.Text = "Xóa";
            this.cmdDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDel.UseVisualStyleBackColor = false;
            this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
            // 
            // cmdFindHDVC
            // 
            this.cmdFindHDVC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmdFindHDVC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFindHDVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFindHDVC.ForeColor = System.Drawing.Color.Black;
            //this.cmdFindHDVC.Image = global::MDSolution.Properties.Resources.buscar_red__10_;
            this.cmdFindHDVC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFindHDVC.Location = new System.Drawing.Point(478, 27);
            this.cmdFindHDVC.Margin = new System.Windows.Forms.Padding(4);
            this.cmdFindHDVC.Name = "cmdFindHDVC";
            this.cmdFindHDVC.Size = new System.Drawing.Size(83, 39);
            this.cmdFindHDVC.TabIndex = 10;
            this.cmdFindHDVC.Text = "Tìm";
            this.cmdFindHDVC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFindHDVC.UseVisualStyleBackColor = false;
            this.cmdFindHDVC.Click += new System.EventHandler(this.cmdFindHopDong_Click);
            // 
            // frmGhepMaCan
            // 
            this.AcceptButton = this.cmdAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(566, 391);
            this.Controls.Add(this.cmdDel);
            this.Controls.Add(this.cmdFindHDVC);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtKhoiLuong);
            this.Controls.Add(this.txtSoHopDong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgList);
            this.Controls.Add(this.cmdAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGhepMaCan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật ghép mã cân";
            this.Load += new System.EventHandler(this.frmGhepMaCan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.TextBox txtSoHopDong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKhoiLuong;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdFindHDVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhoiLuong;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Button cmdDel;
    }
}