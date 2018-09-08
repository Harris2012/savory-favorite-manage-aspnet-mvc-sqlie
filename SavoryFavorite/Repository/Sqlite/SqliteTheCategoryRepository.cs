using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using SavoryFavorite.Repository.Entity;

namespace SavoryFavorite.Repository.Sqlite
{
    public class SqliteTheCategoryRepository : ITheCategoryRepository
    {

        private SqliteConnectionProvider connectionProvider;

        public SqliteTheCategoryRepository(SqliteConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public TheCategoryEntity GetById(int id)
        {
            string sql = "select category_id as CategoryId, category_id as CateoryName from category where Id = ?";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QueryFirstOrDefault<TheCategoryEntity>(sql, new { Id = id });
            }
        }

        public List<TheCategoryEntity> GetEntityList()
        {
            string sql = "select category_id as CategoryId, category_id as CateoryName from category";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<TheCategoryEntity>(sql).ToList();
            }
        }
    }
}
