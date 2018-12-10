using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using SavoryFavoriteManage.Repository.Entity;

namespace SavoryFavoriteManage.Repository.Sqlite
{
    public class SqliteCategoryRepository : ICategoryRepository
    {

        private SqliteConnectionProvider connectionProvider;

        public SqliteCategoryRepository(SqliteConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public void Create(CategoryEntity entity)
        {
            string sql = "insert into category(category_id, category_name, description) values (@CategoryId, @CategoryName, @Description);";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { CategoryId = entity.CategoryId, CategoryName = entity.CategoryName, Description = entity.Description });
            }
        }

        public CategoryEntity GetById(long id)
        {
            string sql = "select id, category_id as CategoryId, category_name as CategoryName, description as Description from category where Id = ?";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QueryFirstOrDefault<CategoryEntity>(sql, new { Id = id });
            }
        }

        public int GetCount()
        {
            string sql = "select count(1) from category";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.QuerySingle<int>(sql);
            }
        }

        public List<CategoryEntity> GetEntityList()
        {
            string sql = "select id, category_id as CategoryId, category_name as CategoryName, description as Description from category";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<CategoryEntity>(sql).ToList();
            }
        }

        public List<CategoryEntity> GetEntityList(int pageIndex, int pageSize)
        {
            string sql = "select id, category_id as CategoryId, category_name as CategoryName, description as Description from category limit @Start, @Count";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                return sqliteConn.Query<CategoryEntity>(sql, new { Start = (pageIndex - 1) * pageSize, Count = pageSize }).ToList();
            }
        }

        public void Update(CategoryEntity entity)
        {
            string sql = "update category set category_id = @CategoryId, category_name = @CategoryName, description = @Description where id = @Id;";

            using (var sqliteConn = connectionProvider.GetConnection())
            {
                sqliteConn.Execute(sql, new { id = entity.Id, CategoryId = entity.CategoryId, CategoryName = entity.CategoryName, Description = entity.Description });
            }
        }
    }
}
