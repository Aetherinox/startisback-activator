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
            this.txt_ETH = new SIBActivator.AetherxTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_BCH = new SIBActivator.AetherxTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.aetherxTextBox3 = new SIBActivator.AetherxTextBox();
            this.lbl_Subtitle = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pic_BTC = new System.Windows.Forms.PictureBox();
            this.pic_ETH = new System.Windows.Forms.PictureBox();
            this.pic_BCH = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ETH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BCH)).BeginInit();
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
            // txt_ETH
            // 
            this.txt_ETH.AllowFocus = true;
            this.txt_ETH.AutoScroll = true;
            this.txt_ETH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt_ETH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_ETH.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_ETH.BorderSize = 1;
            this.txt_ETH.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_ETH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_ETH.Location = new System.Drawing.Point(15, 376);
            this.txt_ETH.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ETH.Multiline = false;
            this.txt_ETH.MultilineScrollbars = true;
            this.txt_ETH.Name = "txt_ETH";
            this.txt_ETH.Padding = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.txt_ETH.PasswordChar = false;
            this.txt_ETH.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_ETH.PlaceholderText = "";
            this.txt_ETH.ReadOnly = true;
            this.txt_ETH.Selectable = true;
            this.txt_ETH.Size = new System.Drawing.Size(503, 33);
            this.txt_ETH.TabIndex = 14;
            this.txt_ETH.UnderlineStyle = true;
            this.txt_ETH.Value = "0xC6A9cA5B17265f41636a45dF165a5821f9d26445";
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
            // txt_BCH
            // 
            this.txt_BCH.AllowFocus = true;
            this.txt_BCH.AutoScroll = true;
            this.txt_BCH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt_BCH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_BCH.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_BCH.BorderSize = 1;
            this.txt_BCH.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_BCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_BCH.Location = new System.Drawing.Point(15, 434);
            this.txt_BCH.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BCH.Multiline = false;
            this.txt_BCH.MultilineScrollbars = true;
            this.txt_BCH.Name = "txt_BCH";
            this.txt_BCH.Padding = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.txt_BCH.PasswordChar = false;
            this.txt_BCH.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_BCH.PlaceholderText = "";
            this.txt_BCH.ReadOnly = true;
            this.txt_BCH.Selectable = true;
            this.txt_BCH.Size = new System.Drawing.Size(503, 33);
            this.txt_BCH.TabIndex = 16;
            this.txt_BCH.UnderlineStyle = true;
            this.txt_BCH.Value = "bitcoincash:qrf53klxwhh6t74cfdkv3u3knvhdtpwaku4qgdapja";
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
            // pic_BTC
            // 
            this.pic_BTC.BackColor = System.Drawing.Color.Transparent;
            this.pic_BTC.Image = global::SIBActivator.Properties.Resources.btc;
            this.pic_BTC.Location = new System.Drawing.Point(21, 320);
            this.pic_BTC.Name = "pic_BTC";
            this.pic_BTC.Size = new System.Drawing.Size(25, 25);
            this.pic_BTC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_BTC.TabIndex = 36;
            this.pic_BTC.TabStop = false;
            // 
            // pic_ETH
            // 
            this.pic_ETH.BackColor = System.Drawing.Color.Transparent;
            this.pic_ETH.Image = global::SIBActivator.Properties.Resources.eth;
            this.pic_ETH.Location = new System.Drawing.Point(21, 380);
            this.pic_ETH.Name = "pic_ETH";
            this.pic_ETH.Size = new System.Drawing.Size(25, 25);
            this.pic_ETH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_ETH.TabIndex = 37;
            this.pic_ETH.TabStop = false;
            // 
            // pic_BCH
            // 
            this.pic_BCH.BackColor = System.Drawing.Color.Transparent;
            this.pic_BCH.Image = global::SIBActivator.Properties.Resources.bch;
            this.pic_BCH.Location = new System.Drawing.Point(21, 438);
            this.pic_BCH.Name = "pic_BCH";
            this.pic_BCH.Size = new System.Drawing.Size(25, 25);
            this.pic_BCH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_BCH.TabIndex = 38;
            this.pic_BCH.TabStop = false;
            // 
            // FormContribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(530, 481);
            this.ControlBox = false;
            this.Controls.Add(this.pic_BCH);
            this.Controls.Add(this.pic_ETH);
            this.Controls.Add(this.pic_BTC);
            this.Controls.Add(this.lbl_Subtitle);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.aetherxTextBox3);
            this.Controls.Add(this.txt_BCH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ETH);
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
            ((System.ComponentModel.ISupportInitialize)(this.pic_BTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ETH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BCH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btn_Close;
        private System.Windows.Forms.PictureBox imgHeader;
        private AetherxTextBox txt_BTC;
        private System.Windows.Forms.Label lbl_Dev_PIV_Thumbprint;
        private AetherxTextBox txt_ETH;
        private System.Windows.Forms.Label label1;
        private AetherxTextBox txt_BCH;
        private System.Windows.Forms.Label label2;
        private AetherxTextBox aetherxTextBox3;
        private System.Windows.Forms.Label lbl_Subtitle;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox pic_BTC;
        private System.Windows.Forms.PictureBox pic_ETH;
        private System.Windows.Forms.PictureBox pic_BCH;
    }
}