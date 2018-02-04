using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.PopupMedarbejder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PoptcPersonale : ContentPage
	{
        FirebaseFolder.FriebaseCTPersonale fbPersonale = new FirebaseFolder.FriebaseCTPersonale();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await fbPersonale.GetPersonale();
            listviewPersonale.BindingContext = list;
        }
        public PoptcPersonale ()
		{
			InitializeComponent ();
		}

        private async Task listviewPersonale_Refreshing(object sender, EventArgs e)
        {
            listviewPersonale.BindingContext = await fbPersonale.GetPersonale();
            listviewPersonale.IsRefreshing = false;
        }

        async void deleteClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var data = (DatabaseFolder.DatabaseTCPersonale)mItem.CommandParameter;
            var result = await fbPersonale.getDeleteBegAsync(data.key);

            if (result) await DisplayAlert("Success", "Enheden er blevet slettet", "ok");
            else await DisplayAlert("Fejl", "Enheden blev ikke slettet, prøv igen", "ok");
        }
    }
}