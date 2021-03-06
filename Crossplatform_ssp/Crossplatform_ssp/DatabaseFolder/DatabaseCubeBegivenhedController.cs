﻿using Crossplatform_ssp.DatabaseFolder;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

       /* public int Save_begivenhed_C(DatabaseCubeBegivenhed dcb)
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
        public DatabaseCubeBegivenhed Get_Begivenhed()
        {
         lock (locker)
         {
                if (database.Table<DatabaseCubeBegivenhed>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<DatabaseCubeBegivenhed>().First();
                }
         }
        }

        public int Delete_begivenhed_C(int id)
        {
            lock (locker)
            {
                return database.Delete<DatabaseCubeBegivenhed>(id);
            }
        }
    }
}
