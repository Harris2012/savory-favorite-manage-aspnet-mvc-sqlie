using SavoryFavoriteManage.Controllers.Request;
using SavoryFavoriteManage.Repository.Entity;
using SavoryFavoriteManage.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryFavoriteManage.Convertor
{
    public interface ICategoryConvertor
    {

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        CategoryEntity toEntity(CategoryCreateRequest request);

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        CategoryEntity toEntity(CategoryUpdateRequest request);

        /// <summary>
        /// 获取空 vo
        /// </summary>
        CategoryVo toEmptyVo();

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        CategoryVo toLessVo(CategoryEntity entity);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        CategoryVo toMoreVo(CategoryEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<CategoryVo> toLessVoList(List<CategoryEntity> entityList);
    }
}
