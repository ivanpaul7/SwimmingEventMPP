using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services {
    public class SwimException:Exception {
        public SwimException():base() { }

        public SwimException(String msg) : base(msg) { }

        public SwimException(String msg, Exception ex) : base(msg, ex) { }

    }
}
