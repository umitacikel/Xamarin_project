using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossplatform_ssp.FirebaseFolder
{
    public class FirebaseSSPUngeråd
    {
        FirebaseClient FbClient;
        public FirebaseSSPUngeråd()
        {
            FbClient = new FirebaseClient("https://sspappprojekt.firebaseio.com/");
        }

        public async Task<List<DatabaseFolder.DatabaseSSPUngRåd>> GetUngrådList()
        {
            return (await FbClient
                .Child("SSPUngRåd")
                .OnceAsync<DatabaseFolder.DatabaseSSPUngRåd>())
                .Select((item) =>
                new DatabaseFolder.DatabaseSSPUngRåd
                {
                    UngRåd_Titel = item.Object.UngRåd_Titel,
                    UngRåd_Tekst = item.Object.UngRåd_Tekst
                }).ToList();
        }
    }
}
