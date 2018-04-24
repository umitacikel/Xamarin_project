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

    public class FirebasePublikationerDB
    {
        FirebaseClient client;
        FirebaseStorage storage;

        public FirebasePublikationerDB()
        {
            client = new FirebaseClient("https://sspappprojekt.firebaseio.com/");
            storage = new FirebaseStorage("sspappprojekt.appspot.com");
        }


        public async Task SavePdf(Stream str, DatabaseFolder.DatabasePublikationer publikation)
        {
            try
            {
                var datatext = await client.Child("Publikationer").PostAsync(publikation);

                var pdfdata = await new FirebaseStorage("sspappprojekt.appspot.com")
                                .Child("Publikationer")
                                .Child(datatext.Key)
                                .PutAsync(str);

                publikation.ForsideBillede = pdfdata;

                await client.Child("Publikationer/" + datatext.Key).PutAsync(publikation);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }


        public async Task<List<DatabaseFolder.DatabasePublikationer>> getPubli()
        {
            return (await client
                .Child("Publikationer")
                .OnceAsync<DatabaseFolder.DatabasePublikationer>())
                .Select((item) =>
                new DatabaseFolder.DatabasePublikationer
                {
                    key = item.Key,
                    Navn = item.Object.Navn,
                    Link = item.Object.Link,
                    ForsideBillede = item.Object.ForsideBillede
                }).ToList();

        }


        public async Task<bool> getDeleteAsync(String key)
        {
            try
            {
                await client
                         .Child("Publikationer/" + key)
                         .DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

    }
}
