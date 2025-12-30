namespace Store_Mamager
{
    partial class Form_TrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TrangChu));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_TabC_ChucNang = new MaterialSkin.Controls.MaterialTabControl();
            this.tab_TrangChu = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.materialButton5 = new MaterialSkin.Controls.MaterialButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.M_CB_ChucVu = new MaterialSkin.Controls.MaterialComboBox();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.M_B_TimKiem = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.tab_DonHang = new System.Windows.Forms.TabPage();
            this.tab_KhoHang = new System.Windows.Forms.TabPage();
            this.tab_DoanhThu = new System.Windows.Forms.TabPage();
            this.tab_KhuyenMai = new System.Windows.Forms.TabPage();
            this.tab_DangXuat = new System.Windows.Forms.TabPage();
            this.sqlDataAdapter1 = new Microsoft.Data.SqlClient.SqlDataAdapter();
            this.M_CB_ThoiGianLam = new MaterialSkin.Controls.MaterialComboBox();
            this.materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            this.materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.materialButton4 = new MaterialSkin.Controls.MaterialButton();
            this.M_L_MaNhanVien1 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_HoVaTen1 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_ChucVu1 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_HTLViec1 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_SDT1 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_SDT2 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_HTLViec2 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_ChucVu2 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_HoVaTen2 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_MaNhanVien2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton6 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton7 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton8 = new MaterialSkin.Controls.MaterialButton();
            this.M_L_MaNhanVien3 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_SDT3 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_HoVaTen3 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_HTLViec3 = new MaterialSkin.Controls.MaterialLabel();
            this.M_L_ChucVu3 = new MaterialSkin.Controls.MaterialLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_TabC_ChucNang.SuspendLayout();
            this.tab_TrangChu.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "approval_delegation_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24.png");
            this.imageList1.Images.SetKeyName(1, "box_edit_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24.png");
            this.imageList1.Images.SetKeyName(2, "order_approve_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24.png");
            this.imageList1.Images.SetKeyName(3, "Trang_Chu_01.png");
            this.imageList1.Images.SetKeyName(4, "Trang_Chu_07.png");
            // 
            // m_TabC_ChucNang
            // 
            this.m_TabC_ChucNang.Controls.Add(this.tab_TrangChu);
            this.m_TabC_ChucNang.Controls.Add(this.tab_DonHang);
            this.m_TabC_ChucNang.Controls.Add(this.tab_KhoHang);
            this.m_TabC_ChucNang.Controls.Add(this.tab_DoanhThu);
            this.m_TabC_ChucNang.Controls.Add(this.tab_KhuyenMai);
            this.m_TabC_ChucNang.Controls.Add(this.tab_DangXuat);
            this.m_TabC_ChucNang.Depth = 0;
            this.m_TabC_ChucNang.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_TabC_ChucNang.ImageList = this.imageList1;
            this.m_TabC_ChucNang.Location = new System.Drawing.Point(3, 88);
            this.m_TabC_ChucNang.MouseState = MaterialSkin.MouseState.HOVER;
            this.m_TabC_ChucNang.Multiline = true;
            this.m_TabC_ChucNang.Name = "m_TabC_ChucNang";
            this.m_TabC_ChucNang.SelectedIndex = 0;
            this.m_TabC_ChucNang.Size = new System.Drawing.Size(1914, 5470);
            this.m_TabC_ChucNang.TabIndex = 0;
            this.m_TabC_ChucNang.SelectedIndexChanged += new System.EventHandler(this.m_TabC_ChucNang_SelectedIndexChanged);
            // 
            // tab_TrangChu
            // 
            this.tab_TrangChu.BackColor = System.Drawing.Color.Silver;
            this.tab_TrangChu.Controls.Add(this.groupBox5);
            this.tab_TrangChu.Controls.Add(this.button3);
            this.tab_TrangChu.Controls.Add(this.button2);
            this.tab_TrangChu.Controls.Add(this.groupBox4);
            this.tab_TrangChu.Controls.Add(this.groupBox3);
            this.tab_TrangChu.Controls.Add(this.groupBox2);
            this.tab_TrangChu.Controls.Add(this.groupBox1);
            this.tab_TrangChu.Controls.Add(this.materialProgressBar1);
            this.tab_TrangChu.ImageKey = "Trang_Chu_01.png";
            this.tab_TrangChu.Location = new System.Drawing.Point(4, 39);
            this.tab_TrangChu.Name = "tab_TrangChu";
            this.tab_TrangChu.Padding = new System.Windows.Forms.Padding(3);
            this.tab_TrangChu.Size = new System.Drawing.Size(1906, 5427);
            this.tab_TrangChu.TabIndex = 0;
            this.tab_TrangChu.Text = "Trang Chủ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox3);
            this.groupBox4.Controls.Add(this.materialButton7);
            this.groupBox4.Controls.Add(this.M_L_ChucVu3);
            this.groupBox4.Controls.Add(this.materialButton8);
            this.groupBox4.Controls.Add(this.M_L_HTLViec3);
            this.groupBox4.Controls.Add(this.M_L_MaNhanVien3);
            this.groupBox4.Controls.Add(this.M_L_HoVaTen3);
            this.groupBox4.Controls.Add(this.M_L_SDT3);
            this.groupBox4.Location = new System.Drawing.Point(3, 568);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1894, 212);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.materialButton6);
            this.groupBox3.Controls.Add(this.materialButton3);
            this.groupBox3.Controls.Add(this.M_L_MaNhanVien2);
            this.groupBox3.Controls.Add(this.M_L_SDT2);
            this.groupBox3.Controls.Add(this.M_L_HoVaTen2);
            this.groupBox3.Controls.Add(this.M_L_HTLViec2);
            this.groupBox3.Controls.Add(this.M_L_ChucVu2);
            this.groupBox3.Location = new System.Drawing.Point(6, 341);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1894, 212);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.M_L_SDT1);
            this.groupBox2.Controls.Add(this.M_L_HTLViec1);
            this.groupBox2.Controls.Add(this.M_L_ChucVu1);
            this.groupBox2.Controls.Add(this.M_L_HoVaTen1);
            this.groupBox2.Controls.Add(this.M_L_MaNhanVien1);
            this.groupBox2.Controls.Add(this.materialButton5);
            this.groupBox2.Controls.Add(this.materialButton4);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(6, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1894, 212);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // materialButton5
            // 
            this.materialButton5.AutoSize = false;
            this.materialButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton5.Depth = 0;
            this.materialButton5.HighEmphasis = true;
            this.materialButton5.Icon = null;
            this.materialButton5.Location = new System.Drawing.Point(243, 113);
            this.materialButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton5.Size = new System.Drawing.Size(158, 36);
            this.materialButton5.TabIndex = 2;
            this.materialButton5.Text = "Trên Máy";
            this.materialButton5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton5.UseAccentColor = false;
            this.materialButton5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.materialTextBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.materialTextBox1);
            this.groupBox1.Controls.Add(this.M_CB_ThoiGianLam);
            this.groupBox1.Controls.Add(this.M_CB_ChucVu);
            this.groupBox1.Controls.Add(this.materialButton2);
            this.groupBox1.Controls.Add(this.materialButton1);
            this.groupBox1.Controls.Add(this.M_B_TimKiem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1900, 103);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhân viên !";
            // 
            // M_CB_ChucVu
            // 
            this.M_CB_ChucVu.AutoResize = false;
            this.M_CB_ChucVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.M_CB_ChucVu.Depth = 0;
            this.M_CB_ChucVu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.M_CB_ChucVu.DropDownHeight = 118;
            this.M_CB_ChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.M_CB_ChucVu.DropDownWidth = 121;
            this.M_CB_ChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.M_CB_ChucVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.M_CB_ChucVu.FormattingEnabled = true;
            this.M_CB_ChucVu.IntegralHeight = false;
            this.M_CB_ChucVu.ItemHeight = 29;
            this.M_CB_ChucVu.Location = new System.Drawing.Point(966, 12);
            this.M_CB_ChucVu.MaxDropDownItems = 4;
            this.M_CB_ChucVu.MouseState = MaterialSkin.MouseState.OUT;
            this.M_CB_ChucVu.Name = "M_CB_ChucVu";
            this.M_CB_ChucVu.Size = new System.Drawing.Size(265, 35);
            this.M_CB_ChucVu.StartIndex = 0;
            this.M_CB_ChucVu.TabIndex = 3;
            this.M_CB_ChucVu.UseTallSize = false;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSize = false;
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.BackColor = System.Drawing.Color.Black;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(1687, 24);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(169, 50);
            this.materialButton2.TabIndex = 14;
            this.materialButton2.Text = "Thêm mới";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = false;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.BackColor = System.Drawing.Color.Black;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(1494, 24);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(169, 50);
            this.materialButton1.TabIndex = 13;
            this.materialButton1.Text = "Xóa";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = false;
            // 
            // M_B_TimKiem
            // 
            this.M_B_TimKiem.AutoSize = false;
            this.M_B_TimKiem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.M_B_TimKiem.BackColor = System.Drawing.Color.Black;
            this.M_B_TimKiem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.M_B_TimKiem.Depth = 0;
            this.M_B_TimKiem.HighEmphasis = true;
            this.M_B_TimKiem.Icon = null;
            this.M_B_TimKiem.Location = new System.Drawing.Point(1299, 24);
            this.M_B_TimKiem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.M_B_TimKiem.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_B_TimKiem.Name = "M_B_TimKiem";
            this.M_B_TimKiem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.M_B_TimKiem.Size = new System.Drawing.Size(169, 50);
            this.M_B_TimKiem.TabIndex = 12;
            this.M_B_TimKiem.Text = "Tìm kiếm";
            this.M_B_TimKiem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.M_B_TimKiem.UseAccentColor = false;
            this.M_B_TimKiem.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã nhân viên :";
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(100, 5);
            this.materialProgressBar1.TabIndex = 0;
            // 
            // tab_DonHang
            // 
            this.tab_DonHang.BackColor = System.Drawing.Color.Silver;
            this.tab_DonHang.ImageKey = "order_approve_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24.png";
            this.tab_DonHang.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tab_DonHang.Location = new System.Drawing.Point(4, 39);
            this.tab_DonHang.Name = "tab_DonHang";
            this.tab_DonHang.Padding = new System.Windows.Forms.Padding(3);
            this.tab_DonHang.Size = new System.Drawing.Size(1906, 5427);
            this.tab_DonHang.TabIndex = 1;
            this.tab_DonHang.Text = "Đơn Hàng";
            this.tab_DonHang.Click += new System.EventHandler(this.tab_DonHang_Click);
            // 
            // tab_KhoHang
            // 
            this.tab_KhoHang.ImageKey = "box_edit_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24.png";
            this.tab_KhoHang.Location = new System.Drawing.Point(4, 39);
            this.tab_KhoHang.Name = "tab_KhoHang";
            this.tab_KhoHang.Padding = new System.Windows.Forms.Padding(3);
            this.tab_KhoHang.Size = new System.Drawing.Size(1906, 5427);
            this.tab_KhoHang.TabIndex = 2;
            this.tab_KhoHang.Text = "Kho Hàng";
            this.tab_KhoHang.UseVisualStyleBackColor = true;
            // 
            // tab_DoanhThu
            // 
            this.tab_DoanhThu.ImageKey = "Trang_Chu_07.png";
            this.tab_DoanhThu.Location = new System.Drawing.Point(4, 39);
            this.tab_DoanhThu.Name = "tab_DoanhThu";
            this.tab_DoanhThu.Size = new System.Drawing.Size(1906, 5427);
            this.tab_DoanhThu.TabIndex = 3;
            this.tab_DoanhThu.Text = "Doanh Thu";
            this.tab_DoanhThu.UseVisualStyleBackColor = true;
            // 
            // tab_KhuyenMai
            // 
            this.tab_KhuyenMai.ImageKey = "approval_delegation_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz24.png";
            this.tab_KhuyenMai.Location = new System.Drawing.Point(4, 39);
            this.tab_KhuyenMai.Name = "tab_KhuyenMai";
            this.tab_KhuyenMai.Size = new System.Drawing.Size(1906, 5427);
            this.tab_KhuyenMai.TabIndex = 4;
            this.tab_KhuyenMai.Text = "Khuyến mãi";
            this.tab_KhuyenMai.UseVisualStyleBackColor = true;
            // 
            // tab_DangXuat
            // 
            this.tab_DangXuat.Location = new System.Drawing.Point(4, 39);
            this.tab_DangXuat.Name = "tab_DangXuat";
            this.tab_DangXuat.Size = new System.Drawing.Size(1906, 5427);
            this.tab_DangXuat.TabIndex = 5;
            this.tab_DangXuat.Text = "Đăng xuất !";
            this.tab_DangXuat.UseVisualStyleBackColor = true;
            // 
            // M_CB_ThoiGianLam
            // 
            this.M_CB_ThoiGianLam.AutoResize = false;
            this.M_CB_ThoiGianLam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.M_CB_ThoiGianLam.Depth = 0;
            this.M_CB_ThoiGianLam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.M_CB_ThoiGianLam.DropDownHeight = 118;
            this.M_CB_ThoiGianLam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.M_CB_ThoiGianLam.DropDownWidth = 121;
            this.M_CB_ThoiGianLam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.M_CB_ThoiGianLam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.M_CB_ThoiGianLam.FormattingEnabled = true;
            this.M_CB_ThoiGianLam.IntegralHeight = false;
            this.M_CB_ThoiGianLam.ItemHeight = 29;
            this.M_CB_ThoiGianLam.Location = new System.Drawing.Point(966, 61);
            this.M_CB_ThoiGianLam.MaxDropDownItems = 4;
            this.M_CB_ThoiGianLam.MouseState = MaterialSkin.MouseState.OUT;
            this.M_CB_ThoiGianLam.Name = "M_CB_ThoiGianLam";
            this.M_CB_ThoiGianLam.Size = new System.Drawing.Size(265, 35);
            this.M_CB_ThoiGianLam.StartIndex = 0;
            this.M_CB_ThoiGianLam.TabIndex = 15;
            this.M_CB_ThoiGianLam.UseTallSize = false;
            // 
            // materialTextBox1
            // 
            this.materialTextBox1.AnimateReadOnly = false;
            this.materialTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox1.Depth = 0;
            this.materialTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox1.LeadingIcon = null;
            this.materialTextBox1.Location = new System.Drawing.Point(146, 39);
            this.materialTextBox1.MaxLength = 50;
            this.materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox1.Multiline = false;
            this.materialTextBox1.Name = "materialTextBox1";
            this.materialTextBox1.Size = new System.Drawing.Size(284, 36);
            this.materialTextBox1.TabIndex = 16;
            this.materialTextBox1.Text = "";
            this.materialTextBox1.TrailingIcon = null;
            this.materialTextBox1.UseAccent = false;
            this.materialTextBox1.UseTallSize = false;
            // 
            // materialTextBox2
            // 
            this.materialTextBox2.AnimateReadOnly = false;
            this.materialTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox2.Depth = 0;
            this.materialTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox2.LeadingIcon = null;
            this.materialTextBox2.Location = new System.Drawing.Point(596, 38);
            this.materialTextBox2.MaxLength = 50;
            this.materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox2.Multiline = false;
            this.materialTextBox2.Name = "materialTextBox2";
            this.materialTextBox2.Size = new System.Drawing.Size(284, 36);
            this.materialTextBox2.TabIndex = 18;
            this.materialTextBox2.Text = "";
            this.materialTextBox2.TrailingIcon = null;
            this.materialTextBox2.UseAccent = false;
            this.materialTextBox2.UseTallSize = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Họ và Tên :";
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSize = false;
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = null;
            this.materialButton4.Location = new System.Drawing.Point(243, 44);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(158, 38);
            this.materialButton4.TabIndex = 1;
            this.materialButton4.Text = "Mặc định";
            this.materialButton4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            // 
            // M_L_MaNhanVien1
            // 
            this.M_L_MaNhanVien1.Depth = 0;
            this.M_L_MaNhanVien1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_MaNhanVien1.Location = new System.Drawing.Point(568, 44);
            this.M_L_MaNhanVien1.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_MaNhanVien1.Name = "M_L_MaNhanVien1";
            this.M_L_MaNhanVien1.Size = new System.Drawing.Size(143, 28);
            this.M_L_MaNhanVien1.TabIndex = 3;
            this.M_L_MaNhanVien1.Text = "Mã nhân viên :";
            // 
            // M_L_HoVaTen1
            // 
            this.M_L_HoVaTen1.Depth = 0;
            this.M_L_HoVaTen1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_HoVaTen1.Location = new System.Drawing.Point(568, 113);
            this.M_L_HoVaTen1.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_HoVaTen1.Name = "M_L_HoVaTen1";
            this.M_L_HoVaTen1.Size = new System.Drawing.Size(143, 28);
            this.M_L_HoVaTen1.TabIndex = 4;
            this.M_L_HoVaTen1.Text = "Họ và tên :";
            // 
            // M_L_ChucVu1
            // 
            this.M_L_ChucVu1.Depth = 0;
            this.M_L_ChucVu1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_ChucVu1.Location = new System.Drawing.Point(960, 113);
            this.M_L_ChucVu1.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_ChucVu1.Name = "M_L_ChucVu1";
            this.M_L_ChucVu1.Size = new System.Drawing.Size(143, 28);
            this.M_L_ChucVu1.TabIndex = 5;
            this.M_L_ChucVu1.Text = "Chức vụ :";
            // 
            // M_L_HTLViec1
            // 
            this.M_L_HTLViec1.Depth = 0;
            this.M_L_HTLViec1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_HTLViec1.Location = new System.Drawing.Point(1303, 113);
            this.M_L_HTLViec1.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_HTLViec1.Name = "M_L_HTLViec1";
            this.M_L_HTLViec1.Size = new System.Drawing.Size(143, 28);
            this.M_L_HTLViec1.TabIndex = 6;
            this.M_L_HTLViec1.Text = "Hình thức làm việc :";
            // 
            // M_L_SDT1
            // 
            this.M_L_SDT1.Depth = 0;
            this.M_L_SDT1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_SDT1.Location = new System.Drawing.Point(960, 44);
            this.M_L_SDT1.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_SDT1.Name = "M_L_SDT1";
            this.M_L_SDT1.Size = new System.Drawing.Size(143, 28);
            this.M_L_SDT1.TabIndex = 7;
            this.M_L_SDT1.Text = "SDT :";
            // 
            // M_L_SDT2
            // 
            this.M_L_SDT2.Depth = 0;
            this.M_L_SDT2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_SDT2.Location = new System.Drawing.Point(960, 47);
            this.M_L_SDT2.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_SDT2.Name = "M_L_SDT2";
            this.M_L_SDT2.Size = new System.Drawing.Size(143, 28);
            this.M_L_SDT2.TabIndex = 20;
            this.M_L_SDT2.Text = "SDT :";
            // 
            // M_L_HTLViec2
            // 
            this.M_L_HTLViec2.Depth = 0;
            this.M_L_HTLViec2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_HTLViec2.Location = new System.Drawing.Point(1303, 116);
            this.M_L_HTLViec2.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_HTLViec2.Name = "M_L_HTLViec2";
            this.M_L_HTLViec2.Size = new System.Drawing.Size(143, 28);
            this.M_L_HTLViec2.TabIndex = 19;
            this.M_L_HTLViec2.Text = "Hình thức làm việc :";
            // 
            // M_L_ChucVu2
            // 
            this.M_L_ChucVu2.Depth = 0;
            this.M_L_ChucVu2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_ChucVu2.Location = new System.Drawing.Point(960, 116);
            this.M_L_ChucVu2.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_ChucVu2.Name = "M_L_ChucVu2";
            this.M_L_ChucVu2.Size = new System.Drawing.Size(143, 28);
            this.M_L_ChucVu2.TabIndex = 18;
            this.M_L_ChucVu2.Text = "Chức vụ :";
            // 
            // M_L_HoVaTen2
            // 
            this.M_L_HoVaTen2.Depth = 0;
            this.M_L_HoVaTen2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_HoVaTen2.Location = new System.Drawing.Point(568, 116);
            this.M_L_HoVaTen2.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_HoVaTen2.Name = "M_L_HoVaTen2";
            this.M_L_HoVaTen2.Size = new System.Drawing.Size(143, 28);
            this.M_L_HoVaTen2.TabIndex = 17;
            this.M_L_HoVaTen2.Text = "Họ và tên :";
            // 
            // M_L_MaNhanVien2
            // 
            this.M_L_MaNhanVien2.Depth = 0;
            this.M_L_MaNhanVien2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_MaNhanVien2.Location = new System.Drawing.Point(568, 47);
            this.M_L_MaNhanVien2.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_MaNhanVien2.Name = "M_L_MaNhanVien2";
            this.M_L_MaNhanVien2.Size = new System.Drawing.Size(143, 28);
            this.M_L_MaNhanVien2.TabIndex = 16;
            this.M_L_MaNhanVien2.Text = "Mã nhân viên :";
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSize = false;
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(243, 116);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(158, 36);
            this.materialButton3.TabIndex = 15;
            this.materialButton3.Text = "Trên Máy";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            // 
            // materialButton6
            // 
            this.materialButton6.AutoSize = false;
            this.materialButton6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton6.Depth = 0;
            this.materialButton6.HighEmphasis = true;
            this.materialButton6.Icon = null;
            this.materialButton6.Location = new System.Drawing.Point(243, 47);
            this.materialButton6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton6.Name = "materialButton6";
            this.materialButton6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton6.Size = new System.Drawing.Size(158, 38);
            this.materialButton6.TabIndex = 14;
            this.materialButton6.Text = "Mặc định";
            this.materialButton6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton6.UseAccentColor = false;
            this.materialButton6.UseVisualStyleBackColor = true;
            // 
            // materialButton7
            // 
            this.materialButton7.AutoSize = false;
            this.materialButton7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton7.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton7.Depth = 0;
            this.materialButton7.HighEmphasis = true;
            this.materialButton7.Icon = null;
            this.materialButton7.Location = new System.Drawing.Point(246, 43);
            this.materialButton7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton7.Name = "materialButton7";
            this.materialButton7.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton7.Size = new System.Drawing.Size(158, 38);
            this.materialButton7.TabIndex = 22;
            this.materialButton7.Text = "Mặc định";
            this.materialButton7.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton7.UseAccentColor = false;
            this.materialButton7.UseVisualStyleBackColor = true;
            // 
            // materialButton8
            // 
            this.materialButton8.AutoSize = false;
            this.materialButton8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton8.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton8.Depth = 0;
            this.materialButton8.HighEmphasis = true;
            this.materialButton8.Icon = null;
            this.materialButton8.Location = new System.Drawing.Point(246, 112);
            this.materialButton8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton8.Name = "materialButton8";
            this.materialButton8.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton8.Size = new System.Drawing.Size(158, 36);
            this.materialButton8.TabIndex = 23;
            this.materialButton8.Text = "Trên Máy";
            this.materialButton8.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton8.UseAccentColor = false;
            this.materialButton8.UseVisualStyleBackColor = true;
            // 
            // M_L_MaNhanVien3
            // 
            this.M_L_MaNhanVien3.Depth = 0;
            this.M_L_MaNhanVien3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_MaNhanVien3.Location = new System.Drawing.Point(571, 43);
            this.M_L_MaNhanVien3.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_MaNhanVien3.Name = "M_L_MaNhanVien3";
            this.M_L_MaNhanVien3.Size = new System.Drawing.Size(143, 28);
            this.M_L_MaNhanVien3.TabIndex = 24;
            this.M_L_MaNhanVien3.Text = "Mã nhân viên :";
            // 
            // M_L_SDT3
            // 
            this.M_L_SDT3.Depth = 0;
            this.M_L_SDT3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_SDT3.Location = new System.Drawing.Point(963, 43);
            this.M_L_SDT3.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_SDT3.Name = "M_L_SDT3";
            this.M_L_SDT3.Size = new System.Drawing.Size(143, 28);
            this.M_L_SDT3.TabIndex = 28;
            this.M_L_SDT3.Text = "SDT :";
            // 
            // M_L_HoVaTen3
            // 
            this.M_L_HoVaTen3.Depth = 0;
            this.M_L_HoVaTen3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_HoVaTen3.Location = new System.Drawing.Point(571, 112);
            this.M_L_HoVaTen3.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_HoVaTen3.Name = "M_L_HoVaTen3";
            this.M_L_HoVaTen3.Size = new System.Drawing.Size(143, 28);
            this.M_L_HoVaTen3.TabIndex = 25;
            this.M_L_HoVaTen3.Text = "Họ và tên :";
            // 
            // M_L_HTLViec3
            // 
            this.M_L_HTLViec3.Depth = 0;
            this.M_L_HTLViec3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_HTLViec3.Location = new System.Drawing.Point(1306, 112);
            this.M_L_HTLViec3.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_HTLViec3.Name = "M_L_HTLViec3";
            this.M_L_HTLViec3.Size = new System.Drawing.Size(143, 28);
            this.M_L_HTLViec3.TabIndex = 27;
            this.M_L_HTLViec3.Text = "Hình thức làm việc :";
            // 
            // M_L_ChucVu3
            // 
            this.M_L_ChucVu3.Depth = 0;
            this.M_L_ChucVu3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_L_ChucVu3.Location = new System.Drawing.Point(963, 112);
            this.M_L_ChucVu3.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_L_ChucVu3.Name = "M_L_ChucVu3";
            this.M_L_ChucVu3.Size = new System.Drawing.Size(143, 28);
            this.M_L_ChucVu3.TabIndex = 26;
            this.M_L_ChucVu3.Text = "Chức vụ :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(906, 2693);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(914, 2701);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 40);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(712, 786);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(397, 71);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            // 
            // button4
            // 
            this.button4.Image = global::Store_Mamager.Properties.Resources.arrow_menu_open_24dp_000000_FILL0_wght400_GRAD0_opsz24;
            this.button4.Location = new System.Drawing.Point(277, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 44);
            this.button4.TabIndex = 1;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::Store_Mamager.Properties.Resources.arrow_menu_close_24dp_000000_FILL0_wght400_GRAD0_opsz24;
            this.button1.Location = new System.Drawing.Point(15, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 44);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Store_Mamager.Properties.Resources.Trang_Chu_03;
            this.pictureBox3.Location = new System.Drawing.Point(28, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(192, 176);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Store_Mamager.Properties.Resources.Trang_Chu_03;
            this.pictureBox2.Location = new System.Drawing.Point(25, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(192, 176);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Store_Mamager.Properties.Resources.Trang_Chu_03;
            this.pictureBox1.Location = new System.Drawing.Point(25, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form_TrangChu
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1920, 990);
            this.Controls.Add(this.m_TabC_ChucNang);
            this.DrawerTabControl = this.m_TabC_ChucNang;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_64;
            this.Name = "Form_TrangChu";
            this.Padding = new System.Windows.Forms.Padding(3, 88, 3, 3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Shop quần áo !";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_TrangChu_Load);
            this.m_TabC_ChucNang.ResumeLayout(false);
            this.tab_TrangChu.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private MaterialSkin.Controls.MaterialTabControl m_TabC_ChucNang;
        private System.Windows.Forms.TabPage tab_DonHang;
        private System.Windows.Forms.TabPage tab_KhoHang;
        private System.Windows.Forms.TabPage tab_DoanhThu;
        private System.Windows.Forms.TabPage tab_KhuyenMai;
        private System.Windows.Forms.TabPage tab_DangXuat;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Windows.Forms.TabPage tab_TrangChu;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialButton M_B_TimKiem;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialButton materialButton5;
        private MaterialSkin.Controls.MaterialComboBox M_CB_ChucVu;
        private MaterialSkin.Controls.MaterialComboBox M_CB_ThoiGianLam;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialButton materialButton4;
        private MaterialSkin.Controls.MaterialLabel M_L_MaNhanVien1;
        private MaterialSkin.Controls.MaterialLabel M_L_HTLViec1;
        private MaterialSkin.Controls.MaterialLabel M_L_ChucVu1;
        private MaterialSkin.Controls.MaterialLabel M_L_HoVaTen1;
        private MaterialSkin.Controls.MaterialLabel M_L_SDT1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private MaterialSkin.Controls.MaterialButton materialButton7;
        private MaterialSkin.Controls.MaterialLabel M_L_ChucVu3;
        private MaterialSkin.Controls.MaterialButton materialButton8;
        private MaterialSkin.Controls.MaterialLabel M_L_HTLViec3;
        private MaterialSkin.Controls.MaterialLabel M_L_MaNhanVien3;
        private MaterialSkin.Controls.MaterialLabel M_L_HoVaTen3;
        private MaterialSkin.Controls.MaterialLabel M_L_SDT3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MaterialSkin.Controls.MaterialButton materialButton6;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialLabel M_L_MaNhanVien2;
        private MaterialSkin.Controls.MaterialLabel M_L_SDT2;
        private MaterialSkin.Controls.MaterialLabel M_L_HoVaTen2;
        private MaterialSkin.Controls.MaterialLabel M_L_HTLViec2;
        private MaterialSkin.Controls.MaterialLabel M_L_ChucVu2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}