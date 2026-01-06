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
            this.components = new System.ComponentModel.Container();
            this.UC_GB_SanPham = new ReaLTaiizor.Controls.ParrotGroupBox();
            this.UC_PB_2 = new System.Windows.Forms.PictureBox();
            this.L_TrangChu_TieuDe = new ReaLTaiizor.Controls.BigLabel();
            this.quan_Ly_Shop_Quan_AoDataSet = new Store_Manager.Quan_Ly_Shop_Quan_AoDataSet();
            this.sizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sizeTableAdapter = new Store_Manager.Quan_Ly_Shop_Quan_AoDataSetTableAdapters.SizeTableAdapter();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.UC_GB_SanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UC_PB_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quan_Ly_Shop_Quan_AoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UC_GB_SanPham
            // 
            this.UC_GB_SanPham.BorderColor = System.Drawing.Color.LightCyan;
            this.UC_GB_SanPham.BorderWidth = 3;
            this.UC_GB_SanPham.Controls.Add(this.L_TrangChu_TieuDe);
            this.UC_GB_SanPham.Controls.Add(this.bigLabel1);
            this.UC_GB_SanPham.Controls.Add(this.UC_PB_2);
            this.UC_GB_SanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC_GB_SanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UC_GB_SanPham.Location = new System.Drawing.Point(0, 0);
            this.UC_GB_SanPham.Name = "UC_GB_SanPham";
            this.UC_GB_SanPham.Padding = new System.Windows.Forms.Padding(0);
            this.UC_GB_SanPham.ShowText = true;
            this.UC_GB_SanPham.Size = new System.Drawing.Size(243, 394);
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
            this.UC_PB_2.Size = new System.Drawing.Size(236, 256);
            this.UC_PB_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UC_PB_2.TabIndex = 4;
            this.UC_PB_2.TabStop = false;
            // 
            // L_TrangChu_TieuDe
            // 
            this.L_TrangChu_TieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.L_TrangChu_TieuDe.BackColor = System.Drawing.Color.Transparent;
            this.L_TrangChu_TieuDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.L_TrangChu_TieuDe.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TrangChu_TieuDe.ForeColor = System.Drawing.Color.Black;
            this.L_TrangChu_TieuDe.Location = new System.Drawing.Point(12, 247);
            this.L_TrangChu_TieuDe.Name = "L_TrangChu_TieuDe";
            this.L_TrangChu_TieuDe.Size = new System.Drawing.Size(223, 106);
            this.L_TrangChu_TieuDe.TabIndex = 5;
            this.L_TrangChu_TieuDe.Text = "Quần short kaki M\r\n>> Nam >> Size M\r\n";
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
            // bigLabel1
            // 
            this.bigLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.Color.YellowGreen;
            this.bigLabel1.Location = new System.Drawing.Point(12, 355);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(223, 33);
            this.bigLabel1.TabIndex = 6;
            this.bigLabel1.Text = "120.010.000 đ";
            this.bigLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UC_HoaDon_SanPham
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.UC_GB_SanPham);
            this.Name = "UC_HoaDon_SanPham";
            this.Size = new System.Drawing.Size(243, 394);
            this.Load += new System.EventHandler(this.UC_HoaDon_SanPham_Load);
            this.UC_GB_SanPham.ResumeLayout(false);
            this.UC_GB_SanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UC_PB_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quan_Ly_Shop_Quan_AoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.ParrotGroupBox UC_GB_SanPham;
        private System.Windows.Forms.PictureBox UC_PB_2;
        private ReaLTaiizor.Controls.BigLabel L_TrangChu_TieuDe;
        private System.Windows.Forms.BindingSource sizeBindingSource;
        private Quan_Ly_Shop_Quan_AoDataSet quan_Ly_Shop_Quan_AoDataSet;
        private Quan_Ly_Shop_Quan_AoDataSetTableAdapters.SizeTableAdapter sizeTableAdapter;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
    }
}
