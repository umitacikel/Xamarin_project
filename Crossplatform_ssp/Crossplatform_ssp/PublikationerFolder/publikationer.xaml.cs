using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class publikationer : ContentPage
	{
        FirebaseFolder.FirebasePublikationerDB fbpubli = new FirebaseFolder.FirebasePublikationerDB();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await fbpubli.getPubli();
            listviewPubli.BindingContext = list;
        }


        public publikationer ()
		{
			InitializeComponent ();

           // listviewPubli.ItemSelected += pubiclick;
        }

        private void pubiclick(object sender, SelectedItemChangedEventArgs e)
        {
          
            var mItem = sender as MenuItem;
            var pubData = (DatabaseFolder.DatabasePublikationer)mItem.CommandParameter;

            Device.OpenUri(new Uri(pubData.Link));

        }

        private async Task listview_Refreshing(object sender, EventArgs e)
        {
            listviewPubli.BindingContext = await fbpubli.getPubli();
            listviewPubli.IsRefreshing = false;
        }




    }
}