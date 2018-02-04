using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseSSPUngRåd
    {
        public String key { get; set; }
        public String UngRåd_Titel { get; set; }
        public string UngRåd_Tekst { get; set; }

        public DatabaseSSPUngRåd() { }
        public DatabaseSSPUngRåd(String ungråd_titel, String ungråd_tekst)
        {
            this.UngRåd_Titel = ungråd_titel;
            this.UngRåd_Tekst = ungråd_tekst;
        }

    }
}
