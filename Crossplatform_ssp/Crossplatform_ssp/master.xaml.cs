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
	public partial class master : ContentPage
	{
		public master ()
		{
			InitializeComponent ();

            sspBTN.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new ssp());
            };

            cubeBTN.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new cube());
            };

            tetrizBTN.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new tetriz());
            };

            publikationerBTN.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new publikationer());
            };

           
        }
	}
}