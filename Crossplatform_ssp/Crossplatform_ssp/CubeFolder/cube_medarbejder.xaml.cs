using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.CubeFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class cube_medarbejder : ContentPage
	{
        FirebaseFolder.FriebaseCTPersonale fbPersonale = new FirebaseFolder.FriebaseCTPersonale();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await fbPersonale.GetPersonale();
            listviewPersonale.BindingContext = list;
        }
        public cube_medarbejder ()
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