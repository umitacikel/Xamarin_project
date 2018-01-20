using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseTetrizOpslag
    {
        public String T_OpslagEmne { get; set; }
        public String T_OpslagBesked { get; set; }

        public DatabaseTetrizOpslag() { }
        public DatabaseTetrizOpslag(String t_emne, String t_besked)
        {
            this.T_OpslagEmne = t_emne;
            this.T_OpslagBesked = t_besked;
        }
    }
}
