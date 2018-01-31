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
        SQLiteConnection database;
        FirebaseFolder.FirebaseTetrizOpslagDB firebaseTeOp = new FirebaseFolder.FirebaseTetrizOpslagDB();
        FirebaseFolder.FirebaseTetrizBegivenhederDB firebaseTeBe = new FirebaseFolder.FirebaseTetrizBegivenhederDB();
        //----------------------------------------------
        //Opret
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
        //----------------------------------------------
        ContentPage Slet_pop = new ContentPage
        {
            BackgroundColor = Color.White,
            Padding = new Thickness(20, 20, 20, 20),
        };

        ListView SletListView = new ListView()
        {
            RowHeight = 50,
            HasUnevenRows = true,

        };
        //----------------------------------------------
        ContentPage Opdater_pop = new ContentPage()
        {
            BackgroundColor = Color.White,
            Padding = new Thickness(20, 20, 20, 20),
        };

        ListView OpdaterListView = new ListView()
        {
            RowHeight = 50,
            HasUnevenRows = true,
        };

        static Entry Opdater_emne = new Entry()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(10),
            BackgroundColor = Color.Silver
        };

        static Editor Opdater_besked = new Editor()
        {
            HorizontalOptions = LayoutOptions.Fill,
            HeightRequest = 200,
            Margin = new Thickness(10),
            BackgroundColor = Color.Silver
        };

        static Button OpdaterBtn = new Button()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            BackgroundColor = Color.Green,
            Margin = new Thickness(10),
            Text = "Opdater"
        };

        StackLayout Opdater_lay = new StackLayout()
        {
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Orientation = StackOrientation.Vertical,
            Children =
          {Opdater_emne, Opdater_besked, OpdaterBtn}
        };
        //----------------------------------------------

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

            //---------------------------------------------

/*
            sletTBBtn.Clicked += async (sender, i) =>
            {


                database = DependencyService.Get<ISQLite>().GetConnection();
                var data = database.Table<DatabaseTetrizBegivenhed>();

                ObservableCollection<DatabaseTetrizBegivenhed> items = new ObservableCollection<DatabaseTetrizBegivenhed>();

                SletListView.ItemsSource = items;
                SletListView.ItemTemplate = new DataTemplate(typeof(TextCell));
                SletListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "ID");
                SletListView.ItemTemplate.SetBinding(TextCell.TextProperty, "T_BegivenhedEmne");
                SletListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "T_BegivenhedBesked");

                foreach (var listing in data)
                {
                    var from = new string[]
                    {
                    listing.ID +  listing.T_BegivenhedEmne + listing.T_BegivenhedBesked
                    };
                    items.Add(new DatabaseTetrizBegivenhed() { ID = listing.ID, T_BegivenhedEmne = listing.T_BegivenhedEmne, T_BegivenhedBesked = listing.T_BegivenhedBesked });
                }

                Slet_pop.Content = SletListView;
                await Navigation.PushModalAsync(Slet_pop, false);


                SletListView.ItemSelected += async (sende, e) =>
                {
                    if (e.SelectedItem == null)
                    {
                        return;
                    }
                    var foo = e.SelectedItem as DatabaseTetrizBegivenhed;
                    var svar = await DisplayAlert("Slet Opslag", "Er du sikker på du vil slette begivenheden: " + foo.T_BegivenhedEmne, "Ja", "Nej");
                    if (svar == true)
                    {
                        var hentid = e.SelectedItem as DatabaseTetrizBegivenhed;
                        int convertid = Convert.ToInt16(hentid.ID);
                        DatabaseTetrizBegivenhedController dcb = new DatabaseTetrizBegivenhedController();
                        dcb.Delete_begivenhed_T(convertid);
                        await Navigation.PopModalAsync();
                    }
                };
            };
            //---------------------------------------------


            opdaterTBBtn.Clicked += async (sender, a) =>
            {
                database = DependencyService.Get<ISQLite>().GetConnection();
                var data = database.Table<DatabaseTetrizBegivenhed>();
                ObservableCollection<DatabaseTetrizBegivenhed> itemsOpdater = new ObservableCollection<DatabaseTetrizBegivenhed>();

                OpdaterListView.ItemsSource = itemsOpdater;
                OpdaterListView.ItemTemplate = new DataTemplate(typeof(TextCell));
                OpdaterListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "ID");
                OpdaterListView.ItemTemplate.SetBinding(TextCell.TextProperty, "T_BegivenhedEmne");
                OpdaterListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "T_BegivenhedBesked");

                foreach (var listing in data)
                {
                    var from = new string[]
                    {
                    listing.ID +  listing.T_BegivenhedEmne + listing.T_BegivenhedBesked
                    };
                    itemsOpdater.Add(new DatabaseTetrizBegivenhed() { ID = listing.ID, T_BegivenhedEmne = listing.T_BegivenhedEmne, T_BegivenhedBesked = listing.T_BegivenhedBesked });
                }

                Opdater_pop.Content = OpdaterListView;
                await Navigation.PushModalAsync(Opdater_pop, false);


                OpdaterListView.ItemSelected += (sende, e) =>
                {
                    if (e.SelectedItem == null)
                    {
                        return;
                    }
                    var foo = e.SelectedItem as DatabaseTetrizBegivenhed;
                    Opdater_pop.Content = Opdater_lay;

                    var hentBegivenhed = e.SelectedItem as DatabaseTetrizBegivenhed;
                    Opdater_emne.Text = hentBegivenhed.T_BegivenhedEmne;
                    Opdater_besked.Text = hentBegivenhed.T_BegivenhedBesked;
                    int opdater_id = Convert.ToInt16(hentBegivenhed.ID);

                    OpdaterBtn.Clicked += async (sen, v) =>
                    {
                        DatabaseTetrizBegivenhedController dcb = new DatabaseTetrizBegivenhedController();
                        dcb.Save_begivenhed_T(new DatabaseTetrizBegivenhed { ID = hentBegivenhed.ID, T_BegivenhedEmne = Opdater_emne.Text, T_BegivenhedBesked = Opdater_besked.Text });
                        Opdater_emne.Text = "";
                        Opdater_besked.Text = "";
                        await DisplayAlert("Opdatering", "Begivenheden er blevet opdateret", "Ok");

                    };
                };
            };*/
            //#############################################

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

            //---------------------------------------------

            /*
            sletTOBtn.Clicked += async (sender, i) =>
            {


                database = DependencyService.Get<ISQLite>().GetConnection();
                var data = database.Table<DatabaseTetrizOpslag>();

                ObservableCollection<DatabaseTetrizOpslag> items = new ObservableCollection<DatabaseTetrizOpslag>();

                SletListView.ItemsSource = items;
                SletListView.ItemTemplate = new DataTemplate(typeof(TextCell));
                SletListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "ID");
                SletListView.ItemTemplate.SetBinding(TextCell.TextProperty, "T_OpslagEmne");
                SletListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "T_OpslagBesked");

                foreach (var listing in data)
                {
                    var from = new string[]
                    {
                    listing.ID +  listing.T_OpslagEmne + listing.T_OpslagBesked
                    };
                    items.Add(new DatabaseTetrizOpslag() { ID = listing.ID, T_OpslagEmne = listing.T_OpslagEmne, T_OpslagBesked = listing.T_OpslagBesked });
                }

                Slet_pop.Content = SletListView;
                await Navigation.PushModalAsync(Slet_pop, false);


                SletListView.ItemSelected += async (sende, e) =>
                {
                    if (e.SelectedItem == null)
                    {
                        return;
                    }
                    var foo = e.SelectedItem as DatabaseTetrizOpslag;
                    var svar = await DisplayAlert("Slet Opslag", "Er du sikker på du vil slette opslaget: " + foo.T_OpslagEmne, "Ja", "Nej");
                    if (svar == true)
                    {
                        var hentid = e.SelectedItem as DatabaseTetrizOpslag;
                        int convertid = Convert.ToInt16(hentid.ID);
                        DatabaseTetrizOpslagController dcb = new DatabaseTetrizOpslagController();
                        dcb.Delete_Opslag_T(convertid);
                        await Navigation.PopModalAsync();
                    }
                };
            };
            //---------------------------------------------


            opdaterTOBtn.Clicked += async (sender, a) =>
            {
                database = DependencyService.Get<ISQLite>().GetConnection();
                var data = database.Table<DatabaseTetrizOpslag>();
                ObservableCollection<DatabaseTetrizOpslag> itemsOpdater = new ObservableCollection<DatabaseTetrizOpslag>();

                OpdaterListView.ItemsSource = itemsOpdater;
                OpdaterListView.ItemTemplate = new DataTemplate(typeof(TextCell));
                OpdaterListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "ID");
                OpdaterListView.ItemTemplate.SetBinding(TextCell.TextProperty, "T_OpslagEmne");
                OpdaterListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "T_OpslagBesked");

                foreach (var listing in data)
                {
                    var from = new string[]
                    {
                    listing.ID +  listing.T_OpslagEmne + listing.T_OpslagBesked
                    };
                    itemsOpdater.Add(new DatabaseTetrizOpslag() { ID = listing.ID, T_OpslagEmne = listing.T_OpslagEmne, T_OpslagBesked = listing.T_OpslagBesked });
                }

                Opdater_pop.Content = OpdaterListView;
                await Navigation.PushModalAsync(Opdater_pop, false);


                OpdaterListView.ItemSelected += (sende, e) =>
                {
                    if (e.SelectedItem == null)
                    {
                        return;
                    }
                    Opdater_pop.Content = Opdater_lay;

                    var hentOpslag = e.SelectedItem as DatabaseTetrizOpslag;
                    Opdater_emne.Text = hentOpslag.T_OpslagEmne;
                    Opdater_besked.Text = hentOpslag.T_OpslagBesked;
                    int opdater_id = Convert.ToInt16(hentOpslag.ID);

                    OpdaterBtn.Clicked += async (sen, v) =>
                    {
                        DatabaseTetrizOpslagController dcb = new DatabaseTetrizOpslagController();
                        dcb.Save_Opslag_T(new DatabaseTetrizOpslag { ID = hentOpslag.ID, T_OpslagEmne = Opdater_emne.Text, T_OpslagBesked = Opdater_besked.Text });
                        Opdater_emne.Text = "";
                        Opdater_besked.Text = "";
                        await DisplayAlert("Opdatering", "Opslaget er blevet opdateret", "Ok");

                    };
                };
            };*/



        }
    }
}