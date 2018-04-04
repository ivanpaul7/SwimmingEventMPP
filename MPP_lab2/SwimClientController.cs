using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using model;
using services;

namespace client {
    public class SwimClientController: ISwimObserver {
        bool currrent = false;
        //private SwimMainForm.UpdateObserverDelegate del;
        public event EventHandler<SwimUserEventArgs> updateEvent; //ctrl calls it when it has received an update
        private readonly ISwimServer server;
        private Organizer currentUser;

        public SwimClientController(ISwimServer server) {
            this.server = server;
        }
        public IList<EventPartDTO> findAllEvents() {
            IList<EventPartDTO> all = new List<EventPartDTO>();
            EventPartDTO[] events = server.findEventsNosParticipants();
            foreach (var p in events) {
                all.Add(p);
            }
            return all;
        }

        public void login(string username, string pass) {
            Organizer user = new Organizer(username, pass);
            server.login(user, this);
            Console.WriteLine("Login succeeded ....");
            currentUser = user;
            Console.WriteLine("Current user {0}", user);
        }

   
        public void logout() {
            Console.WriteLine("Ctrl logout");
            server.logout(currentUser, this);
            currentUser = null;
        }

        public IList<Participant> findAllPart() {
            IList<Participant> all = new List<Participant>();
            Participant[] parts = server.findAllParticipants();
            foreach (var p in parts) {
                all.Add(p);
            }
            return all;
}

        //public BindingSource findAllPart() {
        //    BindingSource bindingSource = new BindingSource();
        //    foreach (Participant p in server.findAllParticipants())
        //        bindingSource.Add(p);
        //    return bindingSource;
        //}

        public BindingSource findAllPartForEvent(Event e) {
            BindingSource bindingSource = new BindingSource();
            foreach (Participant p in server.findPartForEvent(e))
                bindingSource.Add(p);
            return bindingSource;
        }

        public void addParticipant(Participant participant) {
            server.addParticipant(participant);
        }

        public void addPart2Event(EventPartDTO e) {
            server.addPart2Event(e);
        }

        protected virtual void OnUserEvent(SwimUserEventArgs e) {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
       }

        public void AddParticipantObserver(Participant part) {
            SwimUserEventArgs userArgs = new SwimUserEventArgs(SwimUserEvent.AddParticipant, part);
            OnUserEvent(userArgs);
        }

        public void AddEventPartObserver(EventPartDTO ev) {
            SwimUserEventArgs userArgs = new SwimUserEventArgs(SwimUserEvent.AddEventPart, ev);
            OnUserEvent(userArgs);
        }
    }
}
