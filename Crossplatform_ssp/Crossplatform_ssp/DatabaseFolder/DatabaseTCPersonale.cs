using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseTCPersonale
    {
        public String key { get; set; }
        public String Navn { get; set; }
        public String Stilling { get; set; }
        public String Email { get; set; }
        public String Nummer { get; set; }
        public String Billede { get; set; }


        public DatabaseTCPersonale() { }

        public DatabaseTCPersonale(String navn, String stilling, string email, String nummer)
        {
            this.Navn = navn;
            this.Stilling = stilling;
            this.Email = email;
            this.Nummer = nummer;
        }
    }
}
