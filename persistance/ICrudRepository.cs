using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistance {
    public interface ICrudRepository<ID, E> {
        E findOne(ID id);
        IEnumerable<E> findAll();
        void save(E e);
        void delete(ID id);
    }
}
