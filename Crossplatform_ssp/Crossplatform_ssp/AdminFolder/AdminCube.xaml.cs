using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.AdminFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminCube : ContentPage
    {

        ContentPage C_begivenhed_pop = new ContentPage
        {
            BackgroundColor = Color.White,
            Padding = new Thickness(20, 20, 20, 20),
        };

        static Entry Begivenhed_emne = new Entry()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(10),
            BackgroundColor = Color.Silver
        };

        static Editor Begivenhed_besked = new Editor()
        {
            HorizontalOptions = LayoutOptions.Fill,
            HeightRequest = 200,
            Margin = new Thickness(10),
            BackgroundColor = Color.Silver
        };

        static Button opret_begivenhed = new Button()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.Green,
            Margin = new Thickness(10),
            Text = "Opret"
        };

        static Button annuller_begivenhed = new Button()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.Red,
            Margin = new Thickness(10),
            Text = "Annuller"
        };
        


        static StackLayout buttons = new StackLayout()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            Orientation = StackOrientation.Horizontal,
            Children = { opret_begivenhed, annuller_begivenhed }
        };

        StackLayout lay = new StackLayout()
        {
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Orientation = StackOrientation.Vertical,
            Children =
          {Begivenhed_emne, Begivenhed_besked, buttons }
        };

     

        public AdminCube ()
		{
			InitializeComponent ();

            opretCBBtn.Clicked += async (sender, e) =>
            {
                C_begivenhed_pop.Content = lay;
                await Navigation.PushModalAsync(C_begivenhed_pop, false);

                annuller_begivenhed.Clicked += (o, i) =>
                {
                 Navigation.PopModalAsync();
                };


                var text = Begivenhed_emne.Text;

            opret_begivenhed.Clicked += (o, i) =>
                {
                    if (text == "a")
                    {
                        DisplayAlert("Fejl", "Udfyld venligst alle felter", "OK");
                    }
                    else if (text != "")
                    {
                        Navigation.PopModalAsync();
                    }
                };


                

            };
		}
	}
}