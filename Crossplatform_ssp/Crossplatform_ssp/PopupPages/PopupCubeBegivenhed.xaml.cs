using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.PopupPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupCubeBegivenhed : ContentPage
	{
        FirebaseFolder.FirebaseCubeBegivenhederDB firedbcube = new FirebaseFolder.FirebaseCubeBegivenhederDB();
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await firedbcube.GetCubeBegivenhedList();
            listviewCubeBegivenhed.BindingContext = list;
        }

        public PopupCubeBegivenhed ()
		{
			InitializeComponent ();
		}
        private async Task listviewCubeBegivenhed_RefreshingAsync(object sender, EventArgs e)
        {
            listviewCubeBegivenhed.BindingContext = await firedbcube.GetCubeBegivenhedList();
            listviewCubeBegivenhed.IsRefreshing = false;
        }

        void updateClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var begData =(DatabaseFolder.DatabaseCubeBegivenhed) mItem.CommandParameter;
            Navigation.PushAsync(new UpdatePage(), true);
            MessagingCenter.Send<PopupCubeBegivenhed, DatabaseFolder.DatabaseCubeBegivenhed>(this, "BegFull", begData);

        }

        async void deleteClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var begData = (DatabaseFolder.DatabaseCubeBegivenhed)mItem.CommandParameter;
            var result = await firedbcube.getDeleteBegAsync(begData.key);

            if (result) await DisplayAlert("Success", "Enheden er blevet slettet", "ok");
            else await DisplayAlert("Fejl", "Enheden blev ikke slettet, prøv igen", "ok");
        }
    }
}