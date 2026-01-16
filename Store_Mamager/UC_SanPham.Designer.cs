namespace Store_Manager
{
    partial class UC_SanPham
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
            this.components = new System.ComponentModel.Container();
            this.SanPham_GB = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.SanPham_PB_HetHang = new ReaLTaiizor.Controls.HopePictureBox();
            this.SanPham_L = new ReaLTaiizor.Controls.BigLabel();
            this.SanPham_L_Gia = new ReaLTaiizor.Controls.BigLabel();
            this.UC_PB_2 = new System.Windows.Forms.PictureBox();
            this.quan_Ly_Shop_Quan_AoDataSet = new Store_Manager.Quan_Ly_Shop_Quan_AoDataSet();
            this.sizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sizeTableAdapter = new Store_Manager.Quan_Ly_Shop_Quan_AoDataSetTableAdapters.SizeTableAdapter();
            this.SanPham_GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SanPham_PB_HetHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UC_PB_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quan_Ly_Shop_Quan_AoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SanPham_GB
            // 
            this.SanPham_GB.BorderColor = System.Drawing.Color.LightCyan;
            this.SanPham_GB.BorderWidth = 3;
            this.SanPham_GB.Controls.Add(this.SanPham_PB_HetHang);
            this.SanPham_GB.Controls.Add(this.UC_PB_2);
            this.SanPham_GB.Controls.Add(this.SanPham_L);
            this.SanPham_GB.Controls.Add(this.SanPham_L_Gia);
            this.SanPham_GB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SanPham_GB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SanPham_GB.Location = new System.Drawing.Point(0, 0);
            this.SanPham_GB.Name = "SanPham_GB";
            this.SanPham_GB.Padding = new System.Windows.Forms.Padding(0);
            this.SanPham_GB.ShowText = true;
            this.SanPham_GB.Size = new System.Drawing.Size(243, 394);
            this.SanPham_GB.TabIndex = 0;
            this.SanPham_GB.TabStop = false;
            this.SanPham_GB.Text = "1";
            this.SanPham_GB.TextColor = System.Drawing.Color.Brown;
            // 
            // SanPham_PB_HetHang
            // 
            this.SanPham_PB_HetHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.SanPham_PB_HetHang.Image = global::Store_Manager.Properties.Resources.SanPham;
            this.SanPham_PB_HetHang.Location = new System.Drawing.Point(162, 168);
            this.SanPham_PB_HetHang.Name = "SanPham_PB_HetHang";
            this.SanPham_PB_HetHang.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.SanPham_PB_HetHang.Size = new System.Drawing.Size(57, 51);
            this.SanPham_PB_HetHang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SanPham_PB_HetHang.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.SanPham_PB_HetHang.TabIndex = 7;
            this.SanPham_PB_HetHang.TabStop = false;
            this.SanPham_PB_HetHang.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // SanPham_L
            // 
            this.SanPham_L.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SanPham_L.BackColor = System.Drawing.Color.Transparent;
            this.SanPham_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SanPham_L.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SanPham_L.ForeColor = System.Drawing.Color.White;
            this.SanPham_L.Location = new System.Drawing.Point(12, 247);
            this.SanPham_L.Name = "SanPham_L";
            this.SanPham_L.Size = new System.Drawing.Size(223, 106);
            this.SanPham_L.TabIndex = 5;
            this.SanPham_L.Text = "Quần short kaki M\r\n>> Nam >> Size M\r\n";
            // 
            // SanPham_L_Gia
            // 
            this.SanPham_L_Gia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SanPham_L_Gia.BackColor = System.Drawing.Color.Transparent;
            this.SanPham_L_Gia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SanPham_L_Gia.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SanPham_L_Gia.ForeColor = System.Drawing.Color.YellowGreen;
            this.SanPham_L_Gia.Location = new System.Drawing.Point(12, 355);
            this.SanPham_L_Gia.Name = "SanPham_L_Gia";
            this.SanPham_L_Gia.Size = new System.Drawing.Size(223, 33);
            this.SanPham_L_Gia.TabIndex = 6;
            this.SanPham_L_Gia.Text = "120.010.000 đ";
            this.SanPham_L_Gia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UC_PB_2
            // 
            this.UC_PB_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UC_PB_2.Image = global::Store_Manager.Properties.Resources.padlock_9821260;
            this.UC_PB_2.Location = new System.Drawing.Point(4, -12);
            this.UC_PB_2.Margin = new System.Windows.Forms.Padding(1);
            this.UC_PB_2.Name = "UC_PB_2";
            this.UC_PB_2.Size = new System.Drawing.Size(236, 256);
            this.UC_PB_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UC_PB_2.TabIndex = 4;
            this.UC_PB_2.TabStop = false;
            this.UC_PB_2.Click += new System.EventHandler(this.UC_PB_2_Click);
            // 
            // quan_Ly_Shop_Quan_AoDataSet
            // 
            this.quan_Ly_Shop_Quan_AoDataSet.DataSetName = "Quan_Ly_Shop_Quan_AoDataSet";
            this.quan_Ly_Shop_Quan_AoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sizeBindingSource
            // 
            this.sizeBindingSource.DataMember = "Size";
            this.sizeBindingSource.DataSource = this.quan_Ly_Shop_Quan_AoDataSet;
            // 
            // sizeTableAdapter
            // 
            this.sizeTableAdapter.ClearBeforeFill = true;
            // 
            // UC_SanPham
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.SanPham_GB);
            this.Name = "UC_SanPham";
            this.Size = new System.Drawing.Size(243, 394);
            this.Load += new System.EventHandler(this.UC_HoaDon_SanPham_Load);
            this.SanPham_GB.ResumeLayout(false);
            this.SanPham_GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SanPham_PB_HetHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UC_PB_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quan_Ly_Shop_Quan_AoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.ParrotGroupBox SanPham_GB;
        private System.Windows.Forms.PictureBox UC_PB_2;
        private ReaLTaiizor.Controls.BigLabel SanPham_L;
        private System.Windows.Forms.BindingSource sizeBindingSource;
        private Quan_Ly_Shop_Quan_AoDataSet quan_Ly_Shop_Quan_AoDataSet;
        private Quan_Ly_Shop_Quan_AoDataSetTableAdapters.SizeTableAdapter sizeTableAdapter;
        private ReaLTaiizor.Controls.BigLabel SanPham_L_Gia;
        private ReaLTaiizor.Controls.HopePictureBox SanPham_PB_HetHang;
    }
}
