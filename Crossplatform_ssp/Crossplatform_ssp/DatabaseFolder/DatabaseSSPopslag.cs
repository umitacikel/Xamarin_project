using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseSSPopslag
    {
        public String Key { get; set; }
        public String Emne { get; set; }
        public String Beskrivelse { get; set; }
        public String Billede { get; set; }

        public DatabaseSSPopslag() { }

        public DatabaseSSPopslag(String emne, String beskrivelse)
        {
            this.Emne = emne;
            this.Beskrivelse = beskrivelse;
        }
    }
}
