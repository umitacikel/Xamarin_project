using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseTCPersonaleController
    {
        static object locker = new object();

        SQLiteConnection database;

        public DatabaseTCPersonaleController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DatabaseTCPersonale>();
        }

      /*  public int Opret_TCPersonale(DatabaseTCPersonale dcb)
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
        */

        public DatabaseTCPersonale hent_TCPersonale()
        {
            lock (locker)
            {
                if (database.Table<DatabaseTCPersonale>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<DatabaseTCPersonale>().First();
                }
            }
        }


        public int Slet_TCPersonale(int id)
        {
            lock (locker)
            {
                return database.Delete<DatabaseTCPersonale>(id);
            }
        }
    }
}
