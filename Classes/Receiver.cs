using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lng = SIBActivator.Properties.Resources;
using Cfg = SIBActivator.Properties.Settings;

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
}
