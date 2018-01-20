using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossplatform_ssp.FirebaseFolder
{
    public class FirebaseTetrizOpslagDB
    {
        FirebaseClient FbClient;
        public FirebaseTetrizOpslagDB()
        {
         FbClient = new FirebaseClient("https://sspappprojekt.firebaseio.com/");
        }
        public async Task<List<DatabaseFolder.DatabaseTetrizOpslag>> GetTetrizOpslagList()
        {
            return (await FbClient
                .Child("TetrizOpslag")
                .OnceAsync<DatabaseFolder.DatabaseTetrizOpslag>())
                .Select((item) =>
                new DatabaseFolder.DatabaseTetrizOpslag
                {
                    T_OpslagEmne = item.Object.T_OpslagEmne,
                    T_OpslagBesked = item.Object.T_OpslagBesked
                }).ToList();
        }

        public async Task AddTetrizOpslag(DatabaseFolder.DatabaseTetrizOpslag opslag)
        {
            await FbClient
                .Child("TetrizOpslag")
                .PostAsync(opslag);
        }
    }
}
