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
	public partial class SSPopslag : ContentPage
	{

        FirebaseFolder.FirebaseSSPopslag fireDB = new FirebaseFolder.FirebaseSSPopslag();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await fireDB.GetOpslag();
            listviewSSPOpslag.BindingContext = list;
        }

        public SSPopslag ()
		{
			InitializeComponent ();
		}


        private async Task listviewOpslag_RefreshingAsync(object sender, EventArgs e)
        {
            listviewSSPOpslag.BindingContext = await fireDB.GetOpslag();
            listviewSSPOpslag.IsRefreshing = false;
        }
    }
}