using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace persistance {
    public class OrganizerMockRepository : IOrganizerRepository {
        private IDictionary<string, Organizer> allOrg;
        public OrganizerMockRepository() {
            allOrg= new Dictionary<string, Organizer>();
            populate();
        }

        private void populate() {
            Organizer org = new Organizer("user","user","USER");
            Organizer org1 = new Organizer("user1", "user1", "USER 1");
            Organizer org2 = new Organizer("user2", "user2", "USER 2");
            Organizer org3 = new Organizer("user3", "user3", "USER 3");
            allOrg[org.Id] = org;
            allOrg[org1.Id] = org1;
            allOrg[org2.Id] = org2;
            allOrg[org3.Id] = org3;
        }

        public bool checkUserPass(Organizer organizer) {
            return allOrg[organizer.Id].Password == organizer.Password;
        }

        public void delete(string id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Organizer> findAll() {
            throw new NotImplementedException();
        }

        public Organizer findOne(string id) {
            throw new NotImplementedException();
        }

        public void save(Organizer e) {
            throw new NotImplementedException();
        }
    }
}
