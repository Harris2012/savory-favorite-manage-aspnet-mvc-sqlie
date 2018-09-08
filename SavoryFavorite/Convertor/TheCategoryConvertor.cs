using SavoryFavorite.Controllers.Request;
using SavoryFavorite.Repository.Entity;
using SavoryFavorite.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavoryFavorite.Convertor
{
    public class TheCategoryConvertor : ITheCategoryConvertor
    {
        public TheCategoryVo toVo(TheCategoryEntity entity)
        {
            TheCategoryVo vo = new TheCategoryVo();

            vo.CategoryId = entity.CategoryId;
            vo.CategoryName = entity.CategoryName;

            return vo;
        }

        public List<TheCategoryVo> getVoList(List<TheCategoryEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0) {
                return null;
            }

            List<TheCategoryVo> voList = new List<TheCategoryVo>();
            foreach (TheCategoryEntity entity in entityList)
            {

                TheCategoryVo vo = toVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public List<TheCategoryVo> getLessVoList(List<TheCategoryEntity> entityList, int key)
        {
            if (entityList == null || entityList.Count == 0) {
                return null;
            }

            foreach (TheCategoryEntity entity in entityList)
            {
                if (entity.CategoryId == key)
                {
                    return new List<TheCategoryVo> { toVo(entity) };
                }
            }

            return null;
        }

        public List<TheCategoryVo> getMoreVoList(List<TheCategoryEntity> entityList, int key)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<TheCategoryVo> voList = new List<TheCategoryVo>();
            foreach (TheCategoryEntity entity in entityList)
            {
                TheCategoryVo vo = toVo(entity);
                voList.Add(vo);

                if (entity.CategoryId == key)
                {
                    vo.Selected = true;
                }
            }

            return voList;
        }

        public List<TheCategoryVo> getLessVoList(List<TheCategoryEntity> entityList, List<int> keys)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<TheCategoryVo> voList = new List<TheCategoryVo>();
            foreach (TheCategoryEntity entity in entityList)
            {
                if (!keys.Contains(entity.CategoryId))
                {
                    continue;
                }

                TheCategoryVo vo = toVo(entity);
                vo.Selected = true;
                voList.Add(vo);

                if(voList.Count == keys.Count)
                {
                    break;
                }
            }

            return voList;
        }

        public List<TheCategoryVo> getMoreVoList(List<TheCategoryEntity> entityList, List<int> keys)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<TheCategoryVo> voList = new List<TheCategoryVo>();
            foreach (TheCategoryEntity entity in entityList)
            {
                TheCategoryVo vo = toVo(entity);
                if (keys.Contains(entity.CategoryId))
                {
                    vo.Selected = true;
                }
                voList.Add(vo);
            }

            return voList;
        }
    }
}
