namespace Store_Mamager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.M_TB_Thoat = new MaterialSkin.Controls.MaterialButton();
            this.M_TB_DangNhap = new MaterialSkin.Controls.MaterialButton();
            this.M_TB_PassWord = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.M_TB_UserName = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.EP_CheckLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_CheckLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.pictureBox2);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(2470, 74);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(28, 27, 28, 27);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(28, 27, 28, 27);
            this.materialCard1.Size = new System.Drawing.Size(1544, 1812);
            this.materialCard1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::Store_Mamager.Properties.Resources.logo_shop_quan_ao_nam_9;
            this.pictureBox2.Location = new System.Drawing.Point(28, 27);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1488, 1758);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.groupBox1.Controls.Add(this.M_TB_Thoat);
            this.groupBox1.Controls.Add(this.M_TB_DangNhap);
            this.groupBox1.Controls.Add(this.M_TB_PassWord);
            this.groupBox1.Controls.Add(this.M_TB_UserName);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(996, 920);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // M_TB_Thoat
            // 
            this.M_TB_Thoat.AutoSize = false;
            this.M_TB_Thoat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.M_TB_Thoat.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.M_TB_Thoat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.M_TB_Thoat.Depth = 0;
            this.M_TB_Thoat.HighEmphasis = true;
            this.M_TB_Thoat.Icon = global::Store_Mamager.Properties.Resources.cancel_24dp_EA3323_FILL1_wght400_GRAD0_opsz24;
            this.M_TB_Thoat.Location = new System.Drawing.Point(207, 568);
            this.M_TB_Thoat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.M_TB_Thoat.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_TB_Thoat.Name = "M_TB_Thoat";
            this.M_TB_Thoat.NoAccentTextColor = System.Drawing.Color.Empty;
            this.M_TB_Thoat.Size = new System.Drawing.Size(237, 46);
            this.M_TB_Thoat.TabIndex = 5;
            this.M_TB_Thoat.Text = "Thoát !";
            this.M_TB_Thoat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.M_TB_Thoat.UseAccentColor = true;
            this.M_TB_Thoat.UseVisualStyleBackColor = false;
            this.M_TB_Thoat.Click += new System.EventHandler(this.M_TB_Thoat_Click);
            // 
            // M_TB_DangNhap
            // 
            this.M_TB_DangNhap.AutoSize = false;
            this.M_TB_DangNhap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.M_TB_DangNhap.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.M_TB_DangNhap.Depth = 0;
            this.M_TB_DangNhap.HighEmphasis = true;
            this.M_TB_DangNhap.Icon = global::Store_Mamager.Properties.Resources.login_24dp_FFFFFF_FILL0_wght400_GRAD0_opsz242;
            this.M_TB_DangNhap.Location = new System.Drawing.Point(535, 568);
            this.M_TB_DangNhap.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.M_TB_DangNhap.MouseState = MaterialSkin.MouseState.HOVER;
            this.M_TB_DangNhap.Name = "M_TB_DangNhap";
            this.M_TB_DangNhap.NoAccentTextColor = System.Drawing.Color.Empty;
            this.M_TB_DangNhap.Size = new System.Drawing.Size(237, 46);
            this.M_TB_DangNhap.TabIndex = 4;
            this.M_TB_DangNhap.Text = "Đăng nhập !";
            this.M_TB_DangNhap.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.M_TB_DangNhap.UseAccentColor = false;
            this.M_TB_DangNhap.UseVisualStyleBackColor = true;
            this.M_TB_DangNhap.Click += new System.EventHandler(this.M_TB_DangNhap_Click);
            // 
            // M_TB_PassWord
            // 
            this.M_TB_PassWord.AllowPromptAsInput = true;
            this.M_TB_PassWord.AnimateReadOnly = false;
            this.M_TB_PassWord.AsciiOnly = false;
            this.M_TB_PassWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.M_TB_PassWord.BeepOnError = false;
            this.M_TB_PassWord.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.M_TB_PassWord.Depth = 0;
            this.M_TB_PassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_TB_PassWord.HidePromptOnLeave = false;
            this.M_TB_PassWord.HideSelection = true;
            this.M_TB_PassWord.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.M_TB_PassWord.LeadingIcon = null;
            this.M_TB_PassWord.Location = new System.Drawing.Point(283, 385);
            this.M_TB_PassWord.Mask = "";
            this.M_TB_PassWord.MaxLength = 32767;
            this.M_TB_PassWord.MouseState = MaterialSkin.MouseState.OUT;
            this.M_TB_PassWord.Name = "M_TB_PassWord";
            this.M_TB_PassWord.PasswordChar = '\0';
            this.M_TB_PassWord.PrefixSuffixText = null;
            this.M_TB_PassWord.PromptChar = '_';
            this.M_TB_PassWord.ReadOnly = false;
            this.M_TB_PassWord.RejectInputOnFirstFailure = false;
            this.M_TB_PassWord.ResetOnPrompt = true;
            this.M_TB_PassWord.ResetOnSpace = true;
            this.M_TB_PassWord.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.M_TB_PassWord.SelectedText = "";
            this.M_TB_PassWord.SelectionLength = 0;
            this.M_TB_PassWord.SelectionStart = 0;
            this.M_TB_PassWord.ShortcutsEnabled = true;
            this.M_TB_PassWord.Size = new System.Drawing.Size(426, 48);
            this.M_TB_PassWord.SkipLiterals = true;
            this.M_TB_PassWord.TabIndex = 3;
            this.M_TB_PassWord.TabStop = false;
            this.M_TB_PassWord.Text = "PassWord";
            this.M_TB_PassWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.M_TB_PassWord.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.M_TB_PassWord.TrailingIcon = null;
            this.M_TB_PassWord.UseSystemPasswordChar = false;
            this.M_TB_PassWord.ValidatingType = null;
            this.M_TB_PassWord.Click += new System.EventHandler(this.M_TB_PassWord_Click_1);
            this.M_TB_PassWord.MouseLeave += new System.EventHandler(this.M_TB_PassWord_MouseLeave);
            // 
            // M_TB_UserName
            // 
            this.M_TB_UserName.AllowPromptAsInput = true;
            this.M_TB_UserName.AnimateReadOnly = false;
            this.M_TB_UserName.AsciiOnly = false;
            this.M_TB_UserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.M_TB_UserName.BeepOnError = false;
            this.M_TB_UserName.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.M_TB_UserName.Depth = 0;
            this.M_TB_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.M_TB_UserName.HidePromptOnLeave = false;
            this.M_TB_UserName.HideSelection = true;
            this.M_TB_UserName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.M_TB_UserName.LeadingIcon = null;
            this.M_TB_UserName.Location = new System.Drawing.Point(283, 299);
            this.M_TB_UserName.Mask = "";
            this.M_TB_UserName.MaxLength = 32767;
            this.M_TB_UserName.MouseState = MaterialSkin.MouseState.OUT;
            this.M_TB_UserName.Name = "M_TB_UserName";
            this.M_TB_UserName.PasswordChar = '\0';
            this.M_TB_UserName.PrefixSuffixText = null;
            this.M_TB_UserName.PromptChar = '_';
            this.M_TB_UserName.ReadOnly = false;
            this.M_TB_UserName.RejectInputOnFirstFailure = false;
            this.M_TB_UserName.ResetOnPrompt = true;
            this.M_TB_UserName.ResetOnSpace = true;
            this.M_TB_UserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.M_TB_UserName.SelectedText = "";
            this.M_TB_UserName.SelectionLength = 0;
            this.M_TB_UserName.SelectionStart = 0;
            this.M_TB_UserName.ShortcutsEnabled = true;
            this.M_TB_UserName.Size = new System.Drawing.Size(426, 48);
            this.M_TB_UserName.SkipLiterals = true;
            this.M_TB_UserName.TabIndex = 2;
            this.M_TB_UserName.TabStop = false;
            this.M_TB_UserName.Text = "UserName";
            this.M_TB_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.M_TB_UserName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.M_TB_UserName.TrailingIcon = null;
            this.M_TB_UserName.UseSystemPasswordChar = false;
            this.M_TB_UserName.ValidatingType = null;
            this.M_TB_UserName.Click += new System.EventHandler(this.M_TB_UserName_Click_1);
            this.M_TB_UserName.MouseLeave += new System.EventHandler(this.M_TB_UserName_MouseLeave);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.materialLabel1.Location = new System.Drawing.Point(412, 191);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(202, 41);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Đăng Nhập !";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Store_Mamager.Properties.Resources.padlock_9821260;
            this.pictureBox1.Location = new System.Drawing.Point(379, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // EP_CheckLogin
            // 
            this.EP_CheckLogin.ContainerControl = this;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox3.Image = global::Store_Mamager.Properties.Resources.logo_shop_quan_ao_nam_9;
            this.pictureBox3.Location = new System.Drawing.Point(941, 64);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(530, 920);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1477, 990);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.materialCard1);
            this.DrawerAutoHide = false;
            this.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 6, 6);
            this.Text = "Đăng Nhập !";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_CheckLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialMaskedTextBox M_TB_PassWord;
        private MaterialSkin.Controls.MaterialMaskedTextBox M_TB_UserName;
        private MaterialSkin.Controls.MaterialButton M_TB_DangNhap;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.ErrorProvider EP_CheckLogin;
        private MaterialSkin.Controls.MaterialButton M_TB_Thoat;
    }
}

