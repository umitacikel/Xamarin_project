using Crossplatform_ssp.DatabaseFolder;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.AdminFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminSSP : ContentPage
	{

        public AdminSSP ()
		{
			InitializeComponent ();


        }

        void updateFripas()
        {
            Navigation.PushAsync(new PopupSSP.PopupFritids());
        }

        void updateUngeråd()
        {
            Navigation.PushAsync(new PopupSSP.PopupUngråd());
        }

    }
}