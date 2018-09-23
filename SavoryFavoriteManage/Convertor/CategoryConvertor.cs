using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SavoryFavoriteManage.Controllers.Request;
using SavoryFavoriteManage.Repository.Entity;
using SavoryFavoriteManage.Vo;

namespace SavoryFavoriteManage.Convertor
{
    public class CategoryConvertor : ICategoryConvertor
    {

        public CategoryEntity toEntity(CategoryCreateRequest request)
        {
            CategoryEntity entity = new CategoryEntity();

            entity.CategoryId = request.CategoryId != null ? request.CategoryId.Value : 0;
            entity.CategoryName = request.CategoryName;
            entity.Description = request.Description;

            return entity;
        }

        public CategoryEntity toEntity(CategoryUpdateRequest request)
        {
            CategoryEntity entity = new CategoryEntity();

            entity.Id = request.Id;
            entity.CategoryId = request.CategoryId != null ? request.CategoryId.Value : 0;
            entity.CategoryName = request.CategoryName;
            entity.Description = request.Description;

            return entity;
        }

        public CategoryVo toEmptyVo()
        {
            CategoryVo vo = new CategoryVo();

            return vo;
        }

        public CategoryVo toLessVo(CategoryEntity entity)
        {
            CategoryVo vo = toVo(entity);

            return vo;
        }

        public CategoryVo toMoreVo(CategoryEntity entity)
        {
            CategoryVo vo = toVo(entity);

            return vo;
        }

        public List<CategoryVo> toLessVoList(List<CategoryEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return null;
            }

            List<CategoryVo> voList = new List<CategoryVo>();
            foreach (CategoryEntity entity in entityList) {
                voList.Add(toLessVo(entity));
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private CategoryVo toVo(CategoryEntity entity)
        {
            CategoryVo vo = new CategoryVo();

            vo.Id = entity.Id;
            vo.CategoryId = entity.CategoryId;
            vo.CategoryName = entity.CategoryName;
            vo.Description = entity.Description;

            return vo;
        }
    }
}
