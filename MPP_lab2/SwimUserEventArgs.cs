using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client {
    public enum SwimUserEvent {
        AddEventPart, AddParticipant
    };
    public class SwimUserEventArgs : EventArgs {
        private readonly SwimUserEvent userEvent;
        private readonly Object data;

        public SwimUserEventArgs(SwimUserEvent userEvent, object data) {
            this.userEvent = userEvent;
            this.data = data;
        }

        public SwimUserEvent UserEventType {
            get { return userEvent; }
        }

        public object Data {
            get { return data; }
        }
    }
}
