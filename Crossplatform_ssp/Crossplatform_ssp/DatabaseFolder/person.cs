using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public class person
    {
        public String Key { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }

        public person() { }

        public person(String name, String lastname, String email) {
            this.Name = name;
            this.LastName = lastname;
            this.Email = email;
        }
    }
}
