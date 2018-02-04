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
	public partial class PopupCubeOpslag : ContentPage
	{
        FirebaseFolder.FirebaseDB fireDB = new FirebaseFolder.FirebaseDB();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await fireDB.GetCubeOpslagList();
            listviewCubeOpslag.BindingContext = list;
        }

        public PopupCubeOpslag ()
		{
			InitializeComponent ();
		}

        private async Task listviewCubeOpslag_RefreshingAsync(object sender, EventArgs e)
        {
            listviewCubeOpslag.BindingContext = await fireDB.GetCubeOpslagList();
            listviewCubeOpslag.IsRefreshing = false;
        }

        void updateClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var opsData = (DatabaseFolder.DatabaseCubeOpslag)mItem.CommandParameter;
            Navigation.PushAsync(new UpdatePageCubeOpslag(), true);
            MessagingCenter.Send<PopupCubeOpslag, DatabaseFolder.DatabaseCubeOpslag>(this, "OpsFull", opsData);

        }

        async void deleteClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var opsData = (DatabaseFolder.DatabaseCubeOpslag)mItem.CommandParameter;
            var result = await fireDB.getDeleteBegAsync(opsData.key);

            if (result) await DisplayAlert("Success", "Enheden er blevet slettet", "ok");
            else await DisplayAlert("Fejl", "Enheden blev ikke slettet, prøv igen", "ok");
        }
    }
}