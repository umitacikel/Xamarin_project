using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
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
                    C_BegivenhedBesked = item.Object.C_BegivenhedBesked
                }).ToList();
        }

        public async Task AddCubeBegivenhed(DatabaseFolder.DatabaseCubeBegivenhed opslag)
        {
            await FbClient
                .Child("CubeBegivenhed")
                .PostAsync(opslag);
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
