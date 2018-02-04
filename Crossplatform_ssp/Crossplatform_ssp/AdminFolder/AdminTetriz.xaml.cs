using Crossplatform_ssp.DatabaseFolder;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.AdminFolder
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminTetriz : ContentPage
    {
        FirebaseFolder.FirebaseTetrizOpslagDB firebaseTeOp = new FirebaseFolder.FirebaseTetrizOpslagDB();
        FirebaseFolder.FirebaseTetrizBegivenhederDB firebaseTeBe = new FirebaseFolder.FirebaseTetrizBegivenhederDB();
   
        PopupPage Opret_pop = new PopupPage
        {
            BackgroundColor = Color.White,
            Padding = new Thickness(20, 20, 20, 20),
        };

        static Entry Opret_Emne = new Entry()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(10),
            BackgroundColor = Color.Silver
        };

        static Editor Opret_Besked = new Editor()
        {
            HorizontalOptions = LayoutOptions.Fill,
            HeightRequest = 200,
            Margin = new Thickness(10),
            BackgroundColor = Color.Silver
        };

        static Button opret_OpretBtn = new Button()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.Green,
            Margin = new Thickness(10),
            Text = "Opret"
        };

        static Button annullerBtn = new Button()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.Red,
            Margin = new Thickness(10),
            Text = "Annuller"
        };

        static StackLayout Opret_buttons = new StackLayout()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            Orientation = StackOrientation.Horizontal,
            Children = { opret_OpretBtn, annullerBtn }
        };

        StackLayout Opret_lay = new StackLayout()
        {
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Orientation = StackOrientation.Vertical,
            Children =
          {Opret_Emne, Opret_Besked, Opret_buttons }
        };
       

        public AdminTetriz()
        {
            InitializeComponent();

            annullerBtn.Clicked += (o, i) =>
            {
                Navigation.PopModalAsync();
            };

            opretTBBtn.Clicked += async (sender, e) =>
            {
                Opret_pop.Content = Opret_lay;
                await Navigation.PushPopupAsync(Opret_pop);

                opret_OpretBtn.Clicked += async (o, i) =>
                {
                    var beg_emne = Opret_Emne.Text;
                    var beg_besked = Opret_Besked.Text;
                    if (string.IsNullOrEmpty(beg_emne) || string.IsNullOrEmpty(beg_besked))
                    {
                      await  DisplayAlert("Fejl", "Udfyld venligst alle felter", "OK");
                    }
                    else if (!string.IsNullOrEmpty(beg_emne) || !string.IsNullOrEmpty(beg_besked))
                    {
                        var begivenhed = new DatabaseFolder.DatabaseTetrizBegivenhed(beg_emne, beg_besked);
                        await firebaseTeBe.AddCubeBegivenhed(begivenhed);

                        Opret_Emne.Text = "";
                        Opret_Besked.Text = "";
                        await Navigation.PopPopupAsync();
                        await DisplayAlert("Begivenhed", "Begivenhed oprettet", "ok");

                    }
                };
            };

           

            opretTOBtn.Clicked += async (sender, e) =>
            {
                Opret_pop.Content = Opret_lay;
                await Navigation.PushPopupAsync(Opret_pop);

                opret_OpretBtn.Clicked += async (o, i) =>
                {
                    var beg_emne = Opret_Emne.Text;
                    var beg_besked = Opret_Besked.Text;
                    if (string.IsNullOrEmpty(beg_emne) || string.IsNullOrEmpty(beg_besked))
                    {
                     await   DisplayAlert("Fejl", "Udfyld venligst alle felter", "OK");
                    }
                    else if (!string.IsNullOrEmpty(beg_emne) || !string.IsNullOrEmpty(beg_besked))
                    {
                        var opslag = new DatabaseFolder.DatabaseTetrizOpslag(beg_emne, beg_besked);
                        await firebaseTeOp.AddTetrizOpslag(opslag);

                        Opret_Emne.Text = "";
                        Opret_Besked.Text = "";
                        await Navigation.PopPopupAsync();
                        await DisplayAlert("Opslag", "Opslag oprettet", "ok");

                    }
                };
            };

        }

        void tetBeg(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupPages.PopupTetrizBegivenheder());
        }

        void tetOpslag(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupPages.PopupTetrizOpslag());
        }
    }
}