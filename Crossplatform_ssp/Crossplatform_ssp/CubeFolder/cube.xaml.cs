using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp
{
	public partial class cube : TabbedPage
	{
		public cube ()
		{
			InitializeComponent();

            var cube_opslag = new CubeFolder.cube_opslag();
            var cube_beg = new CubeFolder.cube_begivenheder();
            var cube_med = new CubeFolder.cube_medarbejder();

            this.Children.Add(cube_opslag);
            this.Children.Add(cube_beg);
            this.Children.Add(cube_med);

            this.BarBackgroundColor = Color.FromHex("#29B19D");
            this.BarTextColor = Color.White;
        }
    }
}