using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavorite.Repository.Entity;

namespace SavoryFavorite.Meta
{
    public interface ITheCategoryMeta
    {
        /// <summary>
        /// 获取元数据列表
        /// </summary>
        /// <returns>元数据列表</returns>
        List<TheCategoryEntity> GetEntityList();

        /// <summary>
        /// 刷新缓存
        /// </summary>
        void Refresh();
    }
}
