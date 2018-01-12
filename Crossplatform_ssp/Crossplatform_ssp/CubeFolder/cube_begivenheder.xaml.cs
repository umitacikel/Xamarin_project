using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.CubeFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class cube_begivenheder : ContentPage
	{
        SQLiteConnection database;

        public cube_begivenheder ()
		{
			InitializeComponent ();

		}


        private void DD_Clicked(object sender, EventArgs e)
        {
            var table = database.Table<DatabaseFolder.DatabaseCubeBegivenhed>();
            foreach (var s in table)
            {
                Console.WriteLine(s.C_BegivenhedEmne + "    " + s.C_BegivenhedBesked);
            }
        }
    }
}