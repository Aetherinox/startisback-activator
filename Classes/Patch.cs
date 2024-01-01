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
using System.Security.AccessControl;
using System.Security.Principal;

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
        private Perms Perms                     = new Perms( );

        private static string patch_launch_dir  = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetEntryAssembly( ).Location );
        private static string sib_exe_filename  = Cfg.Default.app_target_exe;

        /*
             StartIsBack Search Locations
        */

        private static string findSib_Appdata   = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string findSib_Prog64    = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.ProgramFiles ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string findSib_Prog86    = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.ProgramFilesX86 ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string findSib_PatchHome = Path.Combine( patch_launch_dir,
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

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
            paths_lst [ paths_lst.Length - 1 ] = findSib_Appdata;

            Array.Resize( ref paths_lst, paths_lst.Length + 1 );
            paths_lst [ paths_lst.Length - 1 ] = findSib_Prog64;

            Array.Resize( ref paths_lst, paths_lst.Length + 1 );
            paths_lst [ paths_lst.Length - 1 ] = findSib_Prog86;

            Array.Resize( ref paths_lst, paths_lst.Length + 1 );
            paths_lst [ paths_lst.Length - 1 ] = findSib_PatchHome;

            /*
                define
            */

            if ( File.Exists( findSib_Appdata ) )
            {
                Array.Resize( ref paths_arr, paths_arr.Length + 1 );
                paths_arr [ paths_arr.Length - 1 ] = findSib_Appdata;
            }

            if ( File.Exists( findSib_Prog64 ) )
            {
                Array.Resize( ref paths_arr, paths_arr.Length + 1 );
                paths_arr [ paths_arr.Length - 1 ] = findSib_Prog64;
            }

            if ( File.Exists( findSib_Prog86 ) )
            {
                Array.Resize( ref paths_arr, paths_arr.Length + 1 );
                paths_arr [ paths_arr.Length - 1 ] = findSib_Prog86;
            }

            if ( File.Exists( findSib_PatchHome ) )
            {
                Array.Resize( ref paths_arr, paths_arr.Length + 1 );
                paths_arr [ paths_arr.Length - 1 ] = findSib_PatchHome;
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
                    ext_default = src_file_path;

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
                msimg32.dll filename
            */
            
            string msImg32_filename             = Cfg.Default.app_patch_file;

            /*
                loop each dll path
            */

            foreach ( string sib_path_exe in paths_arr )
            {
                string StartIsBackCfg_folder    = Path.GetDirectoryName( sib_path_exe );
                string patch_bak_fullpath       = sib_path_exe + ".bak";
                string ps_query_var             = "$user_current = $env:username";
                string ps_query_takeown         = "takeown /f \'" + patch_bak_fullpath + "'";
                string ps_query_icalcs          = "icacls \'\" + patch_bak_fullpath +\"' /grant \"${user_current}:F\" /C /L";

                #if DEBUG
                    try
                    {
                        StreamWriter sw_o       = new StreamWriter( "sibactivator.dmp", true );
                                                sw_o.WriteLine( ps_query_var );
                                                sw_o.WriteLine( ps_query_takeown );
                                                sw_o.WriteLine( ps_query_icalcs );
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
                    if full backup path exists
                        x:\path\to\StartIsBackCfg.exe.bak
                */

                if ( File.Exists( patch_bak_fullpath ) )
                {

                    /*
                        run powershell commands to adjust permissions
                    */

                    using ( PowerShell ps = PowerShell.Create( ) )
                    {

                        ps.AddScript( ps_query_var );
                        ps.AddScript( ps_query_takeown );
                        ps.AddScript( ps_query_icalcs );

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
                        MessageBox.Show( string.format( ".bak backup file already exists, deleting it and creating new\n\n{0}", patch_bak_fullpath ),
                            "Debug: Found existing",
                            MessageBoxButtons.OK, MessageBoxIcon.None
                        );
                    #endif
                    
                    /*
                        DELETE existing x:\path\to\StartIsBackCfg.exe.bak
                    */

                    File.Delete         ( sib_path_exe );

                    /*
                        CREATE new x:\path\to\StartIsBackCfg.exe.bak
                    */

                    File.Move           ( patch_bak_fullpath, sib_path_exe );
                }

                /*
                    SET     attributes on StartIsBackCfg.exe
                    COPY    StartIsBackCfg.exe -> StartIsBackCfg.exe.bak
                    SET     attributes on StartIsBackCfg.exe.bak
                */

                File.SetAttributes      ( sib_path_exe,         FileAttributes.Normal );
                File.Copy               ( sib_path_exe,         patch_bak_fullpath );
                File.SetAttributes      ( patch_bak_fullpath,   FileAttributes.Normal );

                #if DEBUG
                    MessageBox.Show(
                        "The following file will be backed up: \n\n" + sib_path_exe + "\n" + patch_bak_fullpath,
                        "Debug: Create Backup of DLL",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.None
                    );
                #endif

                /*
                    extract msimg32.dll patched file to folder where patcher exe ran from
                */

                File.WriteAllBytes( Cfg.Default.app_patch_file, SIBActivator.Properties.Resources.msimg32 );

                /*
                    msimg32.dll extraction failed for whatever reason
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
                    get StartIsBack exe path from stripped dll full path
                        C:\Program Files\StartIsBack\StartIsBackCfg.exe ->
                        C:\Program Files\StartIsBack\
                */

                string msImg32_fullpath_to          = StartIsBackCfg_folder + @"\" + msImg32_filename;

                /*
                    make sure StartIsBack installation dir exists
                */

                if ( !String.IsNullOrEmpty( StartIsBackCfg_folder ) )
                {

                    string StartIsBackCfg_fullpath  = StartIsBackCfg_folder + "\\" + Cfg.Default.app_target_exe;
                    string x509_cert                = Helpers.x509_Thumbprint( Cfg.Default.app_patch_file );

                    /*
                        x509 certificate

                        Add integrity validation. Ensure the resource DLL has been signed by the developer,
                        otherwise cancel the patching step.

                        0       : Not signed
                        1       : Signed but not from the developer
                        other   : Valid certificate thumbprint
                    */

                    if ( x509_cert != "0" )
                    {

                        /* certificate: resource file  signed */
                        if ( x509_cert.ToLower( ) == Cfg.Default.app_dev_piv_thumbprint.ToLower( ) )
                        {
                            /* certificate: resource file signed and authentic */
                            StatusBar.Update( "Integrity check success" );
                        }
                        else
                        {
                            /* certificate: resource file signed but not by developer */

                            StatusBar.Update( "Integrity check failed" );

                            MessageBox.Show( string.Format( "The fails associated to this patch have a signature, however, it is not by the developer who wrote the patch, aborting...\n\nCertificate Thumbprint: \n{0}", x509_cert ),
                                "Integrity Check Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error
                            );

                            return;
                        }
                    }
                    else
                    {
                        /* certificate: resource file not signed at all */

                        StatusBar.Update( "Integrity check failed" );

                        MessageBox.Show( string.Format( "The files for this activator are not signed and may be fake from another source. Files from this activator's developer will ALWAYS be signed.\n\nEnsure you downloaded this patch from the developer.\n\nFailed File(s):\n     {0}", Cfg.Default.app_patch_file ),
                            "Integrity Check Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );

                        return;
                    }

                    /* validate StartIsBackCfg.exe as Windows application */
                    bool bValidExe = Helpers.IsExeFile( StartIsBackCfg_fullpath );

                    if ( !File.Exists( StartIsBackCfg_fullpath ) || !bValidExe )
                    {

                        StatusBar.Update( StartIsBackCfg_fullpath + " not valid" );

                        MessageBox.Show( string.Format( "The file {0} is not a valid Windows application or may be corrupted.\n\nReinstall StartIsBack", StartIsBackCfg_fullpath ),
                            "Invalid Application",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );

                        return;
                    }

                    /*
                        patched dll already exists, delete
                    */

                    if ( File.Exists( msImg32_fullpath_to ) )
                        File.Delete( msImg32_fullpath_to );

                    /*
                        copy new patched dll to StartIsBack install folder
                    */

                    if ( File.Exists( msImg32_filename ) )
                        File.Move( msImg32_filename, msImg32_fullpath_to );

                    /* start application */
                    System.Diagnostics.Process.Start( StartIsBackCfg_fullpath );
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
