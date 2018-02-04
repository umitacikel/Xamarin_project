using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.PopupSSP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupFritids : ContentPage
	{
        FirebaseFolder.FirebaseSSPFritidspasDB firebaseFriPas = new FirebaseFolder.FirebaseSSPFritidspasDB();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await firebaseFriPas.GetfripasList();
            listviewfripas.BindingContext = list;
        }
        public PopupFritids ()
		{
			InitializeComponent ();
		}

        private async Task listviewfripas_RefreshingAsync(object sender, EventArgs e)
        {
            listviewfripas.BindingContext = await firebaseFriPas.GetfripasList();
            listviewfripas.IsRefreshing = false;
        }

        void updateClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var data = (DatabaseFolder.DatabaseSSPFritidspas)mItem.CommandParameter;
            Navigation.PushAsync(new UpdateFritids(), true);
            MessagingCenter.Send<PopupFritids, DatabaseFolder.DatabaseSSPFritidspas>(this, "fritidspass", data);

        }

    }
}