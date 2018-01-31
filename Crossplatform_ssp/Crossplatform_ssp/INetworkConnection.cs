using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp
{
    public interface INetworkConnection
    {
        bool isConnected { get; }
        void CheckInternetConnection();

    }
}
