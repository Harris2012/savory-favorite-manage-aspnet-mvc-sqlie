using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavorite.Repository.Entity;

namespace SavoryFavorite.Repository
{
    public interface ITheCategoryRepository
    {
        /// <summary>
        /// 获取所有实体
        /// </summary>
        List<TheCategoryEntity> GetEntityList();

        /// <summary>
        /// 获取单个实体
        /// </summary>
        TheCategoryEntity GetById(int id);
    }
}
