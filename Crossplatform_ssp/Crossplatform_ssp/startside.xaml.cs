using Com.Hitomi.Cmlibrary;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Crossplatform_ssp 
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class startside : ContentPage
    {

        public startside() {
            InitializeComponent();


            startSSPBtn.Clicked += async (sender, e) => {
                await App.NavigateMasterDetail(new ssp());
            };

            startCubeBtn.Clicked += async (sender, e) => {
                await App.NavigateMasterDetail(new cube());
            };

            startTetrizBtn.Clicked += async (sender, e) => {
                await App.NavigateMasterDetail(new tetriz());
            };

            startPubBtn.Clicked += async (sender, e) => {
                await App.NavigateMasterDetail(new publikationer());
            };

            Init();
        }

        void Init()
        {
            App.StartCheckIfInternet(lbl_NoInternet, this);
        }
    }
}