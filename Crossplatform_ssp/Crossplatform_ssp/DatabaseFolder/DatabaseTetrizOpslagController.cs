using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseTetrizOpslagController
    {
        static object locker = new object();

        SQLiteConnection database;

        public DatabaseTetrizOpslagController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DatabaseTetrizOpslag>();
        }

      /*  public int Save_Opslag_T(DatabaseTetrizOpslag dcb)
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
        public DatabaseTetrizOpslag Get_Opslag()
        {
            lock (locker)
            {
                if (database.Table<DatabaseTetrizOpslag>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<DatabaseTetrizOpslag>().First();
                }
            }
        }

        public int Delete_Opslag_T(int id)
        {
            lock (locker)
            {
                return database.Delete<DatabaseTetrizOpslag>(id);
            }
        }
    }
}
