using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    [Serializable]
    public class Organizer : IHasID<String> {
        String username, password, name;

        public Organizer(String username, String pass, String name) {
            this.username = username;
            this.password = pass;
            this.name = name;
        }

        public Organizer(String username, String pass) : this(username, pass, "") { }

            public string Id {
            get {
                return this.username;
            }

            set {
                this.username=value;
            }
        }

        public string Name {
            get {
                return name;
            }

            set {
                name = value;
            }
        }

        public string Password {
            get {
                return password;
            }

            set {
                password = value;
            }
        }
    }
}
