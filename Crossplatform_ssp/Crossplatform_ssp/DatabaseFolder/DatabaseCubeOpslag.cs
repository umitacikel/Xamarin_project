using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseCubeOpslag
    {
       
        public String C_OpslagEmne { get; set; }
        public String C_OpslagBesked { get; set; }

        public DatabaseCubeOpslag() { }
        public DatabaseCubeOpslag(String c_emne, String c_besked)
        {
            this.C_OpslagEmne = c_emne;
            this.C_OpslagBesked = c_besked;
        }
    }
}
