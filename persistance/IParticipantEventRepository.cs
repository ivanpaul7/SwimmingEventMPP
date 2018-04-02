using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace persistance {
    public interface IParticipantEventRepository : ICrudRepository<EventPartDTO, EventPartDTO> {
        IEnumerable<EventPartDTO> findEventsNosParticipants();
        IEnumerable<Participant> findPartForEvent(Event e);
    }
}
