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
	public partial class UpdatePageTetrizOpslag : ContentPage
	{

        DatabaseFolder.DatabaseTetrizOpslag ops = new DatabaseFolder.DatabaseTetrizOpslag();

        public UpdatePageTetrizOpslag ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<PopupTetrizOpslag, DatabaseFolder.DatabaseTetrizOpslag>(this, "OpsFullt", (page, data) =>
            {
                ops = data;
                _emne.Text = ops.T_OpslagEmne;
                _besked.Text = ops.T_OpslagBesked;

                MessagingCenter.Unsubscribe<PopupTetrizOpslag, DatabaseFolder.DatabaseTetrizOpslag>(this, "OpsFullt");
            });
        }

        async void updateClickedAsync(object sender, EventArgs e)
        {
            activityind.IsRunning = true;
            ops.T_OpslagEmne = _emne.Text;
            ops.T_OpslagBesked = _besked.Text;

            var db = new FirebaseFolder.FirebaseTetrizOpslagDB();
            var result = await db.getUpdateAsync(ops.key, ops);
            activityind.IsRunning = false;

            if (result) await Navigation.PopAsync();
            else await DisplayAlert("Fejl", "Der opstod en fejl, prøv igen", "ok");
        }
    }
}