/*
    @app        : StartIsBack Activator
    @repo       : https://github.com/Aetherinox/startallback-activator
    @author     : Aetherinox
*/

using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Text;
using Lng = SIBActivator.Properties.Resources;
using Cfg = SIBActivator.Properties.Settings;
using System.Management.Automation.Language;

namespace SIBActivator
{

    /*
        OReceiver > Status Bar
    */

    public interface IReceiver
    {
        void Status( string message );
    }

    /*
        Receiver > Status Bar
    */

    public static class StatusBar
    {
        private static IReceiver recv = null;

        /*
            Receiver > Initialize
        */

        public static void InitializeReceiver( IReceiver f )
        {
            recv = f;
        }

        /*
            Receiver > Send Message
        */

        public static void Update( string message )
        {
            if ( recv != null ) recv.Status( message );
        }
    }

/*
    Class > Patch
*/

    class Patch
    {

        private Helpers Helpers                 = new Helpers( );

        private static string patcher_exe_dir   = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetEntryAssembly( ).Location );
        private static string sib_exe_filename  = Cfg.Default.app_target_exe;

        private static string sib_exe_appdata   = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string sib_exe_prog64    = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.ProgramFiles ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string sib_exe_prog86    = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.ProgramFilesX86 ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string sib_exe_home      = Path.Combine( patcher_exe_dir,
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private string query_result;

        /*
             Start Patch
        */

        public void Start( string path_selected = "auto" )
        {

            /*
                define arrays
            */

            string[] paths_arr      = new string[] { };
            string[] paths_lst      = new string[] { };

        /*
            populate path list array
        */

            Array.Resize( ref paths_lst, paths_lst.Length + 1 );
            paths_lst [ paths_lst.Length - 1 ] = sib_exe_appdata;

            Array.Resize( ref paths_lst, paths_lst.Length + 1 );
            paths_lst [ paths_lst.Length - 1 ] = sib_exe_prog64;

            Array.Resize( ref paths_lst, paths_lst.Length + 1 );
            paths_lst [ paths_lst.Length - 1 ] = sib_exe_prog86;

            Array.Resize( ref paths_lst, paths_lst.Length + 1 );
            paths_lst [ paths_lst.Length - 1 ] = sib_exe_home;

            /*
                define
            */

            if ( File.Exists( sib_exe_appdata ) )
            {
                Array.Resize( ref paths_arr, paths_arr.Length + 1 );
                paths_arr [ paths_arr.Length - 1 ] = sib_exe_appdata;
            }

            if ( File.Exists( sib_exe_prog64 ) )
            {
                Array.Resize( ref paths_arr, paths_arr.Length + 1 );
                paths_arr [ paths_arr.Length - 1 ] = sib_exe_prog64;
            }

            if ( File.Exists( sib_exe_prog86 ) )
            {
                Array.Resize( ref paths_arr, paths_arr.Length + 1 );
                paths_arr [ paths_arr.Length - 1 ] = sib_exe_prog86;
            }

            if ( File.Exists( sib_exe_home ) )
            {
                Array.Resize( ref paths_arr, paths_arr.Length + 1 );
                paths_arr [ paths_arr.Length - 1 ] = sib_exe_home;
            }

            /*
                custom file loaded
            */

            if ( path_selected != "auto" )
            {

                if ( File.Exists( path_selected ) )
                {

                    paths_arr = new string [ ] { };
                    paths_lst = new string [ ] { };

                    Array.Resize( ref paths_arr, paths_arr.Length + 1 );
                    paths_arr [ paths_arr.Length - 1 ] = path_selected;

                    Array.Resize( ref paths_lst, paths_lst.Length + 1 );
                    paths_lst [ paths_lst.Length - 1 ] = path_selected;

                    #if DEBUG
                        MessageBox.Show(
                            "Message,
                            "Debug: Title",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.None
                        );
                    #endif

                }
            }

            /*
                count results
            */

            int i_arr = paths_arr.Length;

            /*
                if list of paths empty, concat array into string and return error message listing what
                paths were checked.
            */

            if ( i_arr == 0 )
            {

                string path_compiled    = "";
                StringBuilder sb        = new StringBuilder( );

                sb.Append( Environment.NewLine );

                foreach ( string file in paths_lst )
                {
                    sb.Append( Environment.NewLine );
                    sb.Append( file );

                    path_compiled = sb.ToString( );
                }

                StatusBar.Update( "StartIsBack not found, loading manual dialog ..." );

                MessageBox.Show( string.Format( Lng.msgbox_nolocpath_msg, path_compiled ),
                    Lng.msgbox_nolocpath_title,
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );

                /*
                    Attempt to allow user to manually select file to be patched.
                */

                string src_file_path    = Helpers.FindApp( );
                string ext_default      = @"c:\";

                if ( !String.IsNullOrEmpty( src_file_path ) )
                {
                    ext_default = src_file_path;
                }

                OpenFileDialog dlg      = new OpenFileDialog( );
                dlg.Title               = "Locate StartIsBack EXE";
                dlg.InitialDirectory    = ext_default;
                dlg.Filter              = "StartIsBack EXE|StartIsBackCfg.exe|All files (*.*)|*.*";

                if ( dlg.ShowDialog( ) == DialogResult.Cancel )
                {
                    StatusBar.Update( "Cancelled by user" );

                    return;
                }

                if ( dlg.ShowDialog( ) == DialogResult.OK )
                {
                    StreamReader sr     = File.OpenText(dlg.FileName);

                    string s            = sr.ReadLine();
                    StringBuilder sbr   = new StringBuilder();

                    while ( s != null )
                    {
                        sbr.Append( s );
                        s = sr.ReadLine( );
                    }
                    sr.Close( );

                    StatusBar.Update( "Loading " + dlg.FileName );

                }

                StatusBar.Update( Lng.statusbar_sib_not_found );

            }

            /*
                loop each dll path
            */

            foreach ( string path_exe in paths_arr )
            {
                string path_backup      = path_exe + ".bak";
                string query_var        = "$user_current = $env:username";
                string query_takeown    = "takeown /f \'" + path_backup + "'";
                string query_icalcs     = "icacls \'\" + path_backup +\"' /grant \"${user_current}:F\" /C /L";

                #if DEBUG
                    try
                    {
                        StreamWriter sw_o       = new StreamWriter( "sibactivator.dmp", true );
                                                sw_o.WriteLine( query_var );
                                                sw_o.WriteLine( query_takeown );
                                                sw_o.WriteLine( query_icalcs );
                                                sw_o.Close( );
                    }
                    catch ( Exception e )
                    {
                        Console.WriteLine( "Dev Dump: Exception: " + e.Message );
                    }
                    finally
                    {
                        Console.WriteLine( "Dev Dump: Finished" );
                    }
                #endif

                /*
                    backup file exists
                */

                if ( File.Exists( path_backup ) )
                {

                    /*
                        run powershell commands to adjust permissions
                    */

                    using ( PowerShell ps = PowerShell.Create( ) )
                    {

                        ps.AddScript( query_var );
                        ps.AddScript( query_takeown );
                        ps.AddScript( query_icalcs );

                        Collection<PSObject> PSOutput   = ps.Invoke( );
                        StringBuilder sb                = new StringBuilder( );

                        foreach ( PSObject PSItem in PSOutput )
                        {
                            if ( PSItem != null )
                            {
                                Console.WriteLine( $"Output line: [{PSItem}]" );
                                sb.AppendLine( PSItem.ToString( ) );
                            }
                        }

                        if ( ps.Streams.Error.Count > 0 )
                        {
                            // Error collection
                        }
                    }

                    #if DEBUG
                        MessageBox.Show( string.format( ".bak backup file already exists, deleting it and creating new\n\n{0}", path_backup ),
                            "Debug: Found existing",
                            MessageBoxButtons.OK, MessageBoxIcon.None
                        );
                    #endif
                    
                    File.Delete         ( path_exe );
                    File.Move           ( path_backup, path_exe );
                }

                /*
                    Patch
                */

                File.SetAttributes      ( path_exe,     FileAttributes.Normal );
                File.Copy               ( path_exe,     path_backup );
                File.SetAttributes      ( path_backup,  FileAttributes.Normal );

                #if DEBUG
                    MessageBox.Show(
                        "The following file will be backed up: \n\n" + path_exe + "\n" + path_backup,
                        "Debug: Create Backup of DLL",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.None
                    );
                #endif

                /*
                    extract resource file to same folder as patcher exe ran from
                */

                File.WriteAllBytes( Cfg.Default.app_patch_file, SIBActivator.Properties.Resources.msimg32 );

                /*
                    resource extraction failed for whatever reason
                */

                if ( !File.Exists( Cfg.Default.app_patch_file ) )
                {
                    MessageBox.Show( string.Format( "Could not extract patched DLL \n{0}", Cfg.Default.app_patch_file ),
                        "Fatal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error
                    );

                    return;
                }

                /*
                string a1   = Cfg.Default.app_patch_file;
                string a2   = patcher_exe_dir + @"\" + Cfg.Default.app_patch_file;


                if ( File.Exists( a1 ) )
                    File.Move( a1, a2 );

                */


                /*
                    get StartIsBack exe path from stripped dll full path
                        C:\Program Files\StartIsBack\StartIsBackCfg.exe ->
                        C:\Program Files\StartIsBack\
                */

                string path_sib_dir         = Path.GetDirectoryName( path_exe );


                if ( !String.IsNullOrEmpty( path_sib_dir ) )
                {
                    string path_sib_exe     = path_sib_dir + "\\" + Cfg.Default.app_target_exe;
                    string x509_cert        = Helpers.x509_Thumbprint( Cfg.Default.app_patch_file );

                    /*
                        x509 certificate

                        Add integrity validation. Ensure the resource DLL has been signed by the developer,
                        otherwise cancel the patching step.
                    */

                    if ( x509_cert != "false" )
                    {

                        /* certificate: resource file  signed */

                        if ( x509_cert.ToLower( ) == Cfg.Default.app_dev_piv_thumbprint.ToLower( ) )
                        {
                            /* certificate: resource file signed and authentic */

                            StatusBar.Update( "Integrity check success" );

                            MessageBox.Show( string.Format( "Successfully validated that this patch is authentic, continuing...\n\nCertificate Thumbprint: \n{0}", x509_cert ),
                                "Integrity Check: SUCCESS",
                                MessageBoxButtons.OK, MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            /* certificate: resource file signed but not by developer */

                            StatusBar.Update( "Integrity check failed" );

                            MessageBox.Show( string.Format( "The fails associated to this patch have a signature, however, it is not by the developer who wrote the patch, aborting...\n\nCertificate Thumbprint: \n{0}", x509_cert ),
                                "Integrity Check: FAILED",
                                MessageBoxButtons.OK, MessageBoxIcon.Error
                            );

                            return;
                        }
                    }
                    else
                    {
                        /* certificate: resource file not signed at all */

                        StatusBar.Update( "Integrity check failed" );

                        MessageBox.Show( string.Format( "The patched DLL required to complete this task appears to not be signed. The operation is aborting.\n{0}\n\nEnsure you downloaded this patch from the developer.", Cfg.Default.app_patch_file ),
                            "Integrity Check: FAILED",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );

                        return;
                    }

                    /* start application */

                    if ( File.Exists( path_sib_exe ) )
                        System.Diagnostics.Process.Start( path_sib_exe );
                }
            }

            /*
                re-enable AutoRestartShell in registry
                AutoRestartShell = 1
            */

            MessageBox.Show( string.Format( "{0}", Lng.msgbox_patch_compl_msg ),
                Lng.msgbox_patch_compl_title,
                MessageBoxButtons.OK, MessageBoxIcon.Information
            );

            StatusBar.Update( Lng.statusbar_patch_complete );

            return;
        }

    }
}
