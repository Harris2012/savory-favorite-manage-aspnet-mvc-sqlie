using SavoryFavoriteManage.Controllers.Request;
using SavoryFavoriteManage.Repository.Entity;
using SavoryFavoriteManage.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryFavoriteManage.Convertor
{
    public interface ITheCategoryConvertor
    {

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        TheCategoryVo toVo(TheCategoryEntity entity);

        /// <summary>
        /// 获取所有的选项
        /// </summary>
        List<TheCategoryVo> getVoList(List<TheCategoryEntity> entityList);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<TheCategoryVo> getLessVoList(List<TheCategoryEntity> entityList, int key);

        /// <summary>
        /// 获取所有的元数据。标记已经选择的。
        /// </summary>
        List<TheCategoryVo> getMoreVoList(List<TheCategoryEntity> entityList, int key);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<TheCategoryVo> getLessVoList(List<TheCategoryEntity> entityList, List<int> keys);

        /// <summary>
        /// 获取所有的元数据。标记已经选择的。
        /// </summary>
        List<TheCategoryVo> getMoreVoList(List<TheCategoryEntity> entityList, List<int> keys);

    }
}
