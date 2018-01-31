using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.CubeFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class cube_opslag : ContentPage
	{
        FirebaseFolder.FirebaseDB fireDB = new FirebaseFolder.FirebaseDB();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await fireDB.GetCubeOpslagList();
            listviewCubeOpslag.BindingContext = list;
        }


        public cube_opslag ()
		{
			InitializeComponent ();
        }

     

        private async Task listviewCubeOpslag_RefreshingAsync(object sender, EventArgs e)
        {
            listviewCubeOpslag.BindingContext = await fireDB.GetCubeOpslagList();
            listviewCubeOpslag.IsRefreshing = false;
        }
    }
}