using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using HybridOrm.Model;

namespace Hybrid.Orm.Repository.Dapper
{
    public class UserRepository : IReadOnlyRepository<User>
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            }
        }

        public User FindById(int id)
        {
            User user = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                user = cn.Query<User>("SELECT * FROM Users WHERE ID=@ID", new { ID = id }).SingleOrDefault();
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                users = cn.Query<User>("SELECT * FROM Users");
            }

            return users;
        }
    }
}
