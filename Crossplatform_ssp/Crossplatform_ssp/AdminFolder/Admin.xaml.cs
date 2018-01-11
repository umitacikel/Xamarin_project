using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.AdminFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Admin : TabbedPage
	{
		public Admin ()
		{
			InitializeComponent ();

            var adminTet = new AdminTetriz();
            var adminCub = new AdminCube();

            this.Children.Add(adminTet);
            this.Children.Add(adminCub);
		}
	}
}