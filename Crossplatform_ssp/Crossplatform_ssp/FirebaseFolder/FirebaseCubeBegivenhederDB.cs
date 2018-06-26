using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossplatform_ssp.FirebaseFolder
{
    public class FirebaseCubeBegivenhederDB
    {
        FirebaseClient FbClient;

        public FirebaseCubeBegivenhederDB()
        {
            FbClient = new FirebaseClient("https://sspappprojekt.firebaseio.com/");
        }

        public async Task<List<DatabaseFolder.DatabaseCubeBegivenhed>> GetCubeBegivenhedList()
        {
            return (await FbClient
                .Child("CubeBegivenhed")
                .OnceAsync<DatabaseFolder.DatabaseCubeBegivenhed>())
                .Select((item) =>
                new DatabaseFolder.DatabaseCubeBegivenhed
                {
                    key = item.Key,
                    C_BegivenhedEmne = item.Object.C_BegivenhedEmne,
                    C_BegivenhedBesked = item.Object.C_BegivenhedBesked,
                }).ToList();
        }

      

        public async Task AddCubeBegivenhed(DatabaseFolder.DatabaseCubeBegivenhed opslag)
        {
            await FbClient
                .Child("CubeBegivenhed")
                .PostAsync(opslag);
        }

        public async Task<List<DatabaseFolder.person>> getDeltagerAsync(String kkey) {
            return (await FbClient
                    .Child("CubeBegivenhed/" + kkey + "/Tilmeldte")
                    .OnceAsync<DatabaseFolder.person>())
                    .Select((item) =>
                    new DatabaseFolder.person
                    {
                       _name = item.Object._name,
                       _lastName = item.Object._lastName,
                       _Email = item.Object._Email
                    }).ToList();
        }


        public async Task AddDeltager(String key,  DatabaseFolder.person person ) {
            try
            {
                await FbClient
                        .Child("CubeBegivenhed/" + key + "/Tilmeldte")
                        .PostAsync(person);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public async Task<bool> getUpdateAsync(String key, DatabaseFolder.DatabaseCubeBegivenhed begivenhed)
        {
            try
            {
                await FbClient
                         .Child("CubeBegivenhed/" + key)
                         .PutAsync<DatabaseFolder.DatabaseCubeBegivenhed>(begivenhed);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> getDeleteBegAsync(String key)
        {
            try
            {
                await FbClient
                         .Child("CubeBegivenhed/" + key)
                         .DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
