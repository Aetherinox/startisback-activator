using System.Drawing;
using System.Windows.Forms;

namespace SIBActivator
{
    partial class FormAbout
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
                components.Dispose( );
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen clr_border = new Pen(Color.FromArgb(75, 75, 75));
            e.Graphics.DrawRectangle(clr_border, 0, 0, Width - 1, Height - 1);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.btn_Close = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.lbl_Product = new System.Windows.Forms.Label();
            this.lbl_Edu = new System.Windows.Forms.Label();
            this.lnk_TPBLink = new System.Windows.Forms.LinkLabel();
            this.lnk_Github = new System.Windows.Forms.LinkLabel();
            this.lbl_Dev_PIV_Thumbprint = new System.Windows.Forms.Label();
            this.lbl_Dev_GPG_KeyID = new System.Windows.Forms.Label();
            this.imgHeader = new System.Windows.Forms.PictureBox();
            this.txt_Dev_GPG_KeyID = new SIBActivator.AetherxTextBox();
            this.txt_Dev_PIV_Thumbprint = new SIBActivator.AetherxTextBox();
            this.txt_Terms = new SIBActivator.AetherxTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btn_Close.Location = new System.Drawing.Point(492, 7);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(24, 32);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.Click += new System.EventHandler(this.btn_Window_Close_Click);
            this.btn_Close.MouseEnter += new System.EventHandler(this.btn_Window_Close_MouseEnter);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Window_Close_MouseLeave);
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_Version.ForeColor = System.Drawing.Color.White;
            this.lbl_Version.Location = new System.Drawing.Point(413, 103);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(38, 15);
            this.lbl_Version.TabIndex = 4;
            this.lbl_Version.Text = "label1";
            this.lbl_Version.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lbl_Version.Click += new System.EventHandler(this.lbl_Serial_Click);
            // 
            // lbl_Product
            // 
            this.lbl_Product.AutoSize = true;
            this.lbl_Product.Font = new System.Drawing.Font("Myriad Pro Light", 20F);
            this.lbl_Product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(41)))), ((int)(((byte)(101)))));
            this.lbl_Product.Location = new System.Drawing.Point(21, 23);
            this.lbl_Product.Name = "lbl_Product";
            this.lbl_Product.Size = new System.Drawing.Size(79, 32);
            this.lbl_Product.TabIndex = 5;
            this.lbl_Product.Text = "label1";
            this.lbl_Product.Click += new System.EventHandler(this.lbl_Product_Click);
            this.lbl_Product.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_Product_MouseDown);
            this.lbl_Product.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_Product_MouseMove);
            this.lbl_Product.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_Product_MouseUp);
            // 
            // lbl_Edu
            // 
            this.lbl_Edu.AutoSize = true;
            this.lbl_Edu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Edu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_Edu.Location = new System.Drawing.Point(23, 56);
            this.lbl_Edu.Name = "lbl_Edu";
            this.lbl_Edu.Size = new System.Drawing.Size(355, 19);
            this.lbl_Edu.TabIndex = 8;
            this.lbl_Edu.Text = "Educational purposes only. No ads, no music, no bullshit.";
            this.lbl_Edu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_Edu_MouseDown);
            this.lbl_Edu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_Edu_MouseMove);
            this.lbl_Edu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_Edu_MouseUp);
            // 
            // lnk_TPBLink
            // 
            this.lnk_TPBLink.AutoSize = true;
            this.lnk_TPBLink.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnk_TPBLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk_TPBLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lnk_TPBLink.Location = new System.Drawing.Point(25, 100);
            this.lnk_TPBLink.Name = "lnk_TPBLink";
            this.lnk_TPBLink.Size = new System.Drawing.Size(60, 19);
            this.lnk_TPBLink.TabIndex = 1;
            this.lnk_TPBLink.TabStop = true;
            this.lnk_TPBLink.Text = "Releases";
            this.lnk_TPBLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLink_TPB_LinkClicked_1);
            // 
            // lnk_Github
            // 
            this.lnk_Github.AutoSize = true;
            this.lnk_Github.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnk_Github.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk_Github.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lnk_Github.Location = new System.Drawing.Point(105, 100);
            this.lnk_Github.Name = "lnk_Github";
            this.lnk_Github.Size = new System.Drawing.Size(86, 19);
            this.lnk_Github.TabIndex = 2;
            this.lnk_Github.TabStop = true;
            this.lnk_Github.Text = "Github Repo";
            this.lnk_Github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Github_LinkClicked);
            // 
            // lbl_Dev_PIV_Thumbprint
            // 
            this.lbl_Dev_PIV_Thumbprint.AutoSize = true;
            this.lbl_Dev_PIV_Thumbprint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Dev_PIV_Thumbprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_Dev_PIV_Thumbprint.Location = new System.Drawing.Point(11, 365);
            this.lbl_Dev_PIV_Thumbprint.Name = "lbl_Dev_PIV_Thumbprint";
            this.lbl_Dev_PIV_Thumbprint.Size = new System.Drawing.Size(45, 19);
            this.lbl_Dev_PIV_Thumbprint.TabIndex = 9;
            this.lbl_Dev_PIV_Thumbprint.Text = "label1";
            // 
            // lbl_Dev_GPG_KeyID
            // 
            this.lbl_Dev_GPG_KeyID.AutoSize = true;
            this.lbl_Dev_GPG_KeyID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Dev_GPG_KeyID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_Dev_GPG_KeyID.Location = new System.Drawing.Point(11, 430);
            this.lbl_Dev_GPG_KeyID.Name = "lbl_Dev_GPG_KeyID";
            this.lbl_Dev_GPG_KeyID.Size = new System.Drawing.Size(45, 19);
            this.lbl_Dev_GPG_KeyID.TabIndex = 11;
            this.lbl_Dev_GPG_KeyID.Text = "label2";
            // 
            // imgHeader
            // 
            this.imgHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgHeader.BackgroundImage")));
            this.imgHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgHeader.Location = new System.Drawing.Point(1, 1);
            this.imgHeader.Name = "imgHeader";
            this.imgHeader.Size = new System.Drawing.Size(528, 129);
            this.imgHeader.TabIndex = 13;
            this.imgHeader.TabStop = false;
            this.imgHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.imgHeader_Paint);
            this.imgHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseDown);
            this.imgHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseMove);
            this.imgHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseUp);
            // 
            // txt_Dev_GPG_KeyID
            // 
            this.txt_Dev_GPG_KeyID.AllowFocus = true;
            this.txt_Dev_GPG_KeyID.AutoScroll = true;
            this.txt_Dev_GPG_KeyID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.txt_Dev_GPG_KeyID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_Dev_GPG_KeyID.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_Dev_GPG_KeyID.BorderSize = 1;
            this.txt_Dev_GPG_KeyID.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_Dev_GPG_KeyID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_Dev_GPG_KeyID.Location = new System.Drawing.Point(15, 451);
            this.txt_Dev_GPG_KeyID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Dev_GPG_KeyID.Multiline = false;
            this.txt_Dev_GPG_KeyID.MultilineScrollbars = true;
            this.txt_Dev_GPG_KeyID.Name = "txt_Dev_GPG_KeyID";
            this.txt_Dev_GPG_KeyID.Padding = new System.Windows.Forms.Padding(6);
            this.txt_Dev_GPG_KeyID.PasswordChar = false;
            this.txt_Dev_GPG_KeyID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_Dev_GPG_KeyID.PlaceholderText = "";
            this.txt_Dev_GPG_KeyID.ReadOnly = true;
            this.txt_Dev_GPG_KeyID.Selectable = true;
            this.txt_Dev_GPG_KeyID.Size = new System.Drawing.Size(504, 33);
            this.txt_Dev_GPG_KeyID.TabIndex = 12;
            this.txt_Dev_GPG_KeyID.UnderlineStyle = true;
            this.txt_Dev_GPG_KeyID.Value = "";
            // 
            // txt_Dev_PIV_Thumbprint
            // 
            this.txt_Dev_PIV_Thumbprint.AllowFocus = true;
            this.txt_Dev_PIV_Thumbprint.AutoScroll = true;
            this.txt_Dev_PIV_Thumbprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.txt_Dev_PIV_Thumbprint.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_Dev_PIV_Thumbprint.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_Dev_PIV_Thumbprint.BorderSize = 1;
            this.txt_Dev_PIV_Thumbprint.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_Dev_PIV_Thumbprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_Dev_PIV_Thumbprint.Location = new System.Drawing.Point(15, 386);
            this.txt_Dev_PIV_Thumbprint.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Dev_PIV_Thumbprint.Multiline = false;
            this.txt_Dev_PIV_Thumbprint.MultilineScrollbars = true;
            this.txt_Dev_PIV_Thumbprint.Name = "txt_Dev_PIV_Thumbprint";
            this.txt_Dev_PIV_Thumbprint.Padding = new System.Windows.Forms.Padding(6);
            this.txt_Dev_PIV_Thumbprint.PasswordChar = false;
            this.txt_Dev_PIV_Thumbprint.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_Dev_PIV_Thumbprint.PlaceholderText = "";
            this.txt_Dev_PIV_Thumbprint.ReadOnly = true;
            this.txt_Dev_PIV_Thumbprint.Selectable = true;
            this.txt_Dev_PIV_Thumbprint.Size = new System.Drawing.Size(504, 33);
            this.txt_Dev_PIV_Thumbprint.TabIndex = 10;
            this.txt_Dev_PIV_Thumbprint.UnderlineStyle = true;
            this.txt_Dev_PIV_Thumbprint.Value = "";
            // 
            // txt_Terms
            // 
            this.txt_Terms.AllowFocus = false;
            this.txt_Terms.AutoScroll = true;
            this.txt_Terms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.txt_Terms.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.txt_Terms.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.txt_Terms.BorderSize = 2;
            this.txt_Terms.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Terms.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt_Terms.Location = new System.Drawing.Point(15, 143);
            this.txt_Terms.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Terms.Multiline = true;
            this.txt_Terms.MultilineScrollbars = true;
            this.txt_Terms.Name = "txt_Terms";
            this.txt_Terms.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Terms.PasswordChar = false;
            this.txt_Terms.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_Terms.PlaceholderText = "";
            this.txt_Terms.ReadOnly = true;
            this.txt_Terms.Selectable = false;
            this.txt_Terms.Size = new System.Drawing.Size(504, 191);
            this.txt_Terms.TabIndex = 3;
            this.txt_Terms.UnderlineStyle = false;
            this.txt_Terms.Value = "";
            this.txt_Terms._TextChanged += new System.EventHandler(this.txt_Terms__TextChanged);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(530, 499);
            this.ControlBox = false;
            this.Controls.Add(this.txt_Dev_GPG_KeyID);
            this.Controls.Add(this.lbl_Dev_GPG_KeyID);
            this.Controls.Add(this.txt_Dev_PIV_Thumbprint);
            this.Controls.Add(this.lbl_Dev_PIV_Thumbprint);
            this.Controls.Add(this.txt_Terms);
            this.Controls.Add(this.lnk_Github);
            this.Controls.Add(this.lnk_TPBLink);
            this.Controls.Add(this.lbl_Edu);
            this.Controls.Add(this.lbl_Product);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.imgHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartIsBack : About";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormAbout_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormAbout_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormAbout_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.imgHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btn_Close;
        private Label lbl_Version;
        private Label lbl_Product;
        private Label lbl_Edu;
        private LinkLabel lnk_TPBLink;
        private LinkLabel lnk_Github;
        private AetherxTextBox txt_Terms;
        private Label lbl_Dev_PIV_Thumbprint;
        private AetherxTextBox txt_Dev_PIV_Thumbprint;
        private Label lbl_Dev_GPG_KeyID;
        private AetherxTextBox txt_Dev_GPG_KeyID;
        private PictureBox imgHeader;
    }
}