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

namespace Crossplatform_ssp.AdminFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminCube : ContentPage
    {
        FirebaseFolder.FirebaseDB firedbCuOP = new FirebaseFolder.FirebaseDB();
        FirebaseFolder.FirebaseCubeBegivenhederDB firedbCuBe = new FirebaseFolder.FirebaseCubeBegivenhederDB();
        //----------------------------------------------
        //Opret
        ContentPage Opret_pop = new ContentPage
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

        public AdminCube()
        {
            InitializeComponent();

            annullerBtn.Clicked += (o, i) =>
            {
                Navigation.PopModalAsync();
            };



            opretCBBtn.Clicked += async (sender, e) =>
            {
                Opret_pop.Content = Opret_lay;
                await Navigation.PushModalAsync(Opret_pop, false);

                opret_OpretBtn.Clicked += async (o, i) =>
                {
                    var beg_emne = Opret_Emne.Text;
                    var beg_besked = Opret_Besked.Text;
                    if (string.IsNullOrEmpty(beg_emne) || string.IsNullOrEmpty(beg_besked))
                    {
                        await DisplayAlert("Fejl", "Udfyld venligst alle felter", "OK");
                    }
                    else if (!string.IsNullOrEmpty(beg_emne) || !string.IsNullOrEmpty(beg_besked))
                    {
                        var begivenhed = new DatabaseFolder.DatabaseCubeBegivenhed(beg_emne, beg_besked);
                        await firedbCuBe.AddCubeBegivenhed(begivenhed);

                        Opret_Emne.Text = "";
                        Opret_Besked.Text = "";
                        await Navigation.PopModalAsync();
                        await DisplayAlert("Begivenhed", "Begivenhed oprettet", "ok");

                    }
                };
            };

            //---------------------------------------------

            /*
                        sletCBBtn.Clicked += async (sender, i) =>
                        {


                            database = DependencyService.Get<ISQLite>().GetConnection();
                            var data = database.Table<DatabaseCubeBegivenhed>();

                            ObservableCollection<DatabaseCubeBegivenhed> items = new ObservableCollection<DatabaseCubeBegivenhed>();

                            SletListView.ItemsSource = items;
                            SletListView.ItemTemplate = new DataTemplate(typeof(TextCell));
                            SletListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "ID");
                            SletListView.ItemTemplate.SetBinding(TextCell.TextProperty, "C_BegivenhedEmne");
                            SletListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "C_BegivenhedBesked");

                            foreach (var listing in data)
                            {
                                var from = new string[]
                                {
                                listing.ID +  listing.C_BegivenhedEmne + listing.C_BegivenhedBesked
                                };
                                items.Add(new DatabaseCubeBegivenhed() { ID = listing.ID, C_BegivenhedEmne = listing.C_BegivenhedEmne, C_BegivenhedBesked = listing.C_BegivenhedBesked });
                            }

                            Slet_pop.Content = SletListView;
                            await Navigation.PushModalAsync(Slet_pop, false);


                            SletListView.ItemSelected += async (sende, e) =>
                            {
                                if (e.SelectedItem == null)
                                {
                                    return;
                                }
                                var foo = e.SelectedItem as DatabaseCubeBegivenhed;
                                var svar = await DisplayAlert("Slet Opslag", "Er du sikker på du vil slette begivenheden: " + foo.C_BegivenhedEmne, "Ja", "Nej");
                                if (svar == true)
                                {
                                    var hentid = e.SelectedItem as DatabaseCubeBegivenhed;
                                    int convertid = Convert.ToInt16(hentid.ID);
                                    DatabaseCubeBegivenhedController dcb = new DatabaseCubeBegivenhedController();
                                    dcb.Delete_begivenhed_C(convertid);
                                    await Navigation.PopModalAsync();
                                }
                            };
                        };
                        //---------------------------------------------


                        opdaterCBBtn.Clicked += async (sender, a) =>
                        {
                            database = DependencyService.Get<ISQLite>().GetConnection();
                            var data = database.Table<DatabaseCubeBegivenhed>();
                            ObservableCollection<DatabaseCubeBegivenhed> itemsOpdater = new ObservableCollection<DatabaseCubeBegivenhed>();

                            OpdaterListView.ItemsSource = itemsOpdater;
                            OpdaterListView.ItemTemplate = new DataTemplate(typeof(TextCell));
                            OpdaterListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "ID");
                            OpdaterListView.ItemTemplate.SetBinding(TextCell.TextProperty, "C_BegivenhedEmne");
                            OpdaterListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "C_BegivenhedBesked");

                            foreach (var listing in data)
                            {
                                var from = new string[]
                                {
                                listing.ID +  listing.C_BegivenhedEmne + listing.C_BegivenhedBesked
                                };
                                itemsOpdater.Add(new DatabaseCubeBegivenhed() { ID = listing.ID, C_BegivenhedEmne = listing.C_BegivenhedEmne, C_BegivenhedBesked = listing.C_BegivenhedBesked });
                            }

                            Opdater_pop.Content = OpdaterListView;
                            await Navigation.PushModalAsync(Opdater_pop, false);


                            OpdaterListView.ItemSelected += (sende, e) =>
                            {
                                if (e.SelectedItem == null)
                                {
                                    return;
                                }
                                var foo = e.SelectedItem as DatabaseCubeBegivenhed;
                                Opdater_pop.Content = Opdater_lay;

                                var hentBegivenhed = e.SelectedItem as DatabaseCubeBegivenhed;
                                Opdater_emne.Text = hentBegivenhed.C_BegivenhedEmne;
                                Opdater_besked.Text = hentBegivenhed.C_BegivenhedBesked;
                                int opdater_id = Convert.ToInt16(hentBegivenhed.ID);

                                OpdaterBtn.Clicked += async (sen, v) =>
                                {
                                    DatabaseCubeBegivenhedController dcb = new DatabaseCubeBegivenhedController();
                                    dcb.Save_begivenhed_C(new DatabaseCubeBegivenhed { ID = hentBegivenhed.ID, C_BegivenhedEmne = Opdater_emne.Text, C_BegivenhedBesked = Opdater_besked.Text });
                                    Opdater_emne.Text = "";
                                    Opdater_besked.Text = "";
                                    await DisplayAlert("Opdatering", "Begivenheden er blevet opdateret", "Ok");

                                };
                            };
                        };*/
            //#############################################

            opretCOBtn.Clicked += async (sender, e) =>
            {
                Opret_pop.Content = Opret_lay;
                await Navigation.PushModalAsync(Opret_pop, false);

                opret_OpretBtn.Clicked += async (o, i) =>
                {
                    var beg_emne = Opret_Emne.Text;
                    var beg_besked = Opret_Besked.Text;
                    if (string.IsNullOrEmpty(beg_emne) || string.IsNullOrEmpty(beg_besked))
                    {
                        await DisplayAlert("Fejl", "Udfyld venligst alle felter", "OK");
                    }
                    else if (!string.IsNullOrEmpty(beg_emne) || !string.IsNullOrEmpty(beg_besked))
                    {
                        var opslag = new DatabaseCubeOpslag(beg_emne, beg_besked);

                        await firedbCuOP.AddCubeOpslag(opslag);

                        Opret_Emne.Text = "";
                        Opret_Besked.Text = "";
                        await Navigation.PopModalAsync();
                        await DisplayAlert("Opslag", "Opslag oprettet", "ok");

                    }
                };
            };

            //---------------------------------------------

            /*
                        sletCOBtn.Clicked += async (sender, i) =>
                        {


                            database = DependencyService.Get<ISQLite>().GetConnection();
                            var data = database.Table<DatabaseCubeOpslag>();

                            ObservableCollection<DatabaseCubeOpslag> items = new ObservableCollection<DatabaseCubeOpslag>();

                            SletListView.ItemsSource = items;
                            SletListView.ItemTemplate = new DataTemplate(typeof(TextCell));
                            SletListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "ID");
                            SletListView.ItemTemplate.SetBinding(TextCell.TextProperty, "C_OpslagEmne");
                            SletListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "C_OpslagBesked");

                            foreach (var listing in data)
                            {
                                var from = new string[]
                                {
                                listing.ID +  listing.C_OpslagEmne + listing.C_OpslagBesked
                                };
                                items.Add(new DatabaseCubeOpslag() { ID = listing.ID, C_OpslagEmne = listing.C_OpslagEmne, C_OpslagBesked = listing.C_OpslagBesked });
                            }

                            Slet_pop.Content = SletListView;
                            await Navigation.PushModalAsync(Slet_pop, false);


                            SletListView.ItemSelected += async (sende, e) =>
                            {
                                if (e.SelectedItem == null)
                                {
                                    return;
                                }
                                var foo = e.SelectedItem as DatabaseCubeOpslag;
                                var svar = await DisplayAlert("Slet Opslag", "Er du sikker på du vil slette opslaget: " + foo.C_OpslagEmne, "Ja", "Nej");
                                if (svar == true)
                                {
                                    var hentid = e.SelectedItem as DatabaseCubeOpslag;
                                    int convertid = Convert.ToInt16(hentid.ID);
                                    DatabaseCubeOpslagController dcb = new DatabaseCubeOpslagController();
                                    dcb.Delete_Opslag_C(convertid);
                                    await Navigation.PopModalAsync();
                                }
                            };
                        };
                        //---------------------------------------------


                     //   opdaterCOBtn.Clicked += async (sender, a) =>
                        {
                            database = DependencyService.Get<ISQLite>().GetConnection();
                            var data = database.Table<DatabaseCubeOpslag>();
                            ObservableCollection<DatabaseCubeOpslag> itemsOpdater = new ObservableCollection<DatabaseCubeOpslag>();

                            OpdaterListView.ItemsSource = itemsOpdater;
                            OpdaterListView.ItemTemplate = new DataTemplate(typeof(TextCell));
                            OpdaterListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "ID");
                            OpdaterListView.ItemTemplate.SetBinding(TextCell.TextProperty, "C_OpslagEmne");
                            OpdaterListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "C_OpslagBesked");

                            foreach (var listing in data)
                            {
                                var from = new string[]
                                {
                                listing.ID +  listing.C_OpslagEmne + listing.C_OpslagBesked
                                };
                                itemsOpdater.Add(new DatabaseCubeOpslag() { ID = listing.ID, C_OpslagEmne = listing.C_OpslagEmne, C_OpslagBesked = listing.C_OpslagBesked });
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

                                var hentOpslag = e.SelectedItem as DatabaseCubeOpslag;
                                Opdater_emne.Text = hentOpslag.C_OpslagEmne;
                                Opdater_besked.Text = hentOpslag.C_OpslagBesked;
                                int opdater_id = Convert.ToInt16(hentOpslag.ID);

                                OpdaterBtn.Clicked += async (sen, v) =>
                                {
                                    DatabaseCubeOpslagController dcb = new DatabaseCubeOpslagController();
                                    dcb.Save_Opslag_C(new DatabaseCubeOpslag { ID = hentOpslag.ID, C_OpslagEmne = Opdater_emne.Text, C_OpslagBesked = Opdater_besked.Text });
                                    Opdater_emne.Text = "";
                                    Opdater_besked.Text = "";
                                    await DisplayAlert("Opdatering", "Opslaget er blevet opdateret", "Ok");

                                };
                            };
                        };

                        */

        }

    }
}