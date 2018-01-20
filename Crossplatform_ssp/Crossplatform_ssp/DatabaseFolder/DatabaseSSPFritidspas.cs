using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseSSPFritidspas
    {
       
        public String Fritidspas_Titel { get; set; }
        public string Fritidspas_Tekst { get; set; }

        public DatabaseSSPFritidspas() { }
        public DatabaseSSPFritidspas(String fritidspas_titel, String fritidspas_tekst)
        {
            this.Fritidspas_Titel = fritidspas_titel;
            this.Fritidspas_Tekst = fritidspas_tekst;
        }
    }
}
