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
	public partial class spinnerpopT : PopupPage
	{
        public String keyy;
        FirebaseFolder.FirebaseTetrizBegivenhederDB firedbcube = new FirebaseFolder.FirebaseTetrizBegivenhederDB();

        public spinnerpopT (String key)
		{
			InitializeComponent ();
            keyy = key;
            Console.WriteLine(keyy);
           
        }

        public void tilbage(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var list = firedbcube.getDeltagerAsync(keyy);
            listviewspinner.BindingContext = list;
        }
    }
}