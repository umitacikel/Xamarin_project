using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Crossplatform_ssp.DatabaseFolder
{
 
    public class DatabaseSSPFritidspassController
    {
        static object locker = new object();

        SQLiteConnection database;

        public DatabaseSSPFritidspassController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DatabaseSSPFritidspas>();
        }

       /* public int Opret_SSPFritidspas(DatabaseSSPFritidspas dcb)
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


        public DatabaseSSPFritidspas hent_SSPFritidspas()
        {
            lock (locker)
            {
                if (database.Table<DatabaseSSPFritidspas>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<DatabaseSSPFritidspas>().First();
                }
            }
        }

        public int Slet_SSPFritidspas(int id)
        {
            lock (locker)
            {
                return database.Delete<DatabaseSSPFritidspas>(id);
            }
        }
    }
}
