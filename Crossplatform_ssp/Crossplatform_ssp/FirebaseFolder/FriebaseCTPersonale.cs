using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Xamarin.Database;
using Firebase.Storage;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Crossplatform_ssp.FirebaseFolder
{
    public class FriebaseCTPersonale
    {
        FirebaseClient client;
        FirebaseStorage storage;
        public FriebaseCTPersonale()
        {
            client = new FirebaseClient("https://sspappprojekt.firebaseio.com/");
            storage = new FirebaseStorage("sspappprojekt.appspot.com");
        }

        public async Task saveImageAsync(Stream str, DatabaseFolder.DatabaseTCPersonale personale)
        {
            try
            {
                var datatext = await client.Child("TCPersonale").PostAsync(personale);

                var dataImg = await new FirebaseStorage("sspappprojekt.appspot.com")
                                .Child("TCPersonale")
                                .Child(datatext.Key)
                                .PutAsync(str);

                personale.Billede = dataImg;

                await client.Child("TCPersonale/" + datatext.Key).PutAsync(personale);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<List<DatabaseFolder.DatabaseTCPersonale>> GetPersonale()
        {
            return (await client
                .Child("TCPersonale")
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
                         .Child("TCPersonale/" + key)
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
