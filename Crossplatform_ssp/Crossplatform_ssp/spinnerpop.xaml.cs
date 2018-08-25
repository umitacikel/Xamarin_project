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
	public partial class spinnerpop : PopupPage
	{
        public String keyy;
        FirebaseFolder.FirebaseCubeBegivenhederDB firedbcube = new FirebaseFolder.FirebaseCubeBegivenhederDB();
        

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            var list =  await firedbcube.getDeltagerAsync(keyy);
            listviewspinner.BindingContext = list;
        }

        public spinnerpop(String key)
        {
            InitializeComponent();
        }

        public void tilbage(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

    }
}