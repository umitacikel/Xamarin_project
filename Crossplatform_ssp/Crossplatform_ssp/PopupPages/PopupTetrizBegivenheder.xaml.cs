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
	public partial class PopupTetrizBegivenheder : ContentPage
	{
        FirebaseFolder.FirebaseTetrizBegivenhederDB firedbTeBe = new FirebaseFolder.FirebaseTetrizBegivenhederDB();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await firedbTeBe.GetTetrizBegivenhedList();
            listviewTetrizBegivenhed.BindingContext = list;
        }
        public PopupTetrizBegivenheder ()
		{
			InitializeComponent ();
		}
        private async Task listviewTetrizBegivenhed_RefreshingAsync(object sender, EventArgs e)
        {
            listviewTetrizBegivenhed.BindingContext = await firedbTeBe.GetTetrizBegivenhedList();
            listviewTetrizBegivenhed.IsRefreshing = false;
        }

        void updateClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var begData = (DatabaseFolder.DatabaseTetrizBegivenhed)mItem.CommandParameter;
            Navigation.PushAsync(new UpdatePageTetrizBegivenheder(), true);
            MessagingCenter.Send<PopupTetrizBegivenheder, DatabaseFolder.DatabaseTetrizBegivenhed>(this, "BegFullt", begData);

        }

        async void deleteClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var begData = (DatabaseFolder.DatabaseTetrizBegivenhed)mItem.CommandParameter;
            var result = await firedbTeBe.getDeleteBegAsync(begData.key);

            if (result) await DisplayAlert("Success", "Enheden er blevet slettet", "ok");
            else await DisplayAlert("Fejl", "Enheden blev ikke slettet, prøv igen", "ok");
        }

    }
}