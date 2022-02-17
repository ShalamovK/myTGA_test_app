using Microsoft.EntityFrameworkCore;

namespace myTGA_Common.Contracts {
    public interface IUnitOfWork {
        DbContext DbContext { get; }
        IGenericRepository<T> GetRepository<T>() where T : class, IEntity;
        void SaveChanges();
    }
}
