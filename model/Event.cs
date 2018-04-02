using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    [Serializable]
    public class Event : IHasID<Tuple<int, String>> {
        Tuple<int, string> id;

        public Event(Tuple<int, string> id) {
            this.id = id;
        }
        public Event(int distanta, string stil) {
            this.id = new Tuple<int, string>(distanta,stil);
        }

        public Tuple<int, string> Id {
            get {
                return this.id;
            }

            set {
                this.id=value;
            }
        }

    }
}
