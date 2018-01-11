using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Crossplatform_ssp.DatabaseFolder;
using System.IO;
using Xamarin.Forms;
using Crossplatform_ssp.Droid.Data;

[assembly: Dependency(typeof(SQLite_Android))]

namespace Crossplatform_ssp.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() {}
        public SQLite.SQLiteConnection GetConnection()
        {
            var SQLiteFileName = "DB.SSPdb";
            String documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, SQLiteFileName);

            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}