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

            listviewPubli.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => 
            {
                var eitem = (DatabaseFolder.DatabasePublikationer) e.SelectedItem;
                var linki = eitem.Link;
                Device.OpenUri(new Uri(linki));
            };

        }

       
        private async Task listview_Refreshing(object sender, EventArgs e)
        {
            listviewPubli.BindingContext = await fbpubli.getPubli();
            listviewPubli.IsRefreshing = false;
        }




    }
}