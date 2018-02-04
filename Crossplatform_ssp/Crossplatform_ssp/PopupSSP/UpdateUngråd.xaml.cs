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
	public partial class UpdateUngråd : ContentPage
	{
        DatabaseFolder.DatabaseSSPUngRåd ungeråd = new DatabaseFolder.DatabaseSSPUngRåd();
		public UpdateUngråd ()
		{
			InitializeComponent ();


            MessagingCenter.Subscribe<PopupUngråd, DatabaseFolder.DatabaseSSPUngRåd>(this, "ungeråd", (page, data) =>
            {
                ungeråd = data;
                _emne.Text = ungeråd.UngRåd_Titel;
                _besked.Text = ungeråd.UngRåd_Tekst;

                MessagingCenter.Unsubscribe<PopupUngråd, DatabaseFolder.DatabaseSSPUngRåd>(this, "ungeråd");
            });
        }

        async void updateClickedAsync(object sender, EventArgs e)
        {
            ungeråd.UngRåd_Titel = _emne.Text;
            ungeråd.UngRåd_Tekst = _besked.Text;

            var db = new FirebaseFolder.FirebaseSSPUngeråd();
            var result = await db.getUpdateAsync(ungeråd.key, ungeråd);


            if (result) await Navigation.PopAsync();
            else await DisplayAlert("Fejl", "Der opstod en fejl, prøv igen", "ok");
        }
    }
}