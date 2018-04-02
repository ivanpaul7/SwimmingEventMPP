using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistance;
using model;
using services;

namespace client {
    public class Service {
        private List<ISwimObserver> observers = new List<ISwimObserver>();
        private IParticipantEventRepository repoPartEvent;
        private IEventRepository repoEvent;
        private IParticipantRepository repoPart;
        private IOrganizerRepository repoOrg;

        public Service(IParticipantEventRepository repoPartEvent, IEventRepository repoEvent, IParticipantRepository repoPart, IOrganizerRepository repoOrg) {
            this.repoPartEvent = repoPartEvent;
            this.repoEvent = repoEvent;
            this.repoPart = repoPart;
            this.repoOrg = repoOrg;
        }

        public IEnumerable<EventPartDTO> findEventsNosParticipants() {
            return repoPartEvent.findEventsNosParticipants();
        }

        public IEnumerable<Participant> findAllParticipants() {
            return repoPart.findAll();
        }

        internal bool checkUserPass(Organizer organizer) {
            return repoOrg.checkUserPass(organizer);
        }

        public IEnumerable<Participant> findPartForEvent(Event e) {
            return repoPartEvent.findPartForEvent(e);
        }

        public void addParticipant(Participant participant) {
            repoPart.save(participant);
            Notify();
        }

        internal void addPart2Event(EventPartDTO e) {
            repoPartEvent.save(e);
            Notify();
        }


        // observer
        public void Subscribe(ISwimObserver observer) {
            observers.Add(observer);
        }

        public void Unsubscribe(ISwimObserver observer) {
            observers.Remove(observer);
        }

        public void Notify() {
            observers.ForEach(x => x.UpdateObserver());
        }
    }
}
