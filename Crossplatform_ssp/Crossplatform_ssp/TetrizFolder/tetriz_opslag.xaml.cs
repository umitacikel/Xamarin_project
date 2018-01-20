using Crossplatform_ssp.DatabaseFolder;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.TetrizFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class tetriz_opslag : ContentPage
	{
        FirebaseFolder.FirebaseTetrizOpslagDB firedbTeOp = new FirebaseFolder.FirebaseTetrizOpslagDB();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await firedbTeOp.GetTetrizOpslagList();
            listviewTetrizOpslag.BindingContext = list;
        }
        public tetriz_opslag ()
		{
			InitializeComponent ();

        }

        private async Task listviewTetrizOpslag_RefreshingAsync(object sender, EventArgs e)
        {
            listviewTetrizOpslag.BindingContext = await firedbTeOp.GetTetrizOpslagList();
            listviewTetrizOpslag.IsRefreshing = false;
        }
    }
}