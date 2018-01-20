using Crossplatform_ssp.DatabaseFolder;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.CubeFolder
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class cube_begivenheder : ContentPage
    {
        FirebaseFolder.FirebaseCubeBegivenhederDB firedbcube = new FirebaseFolder.FirebaseCubeBegivenhederDB();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await firedbcube.GetCubeBegivenhedList();
            listviewCubeBegivenhed.BindingContext = list;
        }
        public cube_begivenheder()
        {
            InitializeComponent();

        }

        private async Task listviewCubeBegivenhed_RefreshingAsync(object sender, EventArgs e)
        {
            listviewCubeBegivenhed.BindingContext = await firedbcube.GetCubeBegivenhedList();
            listviewCubeBegivenhed.IsRefreshing = false;
        }
    }
}