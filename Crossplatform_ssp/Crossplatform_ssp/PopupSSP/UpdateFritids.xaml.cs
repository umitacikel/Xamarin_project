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
	public partial class UpdateFritids : ContentPage
	{
        DatabaseFolder.DatabaseSSPFritidspas fritpass = new DatabaseFolder.DatabaseSSPFritidspas();
		public UpdateFritids ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<PopupFritids, DatabaseFolder.DatabaseSSPFritidspas>(this, "fritidspass", (page, data) =>
            {
                fritpass = data;
                _emne.Text = fritpass.Fritidspas_Titel;
                _besked.Text = fritpass.Fritidspas_Tekst;

                MessagingCenter.Unsubscribe<PopupFritids, DatabaseFolder.DatabaseSSPFritidspas>(this, "fritidspass");
            });
        }

        async void updateClickedAsync(object sender, EventArgs e)
        {
            fritpass.Fritidspas_Titel = _emne.Text;
            fritpass.Fritidspas_Tekst = _besked.Text;

            var db = new FirebaseFolder.FirebaseSSPFritidspasDB();
            var result = await db.getUpdateAsync(fritpass.key, fritpass);


            if (result) await Navigation.PopAsync();
            else await DisplayAlert("Fejl", "Der opstod en fejl, prøv igen", "ok");
        }
    }
}