namespace MDSolution.MDForms
{
    partial class frmLuachonGiamia
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
            this.rdGiaso = new System.Windows.Forms.RadioButton();
            this.rdCCS = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdGiaso
            // 
            this.rdGiaso.AutoSize = true;
            this.rdGiaso.Location = new System.Drawing.Point(142, 118);
            this.rdGiaso.Margin = new System.Windows.Forms.Padding(4);
            this.rdGiaso.Name = "rdGiaso";
            this.rdGiaso.Size = new System.Drawing.Size(132, 22);
            this.rdGiaso.TabIndex = 0;
            this.rdGiaso.TabStop = true;
            this.rdGiaso.Text = "Mua theo giá sô";
            this.rdGiaso.UseVisualStyleBackColor = true;
            // 
            // rdCCS
            // 
            this.rdCCS.AutoSize = true;
            this.rdCCS.Location = new System.Drawing.Point(142, 175);
            this.rdCCS.Margin = new System.Windows.Forms.Padding(4);
            this.rdCCS.Name = "rdCCS";
            this.rdCCS.Size = new System.Drawing.Size(124, 22);
            this.rdCCS.TabIndex = 1;
            this.rdCCS.TabStop = true;
            this.rdCCS.Text = "Mua theo CCS";
            this.rdCCS.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(113, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 149);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lựa chọn";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(80, 288);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(97, 35);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(273, 288);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(102, 35);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmLuachonGiamia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 335);
            this.ControlBox = false;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.rdCCS);
            this.Controls.Add(this.rdGiaso);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLuachonGiamia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lựa chọn hình thức giá mía";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdGiaso;
        private System.Windows.Forms.RadioButton rdCCS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
    }
}