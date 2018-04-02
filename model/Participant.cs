using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    [Serializable]
    public class Participant : IHasID<int> {
        int id, age;
        String name;

        public Participant() { }
        public Participant(int id, String name, int age) {
            this.id = id;
            this.Name = name;
            this.Age = age;
        }

        public int Age {
            get {
                return age;
            }

            set {
                age = value;
            }
        }

        public int Id {
            get {
                return this.id;
            }

            set {
                this.id = value;
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
    }
}
