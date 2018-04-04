using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace persistance {
    public class ParticipantMockRepository : IParticipantRepository {
        private IDictionary<int, Participant> allParts;

        public ParticipantMockRepository() {
            allParts = new Dictionary<int, Participant>();
            populateUsers();
        }

        private void populateUsers() {
            Participant part = new Participant(1, "p1", 11);
            Participant part2 = new Participant(2, "p2", 22);
            Participant part3 = new Participant(3, "p3", 33);
            Participant part4 = new Participant(4, "p4", 44);
            Participant part5 = new Participant(5, "p5", 55);
            Participant part6 = new Participant(6, "p6", 66);
            allParts[part.Id] = part;
            allParts[part2.Id] = part2;
            allParts[part3.Id] = part3;
            allParts[part4.Id] = part4;
            allParts[part5.Id] = part5;
            allParts[part6.Id] = part6;
        }

        public void delete(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> findAll() {
            return allParts.Values;
        }

        public Participant findOne(int id) {
            throw new NotImplementedException();
        }

        public void save(Participant e) {
            allParts[e.Id] = e;
        }
    }
}
