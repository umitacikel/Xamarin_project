using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossplatform_ssp.FirebaseFolder
{
    public class FirebaseSSPFritidspasDB
    {
        FirebaseClient FbClient;
        public FirebaseSSPFritidspasDB()
        {
            FbClient = new FirebaseClient("https://sspappprojekt.firebaseio.com/");
        }
        public async Task<List<DatabaseFolder.DatabaseSSPFritidspas>> GetfripasList()
        {
            return (await FbClient
                .Child("SSPFriPas")
                .OnceAsync<DatabaseFolder.DatabaseSSPFritidspas>())
                .Select((item) =>
                new DatabaseFolder.DatabaseSSPFritidspas
                {
                    key = item.Key,
                    Fritidspas_Titel = item.Object.Fritidspas_Titel,
                    Fritidspas_Tekst = item.Object.Fritidspas_Tekst
                }).ToList();
        }

        public async Task<bool> getUpdateAsync(String key, DatabaseFolder.DatabaseSSPFritidspas opslag)
        {
            try
            {
                await FbClient
                         .Child("SSPFriPas/" + key)
                         .PutAsync<DatabaseFolder.DatabaseSSPFritidspas>(opslag);

                return true;
            }
            catch 
            {
                
                return false;
            }
        }
    }
}
