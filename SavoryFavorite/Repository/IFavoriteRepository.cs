using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavorite.Repository.Entity;

namespace SavoryFavorite.Repository
{
    public interface IFavoriteRepository
    {
        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>实体列表</returns>
        List<FavoriteEntity> GetEntityList();

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id">实体编号</param>
        /// <returns>实体</returns>
        FavoriteEntity GetById(long id);

        /// <summary>
        /// 分页获取实体
        /// </summary>
        /// <param name="pageIndex">页码，从1开始</param>
        /// <param name="pageSize">每页个数</param>
        /// <returns>实体列表</returns>
        List<FavoriteEntity> GetEntityList(int pageIndex, int pageSize);

        /// <summary>
        /// 获取实体总个数
        /// </summary>
        /// <returns>实体总个数</returns>
        int GetCount();

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">要新增的实体</param>
        void Create(FavoriteEntity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        void Update(FavoriteEntity entity);
    }
}
