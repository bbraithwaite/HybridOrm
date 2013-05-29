using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridOrm.Model
{
    public interface IReadOnlyRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        T FindById(int id);

        IEnumerable<T> GetAll();
    }
}
