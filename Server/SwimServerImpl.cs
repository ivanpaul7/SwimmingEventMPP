using System;
using System.Collections.Generic;
using model;
using persistance;
using services;
using System.Threading.Tasks;



namespace Server {
    public class SwimServerImpl : ISwimServer {
        private IParticipantEventRepository eventPartRepo;
        private IEventRepository eventRepo;
        private IOrganizerRepository orgRepo;
        private IParticipantRepository partRepo;
        private readonly IDictionary<String, ISwimObserver> loggedClients;

        public SwimServerImpl(IParticipantRepository partRepo, IEventRepository eventRepo, IParticipantEventRepository eventPartRepo, IOrganizerRepository orgRepo) {
            this.partRepo = partRepo;
            this.eventRepo = eventRepo;
            this.eventPartRepo = eventPartRepo;
            this.orgRepo = orgRepo;
            loggedClients = new Dictionary<String, ISwimObserver>();
        }
        public EventPartDTO[] findEventsNosParticipants() {
            IEnumerable<EventPartDTO> events = eventPartRepo.findEventsNosParticipants();
            List<EventPartDTO> result = new List<EventPartDTO>();
            foreach (EventPartDTO e in events) {
                result.Add(e);
            }
            return result.ToArray();
        }

        public void addPart2Event(EventPartDTO e) {
            eventPartRepo.save(e);
            notifyObserverAddEventPart(e);
        }

        public void addParticipant(Participant participant) {
            partRepo.save(participant);
            notifyObserverAddPart(participant);
        }

        public Participant[] findAllParticipants() {
            IEnumerable<Participant> parts = partRepo.findAll();
            List<Participant> result = new List<Participant>();
            foreach (Participant p in parts) {
                result.Add(p);
            }
            return result.ToArray();
        }

        public Participant[] findPartForEvent(Event e) {
            IEnumerable<Participant> parts = eventPartRepo.findPartForEvent(e);
            List<Participant> result = new List<Participant>();
            foreach (Participant p in parts) {
                result.Add(p);
            }
            return result.ToArray();
        }

        private void notifyObserverAddEventPart(EventPartDTO ev) {
            foreach (ISwimObserver obs in loggedClients.Values) {
                Task.Run(() => obs.AddEventPartObserver(ev));
            }
        }
        private void notifyObserverAddPart(Participant part) {
            foreach (ISwimObserver obs in loggedClients.Values) {
                Task.Run(() => obs.AddParticipantObserver(part));
            }
        }

        public void login(Organizer org, ISwimObserver client) {
            if (org != null) {
                if (loggedClients.ContainsKey(org.Id))
                    throw new SwimException("User already logged in.");
                loggedClients[org.Id] = client;
            } else
                throw new SwimException("Authentication failed.");
        }

        public void logout(Organizer org, ISwimObserver client) {
            ISwimObserver localClient = loggedClients[org.Id];
            if (localClient == null)
                throw new SwimException("User " + org.Id + " is not logged in.");
            loggedClients.Remove(org.Id);
        }

        
    }
}