using Crossplatform_ssp.DatabaseFolder;
using Rg.Plugins.Popup.Extensions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.TetrizFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class tetriz_begivenheder : ContentPage
	{
        FirebaseFolder.FirebaseTetrizBegivenhederDB firedbTeBe = new FirebaseFolder.FirebaseTetrizBegivenhederDB();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await firedbTeBe.GetTetrizBegivenhedList();
            listviewTetrizBegivenhed.BindingContext = list;
        }
        public tetriz_begivenheder ()
		{
			InitializeComponent ();



            
               listviewTetrizBegivenhed.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {

                var _key = (DatabaseTetrizBegivenhed)e.SelectedItem;
                Navigation.PushPopupAsync(new tilmeldpopT(_key.key));
                
                
             };
             
             


        }

        private async Task listviewTetrizBegivenhed_RefreshingAsync(object sender, EventArgs e)
        {
            listviewTetrizBegivenhed.BindingContext = await firedbTeBe.GetTetrizBegivenhedList();
            listviewTetrizBegivenhed.IsRefreshing = false;
        }
    }
}
