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
	public partial class PopupsspOpslag : ContentPage
	{

        FirebaseFolder.FirebaseSSPopslag fireDB = new FirebaseFolder.FirebaseSSPopslag();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await fireDB.GetOpslag();
            listviewSSPOpslag.BindingContext = list;
        }

        public PopupsspOpslag()
        {
            InitializeComponent();
        }


        private async Task listviewOpslag_RefreshingAsync(object sender, EventArgs e)
        {
            listviewSSPOpslag.BindingContext = await fireDB.GetOpslag();
            listviewSSPOpslag.IsRefreshing = false;
        }

       

        async void deleteClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var begData = (DatabaseFolder.DatabaseSSPopslag)mItem.CommandParameter;
            var result = await fireDB.getDeleteOpslagAsync(begData.Key);

            if (result) await DisplayAlert("Success", "Enheden er blevet slettet", "ok");
            else await DisplayAlert("Fejl", "Enheden blev ikke slettet, prøv igen", "ok");
        }
    }
}