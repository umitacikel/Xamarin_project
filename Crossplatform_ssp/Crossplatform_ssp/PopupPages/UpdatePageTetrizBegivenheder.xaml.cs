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
	public partial class UpdatePageTetrizBegivenheder : ContentPage
	{
        DatabaseFolder.DatabaseTetrizBegivenhed tet = new DatabaseFolder.DatabaseTetrizBegivenhed();

        public UpdatePageTetrizBegivenheder ()
		{
			InitializeComponent ();


            MessagingCenter.Subscribe<PopupTetrizBegivenheder, DatabaseFolder.DatabaseTetrizBegivenhed>(this, "BegFullt", (page, data) =>
            {
                tet = data;
                _emne.Text = tet.T_BegivenhedEmne;
                _besked.Text = tet.T_BegivenhedBesked;

                MessagingCenter.Unsubscribe<PopupTetrizBegivenheder, DatabaseFolder.DatabaseTetrizBegivenhed>(this, "BegFullt");
            });
        }

        async void updateClickedAsync(object sender, EventArgs e)
        {
            tet.T_BegivenhedEmne = _emne.Text;
            tet.T_BegivenhedBesked = _besked.Text;

            var db = new FirebaseFolder.FirebaseTetrizBegivenhederDB();
            var result = await db.getUpdateAsync(tet.key, tet);


            if (result) await Navigation.PopAsync();
            else await DisplayAlert("Fejl", "Der opstod en fejl, prøv igen", "ok");
        }
    }
}