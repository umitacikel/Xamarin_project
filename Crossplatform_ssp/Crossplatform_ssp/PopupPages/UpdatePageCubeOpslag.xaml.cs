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
	public partial class UpdatePageCubeOpslag : ContentPage
	{
        DatabaseFolder.DatabaseCubeOpslag ops = new DatabaseFolder.DatabaseCubeOpslag();

        public UpdatePageCubeOpslag ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<PopupCubeOpslag, DatabaseFolder.DatabaseCubeOpslag>(this, "OpsFull", (page, data) =>
            {
                ops = data;
                _emne.Text = ops.C_OpslagEmne;
                _besked.Text = ops.C_OpslagBesked;

                MessagingCenter.Unsubscribe<PopupCubeOpslag, DatabaseFolder.DatabaseCubeOpslag>(this, "OpsFull");
            });
        }


        async void updateClickedAsync(object sender, EventArgs e)
        {
            ops.C_OpslagEmne = _emne.Text;
            ops.C_OpslagBesked = _besked.Text;

            var db = new FirebaseFolder.FirebaseDB();
            var result = await db.getUpdateAsync(ops.key, ops);


            if (result) await Navigation.PopAsync();
            else await DisplayAlert("Fejl", "Der opstod en fejl, prøv igen", "ok");
        }
    }
}