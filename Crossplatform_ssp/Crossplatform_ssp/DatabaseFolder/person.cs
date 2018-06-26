using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class person
    {
        public String _name { get; set; }
        public String _lastName { get; set; }
        public String _Email { get; set; }

        public person() { }

        public person(String name, String lastname, String email) {
            this._name = name;
            this._lastName = lastname;
            this._Email = email;
        }
    }
}
