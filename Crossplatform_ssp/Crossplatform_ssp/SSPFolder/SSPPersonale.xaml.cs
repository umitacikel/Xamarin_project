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
	public partial class SSPPersonale : ContentPage
	{
        FirebaseFolder.FirebaseSSPPersonale fbPersonale = new FirebaseFolder.FirebaseSSPPersonale();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await fbPersonale.GetPersonale();
            listviewPersonale.BindingContext = list;
        }
        public SSPPersonale ()
		{
			InitializeComponent ();
		}
        private async Task listviewPersonale_Refreshing(object sender, EventArgs e)
        {
            listviewPersonale.BindingContext = await fbPersonale.GetPersonale();
            listviewPersonale.IsRefreshing = false;
        }
    }
}