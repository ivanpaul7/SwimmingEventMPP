using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistance;
using services;
using ServerTemplate;  //from networking: ServerUtils
using System.Net.Sockets;
using System.Threading;
using networking;

namespace Server {
    class StartServer {
        static void Main(string[] args) {
            IParticipantEventRepository eventPartRepo = new ParticipantEventDbRepository();
            IParticipantRepository partRepo = new ParticipantDbRepository();
            IEventRepository eventRepo = new EventDbRepository();
            IOrganizerRepository orgRepo = new OrganizerDbRepository();

            ISwimServer swimService = new SwimServerImpl(partRepo, eventRepo, eventPartRepo, orgRepo);
            SerialSwimServer server = new SerialSwimServer("127.0.0.1", 55555, swimService);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();
        }
    }

    public class SerialSwimServer : ConcurrentServer {
        private ISwimServer server;
        private SwimClientWorker worker;
        public SerialSwimServer(string host, int port, ISwimServer server) : base(host, port) {
            this.server = server;
            Console.WriteLine("SerialChatServer...");
        }

        protected override Thread createWorker(TcpClient client) {
            worker = new SwimClientWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}
