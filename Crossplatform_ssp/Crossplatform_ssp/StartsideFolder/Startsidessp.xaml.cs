using Crossplatform_ssp.DatabaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crossplatform_ssp.StartsideFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Startsidessp : ContentPage
    {
        FirebaseFolder.FirebaseDB firedbCuOP = new FirebaseFolder.FirebaseDB();

        public Startsidessp()
        {
            InitializeComponent();
        }
	}
}