using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabaseTetrizBegivenhed
    {
        public String T_BegivenhedEmne { get; set; }
        public String T_BegivenhedBesked { get; set; }

        public DatabaseTetrizBegivenhed() {}

        public DatabaseTetrizBegivenhed(string T_emne, string T_besked)
        {
            this.T_BegivenhedEmne = T_emne;
            this.T_BegivenhedBesked = T_besked;
        }
    }
}
