using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    class Program {
        static void Main(string[] args) {
            ParticipantDbRepository repoP = new ParticipantDbRepository();
            OrganizerDbRepository repoO = new OrganizerDbRepository();
            EventDbRepository repoE = new EventDbRepository();
            ParticipantEventDbRepository repoPE = new ParticipantEventDbRepository();

            repoP.save(new Participant(100, "added but will be deleted", 13));
            foreach (Participant p in repoP.findAll()) {
                Console.WriteLine(p.Name);
            }
            Console.WriteLine("==================  PPPPart");
            repoP.delete(100);
            foreach (Participant p in repoP.findAll()) {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("================== OOOOrg");
            Console.WriteLine(repoO.findOne("user").Name);

            Console.WriteLine("================== EEEEvent");
            foreach (Event evv in repoE.findAll()) {
                Console.WriteLine(evv.Id.ToString());
            }

            Console.WriteLine("================== PPPPart EEEEvent");
            //repoPE.save(new Tuple<int, int,String>(3, 800, "BACKSTROKE"));
            //repoPE.delete(new Tuple<int, int, String>(3, 800, "BACKSTROKE"));
            foreach (int cod in repoPE.findParticipantForEvent(new Event(50, "BACKSTROKE"))) {
                Console.WriteLine(cod.ToString());
            }
            Console.WriteLine(" ---");
            foreach (Tuple<int, int, String> t in repoPE.findEventsNosParticipants()) {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine(" ---");
            foreach (Event evx in repoPE.findAllEventsForPart(1)) {
                Console.WriteLine(evx.Id.ToString());
            }
        }
    }
}
