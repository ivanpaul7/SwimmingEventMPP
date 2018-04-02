using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace services {
    public interface ISwimServer {
        void login(Organizer org, ISwimObserver obs);
        void logout(Organizer org, ISwimObserver obs);
        EventPartDTO[] findEventsNosParticipants();
        Participant[] findAllParticipants();
        Participant[] findPartForEvent(Event e);
        void addParticipant(Participant participant);
        void addPart2Event(EventPartDTO e);
    }
}
