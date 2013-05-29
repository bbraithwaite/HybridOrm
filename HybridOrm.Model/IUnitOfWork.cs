using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridOrm.Model
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }

        void Save();
    }
}
