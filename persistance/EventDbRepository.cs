using System;
using System.Collections.Generic;
using model;
using System.Data;

namespace persistance {
    public class EventDbRepository : IEventRepository {
        public void delete(Tuple<int, string> id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> findAll() {
            IDbConnection con = DBUtils.getConnection();
            IList<Event> events = new List<Event>();
            using (var comm = con.CreateCommand()) {
                comm.CommandText = "SELECT * FROM SwimmingEvent";
                using (var dataR = comm.ExecuteReader()) {
                    while (dataR.Read()) {
                        int distance = dataR.GetInt32(0);
                        String name = dataR.GetString(1);
                        Event ev = new Event(distance, name);
                        events.Add(ev);
                    }
                }
            }
            return events;
        }

        public Event findOne(Tuple<int, string> id) {
            throw new NotImplementedException();
        }

        public void save(Event e) {
            throw new NotImplementedException();
        }
    }
}
