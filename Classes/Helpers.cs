﻿/*
    @app        : StartIsBack Activator
    @repo       : https://github.com/Aetherinox/startallback-activator
    @author     : Aetherinox
*/

using System;
using System.Text;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Management.Automation.Language;
using System.Data;
using Lng = SIBActivator.Properties.Resources;
using Cfg = SIBActivator.Properties.Settings;

[AttributeUsage( AttributeTargets.Assembly )]
internal class BuildDateAttribute : Attribute
{
    public BuildDateAttribute( string value )
    {
        DateTime = DateTime.ParseExact(
            value,
            "yyyyMMddHHmmss",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None );
    }

    public DateTime DateTime { get; }
}

namespace SIBActivator
{

    class Helpers
    {

        private static string patch_launch_dir  = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetEntryAssembly( ).Location );
        private static string sib_exe_filename  = Cfg.Default.app_target_exe;

        /*
             StartIsBack Search Locations
        */

        private static string findSib_Appdata   = Path.Combine(
                                                    Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string findSib_Prog64    = Path.Combine(
                                                    Environment.GetFolderPath( Environment.SpecialFolder.ProgramFiles ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string findSib_Prog86    = Path.Combine(
                                                    Environment.GetFolderPath( Environment.SpecialFolder.ProgramFilesX86 ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string findSib_PatchHome = Path.Combine(
                                                    patch_launch_dir,
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        /*
            Find App

            find target application

            A file will be checked in the following order:
                -   Windows Environment Variable PATH
                -   C:\Program Files
                -   C:\Program Files (x86)
                -   C:\Users\$USER\AppData\Local
                -   Patcher exe directory (Where the patcher was executed from)
                -   Powershell where command

            @return     str | directory name
        */

        public string FindApp( )
        {

            /*
                Check for path inside Windows Environment Variables
            */

            String path         = Environment.GetEnvironmentVariable( "path" );
            String[] folders    = path.Split( ';' );

            foreach ( String folder in folders )
            {
                if ( File.Exists( folder + sib_exe_filename ) )
                    return folder;
                else if ( File.Exists( folder + "\\" + sib_exe_filename ) )
                    return folder + "\\";
            }

            /*
                Program files 64
                    C:\Program Files
            */

            if ( File.Exists( findSib_Prog64 ) )
            {
                return Path.GetDirectoryName( findSib_Prog64 );
            }

            /*
                Program files 86
                    C:\Program Files (x86)
            */

            if ( File.Exists( findSib_Prog86 ) )
            {
                return Path.GetDirectoryName( findSib_Prog86 );
            }

            /*
                AppData
                    C:\Users\$USER\AppData\Local
            */

            if ( File.Exists( findSib_Appdata ) )
            {
                return Path.GetDirectoryName( findSib_Appdata );
            }

            /*
               Patcher exe folder
                    This is where the exe patcher resides
            */

            if ( File.Exists( findSib_PatchHome ) )
            {
                return Path.GetDirectoryName( findSib_PatchHome );
            }

            /*
                Last Resort
                    Utilize powershell get-command to see if application is installed
            */

            string ps_query         = "(get-command " + Cfg.Default.app_target_dll32 + ").Path";
            string ps_result        = PowershellQ( ps_query );
            ps_result               = ps_result.Replace( @"\", @"\\" ).Replace( @"""", @"\""" );
            string target_where     = null;

            using ( var reader = new StringReader( ps_result ) )
            {
                target_where = @reader.ReadLine( );
            }

            if ( File.Exists( target_where ) )
            {
                return Path.GetDirectoryName( target_where );
            }

            return String.Empty;
        }

        /*
            ProgramFiles directory
                different way of checking for 32 vs 64 bit OS. Need it for special purposes VS the built-in functions.

            IntPtr.Size
                4   = 32-bit
                8   = 64-bit

            @return     : str
        */

        public static string ProgramFiles( )
        {
            if ( 4 == IntPtr.Size || ( !String.IsNullOrEmpty( Environment.GetEnvironmentVariable( "PROCESSOR_ARCHITEW6432" ) ) ) )
                return Environment.GetEnvironmentVariable( "ProgramFiles(x86)" );

            return Environment.GetEnvironmentVariable( "ProgramFiles" );
        }

        /*
            ProgramFiles64 directory

            @return     : str
        */

        public static string ProgramFilesx64( )
        {
            return Environment.GetEnvironmentVariable( "ProgramFiles" );
        }


        /*
            return ProgramFiles86 directory
        */

        public static string ProgramFilesx86( )
        {
            return Environment.GetEnvironmentVariable( "ProgramFiles(x86)" );
        }

        /*
            Linker Timestamp UTC

            used to help obtain the build date of the software.
            This method doesn't work if you compile your application with /deterministic flag 
        */

        public static DateTime GetLinkerTimestampUtc( Assembly assembly )
        {
            var location = assembly.Location;
            return GetLinkerTimestampUtc( location );
        }

        /*
            Get Linker Timestamp UTC

            used to help obtain the build date of the software.
            This method doesn't work if you compile your application with /deterministic flag 
        */

        public static DateTime GetLinkerTimestampUtc( string filePath )
        {
            const int peHeaderOffset            = 60;
            const int linkerTimestampOffset     = 8;
            var bytes                           = new byte[2048];

            using ( var file = new FileStream( filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
            {
                file.Read( bytes, 0, bytes.Length );
            }

            var headerPos           = BitConverter.ToInt32( bytes, peHeaderOffset );
            var secondsSince1970    = BitConverter.ToInt32( bytes, headerPos + linkerTimestampOffset );
            var dt                  = new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc );

            return dt.AddSeconds( secondsSince1970 );
        }

        /*
            Get Build Date/Time

            An alternative method to obtaining the build date of the software. 
            The functions above should not be used incombination with the one below.

            @usage  : DateTime build_date = Helpers.GetBuildDate( Assembly.GetExecutingAssembly( ) );
        */

        public static DateTime GetBuildDate( Assembly assembly )
        {
            const string buildver_meta_pref = "+build";
            var attribute       = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>( );

            if ( attribute?.InformationalVersion != null )
            {
                var value       = attribute.InformationalVersion;
                var index       = value.IndexOf( buildver_meta_pref );

                if ( index > 0 )
                {
                    value = value.Substring( index + buildver_meta_pref.Length );
                    if ( DateTime.TryParseExact( value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result ) )
                    {
                        return result;
                    }
                }
            }

            return default;
        }

        public static DateTime GetBuild( Assembly assembly )
        {
            var attribute = assembly.GetCustomAttribute<BuildDateAttribute>( );
            return attribute?.DateTime ?? default( DateTime );
        }

        /*
            Execute powershell query
            checks to see if a target file has been signed with x509 cert

            @param      : str query
            @return     : str
        */

        public string PowershellQ( string query )
        {
            using ( PowerShell ps = PowerShell.Create( ) )
            {

                ps.AddScript( query );

                Collection<PSObject> PSOutput = ps.Invoke( );
                StringBuilder sb = new StringBuilder( );

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

                return sb.ToString( );
            }
        }


        /*
            x509 > File Is Signed
            checks to see if a target file has been signed with x509 cert

            @param      : str filepath
            @return     : bool
        */

        public static bool x509_FileSigned( string filepath )
        {
            var runeConfig = RunspaceConfiguration.Create( );
            using ( var rune = RunspaceFactory.CreateRunspace( runeConfig ) )
            {
                rune.Open( );
                using ( var pipe = rune.CreatePipeline())
                {
                    string cmd_exe      = "Get-AuthenticodeSignature \"" + filepath + "\"";
                    pipe.Commands.AddScript( cmd_exe );
                    var results         = pipe.Invoke();
                    rune.Close          ( );
 
                    var sig             = results[ 0 ].BaseObject as Signature;

                    return sig == null || sig.SignerCertificate == null ? 
                           false : ( sig.Status != SignatureStatus.NotSigned );
                }
            }
        }

        /*
            x509 > Thumbprint
            returns the thumbprint for a target file if signed with x509 cert.

            @param      : str filepath
            @return     : str
        */

        public string x509_Thumbprint( string filepath )
        {
            if ( Helpers.x509_FileSigned( filepath ) )
            {

                var runeConfig = RunspaceConfiguration.Create( );
                using ( var rune = RunspaceFactory.CreateRunspace( runeConfig ) )
                {
                    rune.Open( );
                    using ( var pipe = rune.CreatePipeline( ) )
                    {
                        string cmd_exe      = "Get-AuthenticodeSignature \"" + filepath + "\"";
                        pipe.Commands.AddScript( cmd_exe );
                        var results         = pipe.Invoke( );
                        rune.Close          ( );
 
                        var sig             = results[ 0 ].BaseObject as Signature;

                        if ( sig != null ) 
                            return sig.SignerCertificate.GetCertHashString( );

                        return "1";
                    }
                }
            }

            return "0";
        }

        /*
            Validate Executables
            returns if a target file is an executable.
            All executables begin with "MZ" or the hexadecimal "4D 5A"

            @param      : str filepath
            @return     : bool
        */

        public bool IsExeFile( string filepath )
        {
            var bytesBegin = new byte[ 2 ];
            using( var fs = File.Open( filepath, FileMode.Open ) )
            {
                fs.Read( bytesBegin, 0, 2 );
            }

            return Encoding.UTF8.GetString( bytesBegin ) == "MZ";
        }

    }
}
