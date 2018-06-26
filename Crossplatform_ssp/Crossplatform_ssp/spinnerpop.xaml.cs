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

        public spinnerpop(String key)
        {
            InitializeComponent();
            keyy = key;
            Console.WriteLine(keyy);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var list = firedbcube.getDeltagerAsync(keyy);
            listviewspinner.BindingContext = list;
        }


    }
}