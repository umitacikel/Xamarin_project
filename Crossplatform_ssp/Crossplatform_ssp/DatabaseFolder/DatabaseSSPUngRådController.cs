using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseSSPUngRådController
    {
        static object locker = new object();

        SQLiteConnection database;

        public DatabaseSSPUngRådController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DatabaseSSPUngRåd>();
        }

       /* public int Opret_SSPUngRåd(DatabaseSSPUngRåd dcb)
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
        }*/

        
        public DatabaseSSPUngRåd hent_SSPUngRåd()
        {
            lock (locker)
            {
                if (database.Table<DatabaseSSPUngRåd>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<DatabaseSSPUngRåd>().First();
                }
            }
        }

        public int Slet_SSPUngRåd(int id)
        {
            lock (locker)
            {
                return database.Delete<DatabaseSSPUngRåd>(id);
            }
        }

    }
}
