using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using persistance;
using networking;
using services;
using System.Windows.Forms;

namespace client {
    class StartClient {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //IChatServer server=new ChatServerMock();          
            ISwimServer server = new SwimServerProxy("127.0.0.1", 55555);
            SwimClientController ctrl = new SwimClientController(server);
            SwimLogin win = new SwimLogin(ctrl);
            Application.Run(win);
        }
    }
   
}
