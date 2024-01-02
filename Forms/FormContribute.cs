using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lng = SIBActivator.Properties.Resources;
using Cfg = SIBActivator.Properties.Settings;
using System.Runtime.ConstrainedExecution;

namespace SIBActivator.Forms
{
    public partial class FormContribute : Form
    {

        /*
            Define
        */

        private Patch Patch         = new Patch( );
        private Helpers Helpers     = new Helpers( );

        private bool mouseDown;
        private Point lastLocation;

        public FormContribute( )
        {
            InitializeComponent( );

            btn_Close.Parent            = imgHeader;
            btn_Close.BackColor         = Color.Transparent;

            lbl_Title.Parent            = imgHeader;
            lbl_Title.BackColor         = Color.Transparent;

            lbl_Subtitle.Parent         = imgHeader;
            lbl_Subtitle.BackColor      = Color.Transparent;

            string ver                  = AppInfo.ProductVersionCore.ToString( );
            string product              = AppInfo.Title;
            string tm                   = AppInfo.Trademark;

            lbl_Subtitle.Text           = "v" + ver + " by " + tm;
            lbl_Subtitle.Text           = product;

            txt_contrib_intro.Value     = Lng.txt_contrib_intro;
            lbl_BTC.Text                = Lng.lbl_contrib_btc; 
            lbl_ETH.Text                = Lng.lbl_contrib_eth; 
            lbl_BCH.Text                = Lng.lbl_contrib_bch; 

        }

        private void FormDonate_Paint( object sender, PaintEventArgs e )
        {
            Pen clr_border = new Pen(Color.FromArgb(75, 75, 75));
            e.Graphics.DrawRectangle(clr_border, 0, 0, Width - 1, Height - 1);
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close( );
        }

        private void FormDonate_MouseDown( object sender, MouseEventArgs e )
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FormDonate_MouseUp( object sender, MouseEventArgs e )
        {
            mouseDown = false;
        }

        private void FormDonate_MouseMove( object sender, MouseEventArgs e )
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update( );
            }
        }

        private void imgHeader_Paint( object sender, PaintEventArgs e )
        {
            Graphics g          = e.Graphics;
            Color backColor     = Color.FromArgb( 65, 255, 255, 255 );
            var imgSize         = imgHeader.ClientSize;

            e.Graphics.FillRectangle( new SolidBrush( backColor ), 1, imgSize.Height - 2, imgSize.Width - 2, 2 );
        }

        private void imgHeader_MouseDown( object sender, MouseEventArgs e )
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void imgHeader_MouseUp( object sender, MouseEventArgs e )
        {
            mouseDown       = false;
        }

        private void imgHeader_MouseMove( object sender, MouseEventArgs e )
        {
            if ( mouseDown )
            {
                this.Location = new Point(
                    ( this.Location.X - lastLocation.X ) + e.X,
                    ( this.Location.Y - lastLocation.Y ) + e.Y
                );

                this.Update( );
            }
        }

        private void aetherxTextBox3__TextChanged( object sender, EventArgs e )
        {

        }
    }
}
