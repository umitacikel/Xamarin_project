using Crossplatform_ssp.DatabaseFolder;
using Plugin.Media;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        Stream ops_imgstr;

        public AdminSSP ()
		{
			InitializeComponent ();


        }

        void updateFripas()
        {
            Navigation.PushAsync(new PopupSSP.PopupFritids());
        }

        void updateUngeråd()
        {
            Navigation.PushAsync(new PopupSSP.PopupUngråd());
        }

        async void ssp_uploadBilledeFunc(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (CrossMedia.IsSupported == false)
                {
                    await DisplayAlert("Fejl", "Din enhed kan ikke uploade fotos", "Ok");
                }
                else
                {
                    var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions()
                    {

                    });

                    if (file != null)
                    {

                        ssp_billede.Source = ImageSource.FromStream(() => ops_imgstr);
                        ops_imgstr = file.GetStream();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        async void ssp_opretOps(object sender, EventArgs e)
        {
            try
            {
                activityind.IsRunning = true;
                var fire = new FirebaseFolder.FirebaseSSPopslag();
                var person = new DatabaseFolder.DatabaseSSPopslag(ssp_emne.Text, ssp_beskrivelse.Text);

                await fire.saveImageAsync(ops_imgstr, person);
                ssp_emne.Text = "";
                ssp_beskrivelse.Text = "";
                ops_imgstr = null;
                activityind.IsRunning = false;
                await DisplayAlert("Success", "Personale er blevet uploadet", "Ok");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}