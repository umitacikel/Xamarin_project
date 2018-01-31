using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
	public partial class master : ContentPage
	{

        PopupPage pop = new PopupPage()
        {
            BackgroundColor = Color.White,
        };
        static Entry kode = new Entry()
        {
            IsPassword = true,
        };
        static Button okKnap = new Button()
        {
            Text = "Ok",
        };
        StackLayout Opret_lay = new StackLayout()
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Orientation = StackOrientation.Vertical,
            Children =
          {kode, okKnap }
        };

        public master ()
		{
			InitializeComponent ();

            sspBTN.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new ssp());
            };

            cubeBTN.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new cube());
            };

            tetrizBTN.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new tetriz());
            };

            publikationerBTN.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new publikationer());
            };

            AdminBtn.Clicked += async (sender, e) => {
                kode.Text = "";
                pop.Content = Opret_lay;
                await Navigation.PushPopupAsync(pop);
                okKnap.Clicked += async (sende, i) =>
                {
                    if (kode.Text.Equals("1234"))
                    {
                        await Navigation.PopPopupAsync();
                        await App.NavigateMasterDetail(new AdminFolder.Admin());
                    }
                };


            };
           
        }

	}
}