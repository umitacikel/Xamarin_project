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
    }
}
