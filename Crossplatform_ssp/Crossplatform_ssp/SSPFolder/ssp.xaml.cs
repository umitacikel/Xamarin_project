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
	public partial class ssp : TabbedPage
	{
		public ssp ()
		{
			InitializeComponent ();

            var ungeråd = new SSPFolder.Ungerådgivning();
            var fritidspas = new SSPFolder.Fritidspas();
            var personale = new SSPFolder.SSPPersonale();
            var face = new SSPFolder.SSPFacebook();

            this.Children.Add(ungeråd);
            this.Children.Add(fritidspas);
            this.Children.Add(personale);
            this.Children.Add(face);
		}
	}
}