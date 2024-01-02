namespace SIBActivator.Forms
{
    partial class FormContribute
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContribute));
            this.btn_Close = new System.Windows.Forms.Label();
            this.imgHeader = new System.Windows.Forms.PictureBox();
            this.txt_BTC = new SIBActivator.AetherxTextBox();
            this.lbl_Dev_PIV_Thumbprint = new System.Windows.Forms.Label();
            this.aetherxTextBox1 = new SIBActivator.AetherxTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aetherxTextBox2 = new SIBActivator.AetherxTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.aetherxTextBox3 = new SIBActivator.AetherxTextBox();
            this.lbl_Subtitle = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btn_Close.Location = new System.Drawing.Point(492, 7);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(24, 32);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.Text = "";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imgHeader
            // 
            this.imgHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgHeader.BackgroundImage")));
            this.imgHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgHeader.Location = new System.Drawing.Point(1, 1);
            this.imgHeader.Name = "imgHeader";
            this.imgHeader.Size = new System.Drawing.Size(528, 129);
            this.imgHeader.TabIndex = 1;
            this.imgHeader.TabStop = false;
            this.imgHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.imgHeader_Paint);
            this.imgHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseDown);
            this.imgHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseMove);
            this.imgHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseUp);
            // 
            // txt_BTC
            // 
            this.txt_BTC.AllowFocus = true;
            this.txt_BTC.AutoScroll = true;
            this.txt_BTC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt_BTC.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_BTC.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_BTC.BorderSize = 1;
            this.txt_BTC.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_BTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_BTC.Location = new System.Drawing.Point(15, 316);
            this.txt_BTC.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BTC.Multiline = false;
            this.txt_BTC.MultilineScrollbars = true;
            this.txt_BTC.Name = "txt_BTC";
            this.txt_BTC.Padding = new System.Windows.Forms.Padding(36, 6, 6, 6);
            this.txt_BTC.PasswordChar = false;
            this.txt_BTC.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_BTC.PlaceholderText = "";
            this.txt_BTC.ReadOnly = true;
            this.txt_BTC.Selectable = true;
            this.txt_BTC.Size = new System.Drawing.Size(503, 33);
            this.txt_BTC.TabIndex = 12;
            this.txt_BTC.UnderlineStyle = true;
            this.txt_BTC.Value = "1QGTXH5gdkWDueFU46fQiZEwkjtHk1yriy";
            // 
            // lbl_Dev_PIV_Thumbprint
            // 
            this.lbl_Dev_PIV_Thumbprint.AutoSize = true;
            this.lbl_Dev_PIV_Thumbprint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Dev_PIV_Thumbprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_Dev_PIV_Thumbprint.Location = new System.Drawing.Point(11, 295);
            this.lbl_Dev_PIV_Thumbprint.Name = "lbl_Dev_PIV_Thumbprint";
            this.lbl_Dev_PIV_Thumbprint.Size = new System.Drawing.Size(31, 19);
            this.lbl_Dev_PIV_Thumbprint.TabIndex = 11;
            this.lbl_Dev_PIV_Thumbprint.Text = "BTC";
            // 
            // aetherxTextBox1
            // 
            this.aetherxTextBox1.AllowFocus = true;
            this.aetherxTextBox1.AutoScroll = true;
            this.aetherxTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.aetherxTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.aetherxTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.aetherxTextBox1.BorderSize = 1;
            this.aetherxTextBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.aetherxTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.aetherxTextBox1.Location = new System.Drawing.Point(15, 376);
            this.aetherxTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.aetherxTextBox1.Multiline = false;
            this.aetherxTextBox1.MultilineScrollbars = true;
            this.aetherxTextBox1.Name = "aetherxTextBox1";
            this.aetherxTextBox1.Padding = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.aetherxTextBox1.PasswordChar = false;
            this.aetherxTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.aetherxTextBox1.PlaceholderText = "";
            this.aetherxTextBox1.ReadOnly = true;
            this.aetherxTextBox1.Selectable = true;
            this.aetherxTextBox1.Size = new System.Drawing.Size(503, 33);
            this.aetherxTextBox1.TabIndex = 14;
            this.aetherxTextBox1.UnderlineStyle = true;
            this.aetherxTextBox1.Value = "0xC6A9cA5B17265f41636a45dF165a5821f9d26445";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label1.Location = new System.Drawing.Point(11, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "ETH";
            // 
            // aetherxTextBox2
            // 
            this.aetherxTextBox2.AllowFocus = true;
            this.aetherxTextBox2.AutoScroll = true;
            this.aetherxTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.aetherxTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.aetherxTextBox2.BorderFocusColor = System.Drawing.Color.HotPink;
            this.aetherxTextBox2.BorderSize = 1;
            this.aetherxTextBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.aetherxTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.aetherxTextBox2.Location = new System.Drawing.Point(15, 434);
            this.aetherxTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.aetherxTextBox2.Multiline = false;
            this.aetherxTextBox2.MultilineScrollbars = true;
            this.aetherxTextBox2.Name = "aetherxTextBox2";
            this.aetherxTextBox2.Padding = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.aetherxTextBox2.PasswordChar = false;
            this.aetherxTextBox2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.aetherxTextBox2.PlaceholderText = "";
            this.aetherxTextBox2.ReadOnly = true;
            this.aetherxTextBox2.Selectable = true;
            this.aetherxTextBox2.Size = new System.Drawing.Size(503, 33);
            this.aetherxTextBox2.TabIndex = 16;
            this.aetherxTextBox2.UnderlineStyle = true;
            this.aetherxTextBox2.Value = "bitcoincash:qrf53klxwhh6t74cfdkv3u3knvhdtpwaku4qgdapja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label2.Location = new System.Drawing.Point(11, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "BCH";
            // 
            // aetherxTextBox3
            // 
            this.aetherxTextBox3.AllowFocus = false;
            this.aetherxTextBox3.AutoScroll = true;
            this.aetherxTextBox3.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.aetherxTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.aetherxTextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.aetherxTextBox3.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.aetherxTextBox3.BorderSize = 2;
            this.aetherxTextBox3.CausesValidation = false;
            this.aetherxTextBox3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.aetherxTextBox3.ForeColor = System.Drawing.Color.DarkGray;
            this.aetherxTextBox3.Location = new System.Drawing.Point(15, 144);
            this.aetherxTextBox3.Margin = new System.Windows.Forms.Padding(0);
            this.aetherxTextBox3.Multiline = true;
            this.aetherxTextBox3.MultilineScrollbars = false;
            this.aetherxTextBox3.Name = "aetherxTextBox3";
            this.aetherxTextBox3.Padding = new System.Windows.Forms.Padding(9);
            this.aetherxTextBox3.PasswordChar = false;
            this.aetherxTextBox3.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.aetherxTextBox3.PlaceholderText = "";
            this.aetherxTextBox3.ReadOnly = true;
            this.aetherxTextBox3.Selectable = false;
            this.aetherxTextBox3.Size = new System.Drawing.Size(503, 137);
            this.aetherxTextBox3.TabIndex = 17;
            this.aetherxTextBox3.UnderlineStyle = false;
            this.aetherxTextBox3.Value = resources.GetString("aetherxTextBox3.Value");
            this.aetherxTextBox3._TextChanged += new System.EventHandler(this.aetherxTextBox3__TextChanged);
            // 
            // lbl_Subtitle
            // 
            this.lbl_Subtitle.AutoSize = true;
            this.lbl_Subtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_Subtitle.Location = new System.Drawing.Point(35, 72);
            this.lbl_Subtitle.Name = "lbl_Subtitle";
            this.lbl_Subtitle.Size = new System.Drawing.Size(45, 15);
            this.lbl_Subtitle.TabIndex = 35;
            this.lbl_Subtitle.Text = "Version";
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Myriad Pro Light", 22F);
            this.lbl_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(41)))), ((int)(((byte)(101)))));
            this.lbl_Title.Location = new System.Drawing.Point(31, 33);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(145, 36);
            this.lbl_Title.TabIndex = 34;
            this.lbl_Title.Text = "Contribute";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SIBActivator.Properties.Resources.btc;
            this.pictureBox1.Location = new System.Drawing.Point(21, 320);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::SIBActivator.Properties.Resources.eth;
            this.pictureBox2.Location = new System.Drawing.Point(21, 380);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::SIBActivator.Properties.Resources.bch;
            this.pictureBox3.Location = new System.Drawing.Point(21, 438);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // FormContribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(530, 481);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_Subtitle);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.aetherxTextBox3);
            this.Controls.Add(this.aetherxTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.aetherxTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_BTC);
            this.Controls.Add(this.lbl_Dev_PIV_Thumbprint);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.imgHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormContribute";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Donate";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormDonate_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormDonate_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormDonate_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormDonate_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.imgHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btn_Close;
        private System.Windows.Forms.PictureBox imgHeader;
        private AetherxTextBox txt_BTC;
        private System.Windows.Forms.Label lbl_Dev_PIV_Thumbprint;
        private AetherxTextBox aetherxTextBox1;
        private System.Windows.Forms.Label label1;
        private AetherxTextBox aetherxTextBox2;
        private System.Windows.Forms.Label label2;
        private AetherxTextBox aetherxTextBox3;
        private System.Windows.Forms.Label lbl_Subtitle;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}