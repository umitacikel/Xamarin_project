using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossplatform_ssp.FirebaseFolder
{
    public class FirebaseTetrizBegivenhederDB
    {
        FirebaseClient FbClient;

        public FirebaseTetrizBegivenhederDB()
        {
         FbClient = new FirebaseClient("https://sspappprojekt.firebaseio.com/");
        }

        public async Task<List<DatabaseFolder.DatabaseTetrizBegivenhed>> GetTetrizBegivenhedList()
        {
            return (await FbClient
                .Child("TetrizBegivenhed")
                .OnceAsync<DatabaseFolder.DatabaseTetrizBegivenhed>())
                .Select((item) =>
                new DatabaseFolder.DatabaseTetrizBegivenhed
                {
                    T_BegivenhedEmne = item.Object.T_BegivenhedEmne,
                    T_BegivenhedBesked = item.Object.T_BegivenhedBesked
                }).ToList();
        }

        public async Task AddCubeBegivenhed(DatabaseFolder.DatabaseTetrizBegivenhed opslag)
        {
            await FbClient
                .Child("TetrizBegivenhed")
                .PostAsync(opslag);
        }
    }
}
