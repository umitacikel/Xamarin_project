using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.AdminFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminPublikationer : ContentPage
	{
        Stream imgstream;

		public AdminPublikationer ()
		{
			InitializeComponent();
		}


        async Task uploadBillede(object sender, EventArgs e)
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

                        ForsideBillede.Source = ImageSource.FromStream(() => imgstream);
                        imgstream = file.GetStream();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }


        async Task opretFolder(object sender, EventArgs e)
        {
            try
            {
                var fire = new FirebaseFolder.FirebasePublikationerDB();

                var link = new DatabaseFolder.DatabasePublikationer(pdfnavn.Text, pdflink.Text);

                await fire.SavePdf(imgstream, link);

                await DisplayAlert("Success", "pdf er blevet uploadet", "Ok");
                pdfnavn.Text = "";
                pdflink.Text = "";
                imgstream = null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}