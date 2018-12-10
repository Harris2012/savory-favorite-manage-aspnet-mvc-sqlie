using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using SavoryFavoriteManage.Repository.Entity;

namespace SavoryFavoriteManage.Repository.Sqlite
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
            string sql = "select category_id as CategoryId, category_name as CategoryName from category where Id = ?";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QueryFirstOrDefault<TheCategoryEntity>(sql, new { Id = id });
            }
        }

        public List<TheCategoryEntity> GetEntityList()
        {
            string sql = "select category_id as CategoryId, category_name as CategoryName from category";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<TheCategoryEntity>(sql).ToList();
            }
        }
    }
}
