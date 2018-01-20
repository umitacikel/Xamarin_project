using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseCubeOpslagController
    {
        static object locker = new object();

        SQLiteConnection database;

        public DatabaseCubeOpslagController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DatabaseCubeOpslag>();
        }

       /* public int Save_Opslag_C(DatabaseCubeOpslag dcb)
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
        public DatabaseCubeOpslag Get_Opslag()
        {
            lock (locker)
            {
                if (database.Table<DatabaseCubeOpslag>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<DatabaseCubeOpslag>().First();
                }
            }
        }

        public int Delete_Opslag_C(int id)
        {
            lock (locker)
            {
                return database.Delete<DatabaseCubeOpslag>(id);
            }
        }
    }
}

