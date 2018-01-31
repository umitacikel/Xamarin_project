using Crossplatform_ssp.DatabaseFolder;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.SSPFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Fritidspas : ContentPage
	{

        FirebaseFolder.FirebaseSSPFritidspasDB firebaseFriPas = new FirebaseFolder.FirebaseSSPFritidspasDB();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await firebaseFriPas.GetfripasList();
            listviewfripas.BindingContext = list;
        }
        public Fritidspas ()
		{
			InitializeComponent ();
        }

        private void folderBtn_clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://ssp.helsingor.dk/ssp-tilbyder/fritidspas/"));

        }

        private async Task listviewfripas_RefreshingAsync(object sender, EventArgs e)
        {
            listviewfripas.BindingContext = await firebaseFriPas.GetfripasList();
            listviewfripas.IsRefreshing = false;
        }
    }
}