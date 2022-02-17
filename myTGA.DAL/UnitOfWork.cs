using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myTGA_Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace myTGA.DAL {
    public class UnitOfWork : IUnitOfWork {
        private readonly myTGADbContext _dbContext;
        SortedDictionary<string, IGenericRepository> _repositories;

        public UnitOfWork(IServiceProvider serviceProvider) {
            var dbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<myTGADbContext>>();

            _dbContext = dbContextFactory.CreateDbContext();
            _repositories = new SortedDictionary<string, IGenericRepository>();
        }

        public DbContext DbContext => _dbContext;

        IGenericRepository<T> IUnitOfWork.GetRepository<T>() {
            var typeName = typeof(T).FullName;

            if (!_repositories.ContainsKey(typeName)) {
                _repositories.Add(typeName, new GenericRepository<T>(_dbContext));
            }

            return (IGenericRepository<T>)_repositories[typeName];
        }

        public void SaveChanges() {
            _dbContext.ChangeTracker.DetectChanges();
            _dbContext.SaveChanges();
        }
    }
}
