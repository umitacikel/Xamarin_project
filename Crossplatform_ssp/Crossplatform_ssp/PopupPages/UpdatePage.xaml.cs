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
	public partial class UpdatePage : ContentPage
	{
        DatabaseFolder.DatabaseCubeBegivenhed beg = new DatabaseFolder.DatabaseCubeBegivenhed();
		public UpdatePage ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<PopupCubeBegivenhed, DatabaseFolder.DatabaseCubeBegivenhed>(this, "BegFull", (page, data) =>
            {
                beg = data;
                _emne.Text = beg.C_BegivenhedEmne;
                _besked.Text = beg.C_BegivenhedBesked;

                MessagingCenter.Unsubscribe<PopupCubeBegivenhed, DatabaseFolder.DatabaseCubeBegivenhed>(this, "BegFull");
            });
		}


        async void updateClickedAsync(object sender, EventArgs e)
        {
            beg.C_BegivenhedEmne = _emne.Text;
            beg.C_BegivenhedBesked = _besked.Text;

            var db = new FirebaseFolder.FirebaseCubeBegivenhederDB();
           var result = await db.getUpdateAsync(beg.key, beg);


            if (result) await Navigation.PopAsync();
            else await DisplayAlert("Fejl", "Der opstod en fejl, prøv igen", "ok");
        }

    }
}