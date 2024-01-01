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
using System.Windows.Forms;
using Lng = SIBActivator.Properties.Resources;
using Cfg = SIBActivator.Properties.Settings;
using System.Management.Automation.Runspaces;
using System.Management.Automation.Language;

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

        private static string patcher_exe_dir   = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetEntryAssembly( ).Location );
        private static string sib_exe_filename  = Cfg.Default.app_target_exe;

        private static string sib_exe_appdata   = Path.Combine(
                                                    Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string sib_exe_prog64    = Path.Combine(
                                                    Environment.GetFolderPath( Environment.SpecialFolder.ProgramFiles ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string sib_exe_prog86    = Path.Combine(
                                                    Environment.GetFolderPath( Environment.SpecialFolder.ProgramFilesX86 ),
                                                    "StartIsBack",
                                                    sib_exe_filename
                                                );

        private static string sib_exe_home      = Path.Combine(
                                                    patcher_exe_dir,
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

            @returns
                string | directory name
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
                {
                    return folder;
                }
                else if ( File.Exists( folder + "\\" + sib_exe_filename ) )
                {
                    return folder + "\\";
                }
            }


            /*
                Program files 64
                    C:\Program Files
            */

            if ( File.Exists( sib_exe_prog64 ) )
            {
                string file_dir = Path.GetDirectoryName( sib_exe_prog64 );
                return file_dir;
            }

            /*
                Program files 86
                    C:\Program Files (x86)
            */

            if ( File.Exists( sib_exe_prog86 ) )
            {
                string file_dir = Path.GetDirectoryName( sib_exe_prog86 );
                return file_dir;
            }

            /*
                AppData
                    C:\Users\$USER\AppData\Local
            */

            if ( File.Exists( sib_exe_appdata ) )
            {
                string file_dir = Path.GetDirectoryName( sib_exe_appdata );
                return file_dir;
            }

            /*
               Patcher exe folder
                    This is where the exe patcher resides
            */

            if ( File.Exists( sib_exe_home ) )
            {
                string file_dir = Path.GetDirectoryName( sib_exe_home );
                return file_dir;
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
            return ProgramFiles directory
                different way of checking for 32 vs 64 bit OS. Need it for special purposes VS the built-in functions.

            IntPtr.Size
                4   = 32-bit
                8   = 64-bit
        */

        public static string ProgramFiles( )
        {
            if ( 4 == IntPtr.Size || ( !String.IsNullOrEmpty( Environment.GetEnvironmentVariable( "PROCESSOR_ARCHITEW6432" ) ) ) )
            {
                return Environment.GetEnvironmentVariable( "ProgramFiles(x86)" );
            }

            return Environment.GetEnvironmentVariable( "ProgramFiles" );
        }

        /*
            return ProgramFiles64 directory
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

            @usage  : DateTime build_date = Helpers.GetBuildDate(Assembly.GetExecutingAssembly( ));
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

        public string PowershellQ( string query )
        {
            using ( PowerShell ps = PowerShell.Create( ) )
            {

                ps.AddScript( query );

                Collection<PSObject> PSOutput = ps.Invoke( );
                StringBuilder sb = new StringBuilder( );

                foreach ( PSObject outputItem in PSOutput )
                {
                    if ( outputItem != null )
                    {
                        Console.WriteLine( $"Output line: [{outputItem}]" );
                        sb.AppendLine( outputItem.ToString( ) );
                    }
                }

                if ( ps.Streams.Error.Count > 0 )
                {
                    // Error collection
                }

                return sb.ToString( );
            }
        }

        public static bool IsSigned( string filepath )
        {
            var runspaceConfiguration = RunspaceConfiguration.Create();
            using (var runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration))
            {
                runspace.Open();
                using (var pipeline = runspace.CreatePipeline())
                {
                    string cmd_exe      = "Get-AuthenticodeSignature \"" + filepath + "\"";
                    pipeline.Commands.AddScript( cmd_exe );
                    var results         = pipeline.Invoke();
                    runspace.Close();
 
                    var signature       = results[0].BaseObject as Signature;

                    return signature == null || signature.SignerCertificate == null ? 
                           false : ( signature.Status != SignatureStatus.NotSigned );
                }
            }
        }

        public string x509_Thumbprint(string filepath)
        {
            bool bSigned = Helpers.IsSigned( filepath );
            if ( bSigned )
            {

                var runspaceConfiguration = RunspaceConfiguration.Create( );
                using ( var runspace = RunspaceFactory.CreateRunspace( runspaceConfiguration ) )
                {
                    runspace.Open( );
                    using ( var pipeline = runspace.CreatePipeline( ) )
                    {
                        string cmd_exe      = "Get-AuthenticodeSignature \"" + filepath + "\"";
                        pipeline.Commands.AddScript( cmd_exe );
                        var results         = pipeline.Invoke( );
                        runspace.Close      ( );
 
                        var certsig         = results[ 0 ].BaseObject as Signature;

                        if ( certsig != null) 
                            return certsig.SignerCertificate.GetCertHashString( );

                        return "Unknown";

                    }
                }

            }

            return "false";
        }

    }
}
