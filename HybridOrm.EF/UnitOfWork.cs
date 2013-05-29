using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HybridOrm.Model;

namespace HybridOrm.Repository.EF
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        private readonly Repository<User> _useRepository;

        public DbSet<User> Users { get; set; }

        public UnitOfWork()
        {
            _useRepository = new Repository<User>(Users);
        }

        public IRepository<User> UserRepository
        {
            get { return _useRepository; }
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
