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
                    key = item.Key,
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

        public async Task<bool> getUpdateAsync(String key, DatabaseFolder.DatabaseTetrizBegivenhed begivenhed)
        {
            try
            {
                await FbClient
                         .Child("TetrizBegivenhed/" + key)
                         .PutAsync<DatabaseFolder.DatabaseTetrizBegivenhed>(begivenhed);

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
                         .Child("TetrizBegivenhed/" + key)
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
