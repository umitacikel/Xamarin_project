using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Crossplatform_ssp
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
            this.Master = new master();
            this.Detail = new NavigationPage(new startside()) { BarBackgroundColor = Color.FromHex("#29B19D"), BarTextColor = Color.White };
            App.MasterDetail = this;


        }

     
    }
}
