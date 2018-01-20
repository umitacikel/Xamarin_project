using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseTetrizBegivenhedController
    {

        static object locker = new object();

        SQLiteConnection database;

        public DatabaseTetrizBegivenhedController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<DatabaseTetrizBegivenhed>();
        }

       /* public int Save_begivenhed_T(DatabaseTetrizBegivenhed dtb)
        {
            lock (locker)
            {
                if (dtb.ID != 0)
                {
                    database.Update(dtb);
                    return dtb.ID;
                }
                else
                {
                    return database.Insert(dtb);
                }
            }
        }
        */
        public DatabaseTetrizBegivenhed Get_Begivenhed()
        {
            lock (locker)
            {
                if (database.Table<DatabaseTetrizBegivenhed>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<DatabaseTetrizBegivenhed>().First();
                }
            }
        }
        public int Delete_begivenhed_T(int id)
        {
            lock (locker)
            {
                return database.Delete<DatabaseTetrizBegivenhed>(id);
            }
        }
    }
}
