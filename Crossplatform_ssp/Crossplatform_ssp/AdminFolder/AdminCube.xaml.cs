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
    public partial class AdminCube : ContentPage
    {
        FirebaseFolder.FirebaseDB firedbCuOP = new FirebaseFolder.FirebaseDB();
        FirebaseFolder.FirebaseCubeBegivenhederDB firedbCuBe = new FirebaseFolder.FirebaseCubeBegivenhederDB();
        
        public AdminCube()
        {
            InitializeComponent();


        }
        void cubeBeg(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupPages.PopupCubeBegivenhed());
        }
        void cubeOpslag(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupPages.PopupCubeOpslag());
        }


        async void begivenhedOpretCube(object sender, EventArgs e)
        {
            var beg_emne2 = entryBeg.Text;
            var beg_besked2 = editorBeg.Text;
            if (string.IsNullOrEmpty(beg_emne2) || string.IsNullOrEmpty(beg_besked2))
            {
                await DisplayAlert("Fejl", "Udfyld venligst alle felter", "OK");
            }
            else if (!string.IsNullOrEmpty(beg_emne2) || !string.IsNullOrEmpty(beg_besked2))
            {
                activityind.IsRunning = true;
                var begive = new DatabaseFolder.DatabaseCubeBegivenhed(beg_emne2, beg_besked2);
                await firedbCuBe.AddCubeBegivenhed(begive);
                entryBeg.Text = "";
                editorBeg.Text = "";
                activityind.IsRunning = false;
                await DisplayAlert("Begivenhed", "Begivenhed oprettet", "ok");
            }
        }

        async void opslagOpretCube(object sender, EventArgs e)
        {
            var ops_emne = entryOps.Text;
            var ops_besked = editorOps.Text;
            if (string.IsNullOrEmpty(ops_emne) || string.IsNullOrEmpty(ops_besked))
            {
                await DisplayAlert("Fejl", "Udfyld venligst alle felter", "OK");
            }
            else if (!string.IsNullOrEmpty(ops_emne) || !string.IsNullOrEmpty(ops_besked))
            {
                activityind.IsRunning = true;
                var opslag = new DatabaseCubeOpslag(ops_emne, ops_besked);

                await firedbCuOP.AddCubeOpslag(opslag);

                entryOps.Text = "";
                editorOps.Text = "";
                activityind.IsRunning = false;
                await DisplayAlert("Opslag", "Opslag oprettet", "ok");

            }
        }

        void stackBegiTrue(object sender, EventArgs e)
        {
            stackBeg.IsVisible = true;
        }

        void stackBegiFalse(object sender, EventArgs e)
        {
            stackBeg.IsVisible = false;
        }

        void stackOpslTrue(object sender, EventArgs e)
        {
            stackOps.IsVisible = true;
        }

        void stackOpslFalse(object sender, EventArgs e)
        {
            stackOps.IsVisible = false;
        }

    }
}