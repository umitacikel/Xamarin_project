using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseTCPersonale
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Navn { get; set; }
        public String Stilling { get; set; }
        public String Email { get; set; }
        public int Nummer { get; set; }
        public byte[] Billede { get; set; }


        public DatabaseTCPersonale() { }

        public DatabaseTCPersonale(String navn, String stilling, string email, int nummer, byte[] billede)
        {
            this.Navn = navn;
            this.Stilling = stilling;
            this.Email = email;
            this.Nummer = nummer;
            this.Billede = billede;
        }
    }
}
