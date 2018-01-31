using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SystemConfiguration;
using CoreFoundation;
using Crossplatform_ssp.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkConnection))]

namespace Crossplatform_ssp.iOS
{
    public class NetworkConnection : INetworkConnection
    {
        public bool isConnected { get; set; }

        public void CheckInternetConnection()
        {
            InternetStatus();
        }

        public bool InternetStatus()
        {
            NetworkReachabilityFlags flags;
            bool defaultNetworkAvailable = isNetworkAvailable(out flags);
            if (defaultNetworkAvailable && ((flags & NetworkReachabilityFlags.IsDirect) != 0))
            {
                return false;
            }
            else if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
            {
                return true;
            }
            else if (flags == 0)
            {
                return false;
            }
            return true;
        }

        private event EventHandler ReachabilityChanged;
        private void onChange(NetworkReachabilityFlags flags)
        {
            var h = ReachabilityChanged;
            if (h!= null)
            
                h(null, EventArgs.Empty);
            
        }

        private NetworkReachability defaultReachability;
        public bool isNetworkAvailable(out NetworkReachabilityFlags flags)
        {
            if (defaultReachability == null)
            {
                defaultReachability = new NetworkReachability(new System.Net.IPAddress(0));
                defaultReachability.SetNotification(onChange);
                defaultReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
            }
            if (!defaultReachability.TryGetFlags(out flags))
            {
                return false;
            }
            return IsReachableWithoutRequringConnection(flags);
        }

        private bool IsReachableWithoutRequringConnection(NetworkReachabilityFlags flags)
        {
            bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;
            bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;
            if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                noConnectionRequired = true;
            return isReachable && noConnectionRequired;
            
        }
    }
}