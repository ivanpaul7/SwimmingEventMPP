using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace persistance {
    public class ParticipantEventMockRepository : IParticipantEventRepository {
        private IDictionary<int, EventPartDTO> allEP;
        public ParticipantEventMockRepository() {
            allEP = new Dictionary<int, EventPartDTO>();
            populate();
        }

        private void populate() {
            EventPartDTO ep = new EventPartDTO(50, "BACKSTROKE", 1);
            EventPartDTO ep2 = new EventPartDTO(100, "BACKSTROKE", 2);
            allEP[ep.CodPart] = ep;
            allEP[ep2.CodPart] = ep2;
        }

        public void delete(EventPartDTO id) {
            throw new NotImplementedException();
        }

        public IEnumerable<EventPartDTO> findAll() {
            return allEP.Values;
        }

        public IEnumerable<EventPartDTO> findEventsNosParticipants() {
            return allEP.Values;
        }

        public EventPartDTO findOne(EventPartDTO id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> findPartForEvent(Event e) {
            throw new NotImplementedException();
        }

        public void save(EventPartDTO e) {
            throw new NotImplementedException();
        }
    }
}
