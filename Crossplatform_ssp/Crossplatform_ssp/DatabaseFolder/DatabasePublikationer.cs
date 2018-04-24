using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class DatabasePublikationer
    {
        public String key { get; set; }
        public String Navn { get; set; }
        public String Link { get; set; }
        public String ForsideBillede { get; set; }

        public DatabasePublikationer() { }

        public DatabasePublikationer( string navn, string link)
        {
            this.Navn = navn;
            this.Link = link;
        }
    }
}
