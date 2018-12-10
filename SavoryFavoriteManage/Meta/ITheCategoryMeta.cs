using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavoriteManage.Repository.Entity;

namespace SavoryFavoriteManage.Meta
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
