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
	public partial class PopupTetrizOpslag : ContentPage
	{
        FirebaseFolder.FirebaseTetrizOpslagDB firedbTeOp = new FirebaseFolder.FirebaseTetrizOpslagDB();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await firedbTeOp.GetTetrizOpslagList();
            listviewTetrizOpslag.BindingContext = list;
        }
        public PopupTetrizOpslag ()
		{
			InitializeComponent ();
		}

        private async Task listviewTetrizOpslag_RefreshingAsync(object sender, EventArgs e)
        {
            listviewTetrizOpslag.BindingContext = await firedbTeOp.GetTetrizOpslagList();
            listviewTetrizOpslag.IsRefreshing = false;
        }

        void updateClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var opsData = (DatabaseFolder.DatabaseTetrizOpslag)mItem.CommandParameter;
            Navigation.PushAsync(new UpdatePageTetrizOpslag(), true);
            MessagingCenter.Send<PopupTetrizOpslag, DatabaseFolder.DatabaseTetrizOpslag>(this, "OpsFullt", opsData);

        }

        async void deleteClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var opsData = (DatabaseFolder.DatabaseTetrizOpslag)mItem.CommandParameter;
            var result = await firedbTeOp.getDeleteBegAsync(opsData.key);

            if (result) await DisplayAlert("Success", "Enheden er blevet slettet", "ok");
            else await DisplayAlert("Fejl", "Enheden blev ikke slettet, prøv igen", "ok");
        }
    }
}