using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class person
    {
        public String name { get; set; }
        public String lastName { get; set; }
        public String Email { get; set; }

        public person() { }

        public person(String name, String lastname, String email) {
            this.name = name;
            this.lastName = lastname;
            this.Email = email;
        }
    }
}
