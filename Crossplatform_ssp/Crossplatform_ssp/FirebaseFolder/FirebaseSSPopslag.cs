using Firebase.Storage;
using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossplatform_ssp.FirebaseFolder
{
   

    public class FirebaseSSPopslag
    {

        FirebaseClient FbClient;
        FirebaseStorage storage;
        public FirebaseSSPopslag()
        {
          FbClient = new FirebaseClient("https://sspappprojekt.firebaseio.com/");
          storage = new FirebaseStorage("sspappprojekt.appspot.com");
        }

        public async Task saveImageAsync(Stream str, DatabaseFolder.DatabaseSSPopslag personale)
        {
            try
            {
                var datatext = await FbClient.Child("SSPOpslag").PostAsync(personale);

                var dataImg = await new FirebaseStorage("sspappprojekt.appspot.com")
                                .Child("SSPOpslag")
                                .Child(datatext.Key)
                                .PutAsync(str);

                personale.Billede = dataImg;

                await FbClient.Child("SSPOpslag/" + datatext.Key).PutAsync(personale);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public async Task<List<DatabaseFolder.DatabaseSSPopslag>> GetOpslag()
        {
            return (await FbClient
                .Child("SSPOpslag")
                .OnceAsync<DatabaseFolder.DatabaseSSPopslag>())
                .Select((item) =>
                new DatabaseFolder.DatabaseSSPopslag
                {
                    Key = item.Key,
                    Emne = item.Object.Emne,
                    Beskrivelse = item.Object.Beskrivelse,
                    Billede = item.Object.Billede
                }).ToList();
        }

        public async Task<bool> getDeleteOpslagAsync(String key)
        {
            try
            {
                await FbClient
                         .Child("SSPOpslag/" + key)
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
