using System.Collections.Generic;
using System.Linq;

namespace myTGA_Common.Contracts {
    public interface IGenericRepository { 
    }

    public interface IGenericRepository<T> : IGenericRepository where T : IEntity {
        IQueryable<T> GetAll();

        T Add(T item);
        IEnumerable<T> Add(IEnumerable<T> items);

        T Update(T item);
        IEnumerable<T> Update(IEnumerable<T> items);

        T Delete(T item);
        IEnumerable<T> Delete(IEnumerable<T> items);
    }
}
