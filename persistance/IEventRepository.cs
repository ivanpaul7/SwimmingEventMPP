using System;
using model;

namespace persistance {
    public interface IEventRepository : ICrudRepository<Tuple<int, String>, Event> {
    }
}
