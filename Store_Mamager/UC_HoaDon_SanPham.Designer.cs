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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.UC_Card_HienThi = new ReaLTaiizor.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Store_Manager.Properties.Resources.shopping_cart_791967;
            this.pictureBox1.Location = new System.Drawing.Point(148, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.UC_HoaDon_SanPham_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.UC_HoaDon_SanPham_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::Store_Manager.Properties.Resources.logo_shop_quan_ao_nam_14;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(198, 213);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseEnter += new System.EventHandler(this.UC_HoaDon_SanPham_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.UC_HoaDon_SanPham_MouseLeave);
            // 
            // UC_Card_HienThi
            // 
            this.UC_Card_HienThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UC_Card_HienThi.Depth = 0;
            this.UC_Card_HienThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UC_Card_HienThi.Location = new System.Drawing.Point(15, 306);
            this.UC_Card_HienThi.Margin = new System.Windows.Forms.Padding(14);
            this.UC_Card_HienThi.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.UC_Card_HienThi.Name = "UC_Card_HienThi";
            this.UC_Card_HienThi.Padding = new System.Windows.Forms.Padding(14);
            this.UC_Card_HienThi.Size = new System.Drawing.Size(169, 106);
            this.UC_Card_HienThi.TabIndex = 2;
            this.UC_Card_HienThi.MouseEnter += new System.EventHandler(this.UC_HoaDon_SanPham_MouseEnter);
            this.UC_Card_HienThi.MouseLeave += new System.EventHandler(this.UC_HoaDon_SanPham_MouseLeave);
            // 
            // UC_HoaDon_SanPham
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.UC_Card_HienThi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "UC_HoaDon_SanPham";
            this.Size = new System.Drawing.Size(198, 433);
            this.Load += new System.EventHandler(this.UC_HoaDon_SanPham_Load);
            this.MouseEnter += new System.EventHandler(this.UC_HoaDon_SanPham_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UC_HoaDon_SanPham_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ReaLTaiizor.Controls.MaterialCard UC_Card_HienThi;
    }
}
