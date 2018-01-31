using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Crossplatform_ssp.Droid.Data;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]

namespace Crossplatform_ssp.Droid.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool isConnected { get; set; }

        public void CheckInternetConnection()
        {
            var ConnectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetworkInfo = ConnectivityManager.ActiveNetworkInfo;
            if (ActiveNetworkInfo != null && ActiveNetworkInfo.IsConnectedOrConnecting)
            {
                isConnected = true;
            }
            else
            {
                isConnected = false;
            }
        }
    }
}