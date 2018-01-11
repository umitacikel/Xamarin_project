using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseCubeBegivenhedController
    {
        static object locker = new object();

        SQLiteConnection database;

        public DatabaseCubeBegivenhedController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DatabaseCubeBegivenhed>();
        }

        public int Save_begivenhed_C(DatabaseCubeBegivenhed dcb)
        {
            lock (locker)
            {
                if (dcb.ID != 0)
                {
                    database.Update(dcb);
                    return dcb.ID;
                }
                else
                {
                    return database.Insert(dcb);
                }
            }
        }
    }
}
