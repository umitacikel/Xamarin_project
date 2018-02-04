using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossplatform_ssp.FirebaseFolder
{
    public class FirebaseDB
    {
        FirebaseClient FbClient;

        public FirebaseDB()
        {
         FbClient = new FirebaseClient("https://sspappprojekt.firebaseio.com/");
        }

        public async Task<List<DatabaseFolder.DatabaseCubeOpslag>> GetCubeOpslagList()
        {
            return (await FbClient
                .Child("CubeOpslag")
                .OnceAsync<DatabaseFolder.DatabaseCubeOpslag>())
                .Select((item) =>
                new DatabaseFolder.DatabaseCubeOpslag
                {
                    key = item.Key,
                    C_OpslagEmne = item.Object.C_OpslagEmne,
                    C_OpslagBesked  = item.Object.C_OpslagBesked
                }).ToList();
        }

        public async Task AddCubeOpslag(DatabaseFolder.DatabaseCubeOpslag opslag)
        {
            await FbClient
                .Child("CubeOpslag")
                .PostAsync(opslag);
        }

        public async Task<bool> getUpdateAsync(String key, DatabaseFolder.DatabaseCubeOpslag opslag)
        {
            try
            {
                await FbClient
                         .Child("CubeOpslag/" + key)
                         .PutAsync<DatabaseFolder.DatabaseCubeOpslag>(opslag);

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
                         .Child("CubeOpslag/" + key)
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
