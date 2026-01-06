namespace Store_Manager
{
    partial class UC_HoaDon_SanPham
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UC_GB_SanPham = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.UC_PB_2 = new System.Windows.Forms.PictureBox();
            this.UC_GB_SanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UC_PB_2)).BeginInit();
            this.SuspendLayout();
            // 
            // UC_GB_SanPham
            // 
            this.UC_GB_SanPham.BorderColor = System.Drawing.Color.LightCyan;
            this.UC_GB_SanPham.BorderWidth = 3;
            this.UC_GB_SanPham.Controls.Add(this.UC_PB_2);
            this.UC_GB_SanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC_GB_SanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UC_GB_SanPham.Location = new System.Drawing.Point(0, 0);
            this.UC_GB_SanPham.Name = "UC_GB_SanPham";
            this.UC_GB_SanPham.Padding = new System.Windows.Forms.Padding(0);
            this.UC_GB_SanPham.ShowText = true;
            this.UC_GB_SanPham.Size = new System.Drawing.Size(213, 394);
            this.UC_GB_SanPham.TabIndex = 0;
            this.UC_GB_SanPham.TabStop = false;
            this.UC_GB_SanPham.Text = "1";
            this.UC_GB_SanPham.TextColor = System.Drawing.Color.Brown;
            // 
            // UC_PB_2
            // 
            this.UC_PB_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UC_PB_2.Image = global::Store_Manager.Properties.Resources.logo_shop_quan_ao_nam_14;
            this.UC_PB_2.Location = new System.Drawing.Point(4, -12);
            this.UC_PB_2.Name = "UC_PB_2";
            this.UC_PB_2.Size = new System.Drawing.Size(206, 256);
            this.UC_PB_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UC_PB_2.TabIndex = 4;
            this.UC_PB_2.TabStop = false;
            // 
            // UC_HoaDon_SanPham
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.UC_GB_SanPham);
            this.Name = "UC_HoaDon_SanPham";
            this.Size = new System.Drawing.Size(213, 394);
            this.Load += new System.EventHandler(this.UC_HoaDon_SanPham_Load);
            this.UC_GB_SanPham.ResumeLayout(false);
            this.UC_GB_SanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UC_PB_2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.ParrotGroupBox UC_GB_SanPham;
        private System.Windows.Forms.PictureBox UC_PB_2;
    }
}
