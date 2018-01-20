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
	public partial class AdminSSP : ContentPage
	{
        SQLiteConnection database;

        ContentPage Opdater_pop = new ContentPage()
        {
            BackgroundColor = Color.White,
            Padding = new Thickness(20, 20, 20, 20),
        };

        static Entry Opdater_titel = new Entry()
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(10),
            BackgroundColor = Color.Silver
        };

        static Editor Opdater_tekst = new Editor()
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
          {Opdater_titel, Opdater_tekst, OpdaterBtn}
        };
        public AdminSSP ()
		{
			InitializeComponent ();


          /*  OpretUngrådBtn.Clicked += (sender, e) =>
            {
                var oc = new DatabaseSSPUngRåd( "Åben Anonym Ungerådgivning", "Den åbne anonyme ungerådgivning hjælper unge med Råd/Vejledning i forhold til skole, kærester, kammerater, stoffer, at være ung m.v. " +
                      "Den åbne anonyme ungerådgivning er åben om torsdagen, kl 18.30 - 21.30." +
                      "Den åbne anonyme ungerådgivning har til huse hos: SSP Rønnebær Allé 170 3000 Helsingør. " +
                      "Den åbne anonyme ungerådgivning  har tlf: 25 51 24 92 Email: ung.raadgivning@helsingor.dk");

                DatabaseSSPUngRådController dur = new DatabaseSSPUngRådController();
                dur.Opret_SSPUngRåd(oc);
                OpretUngrådBtn.IsEnabled = false;
            };*/

            OpretUngrådBtn.IsEnabled = false;

        /*    OpdaterUngrådBtn.Clicked += (sender, e) =>
            {
                database = DependencyService.Get<ISQLite>().GetConnection();
                var data = database.Table<DatabaseSSPUngRåd>();

                Opdater_pop.Content = Opdater_lay;
                Navigation.PushModalAsync(Opdater_pop, false);


                foreach (var listing in data)
                {
                    var from = new string[]
                    {
                     listing.UngRåd_Titel + listing.UngRåd_Tekst
                    };
                    Opdater_titel.Text = listing.UngRåd_Titel;
                    Opdater_tekst.Text = listing.UngRåd_Tekst;
                }

                OpdaterBtn.Clicked += (sende, a) =>
                {
                    DatabaseSSPUngRådController ssp = new DatabaseSSPUngRådController();
                    var dd = new DatabaseSSPUngRåd(Opdater_titel.Text, Opdater_tekst.Text);
                    ssp.Opret_SSPUngRåd(dd);
                };
            };

            */

      /*      OpretFriPasBtn.Clicked += (sender, e) =>
            {
                var tekst = new DatabaseSSPFritidspas ("Fritidspas", "Fritidspasset skal sikre, at børn og unge i målgruppen 6-17 år, får chancen for at komme i gang med en fritidsaktivitet. " +
                "Fritidspasset tildeles af SSP sekretariatet efter indstilling af en kontaktperson, der har direkte kontakt til barnet - det kan være en lærer i skolen, en pædagog i klub eller SFO, foreningsguide, en boligsocial medarbejder eller tilsvarende kontaktpersoner." +
                "Der gives kun Fritidspas til Helsingørs Kommunale Klubber og Foreninger." +
                "Fritidspasordningen udmøntes i samarbejde med DBU og Red Barnet." +
                "SSP varetager det økonomiske aspekt samt visitationsprocessen, hvor Red Barnet tilbyder opstartsfølgeordning og DBU har fokus på foreningsudvikling." +
                "Der kan gives støtte til:" +
                "Kontingent - max. 2.000 kr.pr.år." +
                "Udstyr - max. 600 kr.pr.år." +
                "Deltagerbetaling til enkeltarrangementer, stævner og lejre - max. 1.000 kr.pr.år." +
                "Et barn kan max. opnå 3.000 kr.i støtte pr.år." +
                "Hvem kan du kontakte?" +
                "Anja Enggaard, Fritidspaskoordinator -aen35@helsingor.dk" +
                "Kasper Jørgensen, Fritidspasvejleder - kjj38@helsingor.dk ");

                DatabaseSSPFritidspassController dfc = new DatabaseSSPFritidspassController();
                dfc.Opret_SSPFritidspas(tekst);
                OpretFriPasBtn.IsEnabled = false;
            };*/

            OpretFriPasBtn.IsEnabled = false;

        /*    OpdaterFripasBtn.Clicked += (sender, e) => 
            {
                database = DependencyService.Get<ISQLite>().GetConnection();
                var data = database.Table<DatabaseSSPFritidspas>();

                Opdater_pop.Content = Opdater_lay;
                Navigation.PushModalAsync(Opdater_pop, false);


                foreach (var listing in data)
                {
                    var from = new string[]
                    {
                     listing.Fritidspas_Titel + listing.Fritidspas_Tekst
                    };
                    Opdater_titel.Text = listing.Fritidspas_Titel;
                    Opdater_tekst.Text = listing.Fritidspas_Tekst;
                }

                OpdaterBtn.Clicked += (sende, a) =>
                {
                    DatabaseSSPFritidspassController ssp = new DatabaseSSPFritidspassController();
                    var dd = new DatabaseSSPFritidspas(Opdater_titel.Text, Opdater_tekst.Text);
                    ssp.Opret_SSPFritidspas(dd);
                };
    
            };*/

        }
    }
}