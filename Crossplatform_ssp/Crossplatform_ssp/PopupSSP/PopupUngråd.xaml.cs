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
	public partial class PopupUngråd : ContentPage
	{
        FirebaseFolder.FirebaseSSPUngeråd FbClientUngRåd = new FirebaseFolder.FirebaseSSPUngeråd();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await FbClientUngRåd.GetUngrådList();
            listviewungråd.BindingContext = list;
        }
        public PopupUngråd ()
		{
			InitializeComponent ();
		}

        private async Task listviewungråd_RefreshingAsync(object sender, EventArgs e)
        {
            listviewungråd.BindingContext = await FbClientUngRåd.GetUngrådList();
            listviewungråd.IsRefreshing = false;
        }


        void updateClicked(object sender, EventArgs e)
        {
            var mItem = sender as MenuItem;
            var data = (DatabaseFolder.DatabaseSSPUngRåd)mItem.CommandParameter;
            Navigation.PushAsync(new UpdateUngråd(), true);
            MessagingCenter.Send<PopupUngråd, DatabaseFolder.DatabaseSSPUngRåd>(this, "ungeråd", data);

        }
    }
}