namespace MDSolution
{
    partial class frmDinhMucSanLuong
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
            Janus.Windows.GridEX.GridEXLayout dgList_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDinhMucSanLuong));
            this.dgList = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgList
            // 
            this.dgList.AlternatingColors = true;
            this.dgList.AutoEdit = true;
            this.dgList.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo tê" +
                "n cột vào đây để nhóm</GroupByBoxInfo></LocalizableData>";
            dgList_DesignTimeLayout.LayoutString = resources.GetString("dgList_DesignTimeLayout.LayoutString");
            this.dgList.DesignTimeLayout = dgList_DesignTimeLayout;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgList.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.dgList.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.dgList.GroupByBoxVisible = false;
            this.dgList.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.dgList.Location = new System.Drawing.Point(0, 0);
            this.dgList.Name = "dgList";
            this.dgList.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.dgList.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.dgList.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.dgList.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgList.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.dgList.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.dgList.Size = new System.Drawing.Size(407, 547);
            this.dgList.TabIndex = 0;
            this.dgList.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.dgList_UpdatingRecord);
            // 
            // frmDinhMucSanLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(407, 547);
            this.Controls.Add(this.dgList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDinhMucSanLuong";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết lập định mức sản lượng";
            this.Load += new System.EventHandler(this.frmDinhMucSanLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX dgList;
    }
}