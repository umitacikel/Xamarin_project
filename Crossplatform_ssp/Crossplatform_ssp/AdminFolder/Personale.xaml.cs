﻿using Plugin.Media;
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
        Stream tc_imgstr;
        Stream ssp_imgstr;

    

       
        public Personale()
        {
            InitializeComponent();
          
        }


        void tcpersonale(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupMedarbejder.PoptcPersonale());
        }

        void sspPersonale(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupMedarbejder.PopsspPersonale());
        }



        async void tc_uploadBilledeFunc(object sender, EventArgs e)
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

                        tc_billede.Source = ImageSource.FromStream(() => tc_imgstr);
                        tc_imgstr = file.GetStream();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        async void tc_opretPersonale(object sender, EventArgs e) {
            try
            {
                activityind.IsRunning = true;
                var fire = new FirebaseFolder.FriebaseCTPersonale();
                var person = new DatabaseFolder.DatabaseTCPersonale(tc_navn.Text, tc_stilling.Text, tc_email.Text, tc_nummer.Text);

                await fire.saveImageAsync(tc_imgstr, person);
                tc_navn.Text = "";
                tc_stilling.Text = "";
                tc_email.Text = "";
                tc_nummer.Text = "";
                tc_imgstr = null;
                activityind.IsRunning = false;
                await DisplayAlert("Success", "Personale er blevet uploadet", "Ok");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        void tc_visibilty(object sender, EventArgs e)
        {
            tetcubStack.IsVisible = true;
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
                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        CustomPhotoSize = 50
                    });

                    if (file != null)
                    {
                        ssp_imgstr = file.GetStream();
                        ssp_billede.Source = ImageSource.FromStream(() => ssp_imgstr);
                       

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        async void ssp_opretPersonale(object sender, EventArgs e)
        {
            try
            {
                activityind.IsRunning = true;
                var fire = new FirebaseFolder.FirebaseSSPPersonale();
                var person = new DatabaseFolder.DatabaseTCPersonale(ssp_navn.Text, ssp_stilling.Text, ssp_email.Text, ssp_nummer.Text);

                await fire.saveImageAsync(ssp_imgstr, person);
                ssp_navn.Text = "";
                ssp_stilling.Text = "";
                ssp_email.Text = "";
                ssp_nummer.Text = "";
                ssp_imgstr = null;
                activityind.IsRunning = false;
                await DisplayAlert("Success", "Personale er blevet uploadet", "Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        void ssp_visibilty(object sender, EventArgs e)
        {
            sspStack.IsVisible = true;
        }
    }
}