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
    public class FirebaseSSPPersonale
    {
        FirebaseClient client;
        FirebaseStorage storage;

        public FirebaseSSPPersonale()
        {
            client = new FirebaseClient("https://sspappprojekt.firebaseio.com/");
            storage = new FirebaseStorage("sspappprojekt.appspot.com");
        }
        public async Task saveImageAsync(Stream str, DatabaseFolder.DatabaseTCPersonale personale)
        {
            try
            {
                var datatext = await client.Child("SSPPersonale").PostAsync(personale);

                var dataImg = await new FirebaseStorage("sspappprojekt.appspot.com")
                                .Child("SSPPersonale")
                                .Child(datatext.Key)
                                .PutAsync(str);

                personale.Billede = dataImg;

                await client.Child("SSPPersonale/" + datatext.Key).PutAsync(personale);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<List<DatabaseFolder.DatabaseTCPersonale>> GetPersonale()
        {
            return (await client
                .Child("SSPPersonale")
                .OnceAsync<DatabaseFolder.DatabaseTCPersonale>())
                .Select((item) =>
                new DatabaseFolder.DatabaseTCPersonale
                {
                    key = item.Key,
                    Navn = item.Object.Navn,
                    Stilling = item.Object.Stilling,
                    Nummer = item.Object.Nummer,
                    Email = item.Object.Email,
                    Billede = item.Object.Billede
                }).ToList();
        }

        public async Task<bool> getDeleteBegAsync(String key)
        {
            try
            {
                await client
                         .Child("SSPPersonale/" + key)
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
