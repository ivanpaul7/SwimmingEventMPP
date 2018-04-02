using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model {
    [Serializable]
    public class EventPartDTO {
        string style;
        int distance, codPart;

        public EventPartDTO(int distance, string style, int codPart) {
            this.style = style;
            this.distance = distance;
            this.codPart = codPart;
        }
        public string Style {
            get {
                return style;
            }

            set {
                style = value;
            }
        }

        public int Distance {
            get {
                return distance;
            }

            set {
                distance = value;
            }
        }

        public int CodPart {
            get {
                return codPart;
            }

            set {
                codPart = value;
            }
        }
    }
}
