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
	public partial class tetriz : TabbedPage
	{
		public tetriz()
		{
			InitializeComponent();

            var tetriz_opslag = new TetrizFolder.tetriz_opslag();
            var tetriz_beg = new TetrizFolder.tetriz_begivenheder();
            var tetriz_med = new TetrizFolder.tetriz_medarbejder();

            this.Children.Add(tetriz_opslag);
            this.Children.Add(tetriz_beg);
            this.Children.Add(tetriz_med);

            this.BarBackgroundColor = Color.FromHex("#29B19D");
            this.BarTextColor = Color.White;

        }
    }
}