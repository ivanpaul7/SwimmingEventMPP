using System;
using model;
namespace persistance {
    public interface IOrganizerRepository : ICrudRepository<String, Organizer> {
        bool checkUserPass(Organizer organizer);
    }
}
