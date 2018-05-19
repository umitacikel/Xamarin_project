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


        public AdminTetriz()
        {
            InitializeComponent();
        }

        void tetBeg(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupPages.PopupTetrizBegivenheder());
        }

        void tetOpslag(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PopupPages.PopupTetrizOpslag());
        }

        async void OpretBegivenhedTetriz(object sender, EventArgs e)
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
                var begivenhed = new DatabaseFolder.DatabaseTetrizBegivenhed(beg_emne2, beg_besked2);
                await firebaseTeBe.AddCubeBegivenhed(begivenhed);

                entryBeg.Text = "";
                editorBeg.Text = "";
                activityind.IsRunning = false;
                await DisplayAlert("Begivenhed", "Begivenhed oprettet", "ok");

            }
        }

        async void OpretOpslagTetriz(object sender, EventArgs e)
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
                var opslag = new DatabaseFolder.DatabaseTetrizOpslag(ops_emne, ops_besked);
                await firebaseTeOp.AddTetrizOpslag(opslag);

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