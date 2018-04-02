using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace networking {
    public interface Request {}

    [Serializable]
    public class LoginRequest : Request {
        private Organizer user;
        public LoginRequest(Organizer user) {
            this.user = user;
        }
        public  Organizer Organizer {
            get {
                return user;
            }
        }
    }
    [Serializable]
    public class LogoutRequest : Request {
        private Organizer user;
        public LogoutRequest(Organizer user) {
            this.user = user;
        }
        public  Organizer Organizer {
            get {
                return user;
            }
        }
    }
    [Serializable]
    public class GetEventsNosPartRequest : Request {
        public GetEventsNosPartRequest() {
        }
    }

    [Serializable]
    public class GetAllPartRequest : Request {
        public GetAllPartRequest() {
        }
    }

    [Serializable]
    public class GetAllPart4EventRequest : Request {
        private Event ev;
        public GetAllPart4EventRequest(Event ev) {
            this.ev = ev;
        }
        public virtual Event Event {
            get {
                return ev;
            }
        }
    }

    [Serializable]
    public class AddParticipantRequest : Request {
        private Participant part;
        public AddParticipantRequest(Participant part) {
            this.part = part;
        }
        public virtual Participant Participant {
            get {
                return part;
            }
        }
    }

    [Serializable]
    public class AddPart2EventRequest : Request {
        private EventPartDTO ev;
        public AddPart2EventRequest(EventPartDTO ev) {
            this.ev = ev;
        }
        public virtual EventPartDTO EventPartDTOent {
            get {
                return ev;
            }
        }
    }
}
