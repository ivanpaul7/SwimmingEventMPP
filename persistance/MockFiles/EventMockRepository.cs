using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace persistance {
    public class EventMockRepository : IEventRepository {
        public void delete(Tuple<int, string> id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> findAll() {
            throw new NotImplementedException();
        }

        public Event findOne(Tuple<int, string> id) {
            throw new NotImplementedException();
        }

        public void save(Event e) {
            throw new NotImplementedException();
        }
    }
}
