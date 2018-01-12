using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseCubeBegivenhed
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String C_BegivenhedEmne { get; set; }
        public String C_BegivenhedBesked { get; set; }

        public DatabaseCubeBegivenhed() { }
        public DatabaseCubeBegivenhed(String c_emne, String c_besked)
        {
            this.C_BegivenhedEmne = c_emne;
            this.C_BegivenhedBesked = c_besked;
        }

    }
}
