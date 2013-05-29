using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using HybridOrm.Model;

namespace Hybrid.Orm.Repository.Dapper
{
    public static class UserRepositoryExtension
    {
        public static IEnumerable<User> GetNewUsers(this IReadOnlyRepository<User> repository)
        {
            IEnumerable<User> users = null;

            using (IDbConnection cn = repository.Connection)
            {
                cn.Open();
                users = cn.Query<User>("SELECT * FROM Users Where CreatedDate = @CreatedDate", new { CreatedDate = DateTime.Now });
            }

            return users;
        }
    }
}