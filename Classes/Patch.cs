/*
    @app        : StartIsBack Activator
    @repo       : https://github.com/Aetherinox/startisback-activator
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

                StatusBar.Update( Lng.status_manual_locate );

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
                dlg.Title               = Lng.dlg_title;
                dlg.InitialDirectory    = ext_default;
                dlg.Filter              = "StartIsBack EXE|StartIsBackCfg.exe|All files (*.*)|*.*";

                if ( dlg.ShowDialog( ) == DialogResult.Cancel )
                {
                    StatusBar.Update( Lng.dlg_cancelled );

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

                    StatusBar.Update( string.Format( Lng.status_dlg_loaded , dlg.FileName ) );

                }

                StatusBar.Update( Lng.status_sib_not_found );

            }

            /*
                msimg32.dll filename
            */
            
            string msImg32_filename             = Cfg.Default.app_patch_file;


            /*
                Temp kill automatic shell restart when process is killed
                AutoRestartShell = 0
            */

            RegistryKey ourKey  = Registry.LocalMachine;
            ourKey              = ourKey.OpenSubKey(
                                    @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon",
                                    true
                                );
            ourKey.SetValue     ( "AutoRestartShell", 0 );

            /*
                 kill task explorer.exe
             */

            try
            {
                Process[] processes = Process.GetProcessesByName( "explorer" );
                foreach ( Process proc in processes )
                {
                    proc.Kill( );
                }
            }
            catch ( Exception )
            {
                StatusBar.Update( Lng.status_taskkill_proc );
                return;
            }

            /*
                 kill / restart task explorer.exe
             */

            try
            {
                Process.Start( "cmd", "/c taskkill /f /im explorer.exe" ).WaitForExit( );
            }
            catch ( Exception )
            {
                StatusBar.Update( Lng.status_taskkill_cmd );
                return;
            }

            /*
                 kill task StartIsBackCfg.exe
             */

            try
            {
                Process[] processes = Process.GetProcessesByName( "StartIsBackCfg" );
                foreach ( Process proc in processes )
                {
                    proc.Kill( );
                }
            }
            catch ( Exception )
            {
                StatusBar.Update( Lng.status_taskkill_startisback );
                return;
            }

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
                        Console.WriteLine( String.format( Lng.cwrite_dmp_exception, e.Message ) );
                    }
                    finally
                    {
                        Console.WriteLine( String.format( Lng.cwrite_dmp_finish ) );
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
                        string.Format( Lng.msgbox_dev_bak_msg, sib_path_exe, patch_bak_fullpath ),
                        Lng.msgbox_dev_bak_title,
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
                    MessageBox.Show( string.Format( Lng.msgbox_extract_err_msg, Cfg.Default.app_patch_file ),
                        Lng.msgbox_extract_err_title,
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
                            StatusBar.Update( Lng.status_integrity_success );
                        }
                        else
                        {
                            /* certificate: resource file signed but not by developer */

                            StatusBar.Update( Lng.status_integrity_fail );

                            MessageBox.Show( string.Format( Lng.msgbox_integrity_fail_msg, x509_cert ),
                                Lng.msgbox_integrity_fail_title,
                                MessageBoxButtons.OK, MessageBoxIcon.Error
                            );

                            return;
                        }
                    }
                    else
                    {
                        /* certificate: resource file not signed at all */

                        StatusBar.Update( Lng.status_integrity_fail );

                        MessageBox.Show( string.Format( Lng.msgbox_integrity_fail_nosign_msg, Cfg.Default.app_patch_file ),
                            Lng.msgbox_integrity_fail_nosign_title,
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );

                        return;
                    }

                    /* validate StartIsBackCfg.exe as Windows application */
                    bool bValidExe = Helpers.IsExeFile( StartIsBackCfg_fullpath );

                    if ( !File.Exists( StartIsBackCfg_fullpath ) || !bValidExe )
                    {

                        StatusBar.Update( Lng.status_app_invalid );

                        MessageBox.Show( string.Format( Lng.msgbox_app_invalid_msg, StartIsBackCfg_fullpath ),
                            Lng.msgbox_app_invalid_title,
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
                start task explorer.exe
            */

            Process.Start( "explorer" );

            /*
                re-enable AutoRestartShell in registry
                AutoRestartShell = 1
            */

            ourKey.SetValue( "AutoRestartShell", 1 );
            ourKey.Close( );

            /*
                re-enable AutoRestartShell in registry
                AutoRestartShell = 1
            */

            MessageBox.Show( string.Format( "{0}", Lng.msgbox_patch_compl_msg ),
                Lng.msgbox_patch_compl_title,
                MessageBoxButtons.OK, MessageBoxIcon.Information
            );

            StatusBar.Update( Lng.status_patch_complete );

            return;
        }

    }
}
