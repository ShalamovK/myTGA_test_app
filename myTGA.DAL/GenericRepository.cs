using Microsoft.EntityFrameworkCore;
using myTGA_Common.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace myTGA.DAL {
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity {
        protected DbSet<T> _table;
        protected myTGADbContext _context;

        public GenericRepository(myTGADbContext context) {
            _context = context;
            _table = _context.Set<T>();
        }

        public T Add(T item) {
            _table.Add(item);

            return item;
        }

        public IEnumerable<T> Add(IEnumerable<T> items) {
            _table.AddRange(items);

            return items;
        }

        public T Delete(T item) {
            _context.Entry(item).State = EntityState.Deleted;

            return item;
        }

        public IEnumerable<T> Delete(IEnumerable<T> items) {
            foreach (T item in items) {
                Delete(item);
            }

            return items;
        }

        public IQueryable<T> GetAll() {
            return _table.AsQueryable();
        }

        public T Update(T item) {
            _context.Entry(item).State = EntityState.Modified;

            return item;
        }

        public IEnumerable<T> Update(IEnumerable<T> items) {
            foreach (T item in items) {
                Update(item);
            }

            return items;
        }
    }
}
