using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace networking {
    public interface Response { }

    [Serializable]
    public class ErrorResponse:Response {
            string message;
            public ErrorResponse(string message) {
                this.message = message;
            }
        
            public  string Message {
                    get {
                        return this.message;
                    }
                }
        }
    [Serializable]
    public class OkResponse : Response {
        }

    [Serializable]
    public class GetEventsNosPartResponse : Response {
        private EventPartDTO[] events;

        public GetEventsNosPartResponse(EventPartDTO[] events) {
            this.events = events;
        }

        public  EventPartDTO[] EventsNosPart {
            get {
                return events;
            }
        }
    }

    [Serializable]
    public class GetAllPart4EventResponse : Response {
        private Participant[] parts;
        public GetAllPart4EventResponse(Participant[] parts) {
            this.parts = parts;
        }
        public  Participant[] Participants {
            get {
                return parts;
            }
        }
    }

    [Serializable]
    public class GetAllPartResponse : Response {
        private Participant[] parts;
        public GetAllPartResponse(Participant[] parts) {
            this.parts = parts;
        }
        public  Participant[] Participants {
            get {
                return parts;
            }
        }
    }

    

    //pentru observer
    public interface UpdateResponse : Response { }
    [Serializable]
    public class UpdateNowResponse : UpdateResponse {
    }
    [Serializable]
    public class AddParticipantObsResponse : UpdateResponse {
        private Participant part;
        public AddParticipantObsResponse(Participant part) {
            this.part = part;
        }
        public  Participant Participant {
            get {
                return part;
            }
        }
    }

}
