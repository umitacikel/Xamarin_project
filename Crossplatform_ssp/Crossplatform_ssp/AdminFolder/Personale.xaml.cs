using Plugin.FilePicker.Abstractions;
using Plugin.FilePicker;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Crossplatform_ssp.AdminFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Personale : ContentPage
	{
		public Personale ()
		{
			InitializeComponent ();

            SQLiteConnection database;


           
               //     FileData filedata = await CrossFilePicker.Current.PickFile();
            
        }
    }
}