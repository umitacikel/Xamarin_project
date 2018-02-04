using Plugin.Media;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
namespace Crossplatform_ssp.AdminFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Personale : ContentPage
	{
        Stream imgstr;

        PopupPage pop = new PopupPage()
        {
            BackgroundColor = Color.White,     
        };
        static  Entry personale_navn = new Entry
        {
            Placeholder="Navn"
        };
        static Entry personale_stilling = new Entry
        {
            Placeholder="Stilling"
        };
        static Entry personale_email = new Entry
        {
            Placeholder="Email"
        };
        static Entry personale_nummer = new Entry
        {
            Placeholder="Nummer"
        };
        static Image personale_billede = new Image
        {
            
        };

        static Button personale_uploadBtn = new Button
        {
            Text="Upload billede"
        };

        static Button personale_opretBtn = new Button
        {
            Text="Opret Personale"
        };

        StackLayout Opret_lay = new StackLayout()
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Orientation = StackOrientation.Vertical,
            Spacing = 20,
            Children =
          {personale_billede, personale_navn, personale_stilling, personale_email, personale_nummer, personale_uploadBtn, personale_opretBtn }
        };
        public Personale()
        {
            InitializeComponent();
           
            opretPersonale.Clicked += async (sender, e) =>
            {
                opretPersonale.IsEnabled = false;
            
                pop.Content = Opret_lay;
                await Navigation.PushPopupAsync(pop);
                personale_navn.Text = "";
                personale_stilling.Text = "";
                personale_email.Text = "";
                personale_nummer.Text = "";
                imgstr = null;
                personale_uploadBtn.Clicked += async (sende, i) =>
                {
                    personale_uploadBtn.IsEnabled = false;
                    try
                    {
                        await CrossMedia.Current.Initialize();

                        if (CrossMedia.IsSupported == false)
                        {
                            await DisplayAlert("Fejl", "Din enhed kan ikke uploade fotos", "ok");
                        }
                        else
                        {
                            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions()
                            {
                               
                            });

                            if (file != null)
                            {

                                personale_billede.Source = ImageSource.FromStream(() => imgstr);
                                imgstr = file.GetStream();

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                };

                personale_opretBtn.Clicked += async (sendr, a) =>
                {
                    try
                    {
                        var fire = new FirebaseFolder.FriebaseCTPersonale();
                        var person = new DatabaseFolder.DatabaseTCPersonale(personale_navn.Text, personale_stilling.Text, personale_email.Text, personale_nummer.Text);

                        await fire.saveImageAsync(imgstr, person);
                        await Navigation.PopPopupAsync();
                        opretPersonale.IsEnabled = true;
                        personale_uploadBtn.IsEnabled = true;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                };

              

            };


            OpretPersonaleSSP.Clicked += async (sender, e) =>
            {
                opretPersonale.IsEnabled = false;
                pop.Content = Opret_lay;
                await Navigation.PushPopupAsync(pop);
                personale_navn.Text = "";
                personale_stilling.Text = "";
                personale_email.Text = "";
                personale_nummer.Text = "";
                imgstr = null;
                personale_uploadBtn.Clicked += async (sende, i) =>
                {
                    personale_uploadBtn.IsEnabled = false;
                    try
                    {
                        await CrossMedia.Current.Initialize();

                        if (CrossMedia.IsSupported == false)
                        {
                            await DisplayAlert("Fejl", "Din enhed kan ikke uploade fotos", "ok");
                        }
                        else
                        {
                            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions()
                            {

                            });

                            if (file != null)
                            {

                                personale_billede.Source = ImageSource.FromStream(() => imgstr);
                                imgstr = file.GetStream();

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                };

                personale_opretBtn.Clicked += async (sendr, a) =>
                {

                    try
                    {
                        var fire = new FirebaseFolder.FirebaseSSPPersonale();
                        var person = new DatabaseFolder.DatabaseTCPersonale(personale_navn.Text, personale_stilling.Text, personale_email.Text, personale_nummer.Text);

                        await fire.saveImageAsync(imgstr, person);
                        await Navigation.PopPopupAsync();

                        opretPersonale.IsEnabled = true;
                        personale_uploadBtn.IsEnabled = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                };



            };
        }


        void tcpersonale(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupMedarbejder.PoptcPersonale());
        }

        void sspPersonale(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupMedarbejder.PopsspPersonale());
        }
    }
}